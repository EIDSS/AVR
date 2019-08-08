namespace AUM.Core
{
  using System;
  using System.Globalization;
  using System.IO;
  using System.Xml;
  using Helper;


  public sealed class ConfigSettings
    {
    // ReSharper disable InconsistentNaming
    private static readonly TimeSpan MaxDownloadAttemptWaitTime = TimeSpan.FromMinutes(5);
    private static readonly TimeSpan DefaultDownloadAttemptWaitTime = TimeSpan.FromSeconds(20);
    // ReSharper restore InconsistentNaming
    private const ushort DefaultDownloadAttempts = 5;
    private const int MaxDownloadAttempts = 20;
    private const ushort DefaultDownloadBufferSize = 32768;
    private const MachineLevel.Level DefaultLevel = MachineLevel.Level.Cdr;
    public string ProgramId { get; set; }
        public string UpdateLocal { get; set; }
    public UrlWrapper UpdateUrl { get; set; }
    public ushort DownloadAttempts { get; private set; }
    public TimeSpan DownloadAttemptWaitTime { get; private set; }
    public ushort DownloadBufferSize { get; private set; }
    public string LogLocal { get; private set; }
        public string BackupPath { get; set; }
        public string ReplicationJob { get; set; }

        /// <summary>
        /// Аргументы командной строки данного запуска
        /// </summary>
        public string Args { get; set; }

        /// <summary>
        /// Как часто запускаются скачивание апдейтов и выкачка логов (HH:MM)
        /// </summary>
        public string IntervalDownload { get; set; }

        /// <summary>
        /// Как часто запускается обновление программ (HH:MM)
        /// </summary>
        public string IntervalUpdate { get; set; }

        /// <summary>
        /// Как часто АУМ записывает флаг своей работоспособности (HH:MM)
        /// </summary>
        public string IntervalSaveState { get; set; }

        /// <summary>
        /// Частота обновления данных в Администраторе (сек).
        /// </summary>
        public int AutoRefreshSeconds { get; set; }


        /// <summary>
        /// Уровень объекта (1-CDR, 2-SLVL, 3-TLVL, 4-WKS, 5-Web, 6-WebWks)
        /// </summary>
        public MachineLevel.Level Level { get; set; }

        /// <summary>
        /// Какую версию имеет обновление
        /// </summary>
        public Version VersionOfUpdate { get; set; }

        /// <summary>
        /// Количество попыток проведения синхронизации
        /// </summary>
        public int SyncCount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ConfigSettings()
        {
            Level = DefaultLevel;
            SyncCount = 5;

            ProgramId =
                BackupPath =
                ReplicationJob = string.Empty;

            //выставляем по умолчанию локальные переменные
            var aumpath = RegistryHelper.ReadFromRegistry("aumpath");
            UpdateLocal = Path.Combine(aumpath, FileHelper.AUMUpdateDirName);
            LogLocal = Path.Combine(aumpath, FileHelper.AUMLogDirName);

          DownloadAttempts = 5;
          DownloadAttemptWaitTime = TimeSpan.FromSeconds(30);

            IntervalDownload = "03:00";
            IntervalUpdate = "06:00";
            IntervalSaveState = "00:01";
            AutoRefreshSeconds = 10;
        }

      public ConfigSettings(string configFileName) : this()
      {
        ReadBVUpdaterConfig(configFileName);
      }

        public void SaveSettings(string configFileName)
        {
            //используем обычную запись в текстовый файл, а не XmlTextWriter
            var fileInfo = new FileInfo(configFileName);
            if (fileInfo.Exists) fileInfo.Attributes = fileInfo.Attributes & ~FileAttributes.ReadOnly;

            using (var file = new StreamWriter(configFileName))
            {
                file.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                file.WriteLine("<config>");
                file.WriteLine("<level value=\"{0}\" />", Level.ToString("d"));
                file.WriteLine("<backupdir path=\"{0}\" />", BackupPath);
                file.WriteLine("<sync count=\"{0}\" />", SyncCount);
                file.WriteLine("<rund interval=\"{0}\" />", IntervalDownload);
                file.WriteLine("<runu interval=\"{0}\" />", IntervalUpdate);
                file.WriteLine("<savestate interval=\"00:01\" />");
                file.WriteLine("<autorefresh seconds=\"10\" />");
                file.WriteLine("<replicationjob name=\"{0}\" />", ReplicationJob);
                file.WriteLine(
                  "<updateurl url=\"{0}\"{1} attempts=\"{2}\" waitSeconds=\"{3}\" bufferSize=\"{4}\" />",
                  UpdateUrl.Primary,
                  string.IsNullOrEmpty(UpdateUrl.Secondary)
                    ? string.Empty
                    : string.Format(CultureInfo.InvariantCulture, " reserve=\"{0}\"", UpdateUrl.Secondary),
                  DownloadAttempts,
                  DownloadAttemptWaitTime.TotalSeconds,
                  DownloadBufferSize);
                file.WriteLine("</config>");
            }
        }

        public void ReadBVUpdaterConfig(string configFileName)
        {
            if (!File.Exists(configFileName)) return;

            using (var reader = new XmlTextReader(configFileName))
            {
                while (reader.Read())
                {
                    if (reader.NodeType != XmlNodeType.Element) continue;
                    if (reader.Name.Equals("backupdir"))
                    {
                        BackupPath = reader.GetAttribute("path");
                    }
                    else if (reader.Name.Equals("rund"))
                    {
                        IntervalDownload = reader.GetAttribute("interval");
                    }
                    else if (reader.Name.Equals("runu"))
                    {
                        IntervalUpdate = reader.GetAttribute("interval");
                    }
                    else if (reader.Name.Equals("savestate"))
                    {
                        IntervalSaveState = reader.GetAttribute("interval");
                    }
                    else if (reader.Name.Equals("autorefresh"))
                    {
                        var s = reader.GetAttribute("seconds");
                        if (!string.IsNullOrEmpty(s)) AutoRefreshSeconds = Convert.ToInt32(s);
                    }
                    else if (reader.Name.Equals("level"))
                    {
                      ReadLevel(reader);
                    }
                    else if (reader.Name.Equals("sync"))
                    {
                        // ReSharper disable PossibleNullReferenceException
                        SyncCount = Convert.ToInt32(reader.GetAttribute("count"));
                        // ReSharper restore PossibleNullReferenceException
                    }
                    else if (reader.Name.Equals("updateurl"))
                    {
                      ReadUpdateUrlSettings(reader);
                    }
                    else if (reader.Name.Equals("replicationjob"))
                    {
                        // ReSharper disable PossibleNullReferenceException
                        ReplicationJob = reader.GetAttribute("name")?? string.Empty;
                        // ReSharper restore PossibleNullReferenceException
                    }
                }
            }
        }

    private void ReadLevel(XmlReader reader)
    {
      var level = reader.GetAttribute("value");
      Level = string.IsNullOrEmpty(level)
        ? DefaultLevel
        : (MachineLevel.Level) Enum.Parse(typeof (MachineLevel.Level), level);
    }

    private void ReadUpdateUrlSettings(XmlReader reader)
    {
      UpdateUrl = new UrlWrapper(reader.GetAttribute("url"), reader.GetAttribute("reserve"));
      DownloadAttempts = ReadNumberOfDownloadAttempts(reader);
      DownloadAttemptWaitTime = ReadDownloadAttemptWaitTime(reader);
      DownloadBufferSize = ReadDownloadBufferSize(reader);
    }

    private static ushort ReadDownloadBufferSize(XmlReader reader)
    {
      ushort downloadBufferSize;
      if (ushort.TryParse(reader.GetAttribute("bufferSize"), out downloadBufferSize)
          && 0 != downloadBufferSize)
      {
        return downloadBufferSize;
      }
      AUMLog.WriteInLog(
        "Can't read download buffer size from config: <updateurl ... bufferSize=... />. Defaults to {0}",
        DefaultDownloadBufferSize);
      return DefaultDownloadBufferSize;
    }

    private static TimeSpan ReadDownloadAttemptWaitTime(XmlReader reader)
    {
      ushort seconds;
      if (ushort.TryParse(reader.GetAttribute("waitSeconds"), out seconds)
          && MaxDownloadAttemptWaitTime.Seconds > seconds)
      {
        return TimeSpan.FromSeconds(seconds);
      }
      AUMLog.WriteInLog(
        "Can't read time between download attempts from config: <updateurl ... waitSeconds=... />. Defaults to {0}",
        DefaultDownloadAttemptWaitTime);
      return  DefaultDownloadAttemptWaitTime;
    }

    private static ushort ReadNumberOfDownloadAttempts(XmlReader reader)
    {
      ushort attempts;
      if (ushort.TryParse(reader.GetAttribute("attempts"), out attempts)
          && 0 != attempts && MaxDownloadAttempts >= attempts)
      {
        return attempts;
      }
      AUMLog.WriteInLog(
        "Can't read number of download attempts from config: <updateurl ... attempts=... />. Defaults to {0}",
        DefaultDownloadAttempts);
      return DefaultDownloadAttempts;
    }
  }
}
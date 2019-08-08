namespace AUM.UpdateCreator
{
  using System;
  using System.Collections.Generic;
  using System.IO;
  using System.Linq;
  using System.Windows.Forms;
  using Core;
  using Core.Helper;
  using ICSharpCode.SharpZipLib.Zip;


  internal sealed class ConsoleUpdateCreator : IUpdateCreator
  {
    private readonly CreatorSettings m_crSettings;
    private PatchOptions m_options;

    internal ConsoleUpdateCreator()
    {
      var configFilename = Path.Combine(Application.StartupPath, "bvupdatecreator.xml");
      m_crSettings = new CreatorSettings(configFilename);
      m_crSettings.ReadConfigFile();
    }

    /// <summary>
    /// Информация из updates.xml (без снапшотов)
    /// </summary>
    private List<TotalUpdateInfo> UpdatesInfo { get; set; }

    #region IUpdateCreator Members

    public int CreatePackage(PatchOptions options)
    {
      m_options = options;
      RefreshCrSettings();
      try
      {
        return CreatePackage();
      }
      catch (Exception ex)
      {
        Console.Error.Write(ex.Message);
        return 2;
      }
    }

    #endregion

    private void RefreshCrSettings()
    {
      m_crSettings.UpdatePath = m_options.UpdateSource;

      if (!string.IsNullOrEmpty(m_options.OutputPath))
      {
        m_crSettings.BuildPath = m_options.OutputPath;
      }

      string errorString;
      UpdatesInfo = AdminHelper.GetTotalUpdateInfo(
        Path.Combine(m_crSettings.BuildPath, FileHelper.UpdatesInfoFileName),
        out errorString);
    }

    private int CreatePackage()
    {
      if (m_crSettings.BuildPath.Length == 0)
      {
        return 2;
      }

      var isSmall = !m_options.IsTotal;

      //создаём отдельные пакеты для каждого продукта и единый total-пакет
      //создаём программы апдейтов для каждого продукта

      var updates = new List<string>();

      if (m_options.Aum.IsIncluded)
      {
        //проверим наличие лишний конфигов, которые были случайно добавлены
        var badFiles = Directory.GetFiles(m_crSettings.AUMPath, "bvupdater*.config*");
        if (badFiles.Length > 0)
        {
          throw new PackageCreatorException(
            "AUM update source folder \"{0}\" contains bad files: {1}",
            m_crSettings.AUMPath,
            string.Join(", ", badFiles));
        }
        updates.Add(
          CreatePatchFile(
            ProductHelper.AumProgramId,
            m_options.Aum.Version,
            m_options.TotalVersion,
            m_crSettings.AUMPath,
            isSmall,
            m_options.Aum.CortegeVersion));
      }
      if (m_options.Db.IsIncluded)
      {
        updates.Add(
          CreatePatchFile(
            ProductHelper.DbProgramId,
            m_options.Db.Version,
            m_options.TotalVersion,
            m_crSettings.DBPath,
            isSmall,
            m_options.Db.CortegeVersion));
      }
      if (m_options.DbArchive.IsIncluded)
      {
        updates.Add(
          CreatePatchFile(
            ProductHelper.DbaProgramId,
            m_options.DbArchive.Version,
            m_options.TotalVersion,
            m_crSettings.DBaPath,
            isSmall,
            m_options.DbArchive.CortegeVersion));
      }
      if (m_options.AvrDb.IsIncluded)
      {
        updates.Add(
          CreatePatchFile(
            ProductHelper.AvrServiceDbProgramId,
            m_options.AvrDb.Version,
            m_options.TotalVersion,
            m_crSettings.AvrDbPath,
            isSmall,
            m_options.AvrDb.CortegeVersion));
      }
      if (m_options.AvrService.IsIncluded)
      {
        updates.Add(CreatePatchFile(
          ProductHelper.AvrServiceProgramId,
          m_options.AvrService.Version,
          m_options.TotalVersion,
          m_crSettings.AvrServicePath,
          isSmall,
          m_options.AvrService.CortegeVersion));
      }
      if (m_options.Desktop.IsIncluded)
      {
        updates.Add(
          CreatePatchFile(
            ProductHelper.EidssProgramId,
            m_options.Desktop.Version,
            m_options.TotalVersion,
            m_crSettings.EidssPath,
            isSmall,
            m_options.Desktop.CortegeVersion));
      }
      if (m_options.NotificationService.IsIncluded)
      {
        updates.Add(
          CreatePatchFile(
            ProductHelper.NsProgramId,
            m_options.NotificationService.Version,
            m_options.TotalVersion,
            m_crSettings.NSPath,
            isSmall,
            m_options.NotificationService.CortegeVersion));
      }
      if (m_options.CustomTasks.IsIncluded)
      {
        updates.Add(
          CreatePatchFile(
            ProductHelper.CustomTasksProgramId,
            m_options.TotalVersion,
            m_options.TotalVersion,
            m_crSettings.CustomTasksPath,
            isSmall,
            string.Empty));
      }

      //все ли апдейты были сделаны
      var allPatchesComplete =
        m_options.Aum.IsIncluded
        && m_options.Db.IsIncluded
        && m_options.DbArchive.IsIncluded
        && m_options.AvrDb.IsIncluded
        && m_options.AvrService.IsIncluded
        && m_options.Desktop.IsIncluded
        && m_options.NotificationService.IsIncluded
        && m_options.CustomTasks.IsIncluded;

      //#region Подготовка к записи файла updates.xml

      var tui = UpdatesInfo.FirstOrDefault(u => u.Version.Equals(m_options.TotalVersion));
      var needAdd = tui == null;
      var totalUpdateInfo = tui ?? new TotalUpdateInfo { Version = m_options.TotalVersion };
      AddUpdateInfo(
        totalUpdateInfo,
        ProductHelper.AumProgramId,
        m_options.Aum.IsIncluded ? m_options.Aum.Version : VersionFactory.EmptyVersion);
      AddUpdateInfo(
        totalUpdateInfo,
        ProductHelper.DbProgramId,
        m_options.Db.IsIncluded ? m_options.Db.Version : VersionFactory.EmptyVersion);
      AddUpdateInfo(
        totalUpdateInfo,
        ProductHelper.DbaProgramId,
        m_options.DbArchive.IsIncluded ? m_options.DbArchive.Version : VersionFactory.EmptyVersion);
      AddUpdateInfo(
        totalUpdateInfo,
        ProductHelper.AvrServiceDbProgramId,
        m_options.AvrDb.IsIncluded ? m_options.AvrDb.Version : VersionFactory.EmptyVersion);
      AddUpdateInfo(
        totalUpdateInfo,
        ProductHelper.AvrServiceProgramId,
        m_options.AvrService.IsIncluded ? m_options.AvrService.Version : VersionFactory.EmptyVersion);
      AddUpdateInfo(
        totalUpdateInfo,
        ProductHelper.EidssProgramId,
        m_options.Desktop.IsIncluded ? m_options.Desktop.Version : VersionFactory.EmptyVersion);
      AddUpdateInfo(
        totalUpdateInfo,
        ProductHelper.NsProgramId,
        m_options.NotificationService.IsIncluded ? m_options.NotificationService.Version : VersionFactory.EmptyVersion);
      AddUpdateInfo(
        totalUpdateInfo,
        ProductHelper.CustomTasksProgramId,
        m_options.CustomTasks.IsIncluded ? m_options.TotalVersion : VersionFactory.EmptyVersion);
      totalUpdateInfo.IsSmall = isSmall;

      //TODO определиться, как задавать апдейты, специфичные для страны
      //totalUpdateInfo.Country = reader.GetAttribute("country") ?? String.Empty;
      //if (totalUpdateInfo.Country.Length > 0)
      //{
      //    //если задана страна, то этот тотал-архив нужно выводить, если только эта страна -- текущая
      //    if (!totalUpdateInfo.Country.Equals(AdminHelper.GetCurrentCountry())) continue;
      //}

      if (needAdd)
      {
        UpdatesInfo.Add(totalUpdateInfo);
      }

      //#endregion

      //собираем полный архив
      //если это кумулятивный апдейт, то в него обязательно должны входить все продукты
      //если какой-то не создавался в этот сеанс работы, то надо взять из предыдущей версии (определить по update.xml)
      //атомарный архив может содержать не полный набор продуктов
      if (!isSmall)
      {
        //кумулятивный патч
        if (!allPatchesComplete)
        {
          //собираем недостающие продукты из предыдущих версий
          if (UpdatesInfo.Count == 0)
          {
            throw new PackageCreatorException(
              "Either patches for all products to be added to the cumulative patch or info on them are required in file updates.xml.");
          }
          var ui = UpdatesInfo[UpdatesInfo.Count - 1];
          if (!m_options.Aum.IsIncluded)
          {
            AddOldUpdate(updates, ui, ProductHelper.AumProgramId);
          }
          if (!m_options.Db.IsIncluded)
          {
            AddOldUpdate(updates, ui, ProductHelper.DbProgramId);
          }
          if (!m_options.DbArchive.IsIncluded)
          {
            AddOldUpdate(updates, ui, ProductHelper.DbaProgramId);
          }
          if (!m_options.AvrDb.IsIncluded)
          {
            AddOldUpdate(updates, ui, ProductHelper.AvrServiceDbProgramId);
          }
          if (!m_options.AvrService.IsIncluded)
          {
            AddOldUpdate(updates, ui, ProductHelper.AvrServiceProgramId);
          }
          if (!m_options.Desktop.IsIncluded)
          {
            AddOldUpdate(updates, ui, ProductHelper.EidssProgramId);
          }
          if (!m_options.NotificationService.IsIncluded)
          {
            AddOldUpdate(updates, ui, ProductHelper.NsProgramId);
          }
          if (!m_options.CustomTasks.IsIncluded)
          {
            AddOldUpdate(updates, ui, ProductHelper.CustomTasksProgramId);
          }
        }
      }
      var updateTotal = UpdHelper.CreateTotalArchive(m_crSettings.BuildPath, updates, isSmall, m_options.TotalVersion.ToString());
      totalUpdateInfo.CRC = FileHelper.CaclulateCRC(updateTotal);

      //в updates.xml записываем информацию о продуктах и о контрольной сумме полного архива
      TotalUpdateInfo.Save(UpdatesInfo, Path.Combine(m_crSettings.BuildPath, FileHelper.UpdatesInfoFileName));

      return 0;
    }

    /// <summary>
    /// Собирает пользовательский ввод и формирует файл run.upd
    /// </summary>
    /// <returns></returns>
    private void CreateUpdateFile(string programId, Version version, string sourceDir, bool isSmallUpdate, string cortegeVersion)
    {
      var filename = Path.Combine(sourceDir, FileHelper.FileNameUpdate);

      var textWriter = XmlHelper.CreateXmlTextWriter(filename, version, programId, isSmallUpdate, cortegeVersion);

      var sqlScriptsList = new List<RunScriptData>();
      var executeDataList = new List<ExecuteData>();

      if (programId == ProductHelper.DbProgramId)
      {
        sqlScriptsList.AddRange(GetDbScripts());
      }
      else if (programId == ProductHelper.DbaProgramId)
      {
        sqlScriptsList.AddRange(GetDbaScripts());
      }
      else if (programId == ProductHelper.AvrServiceDbProgramId)
      {
        sqlScriptsList.AddRange(GetAvrScripts());
      }
      else if (programId == ProductHelper.CustomTasksProgramId)
      {
        executeDataList.AddRange(GetCustomTaskFiles());
      }

      //скрипты
      XmlHelper.AddSQLScriptSection(textWriter, sqlScriptsList);

      //собираем перечень изменений в конфиг-файлах
      //XmlHelper.AddChangeConfigValueSection(textWriter, m_ConfigFilesList);

      //собираем перечень удаляемых файлов
      //XmlHelper.AddDeleteFilesSection(textWriter, lbDeleteFiles);

      //запускаемые файлы
      XmlHelper.AddExecuteSection(textWriter, executeDataList);

      XmlHelper.CloseXmlTextWriter(textWriter);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="programId"></param>
    /// <param name="version"></param>
    /// <param name="versionTotal">Версия total/small архива</param>
    /// <param name="sourceDir"></param>
    /// <param name="isSmallUpdate"></param>
    /// <param name="cortegeVersion"> </param>
    /// <returns>Имя файла патча</returns>
    private string CreatePatchFile(
      string programId,
      Version version,
      Version versionTotal,
      string sourceDir,
      bool isSmallUpdate,
      string cortegeVersion)
    {
      CreateUpdateFile(programId, version, sourceDir, isSmallUpdate, cortegeVersion);

      //архивируем
      var fZip = new FastZip();
      var updateFile = Path.Combine(m_crSettings.BuildPath, FileHelper.GetUpdateFileName(programId, versionTotal.ToString()));
      fZip.CreateZip(updateFile, sourceDir, true, string.Empty);
      var crcFileInfo = new FileInfo(FileHelper.GetCRCFilename(updateFile));
      var crc = FileHelper.CaclulateCRC(updateFile);
      using (var sw = crcFileInfo.CreateText())
      {
        //определяем контрольную сумму получившегося архива
        sw.Write(crc);
      }
      return updateFile;
    }

    private IEnumerable<RunScriptData> GetDbScripts()
    {
      var files = m_options.Db.FileManager.Files;
      return files.Any() ? files.Cast<RunScriptData>() : GetDbScriptsFromFolder(m_crSettings.DBPath);
    }

    private IEnumerable<RunScriptData> GetDbaScripts()
    {
      var files = m_options.DbArchive.FileManager.Files;
      return files.Any() ? files.Cast<RunScriptData>() : GetDbScriptsFromFolder(m_crSettings.DBaPath);
    }

    private IEnumerable<RunScriptData> GetAvrScripts()
    {
      var files = m_options.AvrDb.FileManager.Files;
      return files.Any() ? files.Cast<RunScriptData>() : GetDbScriptsFromFolder(m_crSettings.AvrDbPath);
    }

    private static IEnumerable<RunScriptData> GetDbScriptsFromFolder(string folder)
    {
      var files = new List<RunScriptData>();
      if (folder.Length == 0 || !Directory.Exists(folder))
      {
        return files;
      }
      var sqlFiles = FileHelper.GetFiles(folder, "*.sql", true);
      files.AddRange(sqlFiles.Select(fileInfo => new RunScriptData
      {
        FileName = Path.GetFileName(fileInfo.FullName),
        Checked = true
      }));
      files.Sort(new SqlFileComparer());
      return files;
    }

    private IEnumerable<ExecuteData> GetCustomTaskFiles()
    {
      var files = new List<ExecuteData>();
      var rootfolderName = m_crSettings.CustomTasksPath;
      if (rootfolderName.Length == 0 && !Directory.Exists(rootfolderName))
      {
        return files;
      }
      var localFiles = FileHelper.GetFiles(rootfolderName, "*.bat", false);
      localFiles.AddRange(FileHelper.GetFiles(rootfolderName, "*.cmd", false));
      localFiles.AddRange(FileHelper.GetFiles(rootfolderName, "*.exe", false));
      files.AddRange(localFiles.Select(fileInfo => new ExecuteData
      {
        FileName = Path.GetFileName(fileInfo.FullName),
        Checked = CalculateCheckedState(fileInfo),
        NeedWait = true
      }));
      return files;
    }

    private static bool CalculateCheckedState(FileSystemInfo fileInfo)
    {
      if (!fileInfo.Extension.Equals(".exe", StringComparison.OrdinalIgnoreCase))
      {
        return true;
      }

      var fileParentDirector = Path.GetDirectoryName(fileInfo.FullName);
      var fileName = Path.GetFileNameWithoutExtension(fileInfo.Name);

      return !FileHelper.GetFiles(fileParentDirector, fileName + ".bat", false).Any() &&
             !FileHelper.GetFiles(fileParentDirector, fileName + ".cmd", false).Any();
    }

    private static void AddUpdateInfo(TotalUpdateInfo totalUpdateInfo, string programId, Version version)
    {
      var ui = totalUpdateInfo.Updates.FirstOrDefault(u => u.Alias.Equals(programId));
      if (ui == null)
      {
        totalUpdateInfo.Updates.Add(new UpdateInfo(programId, version));
      }
      else
      {
        ui.VersionFinish = version;
      }
    }

    private void AddOldUpdate(ICollection<string> updates, TotalUpdateInfo ui, string programId)
    {
      var uiProg = ui.GetProduct(programId);
      if (uiProg == null)
      {
        return;
      }

      updates.Add(Path.Combine(
        m_crSettings.BuildPath,
        FileHelper.GetUpdateFileName(programId, uiProg.VersionFinish.ToString())));
      if (programId.Equals(ProductHelper.AumProgramId))
      {
        m_options.Aum.Version = ui.Version;
      }
      else if (programId.Equals(ProductHelper.DbProgramId))
      {
        m_options.Db.Version = ui.Version;
      }
      else if (programId.Equals(ProductHelper.DbaProgramId))
      {
        m_options.DbArchive.Version = ui.Version;
      }
      else if (programId.Equals(ProductHelper.AvrServiceDbProgramId))
      {
        m_options.AvrDb.Version = ui.Version;
      }
      else if (programId.Equals(ProductHelper.AvrServiceProgramId))
      {
        m_options.AvrService.Version = ui.Version;
      }
      else if (programId.Equals(ProductHelper.EidssProgramId))
      {
        m_options.Desktop.Version = ui.Version;
      }
      else if (programId.Equals(ProductHelper.NsProgramId))
      {
        m_options.NotificationService.Version = ui.Version;
      }
      //else if (programID.Equals(ProductHelper.CustomTasksProgramId)) tbTotalVersion.Text = ui.Version;
    }
  }
}
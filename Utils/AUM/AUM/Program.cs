namespace AUM
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Globalization;
  using System.IO;
  using System.Linq;
  using System.Threading;
  using Core;
  using Core.Helper;
  using ICSharpCode.SharpZipLib.Zip;


  internal static class Program
  {
    private static bool s_isSyncRegime;
    private static bool s_isUpdateRegime;
    private static string s_programId;
    private static string s_updateFilename;
    private static long s_idAdminRecord;
    private static Version s_eidssVersion;
    private static string s_configPath;

    private static UpdateForm UpdateForm { get; set; }

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main(string[] args)
    {
      /*
                Аргументы командной строки
             * /d - скачивание апдейтов и выкачивание логов
             * /a - id записи в БД Admin  юзер НЕ ИСПОЛЬЗУЕТСЯ
             * /c - ClientID (например, 002264C0961F) НЕ ИСПОЛЬЗУЕТСЯ
             * /f - имя файла обновления, которое надо применить в этом сеансе (имя файла без расширения)             
             * /s - optional path to bvupdater.config. Used for AUM selfupdate from temp folder
             * 
             * Также существует единственный каталог, куда скачиваются апдейты для всех продуктов, и единственный каталог, откуда выкачиваются логи
            */

      //определяем перечень входных параметров
      s_isSyncRegime = false;
      s_isUpdateRegime = false;
      s_programId = string.Empty;
      s_updateFilename = string.Empty;
      s_idAdminRecord = Updater.EmptyIdAdminRecord;
      s_eidssVersion = VersionFactory.EmptyVersion;
      s_configPath = Path.Combine(UpdHelper.AUMPath, FileHelper.BVUpdaterConfigFileName);

      try
      {
        SecurityLog.WriteToEventLogWindows(EventLogEntryType.Information, "AUM startpoint");
        SecurityLog.WriteToEventLogWindows(EventLogEntryType.Information, "aum.log path = {0}", AUMLog.AUMLogFullPath);
        AUMLog.WriteInLog("==========================");
        AUMLog.WriteInLog("Args: {0}", string.Join(";", args));

        if (!ProcessInputArguments(args))
        {
          return;
        }

        var appPath = FileHelper.GetExecutingPath();
        AUMLog.WriteInLog("Config path: {0}", s_configPath);
        var settings = new ConfigSettings(s_configPath)
        {
          Args = UpdHelper.ArrayToString(args),
          ProgramId = s_programId
        };

        #region Определение культуры

        //на случай, если работает какая-то неправильная кодовая страница
        AUMLog.WriteInLog("ZipConstants Code Page is {0}", ZipConstants.DefaultCodePage);
        AUMLog.WriteInLog(
          "Current Culture is {0}/{1}",
          Thread.CurrentThread.CurrentCulture.DisplayName,
          Thread.CurrentThread.CurrentCulture.EnglishName);
        UpdHelper.SetCorrectCodePage();

        #endregion

        //не может быть запущено несколько копий приложения
        //bool alone;
        //var mutex = new Mutex(true, "AUM60", out alone);

        var updater = GetUpdater(settings);

        //определяем корневой каталог, в котором нужно проводить работы
        var workingDir = updater.WorkingDir;

        //проверяем наличие нужных каталогов
        var path = ProductHelper.IsAUMUpdate(s_programId) ? workingDir : appPath;
        var dirUpdatePath = Path.Combine(path, FileHelper.AUMUpdateDirName);
        var dirLogPath = Path.Combine(path, FileHelper.AUMLogDirName);
        var dirBackupPath = Path.Combine(path, FileHelper.BackupsDirName);

        var dirsExcluded = new List<string>
        {
          dirUpdatePath,
          dirLogPath,
          dirBackupPath
        };
        foreach (var dirName in dirsExcluded.Where(dirName => !Directory.Exists(dirName)))
        {
          Directory.CreateDirectory(dirName);
        }

        #region Sync

        if (s_isSyncRegime)
        {
          Synchronizer.TransferData(settings);
          return;
        }

        #endregion

        #region Update

        //определяем текущую культуру
        //UpdHelper.MainConnection.Open();
        Thread.CurrentThread.CurrentUICulture = UpdHelper.GetCurrentCulture();

        //убиваем недокачанные файлы
        UpdHelper.DeleteFilesWithErrors(dirUpdatePath);

        s_updateFilename = Path.Combine(settings.UpdateLocal, s_updateFilename);

        //проверяем необходимость обновление самого AUM
        //AUM обновляется здесь, чтобы блокировок никаких не включать
        if (ProductHelper.IsAUMUpdate(s_programId))
        {
          updater.RunAUMUpdate(s_updateFilename, s_idAdminRecord);
        }
        else
        {
          updater.RunUpdate(s_updateFilename, s_eidssVersion);
        }

        #endregion
      }
      catch (Exception exc)
      {
        SecurityLog.WriteToEventLogWindows(
          EventLogEntryType.Error,
          "Message='{0}'{1}{1}StackTrace='{2}'{1}{1}StackTrace='{3}'",
          exc.Message,
          Environment.NewLine,
          exc.StackTrace,
          exc.InnerException != null ? exc.InnerException.Message : string.Empty);
      }
    }

    private static Updater GetUpdater(ConfigSettings settings)
    {
      switch (settings.Level)
      {
        case MachineLevel.Level.ClientWks:
          return new UpdaterClientWks(settings);
        case MachineLevel.Level.WebWks:
          return new UpdaterWebWks(settings);
        case MachineLevel.Level.Cdr:
        case MachineLevel.Level.SlvlNsslvl:
        case MachineLevel.Level.Web:
        default:
          return new Updater(settings);
      }
    }

    private static bool ProcessInputArguments(ICollection<string> args)
    {
      if (args.Count == 0)
      {
        return false;
      }

      foreach (var arg in args)
      {
        if (arg.Equals(Args.Sync))
        {
          s_isSyncRegime = true;
        }

        if ((arg.Length <= 2))
        {
          continue;
        }

        if (arg.StartsWith("/f", StringComparison.OrdinalIgnoreCase))
        {
          //тот патч, который применяется
          s_isUpdateRegime = true;
          s_updateFilename = string.Format(CultureInfo.InvariantCulture, "{0}.zip", arg.Substring(2, arg.Length - 2));
          s_programId = FileHelper.ExtractProgramID(s_updateFilename);
        }
        if (arg.StartsWith(Args.Admin))
        {
          //передача идентификатора 
          long.TryParse(arg.Substring(2), out s_idAdminRecord);
        }
        if (arg.StartsWith("/e", StringComparison.OrdinalIgnoreCase))
        {
          //передается дополнительно версия EIDSS (нужно для db и dba)
          var strVersion = arg.Substring(2);
          Version.TryParse(strVersion, out s_eidssVersion);
        }

        if (arg.StartsWith("/s:", StringComparison.OrdinalIgnoreCase))
        {
          s_configPath = arg.Substring(3);
        }
      }

      //неверные входные параметры
      return s_isSyncRegime || s_isUpdateRegime;
    }


    private static void OnUpdaterSetMaxProgressBar()
    {
      UpdateForm.SetProgressbarMax();
    }

    private static void OnUpdaterSetProgressbarMaxValue(int maxValue)
    {
      UpdateForm.SetProgressBarMaxValue(maxValue);
    }

    private static void OnUpdaterMoveNextProgressBar()
    {
      UpdateForm.ProgressbarStep();
    }

    private static void OnUpdaterAddLogString(string message)
    {
      UpdateForm.AddReportString(message);
    }

    private static void InitUpdateForm()
    {
      UpdateForm = new UpdateForm();
      UpdateForm.SetWindowCaption(s_programId);
      UpdateForm.SetProgressBarMaxValue(10);
      UpdateForm.Show();
      UpdateForm.ButtonCloseEnabled(false);
      UpdateForm.SetProgressbarMin();
    }
  }
}
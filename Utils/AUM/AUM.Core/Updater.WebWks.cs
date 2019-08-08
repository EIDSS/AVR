namespace AUM.Core
{
  using System;
  using System.Diagnostics;
  using System.Globalization;
  using System.IO;
  using System.Linq;
  using db;
  using Enums;
  using Helper;


  public sealed class UpdaterWebWks : Updater
  {
    private const string NoDbUpdateRequiredMessage = "This is WebWKS (level {0}). Database Update is ignored.";
    private const string NoDbaUpdateRequiredMessage = "This is WebWKS (level {0}). Archive Database Update is ignored.";
    private const string NoAvrDbUpdateRequiredMessage = "This is WebWKS (level {0}). AVR Service Database Update is ignored.";
    private const string NoNsUpdateRequiredMessage = "This is WebWKS (level {0}). Notification Service Update is ignored.";
    private const string NoAvrServiceUpdateRequiredMessage = "This is WebWKS (level {0}). AVR Service Update is ignored.";
    private const string NoEidssUpdateRequiredMessage = "This is WebWKS (level {0}). EIDSS Update is ignored.";

    public UpdaterWebWks(ConfigSettings settings)
      : base(settings)
    {
    }


    /// <summary>
    /// Определение необходимости делать апдейт
    /// </summary>
    /// <param name="updatePackageFileName">полный путь к пакету апдейта</param>
    /// <param name="productId">обновляемый продукт</param>
    /// <returns></returns>
    private bool IsThisUpdateRequired(string updatePackageFileName, string productId)
    {
      AUMLog.WriteInLog("Check update");

      var fZip = UpdHelper.CreateZipper();
      fZip.ExtractZip(updatePackageFileName, UpdHelper.TempDirPath, FileHelper.FileNameUpdate);
      //если удалось распаковать файл, то определим версию апдейта из него
      var updFileName = Path.Combine(UpdHelper.TempDirPath, FileHelper.FileNameUpdate);
      if (!File.Exists(updFileName))
      {
        return false;
      }

      var updateSettings = UpdHelper.ReadUpdateFile(updFileName);

      if (DoesUpdateFailedByCortege(updateSettings))
      {
        return false;
      }

      Settings.VersionOfUpdate = updateSettings.Version;

      //проверим, для нужной ли программы этот апдейт
      if (!updateSettings.ProgramID.Equals(productId, StringComparison.OrdinalIgnoreCase))
      {
        return false;
      }

      //проверим версию
      //проверяем либо версии программ, либо версию БД
      if (ProductHelper.IsDBUpdate(productId))
      {
        #region Проверка версии БД

        SetUpdateState(
          string.Format(CultureInfo.InvariantCulture, NoDbUpdateRequiredMessage, Settings.Level),
          productId,
          Settings.VersionOfUpdate,
          Settings.Level);
        return false;

        #endregion
      }
      if (ProductHelper.IsDBaUpdate(productId))
      {
        #region Проверка версии БД (архивной)

        SetUpdateState(
          string.Format(CultureInfo.InvariantCulture, NoDbaUpdateRequiredMessage, Settings.Level),
          productId,
          Settings.VersionOfUpdate,
          Settings.Level);
        return false;

        #endregion
      }
      if (ProductHelper.IsAvrServiceDbProgram(productId))
      {
        #region Проверка версии AVR Service БД

        SetUpdateState(
          string.Format(CultureInfo.InvariantCulture, NoAvrDbUpdateRequiredMessage, Settings.Level),
          productId,
          Settings.VersionOfUpdate,
          Settings.Level);
        return false;

        #endregion
      }
      if (ProductHelper.IsNSProgram(productId))
      {
        SetUpdateState(
          string.Format(CultureInfo.InvariantCulture, NoNsUpdateRequiredMessage, Settings.Level),
          productId,
          Settings.VersionOfUpdate,
          Settings.Level);
        return false;
      }
      if (ProductHelper.IsAvrServiceProgram(productId))
      {
        SetUpdateState(
          string.Format(CultureInfo.InvariantCulture, NoAvrServiceUpdateRequiredMessage, Settings.Level),
          productId,
          Settings.VersionOfUpdate,
          Settings.Level);
        return false;
      }
      if (ProductHelper.IsEIDSSProgram(productId))
      {
        SetUpdateState(
          string.Format(CultureInfo.InvariantCulture, NoEidssUpdateRequiredMessage, Settings.Level),
          productId,
          Settings.VersionOfUpdate,
          Settings.Level);
        return false;
      }
      if (ProductHelper.IsExecuteUpdate(productId))
      {
        #region Проверяем по реестру, выполнялся ли такой апдейт

        //если уже есть такая запись (апдейт выполнялся), то выходим
        if (RegistryHelper.DoesExecuteRegistryKeyExist(Settings.VersionOfUpdate))
        {
          SetUpdateState(
            "Check update failed: this update is already applied",
            productId,
            Settings.VersionOfUpdate,
            Settings.Level);
          return false;
        }

        #endregion
      }

      if (!IsCRCCorrect(updatePackageFileName))
      {
        return false;
      }
      AUMLog.WriteInLog("Update is correct and required");
      return true;
    }

    private static bool DoesUpdateFailedByCortege(UpdateSettings updateSettings)
    {
      //считаем, что более ранний total/small архив не может содержать более позднюю версию
      if (!updateSettings.IsSmallUpdate || string.IsNullOrEmpty(updateSettings.CortegeVersion))
      {
        return false;
      }

      AUMLog.WriteInLog("Cortege check");
      foreach (var cortege in UpdHelper.ParseUpdateVersions(updateSettings.CortegeVersion))
      {
        if (ProductHelper.IsAUMUpdate(cortege.ProductID))
        {
          var currentVersion = FileHelper.GetAUMVersion(UpdHelper.AUMPath);
          AUMLog.WriteInLog("Current AUM Version: {0}", currentVersion);
          if (!cortege.IsValidVersion(currentVersion))
          {
            AUMLog.WriteInLog("Check update failed: current Version failed by cortege");
            return true;
          }
        }
      }
      return false;
    }

    private static void SetUpdateState(
          string message,
          string programId,
          Version version,
          MachineLevel.Level machineLevel)
    {
      AUMLog.WriteInLog(message);
      //пишем фейковую запись про то, что обновление не нужно
      //если такая запись не была создана ранее
      
      FileHelper.WriteLogFile(
        FileHelper.GetExecutingPath(),
        true,
        "This component needs no update",
        version.ToString(),
        programId,
        machineLevel,
        message);
    }

    public override void RunUpdate(string updateFilename, Version eidssVersion)
    {
      if (!IsThisUpdateRequired(updateFilename, Settings.ProgramId))
      {
        return;
      }

      //бэкап будем размещать в каталоге backups\Update<версия>
      var tempDir = Path.Combine(Settings.BackupPath, Path.GetFileNameWithoutExtension(updateFilename) ?? string.Empty);
      if (!Directory.Exists(tempDir))
      {
        Directory.CreateDirectory(tempDir);
      }

      //SecurityLog.WriteToEventLogDB(
      //  conn,
      //  Operations.Update,
      //  true,
      //  string.Empty,
      //  string.Format(ResourceHelper.Get("UpdateProcessStarted"), DateTime.Now));

      AddReportString(string.Format(ResourceHelper.Get("UpdateProcessStarted"), DateTime.Now));

      InvokeSetProgressbarMaxValue(10);

      var workDir = Path.Combine(UpdHelper.TempDirPath, Path.GetFileNameWithoutExtension(updateFilename) ?? string.Empty);

      var fZip = ExtractUpdateFiles(updateFilename, workDir);

      InvokeMoveNextProgressBar();

      var updFileName = Path.Combine(workDir, FileHelper.FileNameUpdate);
      //получим программу апдейта
      var settings = UpdHelper.ReadUpdateFile(updFileName);

      //для обновления БД и AUM не нужен clientID
      var clientId = UpdHelper.GetClientID(settings.ProgramID);
      CreateUpdateBlock(clientId, settings, null);
      DeleteRunningApps(null, clientId, settings);

      var success = false;
      var errorMessage = string.Empty; //сюда пишем все сообщения об ошибках

      /*var idAdminRecord = */
      RegisterUpdateStart(WorkingDir, settings);

      //обновление AUM смотри в Program.cs
      if (ProductHelper.IsDBUpdate(settings.ProgramID))
      {
        success = RunDbUpdate(settings, workDir, out errorMessage);
      }
      else if (ProductHelper.IsDBaUpdate(settings.ProgramID))
      {
        success = RunDbaUpdate(settings, workDir, out errorMessage);
      }
      else if (ProductHelper.IsNSProgram(settings.ProgramID))
      {
        success = RunNsUpdate(settings, workDir, out errorMessage);
      }
      else if (ProductHelper.IsAvrServiceDbProgram(settings.ProgramID))
      {
        success = RunAvrServiceDbUpdate(settings, workDir, out errorMessage);
      }
      else if (ProductHelper.IsAvrServiceProgram(settings.ProgramID))
      {
        success = RunAvrServiceUpdate(settings, workDir, out errorMessage);
      }
      else if (ProductHelper.IsEIDSSProgram(settings.ProgramID))
      {
        success = RunEidssUpdate(settings, workDir, out errorMessage);
      }
      else if (ProductHelper.IsExecuteUpdate(settings.ProgramID))
      {
        success = RunXPatch(settings, workDir, out errorMessage);
      }

      //если была ошибка, то отметим это
      if (errorMessage.Length > 0)
      {
        AddReportString(errorMessage);
        //SecurityLog.WriteToEventLogDB(conn, Operations.Update, success, errorMessage,string.Empty);
      }

      var message = string.Format(
        CultureInfo.InvariantCulture,
        success ? ResourceHelper.Get("UpdateSuccessfullyComplete") : ResourceHelper.Get("UpdateFailed"),
        DateTime.Now);
      //SecurityLog.WriteToEventLogDB(conn, Operations.Update, success, string.Empty, message);

      AddReportString(message);
      InvokeSetMaxProgressBar();

      try
      {
        //var description = string.Format(
        //  CultureInfo.InvariantCulture,
        //  "Date Time = {0}; Result = {1}; Updated to Version = {2}; Computer Name = {3}",
        //  DateTime.Now,
        //  success ? "success" : "fail",
        //  settings.Version,
        //  Environment.MachineName);

        //снимаем блокировку апдейта
        DeleteUpdateBlock(null);

        //произвоим запись в системный лог (БД, потом если не получилось, то в журнал Windows)
        //SecurityLog.WriteToEventLogDB(conn, Operations.Update, success, errorMessage, description);

        //кладем логи в локальный каталог
        AddReportString(ResourceHelper.Get("TryCopyLogs"));

        var fullReportString = Report.ToString();
        FileHelper.WriteLogFile(
          FileHelper.GetExecutingPath(),
          success,
          fullReportString,
          settings.Version.ToString(),
          settings.ProgramID,
          Settings.Level,
          message);

        //пишем в Admin окончание обновления
        //if (idAdminRecord > EmptyIdAdminRecord)
        //{
        //  AdminHelper.WriteUpdateFinishedToAdminDB(idAdminRecord, settings.Version, success, fullReportString);
        //}
        //else
        //{
        //  AUMLog.WriteInLog("Can't write into Admin DB ({0})", EmptyIdAdminRecord);
        //}

        // Архивируем бэкапы в один пакет
        string tmp;
        var backupFilename = ArchiveBackups(tempDir, fZip, out tmp);
        InvokeMoveNextProgressBar();

        //удаляем бэкапы
        AddReportString(ResourceHelper.Get("DeleteGarbageBackups"));

        ClearBackup(
          tempDir,
          ProductHelper.IsEIDSSProgram(settings.ProgramID) ? UpdHelper.EIDSSPath : UpdHelper.NSPath,
          Settings.BackupPath, out errorMessage);
        AddReportString(
          errorMessage.Length == 0
          ? ResourceHelper.Get("GarbageBackupsSuccessfullyDeleted")
          : string.Format(ResourceHelper.Get("GarbageBackupsFailedDeleted"), errorMessage));
        File.Move(tmp, backupFilename);

        #region Удаление предыдущих версий бэкапа
        //для каждого продукта может быть только один бэкап, остальные удаляем
        var dirs = Directory.GetDirectories(
          Settings.BackupPath,
          string.Format(CultureInfo.InvariantCulture, "update_{0}_*", Settings.ProgramId));
        foreach (var dir in dirs.Where(dir => !dir.ToUpperInvariant().Equals(tempDir.ToUpperInvariant())))
        {
          FileHelper.DeleteDir(dir, true);
        }
        #endregion

        //работа завершена
        AddReportString(ResourceHelper.Get("WorkComplete"));
      }
      catch (Exception exc)
      {
        errorMessage = UpdHelper.GetErrorMessage(exc);
        AddReportString(errorMessage);
        SecurityLog.WriteToEventLogWindows(EventLogEntryType.Error, errorMessage);
      }
    }

    
    protected bool RunDbUpdate(UpdateSettings settings, string workDir, out string errorMessage)
    {
      errorMessage = string.Empty;
      AddReportString(NoDbUpdateRequiredMessage, Settings.Level);
      return true;
    }

    protected bool RunDbaUpdate(UpdateSettings settings, string workDir, out string errorMessage)
    {
      errorMessage = string.Empty;
      AddReportString(NoDbaUpdateRequiredMessage, Settings.Level);
      return true;
    }

    protected bool RunNsUpdate(UpdateSettings settings, string workDir, out string errorMessage)
    {
      errorMessage = string.Empty;
      AddReportString(NoNsUpdateRequiredMessage, Settings.Level);
      return true;
    }

    protected bool RunEidssUpdate(UpdateSettings settings, string workDir, out string errorMessage)
    {
      errorMessage = string.Empty;
      AddReportString(NoEidssUpdateRequiredMessage, Settings.Level);
      return true;
    }

    protected bool RunAvrServiceDbUpdate(UpdateSettings settings, string workDir, out string errorMessage)
    {
      errorMessage = string.Empty;
      AddReportString(NoAvrDbUpdateRequiredMessage, Settings.Level);
      return true;
    }

    protected bool RunAvrServiceUpdate(UpdateSettings settings, string workDir, out string errorMessage)
    {
      errorMessage = string.Empty;
      AddReportString(NoAvrServiceUpdateRequiredMessage, Settings.Level);
      return true;
    }

    protected override void CreateUpdateBlock(string clientId, UpdateSettings settings, UpdateMessenger updateMessenger)
    {
    }

    protected override void DeleteRunningApps(UpdateMessenger updateMessenger, string clientId, UpdateSettings settings)
    {
    }

    protected override void DeleteUpdateBlock(UpdateMessenger updateMessenger)
    {
    }

    protected override long RegisterUpdateStart(string workingDir, UpdateSettings settings)
    {
      // On WebWKS there is nothing - no db, no EIDSS, nothing. That's why no records in AdminDb
      return EmptyIdAdminRecord;
    }

    protected override long WriteAUMUpdateStartedToAdminDB(Version sourceVersion, Version targetVersion)
    {
      // On WebWKS there is nothing - no db, no EIDSS, nothing. That's why no records in AdminDb
      return EmptyIdAdminRecord;
    }

    protected override void WriteAUMUpdateFinishedToAdminDB(long idAdminRecord, Version versionThisUpdater, bool success)
    {
      // On WebWKS there is nothing - no db, no EIDSS, nothing. That's why no records in AdminDb
    }
  }
}
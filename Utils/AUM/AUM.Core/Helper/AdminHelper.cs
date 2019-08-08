namespace AUM.Core.Helper
{
  using System;
  using System.Collections.Generic;
  using System.Data;
  using System.Data.SqlClient;
  using System.Globalization;
  using System.IO;
  using System.Linq;
  using Enums;
  using UpdateStatus = Enums.UpdateStatus;


    public class TotalUpdatesComparer : IComparer<TotalUpdateInfo>
    {
        public int Compare(TotalUpdateInfo totalUpdateInfo1, TotalUpdateInfo totalUpdateInfo2)
        {
            return (new UpdatesFileNamesComparer()).Compare(
                FileHelper.GetTotalUpdateFileName(string.Format("6.0.0.{0}", totalUpdateInfo1.Version), totalUpdateInfo1.IsSmall)
                , FileHelper.GetTotalUpdateFileName(string.Format("6.0.0.{0}", totalUpdateInfo2.Version), totalUpdateInfo1.IsSmall));
        }
    }


    public static class AdminHelper
    {
      //nodb
      /// <summary>
      /// Читает файл updates.xml и извлекает оттуда информацию о патчах
      /// </summary>
      /// <param name="updatesFile"></param>
      /// <param name="errorString"></param>
      /// <returns></returns>
      public static List<TotalUpdateInfo> GetTotalUpdateInfo(string updatesFile, out string errorString)
      {
        errorString = string.Empty;
        var updateInfoList = new List<TotalUpdateInfo>();

        if (File.Exists(updatesFile))
        {
          updateInfoList.AddRange(XmlHelper.ReadUpdates(updatesFile));
        }
        else
        {
          errorString = string.Format("File not found: '{0}'", updatesFile);
        }

        return updateInfoList;
      }


      /// <summary>
      /// Отыскивает логи, соответствующие указанному апдейту, и выставляет реальный статус
      /// </summary>
      //public static void RefreshUpdateLogInfo(string computerName, IEnumerable<TotalUpdateInfo> totalUpdates)
      //{
      //  var updateInfoList = DatabaseHelper.GetUpdatesInfo(computerName);

      //  //для каждого продуктового патча определяем его статус
      //  //записей может быть несколько, потому что подъем версия 1 => версия 2 может быть в нескольких патчах
      //  foreach (var totalUpdate in totalUpdates)
      //  {
      //    for (var j = 0; j < totalUpdate.Updates.Count; j++)
      //    {
      //      var ui = totalUpdate.Updates[j];
      //      var patches = updateInfoList.Where(
      //        c =>
      //          (c.Alias == ui.Alias)
      //          &&
      //          (c.VersionFinish == ui.VersionFinish)
      //        ).ToList();
      //      if (patches.Count > 0)
      //      {
      //        //находим самый старший патч. Он последний из-за сортировки
      //        var patch = patches[patches.Count - 1];
      //        ui.VersionStart = patch.VersionStart;
      //        ui.Success = patch.Success;
      //        ui.Status = ui.Success ? UpdateStatus.Success : UpdateStatus.Error;
      //      }
      //      else
      //      {
      //        ui.VersionStart = VersionFactory.EmptyVersion;
      //        ui.Success = false;
      //      }

      //      totalUpdate.Updates[j] = ui;
      //    }
      //  }
      //}

      //no db
      public static UpdateStatus GetStatusForLastTotalUpdate(List<TotalUpdateInfo> totalUpdates)
      {
        if (!totalUpdates.Any())
        {
          return UpdateStatus.Unknown;
        }

        /*
         Правила
         1) если последний тотал провалился или неизвестен, то статус соответствующий
         2) если один из small patches старше тотала провалился или неизвестен, то статус соответствующий
             
         */

        //отыскиваем последний тотал-патч и выставляем по нему
        var lastTotalUndex = FindLatestTotalIndex(totalUpdates);
        if (-1 == lastTotalUndex)
        {
          return UpdateStatus.Unknown;
        }
        
        var resultStatus = totalUpdates[lastTotalUndex].GetTotalUpdateStatus();
        //если тотал не последний и после были small, то дополнительно проверим по ним
        return lastTotalUndex != totalUpdates.Count - 1 && resultStatus == UpdateStatus.Success
          ? GetUnsuccessfulSmallStatus(totalUpdates, lastTotalUndex)
          : resultStatus;
      }

      private static UpdateStatus GetUnsuccessfulSmallStatus(IList<TotalUpdateInfo> totalUpdates, int lastTotalUndex)
      {
        for (var index = lastTotalUndex + 1; index < totalUpdates.Count; index++)
        {
          var status = totalUpdates[index].GetTotalUpdateStatus();
          if (!totalUpdates[index].IsSmall || status == UpdateStatus.Success)
          {
            continue;
          }
          return status;
        }
        return UpdateStatus.Success;
      }

      private static int FindLatestTotalIndex(IList<TotalUpdateInfo> totalUpdates)
      {
        for (var index = totalUpdates.Count - 1; index >= 0; index--)
        {
          if (!totalUpdates[index].IsSmall)
          {
            return index;
          }
        }
        return -1;
      }

      public static string GetCurrentCountry()
        {
            //TODO сделать получение страны
            return string.Empty;
        }

        public static string GetCurrentCountryName()
        {
            var result = string.Empty;
            switch (GetCurrentCountry())
            {
                case "":
                    result = "Unknown";
                    break;
            }

            return result;
        }

        public static long GetUpdateFromAdminDB(string programId, string sourceVersion, string strTargetVersion, SqlTransaction transaction = null)
        {
            var parameters = new List<SqlParameter>
                                 {
                                     new SqlParameter("@idfUpdatedComponent", SqlDbType.BigInt) {Direction = ParameterDirection.Output},
                                     new SqlParameter("@strAlias", SqlDbType.VarChar, 5){Value = programId},
                                     new SqlParameter("@strComputerName", SqlDbType.NVarChar, 100){Value = Environment.MachineName},
                                     new SqlParameter("@strSourceVersion", SqlDbType.NVarChar, 50){Value = sourceVersion},
                                     new SqlParameter("@strTargetVersion", SqlDbType.NVarChar, 50){Value = strTargetVersion},
                                 };
            var cmd = DatabaseHelper.ExecuteStoredProc(UpdateDatabases.DbAdmin, "dbo.spAUMGetUpdate", parameters, transaction);
            return cmd != null ? Convert.ToInt64(cmd.Parameters["@idfUpdatedComponent"].Value) : -1;
        }

        /// <summary>
        /// Пишет сведения об начале обновления в БД EIDSS_Admin
        /// </summary>
        /// <returns></returns>
        public static long WriteUpdateStartedToAdminDB(string programId, Version sourceVersion, Version targetVersion, SqlTransaction transaction = null)
        {
            var parameters = new List<SqlParameter>
                                 {
                                     new SqlParameter("@idfUpdatedComponent", SqlDbType.BigInt) {Direction = ParameterDirection.Output},
                                     new SqlParameter("@strAlias", SqlDbType.VarChar, 5){Value = programId},
                                     new SqlParameter("@strComputerName", SqlDbType.NVarChar, 100){Value = Environment.MachineName},
                                     new SqlParameter("@strSourceVersion", SqlDbType.NVarChar, 50){Value = sourceVersion.ToString()},
                                     new SqlParameter("@strTargetVersion", SqlDbType.NVarChar, 50){Value = targetVersion.ToString()}
                                 };
            var cmd = DatabaseHelper.ExecuteStoredProc(UpdateDatabases.DbAdmin, "dbo.spAUMWriteUpdateStarted", parameters, transaction);
            return cmd != null ? Convert.ToInt64(cmd.Parameters["@idfUpdatedComponent"].Value) : -1;
        }

        /// <summary>
        /// Пишет сведения об окончании обновления в БД EIDSS_Admin
        /// </summary>
        /// <returns></returns>
        public static void WriteUpdateFinishedToAdminDB(long idfUpdatedComponent, Version strTargetVersion, bool isSuccess, string strLog, SqlTransaction transaction = null)
        {
            var intUpdateResult = isSuccess ? 0 : 1;
            var parameters = new List<SqlParameter>
                                 {
                                     new SqlParameter("@idfUpdatedComponent", SqlDbType.BigInt) {Value = idfUpdatedComponent},
                                     new SqlParameter("@strTargetVersion", SqlDbType.NVarChar, 50){Value = strTargetVersion.ToString()},
                                     new SqlParameter("@intUpdateResult", SqlDbType.Int){Value = intUpdateResult},
                                     new SqlParameter("@strLog", SqlDbType.NVarChar, -1){Value = strLog}
                                 };
            DatabaseHelper.ExecuteStoredProc(UpdateDatabases.DbAdmin, "dbo.spAUMWriteUpdateFinished", parameters, transaction);
        }

        public static long RegistryPatch(Version patchVersion, bool isSmall, SqlTransaction transaction = null)
        {
            var parameters = new List<SqlParameter>
                                 {
                                     new SqlParameter("@idfEIDSSPatch", SqlDbType.BigInt) {Direction = ParameterDirection.Output},
                                     new SqlParameter("@PatchVersion", SqlDbType.NVarChar, 200) {Value = patchVersion.ToString()},
                                     new SqlParameter("@isSmall", SqlDbType.Bit){Value = isSmall},
                                 };
            var cmd = DatabaseHelper.ExecuteStoredProc(UpdateDatabases.DbAdmin, "dbo.spAUMSaveEIDSSPatch", parameters, transaction);
            return cmd != null ? Convert.ToInt64(cmd.Parameters["@idfEIDSSPatch"].Value) : -1;
        }

        public static bool RegistryPatchProduct(
          Version patchVersion,
          EIDSSComponents idComponent,
          Version componentVersion,
          SqlTransaction transaction = null)
        {
            var parameters = new List<SqlParameter>
                                 {
                                     new SqlParameter("@isCorrect", SqlDbType.BigInt) {Direction = ParameterDirection.Output},
                                     new SqlParameter("@PatchVersion", SqlDbType.NVarChar, 200) {Value = patchVersion.ToString()},
                                     new SqlParameter("@idfEIDSSComponent", SqlDbType.BigInt) {Value = (long)idComponent},
                                     new SqlParameter("@PatchComponentVersion", SqlDbType.NVarChar, 200) {Value = componentVersion.ToString()},
                                 };
            var cmd = DatabaseHelper.ExecuteStoredProc(UpdateDatabases.DbAdmin, "dbo.spAUMSaveEIDSSPatchComponent", parameters, transaction);
            if (cmd != null)
            {
                var o = cmd.Parameters["@isCorrect"].Value;
                return (o != null && !Convert.IsDBNull(o) && Convert.ToBoolean(cmd.Parameters["@isCorrect"].Value));
            }
            return false;
        }

        public static void RegistryAllPatches(string dirUpdatePath)
        {
            //проходим по всем патчам и регистрируем их в EIDSS Admin
            //собираем доступные обновления
            AUMLog.WriteInLog("Write patches info into EIDSS Admin");
            var updates = FileHelper.CollectAndUnzipPatches(dirUpdatePath);
            string errorString;
            var totalUpdatesInfo = GetTotalUpdateInfo(Path.Combine(dirUpdatePath, FileHelper.UpdatesInfoFileName), out errorString);
            if (errorString.Length > 0)
            {
              AUMLog.WriteInLog("Can't read updates.xml. Error = {0}", errorString);
              return;
            }

            //регистрируем все total и small
          Version oldestTotalToRegister;
          if (updates.Any())
          {
            oldestTotalToRegister = RegisterPatchesFromArchives(updates);
          }
          else if (totalUpdatesInfo.Any())
          {
            // let's find last total and register just it and its smalls
            oldestTotalToRegister = RegisterPatchesFromUpdateXml(totalUpdatesInfo);
          }
          else
          {
            AUMLog.WriteInLog("There are no patches for record to EIDSS Admin");
            return;
          }

            foreach (var tui in totalUpdatesInfo)
            {
              if (tui.Version == VersionFactory.EmptyVersion || tui.Version < oldestTotalToRegister)
              {
                continue;
              }
              foreach (var ui in tui.Updates.Where(ui => ui.Alias.Length != 0).Where(ui => ui.VersionFinish != VersionFactory.EmptyVersion))
              {
                EIDSSComponents idComponent;
                if (!Enum.TryParse(ui.Alias, out idComponent))
                {
                  AUMLog.WriteInLog(
                    "Can't register patch component in EIDSS Admin. Patch = {0}. Component Program ID = {1}",
                    tui.Version,
                    ui.Alias);
                  continue;
                }
                AUMLog.WriteInLog(string.Format(
                  CultureInfo.InvariantCulture,
                  RegistryPatchProduct(tui.Version, idComponent, ui.VersionFinish)
                    ? "Patch component {1} (version {0}) successfully registered in EIDSS Admin"
                    : "Can't register patch component in EIDSS Admin. Patch = {0}. Component Program ID = {1}",
                  ui.VersionFinish,
                  ui.Alias));
              }
            }
          AUMLog.WriteInLog("Registration patches finished");
        }

      private static Version RegisterPatchesFromUpdateXml(IList<TotalUpdateInfo> totalUpdatesInfo)
      {
        Version oldestTotalToRegister = null;
        foreach (var tui in LastTotalChain(totalUpdatesInfo).Where(tui => tui.Version != null))
        {
          if (null == oldestTotalToRegister)
          {
            oldestTotalToRegister = tui.Version;
          }
          var version = tui.Version;
          var id = RegistryPatch(version, tui.IsSmall);
          LogPatchRegistration(id, tui.Version.ToString());
        }
        return oldestTotalToRegister ?? VersionFactory.EmptyVersion;
      }

      private static Version RegisterPatchesFromArchives(List<string> updates)
      {
        var oldestTotalToRegister = updates.FirstOrDefault();
        foreach (var update in updates)
        {
          var version = FileHelper.GetVersionFromArchive(update);
          var filename = Path.GetFileName(update);
          if (filename == null)
          {
            continue;
          }
          var id = RegistryPatch(version, filename.Contains("_small_"));
          LogPatchRegistration(id, filename);
        }
        return FileHelper.GetVersionFromArchive(oldestTotalToRegister);
      }

      private static IEnumerable<TotalUpdateInfo> LastTotalChain(IList<TotalUpdateInfo> totalUpdatesInfo)
      {
        var lastTotalChain = new List<TotalUpdateInfo>();
        for(var index = totalUpdatesInfo.Count - 1; 0 <= index; --index)
        {
          lastTotalChain.Add(totalUpdatesInfo[index]);
          if (!totalUpdatesInfo[index].IsSmall)
          {
            break;
          }
        }
        lastTotalChain.Reverse();
        return lastTotalChain;
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="id"></param>
      /// <param name="patchName">patch identification name - for example, filename or version</param>
      private static void LogPatchRegistration(long id, string patchName)
      {
        AUMLog.WriteInLog(string.Format(
          CultureInfo.InvariantCulture,
          id > 0
            ? "Patch {0} successfully registered in EIDSS Admin"
            : "Can't register patch in EIDSS Admin. Patch = {0}",
          patchName));
      }

      public static void SaveState(string comment = "", SqlTransaction transaction = null)
        {
            var parameters = new List<SqlParameter>
                                 {
                                     new SqlParameter("@strComputerName", SqlDbType.NVarChar, 100) {Value = Environment.MachineName},
                                     new SqlParameter("@datLastAUMState", SqlDbType.DateTime) {Value = DateTime.Now},
                                     new SqlParameter("@strComment", SqlDbType.NVarChar, 4000) {Value = comment},
                                 };
            DatabaseHelper.ExecuteStoredProc(UpdateDatabases.DbAdmin, "dbo.spAUMSaveState", parameters, transaction);
        }
    }
}
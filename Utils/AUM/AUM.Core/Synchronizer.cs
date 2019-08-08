namespace AUM.Core
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using Helper;


    public class Synchronizer
    {
        public static string TransferData(ConfigSettings settings)
        {
            return new Synchronizer(settings).TransferData();
        }


        private readonly ConfigSettings m_Settings;

        private Synchronizer(ConfigSettings settings)
        {
            if (null == settings)
            {
                throw new ArgumentNullException("settings");
            }

            m_Settings = settings;
        }

        private string TransferData()
        {
            AUMLog.WriteInLog("==========================");
            AUMLog.WriteInLog("Sync started");

            #region Синхронизация

            var regimeDescription = UpdHelper.GetRegimeCaption(Args.Sync);

            SecurityLog.WriteToEventLogWindows(
              EventLogEntryType.Information,
              "Task: {0}; Started: {1}",
              regimeDescription,
              DateTime.Now);
            string errorString;
            //result = true if updates.xml file is downloaded successfully
            var result = DownloadPatch(out errorString);

            SecurityLog.WriteToEventLogWindows(
              EventLogEntryType.Information,
              "Task: {0}; Finished: {1}; Error (exec process only): {2}",
              regimeDescription,
              DateTime.Now,
              errorString.Length > 0 ? errorString : "none");
            #endregion

            if (result)
            {
                //удаляем старые патчи
                AUMLog.WriteInLog("Delete old updates");
                FileHelper.DeleteOldUpdates(m_Settings.UpdateLocal);

                //проходим по всем патчам и регистрируем их в EIDSS Admin
                //собираем доступные обновления
                if (!MachineLevel.IsWebWks(m_Settings.Level))
                {
                    AdminHelper.RegistryAllPatches(m_Settings.UpdateLocal);
                }
            }
            AUMLog.WriteInLog("Sync finished");
            if (!string.IsNullOrEmpty(errorString))
            {
                AUMLog.WriteInLog("Error string = {0}", errorString);
            }
            return errorString;
        }

        private bool DownloadPatch(out string errorString)
        {
            var downloader = new UpdateDownloader(
              m_Settings.UpdateUrl,
              m_Settings.DownloadAttempts,
              m_Settings.DownloadAttemptWaitTime,
              m_Settings.DownloadBufferSize);
            //Do nothing if it is not possible to download udates.xml file
            if (!downloader.DownloadFileAndCompareContent(FileHelper.UpdatesInfoFileName, m_Settings.UpdateLocal))
            {
                errorString = string.Format(
                  CultureInfo.InvariantCulture,
                  "Can't download {0}. Sync regime interrupted.",
                  FileHelper.UpdatesInfoFileName);
                AUMLog.WriteInLog(errorString);
                return false;
            }
            var updates = AdminHelper.GetTotalUpdateInfo(
                Path.Combine(m_Settings.UpdateLocal, FileHelper.UpdatesInfoFileName),
                out errorString);

            //будем качать файлы от последнего тотала и выше
            var totalInfo = -1;
            for (var index = updates.Count - 1; index >= 0; index--)
            {
                if (!updates[index].IsSmall)
                {
                    totalInfo = index;
                    break;
                }
            }

            if (totalInfo == -1)
            {
                errorString = "there are no records";
            }

            if (errorString.Length > 0)
            {
                AUMLog.WriteInLog("Error while read {0}: {1}", FileHelper.UpdatesInfoFileName, errorString);
            }
            else
            {
                //формируем перечень файлов, которые будем загружать с сервера
                //1. файлы, которых нет на клиенте
                //2. файлы, CRC которых не совпадает с той, что на сервере (на сервере были обновлены)

                var updList = new List<TotalUpdateInfo>();
                for (var index = totalInfo; index < updates.Count; index++)
                {
                    updList.Add(updates[index]);
                }

                foreach (var tui in updList)
                {
                    if (tui.Version == null || tui.Version == VersionFactory.EmptyVersion)
                    {
                        continue;
                    }

                    var updateFile = string.Format("update_{0}_{1}.zip", tui.IsSmall ? "small" : "total", tui.Version);
                    var fullfn = Path.Combine(m_Settings.UpdateLocal, updateFile);
                    if (!IsDownloadRequired(fullfn, tui) || downloader.DownloadFile(updateFile, m_Settings.UpdateLocal))
                    {
                        continue;
                    }
                    AUMLog.WriteInLog("Can't download {0}", updateFile);
                    //delete local file. It will be downloaded next time
                    FileHelper.DeleteFile(Path.Combine(m_Settings.UpdateLocal, updateFile));
                }
            }
            return true;
        }

        private static bool IsDownloadRequired(string filePath, TotalUpdateInfo totalUpdateInfo)
        {
            return !File.Exists(filePath) || FileHelper.CaclulateCRC(filePath) != totalUpdateInfo.CRC;
        }
    }
}
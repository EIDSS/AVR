using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using ICSharpCode.SharpZipLib.Zip;
using Microsoft.SqlServer.Management.Smo;

namespace AUM.Core.Helper
{
    public static class BackupHelper
    {
        static BackupHelper ()
        {
            //TODO правильно ли это?
            if (ZipConstants.DefaultCodePage == 1)
                ZipConstants.DefaultCodePage = Thread.CurrentThread.CurrentCulture.TextInfo.OEMCodePage;
        }

        /// <summary>
        /// Производит бэкап базы данных
        /// </summary>
        /// <param name="server"></param>
        /// <param name="filename">Полный путь к файлу бэкапа</param>
        /// <param name="mainDatabaseSMO"></param>
        public static void BackupDatabase(Server server, Database mainDatabaseSMO, string filename)
        {
            var backup = new Backup {Action = BackupActionType.Database};
            var now = DateTime.Now;
            backup.BackupSetDescription = string.Format("Full backup of '{0}'; created by AUM at '{1}'", mainDatabaseSMO.Name, now);
            backup.BackupSetName = string.Format("AUM-{0}-{1}", mainDatabaseSMO.Name, now);
            backup.Database = mainDatabaseSMO.Name;
            backup.Devices.AddDevice(filename, DeviceType.File);
            backup.Incremental = false;
            backup.SqlBackup(server);
            //архивируем бэкап
            var fZip = UpdHelper.CreateZipper();
            var dirName = Path.GetDirectoryName(filename);
            if (dirName != null)
            {
                var zipFilename = Path.Combine(dirName, string.Format("{0}.zip", Path.GetFileNameWithoutExtension(filename)));
                FileHelper.DeleteFile(zipFilename);
                fZip.CreateZip(zipFilename, dirName, false, UpdHelper.BakFilename, string.Empty);
                FileHelper.DeleteFile(filename);
            }
        }

        /// <summary>
        /// Выполняет архивацию каталогов
        /// </summary>
        /// <param name="copyDirsList">Перечень каталогов, подлежащих архивации</param>
        /// <param name="rootFolder">Каталог, где лежит eidss.main.exe</param>
        /// <param name="tempDir">Временный каталог, куда надо поместить заархивированные каталоги</param>
        public static void BackupDirs(List<CopyDirData> copyDirsList, string rootFolder, string tempDir)
        {
            foreach (var dir in copyDirsList)
            {
                var destinationDir = FileHelper.GetDestinationPath(dir.DestinationDir);

                //собираем каталоги верхнего уровня за исключением Updates и Backups, которые будем использовать как фильтр
                var filterDirs = new List<string>();
                var directoryInfo = new DirectoryInfo(rootFolder);
                foreach (var di in directoryInfo.GetDirectories())
                {
                    if ((!di.Name.Equals(FileHelper.AUMUpdateDirName) && !di.Name.Equals(FileHelper.BackupsDirName)))
                    {
                        filterDirs.Add(di.Name);
                    }
                }

                var filterStr = FileHelper.GetFilterString(filterDirs);
                var fZip = UpdHelper.CreateZipper();
                fZip.CreateZip(string.Format("{0}.zip", Path.Combine(tempDir, dir.SourceDir))
                                , destinationDir
                                , true, filterStr);
            }
        }

        /// <summary>
        /// Создание резервных копий конфиг-файлов
        /// </summary>
        /// <param name="configFilesList">Перечень конфигов для хранения</param>
        /// <param name="tempDir">Временный каталог</param>
        public static void BackupConfigs(List<ChangeConfigData> configFilesList, string tempDir)
        {
            foreach (var cfg in configFilesList)
            {
                var destination = FileHelper.GetDestinationPath(cfg.FileName);
                if (!File.Exists(destination)) continue;
                //переименовываем
                File.Copy(destination, Path.ChangeExtension(destination, "configold"), true);
                //сбрасываем копию каждого такого файла в темповый каталог
                File.Copy(destination, Path.Combine(tempDir, cfg.FileName), true);
            }
        }

        /// <summary>
        /// Копирует корневой каталог в архив с учётом неприкасаемых каталогов
        /// </summary>
        /// <param name="rootFolder">Какой каталог нужно скопировать</param>
        /// <param name="tempDir">Куда нужно положить архив с этим каталогом</param>
        /// <param name="filename">Имя файла бэкапа</param>
        public static string BackupRootDir(string rootFolder, string tempDir, string filename)
        {
            var destinationDir = FileHelper.GetDestinationPath(rootFolder);

            //фильтр по каталогам
            var filterDirs = new List<string>();
            var directoryInfo = new DirectoryInfo(rootFolder);
            foreach (var di in directoryInfo.GetDirectories())
            {
                if ((!di.Name.Equals(FileHelper.AUMUpdateDirName) && !di.Name.Equals(FileHelper.BackupsDirName) && !di.Name.Equals(FileHelper.AUMLogDirName)))
                {
                    filterDirs.Add(di.Name);
                }
            }

            var backupFileName = Path.Combine(tempDir, filename);
            FileHelper.DeleteFile(backupFileName);
            var fZip = UpdHelper.CreateZipper();
            fZip.CreateZip(backupFileName
                            , destinationDir
                            , true, null, FileHelper.GetFilterString(filterDirs));
            return backupFileName;
        }

        /// <summary>
        /// Производит генерацию скриптов по programmability БД в указанный каталог
        /// </summary>
        /// <param name="server"></param>
        /// <param name="database"></param>
        /// <param name="appDir">Каталог, откуда запускается AUM</param>
        /// <param name="outputDir">Каталог, куда выгружать файлы скриптов</param>
        public static void BackupDBIntoScripts(Server server, Database database, string appDir, string outputDir)
        {
            if (!Directory.Exists(outputDir)) Directory.CreateDirectory(outputDir);

            string loginSqlAdmin;
            string passwordSqlAdmin;
            UpdHelper.GetSqlAdminSettings(string.Empty, string.Empty, out loginSqlAdmin, out passwordSqlAdmin);

            //выполняем последовательно три скрипта для выгрузки в три других скрипта));
            for (var i = 1; i <= 3; i++)
            {
                var args = string.Format("-S {0} -d {1} -U {2} -P {3} -i \"{4}\" -o \"{5}\" -y 0"
                                            , server.Name
                                            , database.Name
                                            , loginSqlAdmin
                                            , passwordSqlAdmin
                                            , Path.Combine(appDir, string.Format("InputScript_{0}.sql", i))
                                            , Path.Combine(outputDir, string.Format("OutputScript_{0}.sql", i))
                    );

                //если хоть один из скриптов не выполнился, то выходим
              if (UpdHelper.RunProcess("sqlcmd", args, true, false).Length > 0)
              {
                break;
              }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="database"></param>
        /// <param name="scriptsBackupPath"></param>
        public static string RestoreDB(Database database, string scriptsBackupPath)
        {
            var errorMessage = string.Empty;

            if (!Directory.Exists(scriptsBackupPath)) return errorMessage;
            //попробуем восстановить programmability из скриптов
            var scripts = Directory.GetFiles(scriptsBackupPath, "*.sql");
            try
            {
                foreach (var scriptFilename in scripts)
                {
                    using (var sr = (new FileInfo(Path.Combine(scriptsBackupPath, scriptFilename)).OpenText()))
                    {
                        database.ExecuteNonQuery(sr.ReadToEnd());
                    }
                }
            }
            catch (Exception exc)
            {
                errorMessage = UpdHelper.GetErrorMessage(exc);
            }

            return errorMessage;
        }

        /// <summary>
        /// Производит бэкап главного конфига bvupdater.config
        /// </summary>
        public static void BackupMainConfig(string appPath)
        {
            try
            {
                var filepath = Path.Combine(appPath, FileHelper.BVUpdaterConfigFileName);
                if (!File.Exists(filepath)) return;
                var files = Directory.GetFiles(appPath, "bvupdater*.config");
                var count = files.Length;
                var newFilename = Path.Combine(appPath, string.Format("bvupdater{0}.config", count));
                while (File.Exists(newFilename))
                {
                    count++;
                    newFilename = Path.Combine(appPath, string.Format("bvupdater{0}.config", count));
                }

                FileHelper.RemoveReadonlyAttribute(filepath);
                File.Copy(filepath, newFilename, true);
            }
            catch (Exception exc)
            {
              SecurityLog.WriteToEventLogWindows(EventLogEntryType.Warning, exc.Message);
            }
        }

        /// <summary>
        /// Бэкап служебного лога aum.log
        /// </summary>
        /// <param name="appPath"></param>
        public static void BackupAumLog(string appPath)
        {
            try
            {
                AUMLog.WriteInLog("=== backup aum.log===");
                var logFileName = Path.Combine(appPath, AUMLog.AUMLogFileName);
                AUMLog.WriteInLog("Try to find {0}", logFileName);
                if (!File.Exists(logFileName))
                {
                    AUMLog.WriteInLog("File is not found. Exit backup operation.");
                    return;
                }
                AUMLog.WriteInLog("Success");
                var backupDir = Path.Combine(appPath, "AUMlogBackup");
                if (!Directory.Exists(backupDir))
                {
                    AUMLog.WriteInLog("Try to create dir {0}", backupDir);
                    Directory.CreateDirectory(backupDir);
                    AUMLog.WriteInLog("Success");
                }
                //если прошло больше 1 месяца с даты создания файла, то надо его забэкапить, оригинал удалить
                var dateCreation = File.GetCreationTime(logFileName);
                var dtNow = DateTime.Now;
                if ((dtNow - dateCreation).TotalDays > 31)
                {
                    //делаем архив в указанный каталог
                    var fZip = UpdHelper.CreateZipper();
                    var zipFileName = string.Format("aumlog_{0}_{1}_{2}.zip", dtNow.Month, dtNow.Year, dtNow.Ticks);
                    var zipFullPath = Path.Combine(backupDir, zipFileName);
                    AUMLog.WriteInLog("Try to zip backup {0}", zipFullPath);
                    fZip.CreateZip(zipFullPath, appPath, false, "aum.log");
                    AUMLog.WriteInLog("Success");
                    //удаляем лог
                    AUMLog.WriteInLog("Try to delete current aum.log");
                    if (!FileHelper.DeleteFile(logFileName))
                    {
                        AUMLog.WriteInLog("Can't delete current aum.log");
                    }
                    else
                    {
                        //создадим файл-пустышку, чтобы избавиться от проблемы create date
                        File.Create(logFileName).Dispose();
                        File.SetCreationTime(logFileName, DateTime.Now);
                    }
                    AUMLog.WriteInLog("Backup aum.log completed successful. Old log file into: {0}.", zipFullPath);
                }
                else
                {
                    AUMLog.WriteInLog("Backup is not required.");
                }
            }
            catch (Exception exc)
            {
                var errorString = string.Format("Can't backup aum.log. Error = {0}", exc.Message);
                SecurityLog.WriteToEventLogWindows(EventLogEntryType.Warning, errorString);
            }
        }
    }
}

namespace AUM.Core.Helper
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Windows.Forms;
    using System.Xml;
    using ICSharpCode.SharpZipLib.Checksums;
    using ICSharpCode.SharpZipLib.Core;
    using ICSharpCode.SharpZipLib.Zip;


    /// <summary>
    /// 
    /// </summary>
    public class FileInfoComparer : IComparer<FileInfo>
    {
        #region IComparer<FileInfo> Members

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename1"></param>
        /// <param name="filename2"></param>
        /// <returns></returns>
        public int Compare(FileInfo filename1, FileInfo filename2)
        {
            var result = 0;
            if (filename1.Exists && filename2.Exists)
            {
                result = filename1.LastWriteTimeUtc.CompareTo(filename2.LastWriteTimeUtc);
            }
            return result;
        }

        #endregion
    }

    /// <summary>
    /// Сравнение доступного места на логических дисках (по убыванию свободного места)
    /// </summary>
    public class DriveInfoComparer : IComparer<DriveInfo>
    {
        #region IComparer<DriveInfo> Members

        public int Compare(DriveInfo x, DriveInfo y)
        {
            var xSpace = x.IsReady ? x.AvailableFreeSpace : 0;
            var ySpace = y.IsReady ? y.AvailableFreeSpace : 0;
            return ySpace > xSpace ? 1 : -1;
        }

        #endregion
    }


    /// <summary>
    /// Помощник при работе с файлами
    /// </summary>
    public static class FileHelper
    {
        #region Delegates

        public delegate void CopyFilesHandler(string fileFrom, string fileTo);

        #endregion

        /// <summary>
        /// Имя программы, составленной для выполнения апдейта
        /// </summary>
        public const string FileNameUpdate = "run.upd";

        /// <summary>
        /// Имя файла для резервной копии БД
        /// </summary>
        public const string FileNameBackupDb = "backupdb.bak";

        public const string UpLevelMark = @"..\";
        public const string AUMUpdateDirName = "aumupdate";
        public const string AUMLogDirName = "aumlog";

        public const string BackupsDirName = "backups";
      public const string AUMTempDirName = "temp";
        public const string UpdatesInfoFileName = "updates.xml";

        public const string BVUpdaterConfigFileName = "bvupdater.config";

      public static DriveInfo GetMostFreeLogicalDrive(this List<DriveInfo> drives)
        {
            var drs =
                drives.Where(
                    d => ((d.DriveType == DriveType.Fixed) || (d.DriveType == DriveType.Removable)) && d.IsReady)
                      .ToList();
            DriveInfo result = null;
            if (drs.Count > 0)
            {
                var freeSize = drs[0].AvailableFreeSpace;
                result = drs[0];
                for (var i = 1; i < drs.Count; i++)
                {
                    if (drs[i].AvailableFreeSpace > freeSize)
                    {
                        freeSize = drs[i].AvailableFreeSpace;
                        result = drs[i];
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static string GetFileFromXRegimeLogName(string filename)
        {
            return Path.ChangeExtension(filename, "log");
        }

        public static string GetLogFileName(string programName, string patchSuffix)
        {
            return GetLogFileName(programName, Environment.MachineName, patchSuffix);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="version"></param>
        /// <param name="isSmall"> </param>
        /// <returns></returns>
        public static string GetTotalUpdateFileName(string version, bool isSmall)
        {
            return String.Format("update_{0}_{1}.zip", isSmall ? "small" : "total", version);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="programID"> </param>
        /// <param name="version"></param>
        /// <returns></returns>
        public static string GetUpdateFileName(string programID, string version)
        {
            return String.Format("update_{0}_{1}.zip", programID, version);
        }

        public static string GetLogFileName(string programName, string computerName, string patchSuffix)
        {
            return string.Format(
              CultureInfo.InvariantCulture,
              "update_{0}_{1}_{2}.log",
              programName,
              computerName,
              patchSuffix);
        }

        /// <summary>
        /// Возвращает строку с именами файлов
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        public static string GetFilesFilter(List<FileInfo> files)
        {
            var stringBuilder = new StringBuilder();
            for (var i = 0; i < files.Count; i++)
            {
                stringBuilder.Append(files[i].Name);
                if (i < files.Count - 1) stringBuilder.Append(";");
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static double GetDiskFreeSpace(string disk)
        {
            double result = 0;

            var driveInfos = DriveInfo.GetDrives();
            foreach (var driveInfo in driveInfos)
            {
                if (!driveInfo.Name.ToUpperInvariant().Contains(disk.ToUpperInvariant())) continue;
                result = driveInfo.AvailableFreeSpace;
                break;
            }

            return result;
        }

        /// <summary>
        /// Отыскивает файлы по маске в указанном каталоге и всех его каталогах потомках
        /// </summary>
        /// <param name="rootDirectory"></param>
        /// <param name="resursive"></param>
        /// <returns></returns>
        public static DateTime? GetMostNewestFile(string rootDirectory, bool resursive)
        {
            DateTime? result = null;
            var files = GetFiles(rootDirectory, "*.*", resursive, false);
            if (files.Count > 0)
            {
                var fc = new FileInfoComparer();
                files.Sort(fc);
                result = files[files.Count - 1].LastWriteTimeUtc;
            }

            return result;
        }

        /// <summary>
        /// Отыскивает файлы по маске в указанном каталоге и всех его каталогах потомках
        /// </summary>
        /// <param name="rootDirectory"></param>
        /// <param name="searchMask"></param>
        /// <param name="resursive"></param>
        /// <returns></returns>
        public static List<FileInfo> GetFiles(string rootDirectory, string searchMask, bool resursive)
        {
            return GetFiles(rootDirectory, searchMask, resursive, true);
        }

        /// <summary>
        /// Отыскивает файлы по маске в указанном каталоге и всех его каталогах потомках
        /// </summary>
        /// <param name="rootDirectory"></param>
        /// <param name="searchMask"></param>
        /// <param name="resursive"></param>
        /// <param name="onlyFirstLevelDeep">true -- ищет только на один уровень вниз, false -- на все уровни</param>
        /// <returns></returns>
        public static List<FileInfo> GetFiles
            (string rootDirectory, string searchMask, bool resursive, bool onlyFirstLevelDeep)
        {
            var result = new List<FileInfo>();
            if (!Directory.Exists(rootDirectory)) return result;

            try
            {
                var directoryInfo = new DirectoryInfo(rootDirectory);
                var directoryInfos = directoryInfo.GetDirectories();
                if (resursive)
                {
                    foreach (var dir in directoryInfos)
                    {
                        var innerFiles = GetFiles(dir.FullName, searchMask, !onlyFirstLevelDeep, onlyFirstLevelDeep);
                        result.AddRange(innerFiles);
                    }
                    result.AddRange(directoryInfo.GetFiles(searchMask));
                }
                else
                {
                    result.AddRange(directoryInfo.GetFiles(searchMask));
                }
            }
                // ReSharper disable EmptyGeneralCatchClause
            catch
                // ReSharper restore EmptyGeneralCatchClause
            {
            }

            return result;
        }

        /// <summary>
        /// Даёт возможность выбрать директорию
        /// </summary>
        /// <param name="browserDialog"></param>
        /// <param name="textBox"></param>
        public static void BrowseDialog(FolderBrowserDialog browserDialog, TextBox textBox)
        {
            browserDialog.SelectedPath = textBox.Text;
            if ((browserDialog.ShowDialog() != DialogResult.OK) && (browserDialog.SelectedPath.Length == 0)) return;
            textBox.Text = browserDialog.SelectedPath;
            if (!textBox.Text[textBox.Text.Length - 1].Equals("\\")) textBox.Text += "\\";
        }

        /// <summary>
        /// Отыскивает и возвращает информацию о eidss.main.exe
        /// </summary>
        /// <returns></returns>
        private static FileInfo GetEIDSSExe(string rootFolder)
        {
            var eidssexe = GetFiles(rootFolder, UpdHelper.EIDSSFileName, true);
            return eidssexe.Count == 1 ? eidssexe[0] : null;
        }

        /// <summary>
        /// Отыскивает и возвращает информацию о NS
        /// </summary>
        /// <returns></returns>
        private static FileInfo GetNSexe(string rootFolder)
        {
            var result = GetFiles(rootFolder, UpdHelper.NSFileName, false);
            return result.Count == 1 ? result[0] : null;
        }

        private static FileInfo GetAvrServiceExe(string rootFolder)
        {
            var result = GetFiles(rootFolder, UpdHelper.AVRServiceFileName, false);
            return result.Count == 1 ? result[0] : null;
        }

        /// <summary>
        /// Отыскивает и возвращает информацию о AUM
        /// </summary>
        /// <returns></returns>
        public static FileInfo GetAUMExe(string rootFolder)
        {
            var result = GetFiles(rootFolder, UpdHelper.AUMFileName, true);
            return result.Count == 1 ? result[0] : null;
        }

        /// <summary>
        /// Получает версию файла eidss.main.exe
        /// </summary>
        /// <param name="rootFolder"></param>
        /// <returns></returns>
        public static Version GetEIDSSVersion(string rootFolder)
        {
            Version version = null;
            var eidssexe = GetEIDSSExe(rootFolder);
            if (eidssexe != null)
            {
                version = VersionFactory.NewVersion(FileVersionInfo.GetVersionInfo(eidssexe.FullName).FileVersion);
            }

            return version;
        }

        /// <summary>
        /// Получает версию файла notification server
        /// </summary>
        /// <param name="rootFolder"></param>
        /// <returns></returns>
        public static Version GetNSVersion(string rootFolder)
        {
            Version version = null;
            var exe = GetNSexe(rootFolder);
            if (exe != null)
            {
              version = VersionFactory.NewVersion(FileVersionInfo.GetVersionInfo(exe.FullName).FileVersion);
            }

            return version;
        }

        public static Version GetAvrServiceVersion(string rootFolder)
        {
            Version version = null;
            var exe = GetAvrServiceExe(rootFolder);
            if (exe != null)
            {
              version = VersionFactory.NewVersion(FileVersionInfo.GetVersionInfo(exe.FullName).FileVersion);
            }

            return version;
        }

        /// <summary>
        /// Получает версию файла AUM
        /// </summary>
        /// <param name="rootFolder"></param>
        /// <returns></returns>
        public static Version GetAUMVersion(string rootFolder)
        {
            //для АУМ проверяем версии всех его компонент
            //они все должны быть одной версии. Если есть какой-то необновлённый компонент, то его версия меньше
            //её возвращаем, чтобы обновление прошло по-новой
            var list = new List<string>
                {
                    "AUM.Core60.dll",
                    UpdHelper.AUMFileName,
                    UpdHelper.AUMAdministratorFileName,
                    UpdHelper.AUMServiceFileName
                };
            var version = new Version(100, 0, 0, 0);
            foreach (var file in list)
            {
                var result = GetFiles(rootFolder, file, true);
                var fileInfo = result.Count == 1 ? result[0] : null;
                //если кто-то не найден, это спросим, не ошибка ли это
                if (fileInfo == null)
                {
                    if (MessageBox.Show(string.Format(CultureInfo.InvariantCulture, "File {0} not found. Proceed?", file), "File",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                    {
                        AUMLog.WriteInLog("Error: file '{0}' not found in '{1}'", file, rootFolder);
                        version = VersionFactory.EmptyVersion;
                        break;
                    }
                }
                else
                {
                  var fileVersion = VersionFactory.NewVersion(FileVersionInfo.GetVersionInfo(fileInfo.FullName).FileVersion);
                    AUMLog.WriteInLog("File '{0}' have Version '{1}'", file, fileVersion);
                    if (fileVersion < version) version = fileVersion;
                }
            }
            return version;
        }

        /// <summary>
        /// удаляем файл run.upd, если таковой попал в каталог (он единственный служебный файл)
        /// </summary>
        /// <param name="dir"></param>
        public static void DeleteRunUpd(string dir)
        {
            var runund = Path.Combine(dir, FileNameUpdate);
            if (File.Exists(runund)) DeleteFile(runund);
        }

        /// <summary>
        /// Вычисляет контрольную сумму для файла
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static long CaclulateCRC(string filename)
        {
            var crc = new Crc32 {Value = 0};
            using (var fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                var buffer = new byte[fileStream.Length];
                fileStream.Read(buffer, 0, buffer.Length);
                fileStream.Close();
                crc.Reset();
                crc.Update(buffer);
            }
            return crc.Value;
        }

        /// <summary>
        /// Проверяет, имеет ли указанный файл заданную контрольную сумму
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="crc"></param>
        /// <returns></returns>
        public static bool CompareCRC(string filename, long crc)
        {
            return (CaclulateCRC(filename) == crc);
        }

        public static void DeleteFiles(List<FileInfo> files)
        {
            foreach (var file in files)
            {
                DeleteFile(file.FullName);
            }
        }

        public static bool DeleteFile(string file)
        {
            var result = false;
            try
            {
                if (File.Exists(file))
                {
                    RemoveReadonlyAttribute(file);
                    File.Delete(file);
                }
                result = true;
            }
            catch (Exception exc)
            {
                AUMLog.WriteInLog("Can't delete file '{0}'. Error: {1}.", file, exc.Message);
                SecurityLog.WriteToEventLogWindows(
                  EventLogEntryType.Error,
                  "Message='{0}'\r\n\r\nStackTrace='{1}'", exc.Message, exc.StackTrace);
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        public static void RemoveReadonlyAttribute(string file)
        {
            var aFile = new FileInfo(file);
            if (!aFile.Exists) return;
            aFile.Attributes = aFile.Attributes = aFile.Attributes & ~FileAttributes.ReadOnly; // убрать атрибут
        }

        /// <summary>
        /// Вычисляет имя сопроводительного файла с контрольной суммой, исходя из имени файла пакета апдейта
        /// </summary>
        /// <param name="updatePackageName"></param>
        /// <returns></returns>
        public static string GetCRCFilename(string updatePackageName)
        {
            var fileInfo = new FileInfo(updatePackageName);
            if (fileInfo.DirectoryName == null) return String.Empty;
            return fileInfo.Length == 0
                       ? String.Empty
                       : String.Format("{0}.crc",
                                       Path.Combine(fileInfo.DirectoryName,
                                                    Path.GetFileNameWithoutExtension(fileInfo.Name) ?? String.Empty));
        }

        /// <summary>
        /// Возвращает полный путь к каталогу, который находится выше относительно BaseDir
        /// </summary>
        /// <param name="baseDir"></param>
        /// <param name="upLevelDir"></param>
        /// <returns></returns>
        public static string GetPath(string baseDir, string upLevelDir)
        {
            //baseDir это обычно каталог запуска приложения
            //а это относительный путь upLevelDir = ..\..\..\Data\
            //Нужно соединить каталоги правильно

            var resultPath = new StringBuilder();
            var currentStr = upLevelDir;
            var pathElements = baseDir.Split(new[] {@"\"}, StringSplitOptions.RemoveEmptyEntries);

            var index = 0;
            var cnt = 1;
            while ((index = currentStr.IndexOf(UpLevelMark, index)) >= 0)
            {
                currentStr = currentStr.Substring(index + UpLevelMark.Length);
                if (resultPath.Length > 0) resultPath.Remove(0, resultPath.Length - 1);
                for (var i = 0; i < pathElements.Length - cnt; i++) //??? нужно ли -1 к длине
                {
                    resultPath.Append(pathElements[i]);
                    resultPath.Append(@"\");
                }
                resultPath.Append(currentStr);
                resultPath.Append(@"\");
                cnt++;
            }

            return resultPath.ToString();
        }

        /// <summary>
        /// Событие срабатывает, когда копируются файлы
        /// </summary>
        public static event CopyFilesHandler OnCopyFiles;

        /// <summary>
        /// Копирование каталогов вместе с подкаталогами
        /// </summary>
        /// <param name="sorcePath"></param>
        /// <param name="destRoot"></param>
        public static string CopyDirs(string sorcePath, string destRoot)
        {
            var sb = new StringBuilder();
            foreach (var dir in Directory.GetDirectories(sorcePath, "*.*", SearchOption.AllDirectories))
            {
                var destSubDir = Path.Combine(destRoot, Path.GetFileName(dir) ?? String.Empty);
                if (!Directory.Exists(destSubDir)) Directory.CreateDirectory(destSubDir);
                var errorString = CopyDirs(dir, destSubDir);
                if (errorString.Length > 0) sb.AppendLine(errorString);
            }
            var es = CopyFiles(sorcePath, destRoot);
            if (es.Length > 0) sb.AppendLine(es);
            return sb.ToString();
        }

        /// <summary>
        /// Копирует файл из одного каталога в другой
        /// </summary>
        /// <param name="sorcePath"></param>
        /// <param name="destPath"></param>
        public static bool CopyFile(string sorcePath, string destPath)
        {
            var result = false;
            //снимаем readonly у файла, на который производим копирование
            try
            {
                var fileInfo = new FileInfo(destPath);
                if (fileInfo.Exists) fileInfo.IsReadOnly = false;
                File.Copy(sorcePath, destPath, true);
                result = true;
            }
            catch (Exception exc)
            {
                AUMLog.WriteInLog("Can't copy file '{0}'. Error: {1}", sorcePath, exc.Message);
            }
            if (OnCopyFiles != null) OnCopyFiles(sorcePath, destPath);
            return result;
        }

        /// <summary>
        /// Копирует все файлы из одного каталога в другой
        /// </summary>
        /// <param name="sorceDir"></param>
        /// <param name="destRoot"></param>
        public static string CopyFiles(string sorceDir, string destRoot)
        {
            var sb = new StringBuilder();

            foreach (var filePath in Directory.GetFiles(sorceDir))
            {
                var fileName = Path.GetFileName(filePath);
                var destPath = Path.Combine(destRoot, fileName ?? String.Empty);
                //снимаем readonly у файла, на который производим копирование
                try
                {
                    var fileInfo = new FileInfo(destPath);
                    if (fileInfo.Exists) fileInfo.IsReadOnly = false;
                    File.Copy(filePath, destPath, true);
                }
                catch (Exception exc)
                {
                    AUMLog.WriteInLog("Can't copy file '{0}'. Error: {1}", filePath, exc.Message);
                    sb.AppendLine(exc.Message);
                }
                if (OnCopyFiles != null) OnCopyFiles(filePath, destPath);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Создание имени файла бэкапа по шаблону
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        public static string GetBackupFilename(string version)
        {
            return String.Format("backup{0}.update", version);
        }

        /// <summary>
        /// Удаление каталога вместе с подкаталогами и файлами
        /// </summary>
        /// <param name="path"></param>
        /// <param name="needDeletePathDir"></param>
        public static void DeleteDir(string path, bool needDeletePathDir)
        {
            try
            {
                if (!Directory.Exists(path)) return;
                foreach (var filePath in Directory.GetFiles(path))
                {
                    DeleteFile(filePath);
                }

                foreach (var dir in Directory.GetDirectories(path, "*.*", SearchOption.AllDirectories))
                {
                    var directoryInfo = new DirectoryInfo(dir);
                    if (!directoryInfo.Exists) continue;
                    if ((directoryInfo.GetFiles().Length > 0) || (directoryInfo.GetDirectories().Length > 0))
                    {
                        DeleteDir(dir, true);
                    }
                    else
                    {
                        Directory.Delete(dir);
                    }
                }

                if (needDeletePathDir) Directory.Delete(path);
            }
            catch (Exception exc)
            {
                AUMLog.WriteInLog("Can't delete directory '{0}'. Error: {1}.", path, exc.Message);
            }
        }

        /// <summary>
        /// Получает аргумент командной строки
        /// </summary>
        /// <param name="args"></param>
        /// <param name="argName"></param>
        /// <returns></returns>
        public static string GetCommandLineArgument(string[] args, string argName)
        {
            var result = String.Empty;
            foreach (var s in args)
            {
                var arg = s.ToLowerInvariant();
                if (arg.Substring(0, 2).Contains(argName))
                {
                    result = arg.Substring(2);
                }
            }
            return result;
        }

        /// <summary>
        /// Восстанавливает архив в корневой каталог
        /// </summary>
        /// <param name="rootFolder">В какой каталог надо развернуть</param>
        /// <param name="backupFileName">Полный путь к файлу бэкапа</param>
        public static void RestoreRootDir(string rootFolder, string backupFileName)
        {
            var fastZipEvents = new FastZipEvents {FileFailure = OnFileFailture, DirectoryFailure = OnDirectoryFailure};
            var fastZip = new FastZip(fastZipEvents);
            fastZip.ExtractZip(backupFileName, rootFolder, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void OnDirectoryFailure(object sender, ScanFailureEventArgs e)
        {
            e.ContinueRunning = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void OnFileFailture(object sender, ScanFailureEventArgs e)
        {
            e.ContinueRunning = true;
        }

        /// <summary>
        /// Возвращает путь к файлу с учётом каталогов разного уровня залегания
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetDestinationPath(string path)
        {
            return path.Contains(UpLevelMark)
                       ? GetPath(Application.StartupPath, path)
                       : Path.Combine(Application.StartupPath, path);
        }

        /// <summary>
        /// Проверяет, запущен ли процесс
        /// </summary>
        /// <param name="processName"></param>
        /// <returns></returns>
        public static bool IsProcessExists(string processName)
        {
            return Process.GetProcessesByName(Path.GetFileNameWithoutExtension(processName)).Length > 0;
        }

        /// <summary>
        /// Останавливает процесс
        /// </summary>
        /// <param name="processName">Дружественное имя процесса (без расширения)</param>
        /// <param name="errorMessage">Текст ошибки, если она случится</param>
        /// <param name="filename">полный путь к файлу, откуда был запущен процесс</param>
        /// <returns>true-процесс был успешно остановлен</returns>
        public static bool StopProcess(string processName, out string errorMessage, out string filename)
        {
            bool result;
            errorMessage = filename = string.Empty;

            try
            {
                var ps = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(processName));

                foreach (var p in ps)
                {
                    //если не удастся закрыть окно программы, например, если у программы нет окна, то убиваем процесс
                    //filename = p.MainModule.FileName;
                    //if (!p.CloseMainWindow()) p.Kill();
                    p.Kill();
                }

                result = true;
            }
            catch (Exception exc)
            {
                result = false;
                errorMessage = exc.Message;
            }

            if (errorMessage.Length > 0)
                SecurityLog.WriteToEventLogWindows(
                  EventLogEntryType.Error,
                  "Can't stop process. Error Message = {0}; processFileName= {1}",
                  errorMessage,
                  filename);

            return result;
        }

        /// <summary>
        /// Запускает процесс
        /// </summary>
        /// <param name="processName">Полный путь к запускаемому файлу</param>
        /// <param name="arguments"></param>
        public static void StartProcess(string processName, string arguments = "")
        {
            if (File.Exists(processName)) Process.Start(new ProcessStartInfo(processName, arguments));
        }

        /// <summary>
        /// Запись лога из программ, запускаемых в X-режиме
        /// </summary>
        /// <param name="filename"> </param>
        /// <param name="success"></param>
        /// <param name="logData"></param>
        /// <param name="appPath"> </param>
        public static void WriteLogFileForExecuteApp
            (string appPath, string filename, bool success, List<string> logData)
        {
            var logFile = GetFileFromXRegimeLogName(filename);
            DeleteFile(logFile);
            using (var sw = new StreamWriter(Path.Combine(appPath, logFile)))
            {
                sw.WriteLine(success.ToString());
                foreach (var logstr in logData)
                {
                    sw.WriteLine(logstr);
                }
            }
        }

        /// <summary>
        /// Пишет лог-файл в хранилище логов
        /// </summary>
        /// <param name="rootDir"></param>
        /// <param name="success"></param>
        /// <param name="logData"></param>
        /// <param name="patchSuffix"></param>
        /// <param name="programName"></param>
        /// <param name="level">Уровень машины (1-4) </param>
        /// <param name="errorMessage"></param>
        public static string WriteLogFile(
          string rootDir,
          bool success,
          string logData,
          string patchSuffix,
          string programName,
          MachineLevel.Level level,
          string errorMessage)
        {
            var updatesLogPath = Path.Combine(rootDir, AUMLogDirName);
            //логи будем сохранять в подкаталог с именем компьютера
            updatesLogPath = Path.Combine(updatesLogPath, Environment.MachineName);
            if (!Directory.Exists(updatesLogPath)) Directory.CreateDirectory(updatesLogPath);
            var logFilename = Path.Combine(updatesLogPath, GetLogFileName(programName, patchSuffix));
            var textWriter = new XmlTextWriter(logFilename, null) {Formatting = Formatting.Indented};
            textWriter.WriteStartDocument(false);
            textWriter.WriteComment(String.Format("Created at {0} by AUM", DateTime.Now));
            textWriter.WriteStartElement("log");

            textWriter.WriteStartElement("status");
            textWriter.WriteAttributeString("success", success ? "1" : "0");
            textWriter.WriteEndElement();

            textWriter.WriteStartElement("machine");
            textWriter.WriteAttributeString("level", level.ToString("d"));
            textWriter.WriteEndElement();

            if (!success)
            {
                textWriter.WriteStartElement("error");
                textWriter.WriteAttributeString("message", errorMessage);
                textWriter.WriteEndElement();
            }

            textWriter.WriteStartElement("datetime");
            textWriter.WriteAttributeString("datetime", DateTime.Now.ToString(CultureInfo.InvariantCulture));
            textWriter.WriteEndElement();

            textWriter.WriteStartElement("logdata");
            textWriter.WriteAttributeString("data", logData);
            textWriter.WriteEndElement();

            textWriter.WriteEndElement(); //корневой элемент
            textWriter.Close();
            return logFilename;
        }

        public static int GetLevelFromLogFile(string logFilename)
        {
            var result = 0;

            if (File.Exists(logFilename))
            {
                var successString = XmlHelper.ReadAttributeFromXML(logFilename, "machine", "level");
                if (!String.IsNullOrEmpty(successString)) Int32.TryParse(successString, out result);
            }
            return result;
        }

        public static Enums.UpdateStatus GetResultFromLogFile(string logFilename)
        {
            var result = Enums.UpdateStatus.Unknown;

            if (File.Exists(logFilename))
            {
                var successString = XmlHelper.ReadAttributeFromXML(logFilename, "status", "success");
                result = successString == "1" ? Enums.UpdateStatus.Success : Enums.UpdateStatus.Error;
            }
            return result;
        }

        public static string GetTextFromLogFile(string logFilename)
        {
            var logdata = String.Empty;
            if (File.Exists(logFilename))
            {
                logdata = XmlHelper.ReadAttributeFromXML(logFilename, "logdata", "data");
            }
            return logdata;
        }

        /// <summary>
        /// Производит полное восстановление базы данных
        /// </summary>
        /// <param name="connection">Соединение с БД, которую нужно восстановить из бэкапа</param>
        /// <param name="databaseName">имя БД EIDSS</param>
        /// <param name="filename">Полный путь к файлу бэкапа</param>
        public static void RestoreDatabase(SqlConnection connection, string databaseName, string filename)
        {
            if (connection.State != ConnectionState.Open) connection.Open();
            var command =
                new SqlCommand(
                    String.Format(
                        "Restore Database {0} From Disk = N'{1}' WITH  FILE = 1,  KEEP_REPLICATION,  NOUNLOAD,  REPLACE,  STATS = 10",
                        databaseName, filename), connection) {CommandType = CommandType.Text};
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filterValues"></param>
        /// <returns></returns>
        public static string GetFilterString(List<string> filterValues)
        {
            var stringBuilder = new StringBuilder();
            for (var i = 0; i < filterValues.Count; i++)
            {
                stringBuilder.Append(filterValues[i]);
                if (i < filterValues.Count - 1) stringBuilder.Append(";");
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="processes"></param>
        /// <param name="sqlConnection"></param>
        public static List<string> StopProcesses(List<string> processes, SqlConnection sqlConnection)
        {
            var processesWasStoped = new List<string>();

            foreach (var processName in processes)
            {
                string errMessage;
                string processFileName;
                if (StopProcess(processName, out errMessage, out processFileName))
                {
                    if (processFileName.Length > 0) processesWasStoped.Add(processFileName);
                }
                if (errMessage.Length > 0)
                {
                    SecurityLog.WriteToEventLogDB(sqlConnection, Operations.Update, false,
                                                  String.Format("Update execute with error:{0}", errMessage),
                                                  String.Empty);
                    break;
                }
            }

            return processesWasStoped;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="processes"></param>
        public static void StartProcesses(List<string> processes)
        {
            foreach (var processFileName in processes)
            {
                StartProcess(processFileName);
            }
        }

        /// <summary>
        /// Определяет старейший из файлов
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        public static FileInfo GetLatestFile(FileInfo[] files)
        {
            FileInfo result = null;

            if (files.Length > 0)
            {
                result = files[0];

                foreach (var file in files)
                {
                    if (file.CreationTime > result.CreationTime) result = file;
                }
            }

            return result;
        }

        public static string GetExecutingPath()
        {
          var asm = Assembly.GetExecutingAssembly();
          if (asm.GetName().Name.StartsWith("nunit"))
          {
            asm = Assembly.GetCallingAssembly();
          }

          var dn = Path.GetDirectoryName(GetAssemblyLocation(asm));
          if (dn == null)
          {
            return string.Empty;
          }
          var appDir = new DirectoryInfo(dn);
          return string.Format(CultureInfo.InvariantCulture, "{0}\\", appDir.FullName);
        }

        public static Version ConvertToVersion(IEnumerable<string> versionParts)
        {
            Version v;
            if (null == versionParts || !Version.TryParse(string.Join(".", versionParts), out v))
            {
                v = VersionFactory.EmptyVersion;
            }
            return v;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="archiveFilename"></param>
        /// <returns></returns>
        public static Version GetVersionFromArchive(string archiveFilename)
        {
          var result = VersionFactory.EmptyVersion;
          var f1 = Path.GetFileNameWithoutExtension(archiveFilename);
          if (string.IsNullOrEmpty(f1))
          {
            return result;
          }
          var pos1 = f1.LastIndexOf("_", StringComparison.Ordinal);
          if (pos1 > 0)
          {
            result = VersionFactory.NewVersion(f1.Substring(pos1 + 1, f1.Length - pos1 - 1));
          }
          return result;
        }

        /// <summary>
        /// Извлекает из имени файла Program ID
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static string ExtractProgramID(string filename)
        {
            var fn = Path.GetFileNameWithoutExtension(filename);
            if (fn == null) return string.Empty;
            var lastIndex = fn.LastIndexOf("_", StringComparison.Ordinal);
            var firstIndex = "update_".Length;
            return (lastIndex > firstIndex) ? fn.Substring(firstIndex, lastIndex - firstIndex) : String.Empty;
        }

        /// <summary>
        /// Удаляет устаревшие патчи
        /// </summary>
        public static void DeleteOldUpdates(string dirUpdatePath)
        {
            //определим самый старший total-патч
            AUMLog.WriteInLog("Delete files from '{0}'", dirUpdatePath);
            var filesTotalArchive = Directory.GetFiles(dirUpdatePath, "update_total_*.zip",
                                                       SearchOption.TopDirectoryOnly);
            AUMLog.WriteInLog("Total archives found: {0}", filesTotalArchive.Length);
            Array.Sort(filesTotalArchive, new UpdatesFileNamesComparer());

            //обязательно должен быть хотя бы один total-архив
          if (!filesTotalArchive.Any())
          {
            return;
          }

            //самый поздний total
            var fileTotalUpdateArchive = filesTotalArchive[filesTotalArchive.Length - 1];
            var versionTotal = GetVersionFromArchive(fileTotalUpdateArchive);

            //проходим все файлы и удаляем те, что младше
            var files = Directory.GetFiles(dirUpdatePath, "update_*.zip", SearchOption.TopDirectoryOnly);
            for (var i = files.Length - 1; i >= 0; i--)
            {
                var file = files[i];
                var version = GetVersionFromArchive(file);
                if (version.Equals(VersionFactory.EmptyVersion)) continue;
                if (version < versionTotal)
                {
                    DeleteFile(file);
                    var fileCrc = Path.ChangeExtension(file, "crc");
                    if (File.Exists(fileCrc)) DeleteFile(fileCrc);
                }
            }
        }

      /// <summary>
      ///   Удаляет битые лог-файлы
      /// </summary>
      public static void DeleteWrongLogFiles(string dirLogPath)
      {
        AUMLog.WriteInLog("Check wrong log files");
        var logfiles = GetFiles(dirLogPath, "*.log", true);
        foreach (var file in logfiles)
        {
          try
          {
            XmlHelper.ReadAttributeFromXML(file.FullName, "status", "success");
          }
          catch (Exception exc)
          {
            AUMLog.WriteInLog("Wrong log file '{0}' was found (Error: {1})", file.FullName, exc.Message);
            DeleteFile(file.FullName);
          }
        }
      }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dirUpdatePath"></param>
        /// <returns></returns>
        public static List<string> CollectUpdates(string dirUpdatePath)
        {
            AUMLog.WriteInLog("Collect updates");
            var updatesForExecute = new List<string>();
            var fcUpdates = new UpdatesFileNamesComparer();
            AUMLog.WriteInLog("Collect total patches");
            var filesTotalArchive = Directory.GetFiles(dirUpdatePath, "update_total_*.zip",
                                                       SearchOption.TopDirectoryOnly);
            Array.Sort(filesTotalArchive, fcUpdates);

            AUMLog.WriteInLog("Collect small patches");
            var filesSmallArchive = Directory.GetFiles(dirUpdatePath, "update_small_*.zip",
                                                       SearchOption.TopDirectoryOnly);
            Array.Sort(filesSmallArchive, fcUpdates);

            //выявляем старшие архивы в каждой выборке
            var versionTotal = VersionFactory.EmptyVersion;
            var fileTotalUpdateArchive = String.Empty;
            if (filesTotalArchive.Length > 0)
            {
                //самый поздний total
                fileTotalUpdateArchive = filesTotalArchive[filesTotalArchive.Length - 1];
                versionTotal = GetVersionFromArchive(fileTotalUpdateArchive);
                AUMLog.WriteInLog("The top-Version total update Version is {0}", versionTotal);
            }

            var versionSmall = VersionFactory.EmptyVersion;
            if (filesSmallArchive.Length > 0)
            {
                //самый поздний small
                var fileSmallUpdateArchive = filesSmallArchive[filesSmallArchive.Length - 1];
                versionSmall = GetVersionFromArchive(fileSmallUpdateArchive);
                AUMLog.WriteInLog("The top-Version small update Version is {0}", versionSmall);
            }

            //если самый старший патч -- кумулятивный, то нужно исполнять только его.
            //Иначе от кумулятивного и выше.
            AUMLog.WriteInLog("Collect updates");
            if (fileTotalUpdateArchive.Length > 0) updatesForExecute.Add(fileTotalUpdateArchive);
            if (versionTotal < versionSmall)
            {
                foreach (var updateFile in filesSmallArchive)
                {
                    var version = GetVersionFromArchive(updateFile);
                    if (version.Equals(VersionFactory.EmptyVersion)) continue;
                    if (!versionTotal.Equals(VersionFactory.EmptyVersion) && (version < versionTotal)) continue;
                    updatesForExecute.Add(updateFile);
                }
            }

            AUMLog.WriteInLog("Updates for execute count = {0}", updatesForExecute.Count);
            for (var index = 0; index < updatesForExecute.Count; index++)
            {
                var update = updatesForExecute[index];
                AUMLog.WriteInLog("#{0} {1}", index, update);
            }

            return updatesForExecute;
        }

      private static string GetAssemblyLocation(Assembly asm)
      {
        const string FilePrefix = "file:///";
        return asm.CodeBase.StartsWith(FilePrefix, StringComparison.OrdinalIgnoreCase)
          ? asm.CodeBase.Substring(FilePrefix.Length).Replace("/", @"\")
          : asm.Location;
      }

        public static List<string> CollectAndUnzipPatches(string dirUpdatePath)
        {
            var updateArchives = CollectUpdates(dirUpdatePath);
            if (updateArchives.Count == 0) return updateArchives;

            //распаковываем все обновления
            foreach (var updateArchive in updateArchives)
            {
                UpdHelper.ExtractDirFromUpdate(updateArchive, dirUpdatePath, string.Empty);
            }
            return updateArchives;
        }

        public static string ConvertToUnicode(string source)
        {
            var unibyte = Encoding.Unicode.GetBytes(source);
            var sb = new StringBuilder();
            foreach (var b in unibyte)
            {
                sb.AppendFormat("{0}{1}", @"\u", b.ToString("X"));
            }
            return sb.ToString();
        }

        public static string GetPathWithoutRoot(string path)
        {
          var fullPath = Path.GetFullPath(path);
          var pathRoot = Path.GetPathRoot(fullPath);
          return !string.IsNullOrEmpty(pathRoot) ? fullPath.Remove(0, pathRoot.Length) : fullPath;
        }
    }
}
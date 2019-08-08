using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using AUM.Core.Helper;
using TaskScheduler;

namespace CreateScriptTask
{
    class Program
    {
        static void Main(string[] args)
        {
            // List of strings with execution log
            // Start logging 
            var logStrings = new List<string>
                                 {
                                     "Create the task running sql script"
                                 };
            AddInfoString(ref logStrings, "Starting...");
            bool res = false;
            try
            {

                var taskName = "";
                var scriptFileName = "";
                var beginTime = new TimeSpan(0, 0, 0);
                var duration = 0;
                var interval = 0;
                var taskType = "D";
                var weekDay = -1;
                var deleteOldTask = false;
                var shouldCreateTask = false;
                if (args.Length == 0)
                {
                    DisplayHelp();
                    AddInfoString(ref logStrings, string.Format("No parameters to create task are provided."));
                    return;
                }
                foreach (string arg in args)
                {
                    string op = arg.Substring(0, 2);
                    string value = arg.Length > 2 ? arg.Substring(2) : "";
                    switch (op)
                    {
                        case "\\t":
                            taskName = value;
                            break;
                        case "\\f":
                            scriptFileName = value;
                            break;
                        case "\\s":
                            TimeSpan.TryParse(value, out beginTime);
                            shouldCreateTask = true;
                            break;
                        case "\\d":
                            Int32.TryParse(value, out duration);
                            shouldCreateTask = true;
                            break;
                        case "\\i":
                            Int32.TryParse(value, out interval);
                            shouldCreateTask = true;
                            break;
                        case "\\w":
                            Int32.TryParse(value, out weekDay);
                            shouldCreateTask = true;
                            break;
                        case "\\m":
                            Int32.TryParse(value, out weekDay);
                            shouldCreateTask = true;
                            break;
                        case "\\r":
                            deleteOldTask = true;
                            break;
                        case "\\h":
                        case "\\?":
                            DisplayHelp();
                            break;
                    }
                }
                string serverName = RegistryHelper.ReadFromRegistry("SQLServer");
                if (string.IsNullOrEmpty(serverName))
                {
                    AddInfoString(ref logStrings, string.Format("SQL server name is not found in the registry."));
                    return;
                }
                string dbName = RegistryHelper.ReadFromRegistry("SQLDatabase");
                if (string.IsNullOrEmpty(dbName))
                {
                    AddInfoString(ref logStrings, string.Format("EIDSS database name is not found in the registry."));
                    return;
                }

                if (string.IsNullOrEmpty(scriptFileName))
                {
                    AddInfoString(ref logStrings, "script to run is not defined.");
                    return;
                }
                var newScriptFileName = string.Format("{0}_{1}{2}", Path.GetFileNameWithoutExtension(scriptFileName), dbName, Path.GetExtension(scriptFileName));
                taskName = String.IsNullOrEmpty(taskName) ? Path.GetFileNameWithoutExtension(newScriptFileName) : string.Format("{0}_{1}", taskName, dbName);
                if (Task.Exists(taskName))
                {
                    if (deleteOldTask)
                    {
                        Task.Delete(taskName);
                        AddInfoString(ref logStrings, string.Format("Old task {0} is deleted.", taskName));
                        if (!shouldCreateTask)
                        {
                            res = true;
                            return;
                        }

                    }
                    else
                    {
                        res = true;
                        AddInfoString(ref logStrings, string.Format("Task with name {0} exists already.", taskName));
                        return;
                    }
                }
                string programFilesFolder = Environment.GetFolderPath(Environment.Is64BitOperatingSystem
                                                                          ? Environment.SpecialFolder.ProgramFilesX86
                                                                          : Environment.SpecialFolder.ProgramFiles);
                string pathToScript = Path.Combine(programFilesFolder, @"Black & Veatch\Replication_StartDir_v4");
                if (!serverName.ToLowerInvariant().StartsWith(Environment.MachineName.ToLowerInvariant()))
                {
                    res = true;
                    AddInfoString(ref logStrings, string.Format("Sql server is placed on other machine. Task should not be created"));
                    return;
                }
                if (!Directory.Exists(pathToScript))
                {
                    Directory.CreateDirectory(pathToScript);
                }
                File.Copy(scriptFileName, Path.Combine(pathToScript, newScriptFileName), true);
                //File.Copy("CreateScriptTask.bat", Path.Combine(pathToScript, "CreateScriptTask.bat"), true);
                //File.Copy("CreateScriptTask.exe", Path.Combine(pathToScript, "CreateScriptTask.exe"), true);
                //File.Copy("TaskScheduler.dll", Path.Combine(pathToScript, "TaskScheduler.dll"), true);
                //File.Copy("Interop.TaskSchedulerLib.dll", Path.Combine(pathToScript, "Interop.TaskSchedulerLib.dll"), true);
                //File.Copy("AUM.Core.dll", Path.Combine(pathToScript, "AUM.Core.dll"), true);

                string startupPath = pathToScript;

                scriptFileName = Path.Combine(startupPath, newScriptFileName);
                if (!File.Exists(scriptFileName))
                {
                    AddInfoString(ref logStrings, string.Format("script {0} dosen't exist.", scriptFileName));
                    return;
                }


                if (!(taskType == "T" || taskType == "D" || taskType == "W"))
                    taskType = "D";
                if (weekDay > 0)
                    taskType = "W";
                else if (interval > 0)
                    taskType = "T";

                Task task;
                /*
                var sqlCmdPath = string.Format(@"{0}\Microsoft SQL Server\110\Tools\Binn",
                                                  Environment.GetFolderPath(
                                                      Environment.SpecialFolder.CommonProgramFiles));
                */
                var sqlParams = string.Format("-S {0} -d {1} -E -b -i \"{2}\"", serverName, dbName, scriptFileName);
                switch (taskType)
                {
                    case "D":
                        task = Task.CreateDaily(taskName, "sqlcmd.exe", sqlParams, startupPath, beginTime,
                                                       interval, duration);
                        break;
                    case "W":
                        task = Task.CreateWeekly(taskName, "sqlcmd.exe", sqlParams, startupPath, DateTime.Now, weekDay, beginTime, duration);
                        break;
                    default:
                        task = Task.Create(taskName, "sqlcmd.exe", sqlParams, startupPath, DateTime.Today.Add(beginTime), interval, duration);
                        break;
                }
                if (task != null)
                    task.Run();
                else
                    AddInfoString(ref logStrings, string.Format("Task is not created by unknow reason."));
            }

            catch (Exception ex)
            {

                // Log error
                AddErrorString(ref logStrings, GetFullError(ex));
            }
            finally
            {
                // Finish logging
                AddInfoString(ref logStrings, "Finish");

                //Create execution log
                FileHelper.WriteLogFileForExecuteApp(GetExecutableFilePath(), GetExecutableFileName(), res, logStrings);
            }
        }
        private static void DisplayHelp()
        {
            Console.Out.Write("command arguments:\r\n" +
                             "\\tTaskName - name of the task\r\n" +
                             "\\fScriptFileName - file name with script that shall be run by task\r\n" +
                             "\\sTime - time to start task\r\n" +
                             "\\dDaysCount - duration of task. If Days >0 , task will be stopeed after DaysCount days\r\n" +
                             "\\iN - interval in hours between task starts\r\n" +
                             "\\m[T:W:D] - task type, T - by time with period defined by \\i option, W - weekly, D - dayly\r\n" +
                             "\\r - remove task if it exists\r\n" +
                             "\\h \\? - show this help"
               );
        }
        #region Log Methods

        /// <summary>
        /// Adds information string to the log
        /// </summary>
        /// <param name="logStrings">List of log strings</param>
        /// <param name="infoString">String containg information to include to the log</param>
        public static void AddInfoString(ref List<string> logStrings, string infoString)
        {
            if (logStrings == null)
            {
                logStrings = new List<string>();
            }

            logStrings.Add(string.Format("Creating sql command task {0}: {1}", DateTime.Now.ToString(CultureInfo.InvariantCulture), infoString));
        }

        /// <summary>
        /// Adds error message to the log
        /// </summary>
        /// <param name="logStrings">List of log strings</param>
        /// <param name="errorMessage">String containg error message to include to the log</param>
        public static void AddErrorString(ref List<string> logStrings, string errorMessage)
        {
            if (logStrings == null)
            {
                logStrings = new List<string>();
            }

            logStrings.Add(string.Format("Creating sql command task error {0}: {1}", DateTime.Now.ToString(CultureInfo.InvariantCulture), errorMessage));
        }
        #region Useful methods

        /// <summary>
        /// Returns source string if it is not empty, otherwise returns default string.
        /// </summary>
        /// <param name="val">Source string</param>
        /// <param name="defVal">Default string</param>
        /// <returns>Returns source string if it is not empty, otherwise returns default string</returns>
        public static string IsNull
        (
            string val,
            string defVal
        )
        {
            string res = val;

            if (defVal == null)
            {
                defVal = "";
            }

            if (string.IsNullOrEmpty(val))
            {
                res = defVal;
            }
            return res;
        }

        /// <summary>
        /// Returns string with exception message including messages of all inner exceptions.
        /// </summary>
        /// <param name="exception">Application exception</param>
        /// <returns>Returns string with exception message including messages of all inner exceptions</returns>
        public static string GetFullError
        (
            Exception exception
        )
        {
            var msgError = "";

            var ex = exception;
            if (ex == null)
            {
                return (msgError);
            }

            msgError = string.Format("Exception: {0}", ex.Message);

            var i = 0;
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
                i = i + 1;
                msgError = string.Format("{0} \n {1} {2}: {3}", msgError, "Inner exception", i.ToString(CultureInfo.InvariantCulture), ex.Message);
            }

            return (msgError);
        }


        /// <summary>
        /// Returns name of application executable file 
        /// </summary>
        /// <returns>Returns name of application executable file</returns>
        public static string GetExecutableFileName()
        {
            return (Path.GetFileName(Assembly.GetEntryAssembly().Location));
        }

        /// <summary>
        /// Returns name of directory containing application executable file
        /// </summary>
        /// <returns>Returns name of directory containing application executable file</returns>
        public static string GetExecutableFilePath()
        {
            return (Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }

        /// <summary>
        /// Returns file path with application startup path in the beggining.
        /// </summary>
        /// <param name="fileName">File name</param>
        /// <returns>Returns String value containing file path with application startup path in the beggining</returns>
        public static string CombineAppStartUpPathWithFileName(string fileName)
        {
            return (Path.Combine(IsNull(GetExecutableFilePath(), String.Empty), fileName));
        }

        #endregion

        #endregion

    }
}

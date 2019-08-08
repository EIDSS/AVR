using System;
using System.Diagnostics;
using System.IO;
using AUM.Core.Helper;

namespace AUM.Core
{
  using System.Globalization;


  /// <summary>
    /// Собственный (технический) лог AUM
    /// </summary>
    public static class AUMLog
    {
        private static string AUMLogDirPath { get; set; }

        /// <summary>
        /// 
        /// </summary>
        static AUMLog()
        {
            AUMLogDirPath = FileHelper.GetExecutingPath();
        }

        public static string AUMLogFileName
        {
            get { return "aum.log"; }
        }

        /// <summary>
        /// 
        /// </summary>
        public static string AUMLogFullPath
        {
            get { return Path.Combine(AUMLogDirPath, AUMLogFileName); }
        }

        private static readonly object m_LockObj = new object();

      public static void WriteInLog(string format, params object[] args)
        {
          var message = string.Format(CultureInfo.InvariantCulture, format, args);
            lock (m_LockObj)
            {
                try
                {
                    using (var sw = new StreamWriter(AUMLogFullPath, true))
                    {
                        sw.WriteLine("[{0}] {1}", DateTime.Now, message);
                        sw.Flush();
                        sw.Close();
                    }
                }
                catch (Exception)
                {
                    SecurityLog.WriteToEventLogWindows(
                      EventLogEntryType.Error,
                      string.Format("Can't write into aum.log (path={0})", AUMLogFullPath));
                }
            }
        }
    }
}

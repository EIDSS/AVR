using System;
using System.Diagnostics;

namespace AUM.Core.Helper
{
  using System.Globalization;


  public class RunHelper
    {
        public RunHelper()
        {
            EffortCount = 3; //три попытки запуска
        }

        public int EffortCount { get; private set; }

        public delegate void RunUpdateDelegate(ConfigSettings settings);
        public delegate void RunSystemOperationsDelegate(string path);
        public delegate string RunSyncDelegate(ConfigSettings settings);

        public void Run(
          RunSyncDelegate methodSync,
          RunSystemOperationsDelegate methodSystemOperations,
          string path,
          ConfigSettings settings)
        {
            var mode ="sync";
            if (methodSystemOperations != null)
            {
                mode = "system operations";
            }
            
            try
            {
                var efNum = 1;
                while (efNum <= EffortCount)
                {
                    try
                    {
                        efNum++;
                        if ((settings != null) && (methodSync != null))
                        {
                            methodSync(settings);
                        }
                        else if (methodSystemOperations != null)
                        {
                            methodSystemOperations(path);
                        }
                        break;
                    }
                    catch (Exception exc)
                    {
                      var err = string.Format(CultureInfo.InvariantCulture, "Unexpected error = '{0}' (effort # {1}; mode='{2}')", exc.Message, efNum - 1, mode);
                        AUMLog.WriteInLog(err);
                        SecurityLog.WriteToEventLogWindows(EventLogEntryType.Error, err);
                    }
                }
            }
            catch (Exception exc)
            {
              var err = string.Format(CultureInfo.InvariantCulture, "Unexpected error (general) = '{0}; mode='{1}'", exc.Message, mode);
                SecurityLog.WriteToEventLogWindows(EventLogEntryType.Error, err);
            }
        }

        public void Run(RunUpdateDelegate methodUpdate, ConfigSettings settings)
        {
          if (null == methodUpdate || null ==settings)
          {
            return;
          }

          try
          {
            var efNum = 1;
            while (efNum <= EffortCount)
            {
              try
              {
                efNum++;
                methodUpdate(settings);
                break;
              }
              catch (Exception exc)
              {
                var err = string.Format(
                  CultureInfo.InvariantCulture,
                  "Unexpected error = '{0}' (effort # {1}; mode='{2}')",
                  exc.Message,
                  efNum - 1,
                  "update");
                AUMLog.WriteInLog(err);
                SecurityLog.WriteToEventLogWindows(EventLogEntryType.Error, err);
              }
            }
          }
          catch (Exception exc)
          {
            var err = string.Format(
              CultureInfo.InvariantCulture,
              "Unexpected error (general) = '{0}; mode='{1}'",
              exc.Message,
              "update");
            SecurityLog.WriteToEventLogWindows(EventLogEntryType.Error, err);
          }
        }
    }
}

using System;
using System.Globalization;
using AUM.Core;
using AUM.Diagnostics;
using Microsoft.Win32.TaskScheduler;

namespace AUM.Administrator
{
  using Core.Diagnostics;


  public class TaskProvider : IJobProvider
    {
        Task m_Task;

        public bool IsRunning
        {
            get
            {
                if (m_Task == null)
                {
                    return false;
                }
                try
                {
                    var state = m_Task.State;
                    Dbg.Debug("task state: {0}", m_Task.State.ToString());
                    AUMLog.WriteInLog("task state: {0}", m_Task.State);
                    return state == TaskState.Running;
                }
                catch (Exception ex)
                {
                    Dbg.Debug("error in Task.IsRunning: {0}", ex);
                    AUMLog.WriteInLog("error in Task.IsRunning: {0}", ex.Message);
                    if (LastError != null) m_LastError = ex.ToString();
                    return false;
                }
            }
        }
        private string m_LastError;
        public string LastError
        {
            get
            {
                if (!string.IsNullOrEmpty(m_LastError))
                {
                    return m_LastError;
                }
                if (m_Task == null)
                {
                    return null;
                }
                int err;
                try
                {
                    err = m_Task.LastTaskResult;
                }
                catch (Exception ex)
                {
                    Dbg.Debug("error in Task.GetLastError: {0}", ex);
                    AUMLog.WriteInLog("error in Task.GetLastError: {0}", ex.Message);
                    return null;
                }
                switch (err)
                {
                    case 0:
                        return null;
                    default:
                        return err.ToString(CultureInfo.InvariantCulture);
                }
            }
        }

        public string JobName
        {
            get { return m_JobName; }
        }


        private string m_JobName = String.Empty;
        public int Run(string aJobName)
        {
            try
            {
                m_LastError = String.Empty;
                using (var ts = new TaskService())
                {
                    m_Task = ts.FindTask(aJobName);
                    if ((m_Task == null))
                    {
                        Dbg.Debug("Task for job {0} is not found.", aJobName);
                        m_LastError = String.Format("Task for job {0} is not found.", aJobName);
                        AUMLog.WriteInLog(m_LastError);
                        return 1;
                    }
                    m_JobName = aJobName;
                }

            }
            catch (Exception ex)
            {
                Dbg.Debug("error in Task.Create for job {0}: {1}", aJobName, ex);
                AUMLog.WriteInLog("error in Task.Create for job {0}: {1}", aJobName, ex);
                if (LastError != null) m_LastError = ex.ToString();
                return 1;
            }
            try
            {
                m_Task.Run();
            }
            catch (Exception ex)
            {
                Dbg.Debug("error in Task.Run for job {0}: {1}", aJobName, ex);
                AUMLog.WriteInLog("error in Task.Run for job {0}: {1}", aJobName, ex);
                if (LastError != null) m_LastError = ex.ToString();
                return 2;
            }
            return 0;
        }


        public static Task CreateTask (string taskName, string application, string parameters, string workingFolder, DateTime start, int hourInterval, int durationDays = 0)
        {
            DeleteTask(taskName);
            using (var ts = new TaskService())
            {
                var td = ts.NewTask();
                // Create a trigger that will fire the task at this time every other day
                var tt = new TimeTrigger {StartBoundary = start};
                tt.Repetition.Interval = TimeSpan.FromHours(hourInterval);
                tt.Repetition.Duration = TimeSpan.FromDays(durationDays);
                td.Triggers.Add(tt);
                // Create an action that will launch Notepad whenever the trigger fires
                td.Actions.Add(new ExecAction(application, parameters, workingFolder));
                // Register the task in the root folder
                ts.RootFolder.RegisterTaskDefinition(taskName, td);

                return ts.GetTask(taskName);
            }
            
        }
        public static void DeleteTask(string taskName)
        {
            using (var ts = new TaskService())
            {
                var task = ts.FindTask(taskName);
                if (task != null)
                    task.Folder.DeleteTask(taskName);
            }
        }
    }
}

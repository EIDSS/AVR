namespace AUM.Administrator
{
  using System;
  using System.Collections.Generic;
  using System.Data;
  using System.Data.SqlClient;
  using System.Linq;
  using System.Threading;
  using System.Windows.Forms;
  using Core;
  using Core.Diagnostics;
  using Microsoft.SqlServer.Management.Smo;
  using Timer = System.Threading.Timer;


  public class JobAccessor
    {
        private readonly string m_ServerName;
        private readonly SqlConnection m_SqlConnection;
        private readonly string m_UserName;
        private readonly string m_Password;
        private const string ExpressEditionName = "Express Edition";
        private readonly List<IJobProvider> m_JobQueue = new List<IJobProvider>();
        private readonly Timer m_Timer;
        public static JobAccessor Instance { get; set; }
        public static bool FromUnitTest { get; set; }
        public static bool FromUnitTestSuccess { get; set; }
        public event SendOrPostCallback OnJobFinished;
        public JobAccessor(string serverName, string userName, string password)
        {
            m_ServerName = serverName;
            m_UserName = userName;
            m_Password = password;
            var builder = new SqlConnectionStringBuilder
                {
                    DataSource = serverName,
                    InitialCatalog = "master",
                    UserID = userName,
                    Password = password
                };
            m_SqlConnection = new SqlConnection(builder.ConnectionString);
            var uiContext = SynchronizationContext.Current;
            if (uiContext == null)
            {
                uiContext = new WindowsFormsSynchronizationContext();
                SynchronizationContext.SetSynchronizationContext(uiContext);
            }
            m_Timer = new Timer(CheckJobsQueueState, uiContext, 1000, 1000);
        }

        public bool IsJobRuning(string jobName)
        {
            try
            {
                lock (m_JobQueue)
                {
                    return m_JobQueue.Any(job => (jobName == job.JobName)); //&& job.IsRunning
                }
            }
            catch (Exception ex)
            {
                Dbg.Debug("error during job running check: {0}", ex);
                AUMLog.WriteInLog("error during job running check: {0}", ex.Message);
            }
            return false;
        }

        private void RaiseJobFinishEvent(SynchronizationContext uiContext, IJobProvider job)
        {
            if (OnJobFinished != null && uiContext != null)
            {
                uiContext.Post(OnJobFinished, job);
            }

        }
        private void CheckJobsQueueState(object state)
        {
            try
            {
                lock (m_JobQueue)
                {
                    if (m_JobQueue.Count == 0)
                        return;
                    var jobsToRemove = new List<IJobProvider>();
                    foreach (IJobProvider job in m_JobQueue)
                    {
                        if (job.IsRunning)
                        {
                            continue;
                        }
                        var err = job.LastError;

                        if (err == null)
                        {
                            Dbg.Debug("[{0:f}] job {1} is finished successfully", CurrentTimeString(), job.JobName);
                            AUMLog.WriteInLog("[{0:f}] job {1} is finished successfully", CurrentTimeString(), job.JobName);
                        }
                        else
                        {
                            Dbg.Debug("[{0:f}] job {1} is failed with error {2}", CurrentTimeString(), job.JobName, err);
                            AUMLog.WriteInLog("[{0:f}] job {1} is failed with error {2}", CurrentTimeString(), job.JobName, err);
                        }
                        RaiseJobFinishEvent(state as SynchronizationContext, job);
                        jobsToRemove.Add(job);
                    }
                    foreach (var job in jobsToRemove)
                    {
                        m_JobQueue.Remove(job);
                    }
                }

            }
            catch (Exception ex)
            {
                Dbg.Debug("error during job state checking: {0}", ex);
                AUMLog.WriteInLog("error during job state checking: {0}", ex.Message);
            }
        }

        public IJobProvider JobProvider
        {
            get { return GetJobProvider(); }
        }
        public string ServerName
        {
            get { return m_ServerName; }
        }

        private IJobProvider m_JobProvider;
        private IJobProvider GetJobProvider()
        {
            if (m_JobProvider != null)
                return m_JobProvider;
            if (IsSqlAgentExist(m_SqlConnection))
                m_JobProvider = new SqlClentAgentJobProvider(m_ServerName, m_UserName, m_Password);
            else
                m_JobProvider = new TaskProvider();
            return m_JobProvider;
        }

        private static bool IsSqlAgentExist(SqlConnection cn)
        {
            try
            {
                if (string.IsNullOrEmpty(cn.DataSource) || string.IsNullOrEmpty(cn.Database))
                    return false;
                if (cn.State != ConnectionState.Open)
                {
                    cn.Open();
                }
                var mainConnection = new Microsoft.SqlServer.Management.Common.ServerConnection(cn);
                var server = new Server(mainConnection);
                if (server.Information.Edition.Trim().ToLowerInvariant().Contains(ExpressEditionName.ToLowerInvariant()))
                {
                    Dbg.Debug("{0}", server.Information.Edition);
                    AUMLog.WriteInLog("{0}", server.Information.Edition);
                    return false;
                }
                else
                {
                    var name = server.JobServer.Name;
                    Dbg.Debug("job server name:{0}", name);
                    AUMLog.WriteInLog("job server name:{0}", name);
                }
            }
            catch (UnsupportedFeatureException ex)
            {
                Dbg.Debug("{0}", ex);
                AUMLog.WriteInLog("{0}", ex.Message);
                return false;
            }
            catch (Exception e)
            {
                Dbg.Debug("{0}", e);
                AUMLog.WriteInLog("{0}", e.Message);
                return false;
            }
            finally
            {
                if (cn.State != ConnectionState.Closed) cn.Close();
            }
            return true;
        }

        public int RunReplicationJob(string jobName)
        {
            var job = GetJobProvider();
            if (job == null)
            {
                Dbg.Debug("job provider for job {0} is not created", jobName);
                AUMLog.WriteInLog("job provider for job {0} is not created", jobName);
                return 1;
            }

            Dbg.Debug("[{0:f}] starting job {1} ...", CurrentTimeString(), jobName);
            AUMLog.WriteInLog("[{0:f}] starting job {1} ...", CurrentTimeString(), jobName);
            var result = job.Run(jobName);
            if (result != 0)
            {
                Dbg.Debug("job {0} is not started", jobName);
                AUMLog.WriteInLog("job {0} is not started", jobName);
                return 1;
            }
            Dbg.Debug("[{0:f}] job {1} is started successfully", CurrentTimeString(), jobName);
            AUMLog.WriteInLog("[{0:f}] job {1} is started successfully", CurrentTimeString(), jobName);
            lock (m_JobQueue)
            {
                m_JobQueue.Add(job);
            }
            return 0;
        }

        private static string CurrentTimeString()
        {
            return DateTime.Now.ToString("d/M/yy H:mm:ss.fff");
        }
    }
}


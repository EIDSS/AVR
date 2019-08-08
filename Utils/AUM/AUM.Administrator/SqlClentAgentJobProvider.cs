using System;
using System.Data.SqlClient;
using System.Linq;
using AUM.Core;
using AUM.Diagnostics;
using Microsoft.SqlServer.Management.Smo.Agent;
using Microsoft.SqlServer.Management.Smo;

namespace AUM.Administrator
{
  using Core.Diagnostics;


  public class SqlClentAgentJobProvider : IJobProvider
    {
        private Server m_Server;
        private readonly string m_ServerName;
        private readonly string m_UserName;
        private readonly string m_Password;

        private Job m_Job;

        public SqlClentAgentJobProvider(string serverName, string userName, string password)
        {
            m_ServerName = serverName;
            m_UserName = userName;
            m_Password = password;
            TryInit();
        }

        private void ResetServerConnection()
        {
            try
            {
                var builder = new SqlConnectionStringBuilder
                    {
                        DataSource = m_ServerName,
                        InitialCatalog = "master",
                        UserID = m_UserName,
                        Password = m_Password
                    };
                var sqlConn = new SqlConnection(builder.ConnectionString);
                sqlConn.Open();
                var mainConnection = new Microsoft.SqlServer.Management.Common.ServerConnection(sqlConn);
                m_Server = new Server(mainConnection);
                m_LastError = String.Empty;
            }
            catch (Exception ex)
            {
                var errStr = String.Format("Can't initialize SMO server {0}. Error={1}", m_ServerName, ex.Message);
                Dbg.Debug(errStr);
                m_Server = null;
                m_LastError = errStr;
                AUMLog.WriteInLog(errStr);
            }
        }


        private void TryInit()
        {
            if (m_Server == null)
            {
                ResetServerConnection();
            }
            else
            {
                try
                {
                    m_Server.Refresh();
                }
                catch (Exception)
                {
                    ResetServerConnection();
                }
            }

        }

        public bool IsRunning
        {
            get
            {
                try
                {
                    if (m_Job == null)
                    {
                        return false;
                    }
                    if ((m_Job.CurrentRunRetryAttempt < 1))
                    {
                        m_Job.Refresh();
                        return (m_LastStartTime == m_Job.LastRunDate);
                    }
                }
                catch (Exception ex)
                {
                    Dbg.Debug("error during job state checking: {0}", ex);
                    AUMLog.WriteInLog("error during job state checking: {0}", ex);
                }
                return false;
            }
        }

        private string m_LastError = String.Empty;

        public string LastError
        {
            get
            {
                if (!string.IsNullOrEmpty(m_LastError))
                {
                    return m_LastError;
                }
                if (m_Job == null)
                {
                    return null;
                }
                var result = m_Job.EnumHistory();
                if (((result != null)))
                {
                    while ((result.Rows.Count == 0))
                    {
                        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(3));
                    }
                    for (int nIndex = 0; nIndex <= result.Rows.Count - 1; nIndex++)
                    {
                        Dbg.Debug("Job history row {0}", nIndex);
                        for (int i = 0; i <= result.Columns.Count - 1; i++)
                        {
                            Dbg.Debug("{0} - {1}: {2}", i, result.Columns[i].ColumnName, result.Rows[nIndex][i]);
                        }

                        // Job name
                        var jobName = result.Rows[nIndex]["JobName"].ToString();
                        // Message
                        var jobMessage = result.Rows[nIndex]["Message"].ToString();
                        // Status
                        var status = (JobOutcome) result.Rows[nIndex]["RunStatus"];
                        if (status == JobOutcome.Succeeded)
                            return null;
                        // Make message
                        if ((status == JobOutcome.Failed || (int) status == 2))
                        {
                            Dbg.Debug("job {0} is failed. {1} {2}", jobName, jobMessage, status.ToString());
                            AUMLog.WriteInLog("job {0} is failed. {1} {2}", jobName, jobMessage, status);
                            return jobMessage;
                        }
                    }
                }
                return null;
            }
        }

        public string JobName
        {
            get { return m_JobName; }
        }

        private DateTime m_LastStartTime;
        private string m_JobName = String.Empty;

        public JobType Type { get; set; }

        public int Run(string aJobName)
        {
            m_JobName = aJobName;
            TryInit();
            if (m_Server == null)
            {
                return 1;
            }

            if (string.IsNullOrEmpty(aJobName))
            {
                Dbg.Debug("Job is not defined for server {0}", m_ServerName);
                m_LastError = String.Format("Job is not defined for server {0}", m_ServerName);
                AUMLog.WriteInLog(m_LastError);
                return 1;
            }
            m_Job = null;
            try
            {
                m_Job = FindJob(aJobName);
                if (m_Job == null)
                {
                    Dbg.Debug("Job <{0}> is not found on server {1}. Job is not started.", aJobName, m_ServerName);
                    m_LastError = String.Format("Job <{0}> is not found on server {1}. Job is not started.", aJobName,
                                                m_ServerName);
                    AUMLog.WriteInLog(m_LastError);
                    return 1;
                }
                m_LastError = String.Empty;
                m_Job.Refresh();
                for (int j = 0; j <= m_Job.JobSteps.Count - 1; j++)
                {
                    var step = m_Job.JobSteps[j];
                    step.RetryAttempts = 1;
                }
                //Don't start job until previous job is not finished
                int errorCount = 0;
                while (JobExecutionStatus.Idle == m_Job.CurrentRunStatus)
                {
                    m_LastStartTime = m_Job.LastRunDate;
                    try
                    {
                        m_Job.Start();
                        break;
                    }
                    catch (Exception ex)
                    {
                        Dbg.Debug("job <{0}> is failed. Source {1}. HiperLink: {2}. {3}", m_Job.Name, ex.Source,
                                  ex.HelpLink, ex.Message);
                        AUMLog.WriteInLog("job <{0}> is failed. Source {1}. HiperLink: {2}. {3}",
                                                        m_Job.Name, ex.Source, ex.HelpLink, ex.Message);
                        if ((ex.InnerException != null))
                        {
                            Dbg.Debug("job <{0}> is failed. Inner exception {1}", m_Job.Name,
                                      ex.InnerException.ToString());
                            AUMLog.WriteInLog("job <{0}> is failed. Inner exception {1}", m_Job.Name,
                                                            ex.InnerException);
                        }
                        errorCount++;
                        if (errorCount > 100) throw;
                    }
                    System.Threading.Thread.Sleep(100);
                    m_Job.Refresh();
                }
                return 0;
            }
            catch (Exception e)
            {
                Dbg.Debug("Job <{0}> starting is failed. {1}", aJobName, e);
                m_LastError = String.Format("Job <{0}> starting is failed. {1}", aJobName, e);
                AUMLog.WriteInLog(m_LastError);
                return 2;
            }

        }

        private Job FindJob(string jobName)
        {
            return
                m_Server.JobServer.Jobs.Cast<Job>()
                        .FirstOrDefault(job => job.Name.ToLowerInvariant() == jobName.ToLowerInvariant());
        }

        public Job CreateJob(string jobName, string query)
        {
            var job = FindJob(jobName);
            if (job == null)
            {
                job = new Job(m_Server.JobServer, jobName);
                job.Create();
                job.ApplyToTargetServer(m_Server.JobServer.Parent.Name);
                m_Server.JobServer.Jobs.Refresh();

                var step = new JobStep(job, "test")
                    {
                        Command = query,
                        ID = 1,
                        SubSystem = AgentSubSystem.TransactSql,
                        DatabaseName = "master",
                        CommandExecutionSuccessCode = 0,
                        //OnSuccessAction = onSuccessAction,
                        OnSuccessStep = 0,
                        //OnFailAction = onFailAction,
                        OnFailStep = 0,
                        RetryAttempts = 1
                    };
                step.Create();
                job.Alter();
                job.JobSteps.Refresh(true);
            }
            return job;
        }
    }
}

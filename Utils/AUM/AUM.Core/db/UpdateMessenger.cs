using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace AUM.Core.db
{
    public class UpdateMessenger
    {
        private readonly SqlConnection m_Connection;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        public UpdateMessenger(SqlConnection cn)
        {
            m_Connection = cn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientID"></param>
        /// <param name="application">Приложение-инициатор апдейта</param>
        /// <param name="withDatabaseUpdate">Будет ли апдейтиться БД</param>
        public void CreateUpdateBlock(string clientID, string application, bool withDatabaseUpdate)
        {
            var command = new SqlCommand("spEIDSSUpdate_CreateUpdateBlock", m_Connection){CommandType = CommandType.StoredProcedure};
            command.Parameters.Add("@ClientID", SqlDbType.NVarChar);
            command.Parameters.Add("@Application", SqlDbType.NVarChar);
            command.Parameters.Add("@WithDatabaseUpdate", SqlDbType.Bit);
            command.Parameters["@ClientID"].Value = clientID;
            command.Parameters["@Application"].Value = application;
            command.Parameters["@WithDatabaseUpdate"].Value = withDatabaseUpdate;
            if (m_Connection.State != ConnectionState.Open) m_Connection.Open();
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// 
        /// </summary>
        public void DeleteUpdateBlock()
        {
            var command = new SqlCommand("spEIDSSUpdate_DeleteUpdateBlock", m_Connection)
                              {CommandType = CommandType.StoredProcedure};
            if (m_Connection.State != ConnectionState.Open) m_Connection.Open();
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enabled"></param>
        public void ManageConnections(bool enabled)
        {
            var operation = enabled ? "Enable" : "Disable";
            AUMLog.WriteInLog("ManageUsers: {0} start", operation);
            var command = new SqlCommand("spEIDSSUpdate_ManageUsers", m_Connection)
                                     {CommandType = CommandType.StoredProcedure};
            command.Parameters.Add("@enable", SqlDbType.NVarChar);
            command.Parameters["@enable"].Value = enabled;
            if (m_Connection.State != ConnectionState.Open) m_Connection.Open();
            command.ExecuteNonQuery();
            AUMLog.WriteInLog("ManageUsers: {0} complete", operation);
        }

        /// <summary>
        /// 
        /// </summary>
        public DataTable GetRunningApps(out string errorString)
        {
            errorString = String.Empty;
            var result = new DataTable();
            AUMLog.WriteInLog("Try to get the running apps...");
            try
            {
                using (var command = new SqlCommand("spEIDSSUpdate_GetRunningApps", m_Connection) { CommandType = CommandType.StoredProcedure })
                {
                    if (m_Connection.State != ConnectionState.Open) m_Connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        result.Load(reader);
                        reader.Close();
                    }
                }
                AUMLog.WriteInLog("Received {0} running apps", result.Rows.Count);
            }
            catch (Exception exc)
            {
                errorString = String.Format("Error: {0}", exc.Message);
                AUMLog.WriteInLog(errorString);
                SecurityLog.WriteToEventLogWindows(EventLogEntryType.Error, errorString);
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientID"></param>
        public DataTable GetCurrentLanguageInfo(string clientID)
        {
            var result = new DataTable();

            var command = new SqlCommand("spEIDSSUpdate_GetCurrentLanguage", m_Connection)
                              {CommandType = CommandType.StoredProcedure};
            command.Parameters.Add("@ClientID", SqlDbType.NVarChar);
            command.Parameters["@ClientID"].Value = clientID;
            if (m_Connection.State != ConnectionState.Open) m_Connection.Open();
            using (var reader = command.ExecuteReader())
            {
                result.Load(reader);
                reader.Close();
            }
            return result;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientID"></param>
        /// <param name="programName"></param>
        public void DeleteRunningApps(string clientID, string programName)
        {
            var command = new SqlCommand("spEIDSSUpdate_DeleteRunningApps", m_Connection)
                              {CommandType = CommandType.StoredProcedure};
            command.Parameters.Add("@ClientID", SqlDbType.NVarChar);
            command.Parameters.Add("@Application", SqlDbType.NVarChar);
            command.Parameters["@ClientID"].Value = clientID;
            command.Parameters["@Application"].Value = programName;
            if (m_Connection.State != ConnectionState.Open) m_Connection.Open();
            command.ExecuteNonQuery();
        }

    }
}
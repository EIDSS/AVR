namespace AUM.Core.Helper
{
  using System;
  using System.Collections.Generic;
  using System.Data;
  using System.Data.SqlClient;
  using System.Diagnostics;
  using System.Linq;
  using System.Text;
  using AUM.db;
  using Enums;
  using Microsoft.SqlServer.Management.Smo;
  using UpdateStatus = Enums.UpdateStatus;


  public static class DatabaseHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="programID"></param>
        /// <returns></returns>
        public static UpdateDatabases GetUpdateDatabase(string programID)
        {
            var result = UpdateDatabases.Unknown;
            if (ProductHelper.IsDBUpdate(programID))
            {
                result = UpdateDatabases.DbMain;
            }
            else if (ProductHelper.IsDBaUpdate(programID))
            {
                result = UpdateDatabases.DbArchive;
            }
            else if (ProductHelper.IsAvrServiceDbProgram(programID))
            {
                result = UpdateDatabases.AVRServiceDb;
            }
            return result;
        }

        public static SqlConnection GetConnection(UpdateDatabases whichDatabase)
        {
            var serverNameKey = "SQLServer";
            var databaseNameKey = "SQLDatabase";
            switch (whichDatabase)
            {
                case UpdateDatabases.DbMain:
                    serverNameKey = "SQLServer";
                    databaseNameKey = "SQLDatabase";
                    break;
                case UpdateDatabases.DbArchive:
                    serverNameKey = "ArchiveServer";
                    databaseNameKey = "ArchiveDatabase";
                    break;
                case UpdateDatabases.AVRServiceDb:
                    serverNameKey = "AvrServiceServer";
                    databaseNameKey = "AvrServiceDatabase";
                    break;
            }
            var sqlServer = RegistryHelper.ReadFromRegistry(serverNameKey);
            var sqlDatabase = RegistryHelper.ReadFromRegistry(databaseNameKey);
            if (sqlServer.Length == 0 || sqlDatabase.Length == 0) return null;

            if (whichDatabase == UpdateDatabases.DbAdmin)
            {
                sqlDatabase = String.Format("{0}_Admin", sqlDatabase);
            }
            string user;
            string password;
            UpdHelper.GetSqlAdminSettings(String.Empty, String.Empty, out user, out password);
            return UpdHelper.GetSqlConnection(sqlServer, sqlDatabase, user, password);
        }

        private static SqlDataReader ExecuteStoredProcWithReader(SqlConnection conn, string procName, IEnumerable<SqlParameter> parameters)
        {
            var cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                Connection = conn,
                CommandText = procName
            };

            if (cmd.Connection.State != ConnectionState.Open) cmd.Connection.Open();

            foreach (var sqlParameter in parameters)
            {
                cmd.Parameters.Add(sqlParameter);
            }

            SqlDataReader reader = null;
            try
            {
                reader = cmd.ExecuteReader();
            }
            catch (Exception exc)
            {
                var message = String.Format("execute procedure '{0}' error: {1}", procName, exc.Message);
                AUMLog.WriteInLog(message);
            }

            return reader;
        }

        public static string CreateStoredProc(string procName, IEnumerable<object> parameters)
        {
            var sb = new StringBuilder();

            if (parameters != null)
            {
                foreach (var p in parameters)
                {
                    var s = p.ToString();
                    var f = sb.Length == 0 ? " '{0}'" : ", '{0}'";
                    sb.AppendFormat(f, s);
                }
            }

            return String.Format("exec {0} {1}", procName, sb);
        }

        public static bool ExecuteStoredProc(Database database, string statement)
        {
            var result = false;
            try
            {
                database.ExecuteNonQuery(statement);
                result = true;
            }
            catch (Exception e)
            {
                AUMLog.WriteInLog("Can't execute stored proc. '{0}'. Error: {1}", statement, e.Message);
                SecurityLog.WriteToEventLogWindows(EventLogEntryType.Error, e.Message);
            }
            return result;
        }

        public static SqlCommand ExecuteStoredProc(UpdateDatabases database, string procName, IEnumerable<SqlParameter> parameters, SqlTransaction transaction = null)
        {
            try
            {
                SqlCommand cmd = null;
                var conn = GetConnection(database);
                if (conn != null)
                {
                    lock (conn)
                    {
                        if (conn.State != ConnectionState.Open) conn.Open();
                        cmd = new SqlCommand
                        {
                            CommandType = CommandType.StoredProcedure,
                            Connection = conn,
                            CommandText = procName
                        };
                        if (transaction != null) cmd.Transaction = transaction;
                        if (parameters != null)
                        {
                            foreach (var sqlParameter in parameters)
                            {
                                cmd.Parameters.Add(sqlParameter);
                            }
                        }
                        cmd.ExecuteNonQuery();
                    }
                    if (conn.State == ConnectionState.Open) conn.Close();
                }
                return cmd;
            }
            catch (Exception e)
            {
                AUMLog.WriteInLog("Can't execute stored proc. '{0}'. Error: {1}", procName, e.Message);
                SecurityLog.WriteToEventLogWindows(EventLogEntryType.Error, e.Message);
                return null;
            }
        }

    public static Version GetCurrentDBVersion(UpdateDatabases databases)
    {
      AUMLog.WriteInLog("GetCurrentDBVersion. Code='{0}'", databases);
      var currentDbVersion = VersionFactory.EmptyVersion;
      var conn = GetConnection(databases);

      if (conn != null)
      {
        try
        {
          using (var command = new SqlCommand("Select [strValue] from dbo.tstLocalSiteOptions where [strName] = 'DatabaseVersion'", conn))
          {
            command.CommandType = CommandType.Text;
            ErrorMessage errObj = null;
            currentDbVersion = VersionFactory.NewVersion((string) DbHelper.ExecScalar(command, conn, ref errObj, null, true));
          }
        }
        catch (Exception exc)
        {
          AUMLog.WriteInLog("Error while get current DB version: {0}", exc);
        }
        if (conn.State == ConnectionState.Open)
        {
          conn.Close();
        }
      }
      else
      {
        AUMLog.WriteInLog("Connection is null");
      }
      AUMLog.WriteInLog("Current version is '{0}'", currentDbVersion);
      return currentDbVersion;
    }

    private static UpdateStatus Status(int status)
    {
      return (UpdateStatus)status;
    }

    private static UpdateStatus Status(bool isSuccess)
    {
      return isSuccess ? UpdateStatus.Success : UpdateStatus.Error;
    }

    public static List<SiteInfo> GetSiteTree(string machineName, MachineLevel.Level level)
    {
      var siteTree = new List<SiteInfo>();

      var conn = GetConnection(UpdateDatabases.DbAdmin);
      if (conn != null)
      {
        var parameters =
          new List<SqlParameter>
          {
            new SqlParameter("@strComputerName", SqlDbType.NVarChar) { Value = machineName },
            new SqlParameter("@intAUMInstallationType", SqlDbType.Int) { Value = MachineLevel.AsInt(level) }
          };
        using (var reader = ExecuteStoredProcWithReader(conn, "dbo.spAUMAdministratorGetNodeTree", parameters))
        {
          if (reader == null)
          {
            return siteTree;
          }
          while (reader.Read())
          {
            var si = new SiteInfo(
              (long) reader["idfsSite"],
              reader["idfsParentSite"] != DBNull.Value ? (long) reader["idfsParentSite"] : 0,
              (string) reader["strComputerName"],
              Status((int) reader["intPatchStatus"]));
            siteTree.Add(si);
          }
        }
        if (conn.State == ConnectionState.Open)
        {
          conn.Close();
        }
      }
      //AddUpdatesInfoToSiteInfo(ref siteTree);

      return siteTree;
    }

    public static List<TotalUpdateInfo> GetUpdatesInfo(string compName, List<TotalUpdateInfo> updates)
    {
      var updatesDictionary = updates.ToDictionary(totalUpdateInfo => totalUpdateInfo.Version);

      var conn = GetConnection(UpdateDatabases.DbAdmin);
      if (conn == null)
      {
        return updates;
      }
      var parameters = new List<SqlParameter>
      {
        new SqlParameter("@strComputerName", SqlDbType.VarChar, 50) { Value = compName }
      };
      using (var reader = ExecuteStoredProcWithReader(conn, "dbo.spAUMUpdatedComponentInfo", parameters))
      {
        if (reader != null)
        {
          while (reader.Read())
          {
            var updateInfo = new UpdateInfo
            {
              ID = (long) reader["idfUpdatedComponent"],
              Alias = (string) reader["strAlias"],
              DateStart = (DateTime) reader["datUpdateStart"],
              DateFinish =
                reader["datUpdateEnd"] != DBNull.Value
                  ? (DateTime) reader["datUpdateEnd"]
                  : DateTime.MinValue,
              Success =
                reader["intUpdateResult"] != DBNull.Value && ((int) reader["intUpdateResult"]) == 0,
              Status = reader["intUpdateResult"] != DBNull.Value ? Status(((int) reader["intUpdateResult"]) == 0) : UpdateStatus.Unknown,
              VersionStart = VersionFactory.NewVersion((string) reader["strSourceVersion"]),
              VersionFinish =
                reader["strTargetVersion"] != DBNull.Value
                  ? VersionFactory.NewVersion((string) reader["strTargetVersion"])
                  : VersionFactory.EmptyVersion,
              ComputerName = (string) reader["strComputerName"]
            };

            var strLog = reader["strLog"] != DBNull.Value ? (string) reader["strLog"] : string.Empty;
            if (strLog.Length > 0)
            {
              updateInfo.Log.AddRange(strLog.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries));
            }

            AddUpdateInfo(ReadPatchVersion(reader), ref updatesDictionary, updateInfo);
          }
        }
        else
        {
          return updates;
        }
      }
      if (conn.State == ConnectionState.Open)
      {
        conn.Close();
      }

      return updates;
    }

    public static UpdateInfo GetUpdateLog(string compName, string componentAlias, string componentVersion)
    {
      var updateInfo = new UpdateInfo();

      var conn = GetConnection(UpdateDatabases.DbAdmin);
      if (conn == null)
      {
        return updateInfo;
      }
      var parameters = new List<SqlParameter>
      {
        new SqlParameter("@strComputerName", SqlDbType.VarChar, 50) { Value = compName },
        new SqlParameter("@strAlias", SqlDbType.NVarChar, 100) { Value = componentAlias },
        new SqlParameter("@strTargetVersion", SqlDbType.NVarChar, 50) { Value = componentVersion }
      };
      using (var reader = ExecuteStoredProcWithReader(conn, "dbo.spAUMUpdatedComponentInfo", parameters))
      {
        if (reader == null)
        {
          return updateInfo;
        }
        while (reader.Read())
        {
          updateInfo = new UpdateInfo
          {
            ID = (long)reader["idfUpdatedComponent"],
            Alias = (string)reader["strAlias"],
            DateStart = (DateTime)reader["datUpdateStart"],
            DateFinish =
              reader["datUpdateEnd"] != DBNull.Value
                ? (DateTime)reader["datUpdateEnd"]
                : DateTime.MinValue,
            Success =
              reader["intUpdateResult"] != DBNull.Value && ((int)reader["intUpdateResult"]) == 0,
            Status = reader["intUpdateResult"] != DBNull.Value ? Status(((int)reader["intUpdateResult"]) == 0) : UpdateStatus.Unknown,
            VersionStart = VersionFactory.NewVersion((string)reader["strSourceVersion"]),
            VersionFinish =
              reader["strTargetVersion"] != DBNull.Value
                ? VersionFactory.NewVersion((string)reader["strTargetVersion"])
                : VersionFactory.EmptyVersion,
            ComputerName = (string)reader["strComputerName"]
          };

          var strLog = reader["strLog"] != DBNull.Value ? (string)reader["strLog"] : string.Empty;
          if (strLog.Length > 0)
          {
            updateInfo.Log.AddRange(strLog.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries));
          }
        }
      }
      if (conn.State == ConnectionState.Open)
      {
        conn.Close();
      }

      return updateInfo;
    }

    private static void AddUpdateInfo(Version patchVersion, ref Dictionary<Version, TotalUpdateInfo> updatesDictionary, UpdateInfo updateInfo)
    {
      if (updatesDictionary.ContainsKey(patchVersion))
      {
        var totalUpdateInfo = updatesDictionary[patchVersion];
        totalUpdateInfo.Updates[totalUpdateInfo.ProductUpdateIndex(updateInfo.Alias)] = updateInfo;
      }
    }

    private static Version ReadPatchVersion(IDataRecord reader)
    {
      var rawPatchVersion = reader["strPatchVersion"];
      return rawPatchVersion != 
        DBNull.Value
        ? VersionFactory.NewVersion((string) rawPatchVersion)
        : VersionFactory.EmptyVersion;
    }
  }
}

namespace AUM.XPatch
{
    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using Core.Enums;
    using Core.Helper;
    using Microsoft.SqlServer.Management.Common;
    using Microsoft.SqlServer.Management.Smo;


    public class GisUpdate : BaseTask
    {
        #region BaseTask

        protected override bool ExecuteInternal()
        {
            if (!RegistryHelper.IsSqlServerInstalled())
            {
                AddInfoString("Sql server is not installed on this PC. Gis update patch shall not be run.");
                return true;
            }
            if (!InstallUpdateFiles())
            {
                return false;
            }
            if (!UpdateGisTablesStructure())
            {
                return false;
            }
            if (!UpdateGisTablesContent())
            {
                return false;
            }
            UnInstallUpdateFiles();
            return true;
        }


        public override string GetName()
        {
            return "Local Gis Tables Update";
        }

        public override Guid GetID()
        {
            return new Guid("{914F193D-9460-4BB2-B860-338E4A775D31}");
        }

        #endregion

        #region implementation

        public const string ScriptName = "6.00.72.107.001_ls_CreateNewWKBTables_20160219.sql";
        public const string UpdateFilesFolder = "UpdateFiles";
        public const string GisUpdateUtility = "gis_v4_update.exe";

        private bool UpdateGisTablesContent()
        {
            try
            {
                var gisUpdateUtility = Path.Combine(m_updateDir, GisUpdateUtility);
                var sqlConnection = DatabaseHelper.GetConnection(UpdateDatabases.DbMain);
                if (sqlConnection == null)
                {
                    AddInfoString("EIDSS connection to sql server can't be retrieved. Gis update patch shall not be run.");
                    return true;
                }
                var p = new Process
                {
                    StartInfo =
                    {
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        FileName = gisUpdateUtility,
                        RedirectStandardError = true,
                        Arguments = string.Format(
                          CultureInfo.InvariantCulture,
                          "\"{0}\" \"reproject_ready\" \\n",
                          sqlConnection.ConnectionString)
                    }
                };
                p.Start();

                // To avoid deadlocks, always read the output stream first and then wait.
                string output = p.StandardOutput.ReadToEnd();
                string error = p.StandardError.ReadToEnd();
                p.WaitForExit();
                if (!string.IsNullOrEmpty(output))
                {
                    AddInfoString(output);
                }
                if (!string.IsNullOrEmpty(error))
                {
                    AddErrorString(error);
                    return false;
                }
                return true;

            }
            catch (Exception ex)
            {
                AddErrorString(GetFullError(ex));
                return false;
            }
        }

        private string m_updateDir;

        private bool InstallUpdateFiles()
        {
            var path = FileHelper.GetExecutingPath();
            m_updateDir = Path.Combine(path, UpdateFilesFolder);
            if (!Directory.Exists(m_updateDir))
            {
                AddErrorString("Folder wit gis update utility <{0}> is not found", m_updateDir);
                return false;
            }
            return true;
        }

        private void UnInstallUpdateFiles()
        {
            if (!string.IsNullOrEmpty(m_updateDir))
            {
                return;
            }
            Directory.Delete(m_updateDir, true);
        }

        private bool UpdateGisTablesStructure()
        {
            AddInfoString("Opening sql connection");
            var sqlConnection = DatabaseHelper.GetConnection(UpdateDatabases.DbMain);
            if (sqlConnection == null)
            {
                AddInfoString("EIDSS connection to sql server can't be retrieved. Gis update patch shall not be run.");
                return true;
            }
            var serverConnection = new ServerConnection(sqlConnection);
            var server = new Server(serverConnection);
            var mainDatabaseSmo = server.Databases[sqlConnection.Database];
            AddInfoString("Server name={0}; Database name={1}", server.Name, mainDatabaseSmo.Name);
            AddInfoString("Running sql script <{0}>", ScriptName);
            serverConnection.BeginTransaction();
            try
            {
                using (var sr = (new FileInfo(Path.Combine(m_updateDir, ScriptName)).OpenText()))
                {
                    mainDatabaseSmo.ExecuteNonQuery(sr.ReadToEnd());
                }
                AddInfoString("Sql script <{0}> is executed successfully", ScriptName);
                serverConnection.CommitTransaction();
                return true;
            }
            catch (Exception ex)
            {
                AddErrorString(GetFullError(ex));
                serverConnection.RollBackTransaction();
                return false;
            }
        }

        #endregion
    }
}
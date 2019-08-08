using System;
using System.Collections;
using System.Data;
using AUM.Configuration;
using AUM.Diagnostics;
using System.Threading;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using AUM.Core;

namespace AUM.db
{
  using Core.Diagnostics;


  public class ConnectionCredentials : IComparable
    {


        protected string m_ConnectionStringFinal;
        private string m_SQLConnectionString;
        private string m_SQLServer;
        private string m_SQLDatabase;
        private string m_SQLUser;
        private string m_SQLPassword;

        public ConnectionCredentials()
        {
            Load(null);
            CreateConnectionString();
        }

        public ConnectionCredentials(string server, string database, string user, string password, string connectionString)
        {
            SetCredentials(connectionString, server, database, user, password);
        }

        public ConnectionCredentials(string configFile)
        {
            Load(configFile);
            CreateConnectionString();
        }
        public void SetCredentials(string connectionString, string server, string database, string user, string password)
        {
            Load(null);
            m_ConnectionStringFinal = null;
            if (!string.IsNullOrEmpty(connectionString))
            {
                m_SQLConnectionString = connectionString;
            }
            if (!string.IsNullOrEmpty(server))
            {
                m_SQLServer = server;
            }
            if (!string.IsNullOrEmpty(database))
            {
                m_SQLDatabase = database;
            }
            if (!string.IsNullOrEmpty(user))
            {
                m_SQLUser = user;
            }
            if (!string.IsNullOrEmpty(password))
            {
                m_SQLPassword = password;
            }
            CreateConnectionString();
        }
        private string CreateConnectionString(string baseConnctionString)
        {
            if (!(baseConnctionString == null))
            {
                baseConnctionString = m_SQLConnectionString;
                if (!(m_SQLUser == null))
                {
                    baseConnctionString = baseConnctionString.Replace("{0}", m_SQLUser);
                }
                if (!(m_SQLPassword == null))
                {
                    baseConnctionString = baseConnctionString.Replace("{1}", m_SQLPassword);
                }
                if (!(m_SQLDatabase == null))
                {
                    baseConnctionString = baseConnctionString.Replace("{2}", m_SQLDatabase);
                }
                if (!(m_SQLServer == null))
                {
                    baseConnctionString = baseConnctionString.Replace("{3}", m_SQLServer);
                }
            }
            return (baseConnctionString);
        }

        public string CreateConnectionString()
        {
            if (Utils.IsEmpty(m_ConnectionStringFinal))
            {
                m_ConnectionStringFinal = CreateConnectionString(m_SQLConnectionString);
                ConnectionManager.ConnectionStringParser parser = new ConnectionManager.ConnectionStringParser(m_ConnectionStringFinal);
                if (UseAsyncConnection)
                {
                    parser.SetItem(ConnectionManager.ConnectionStringPart.Async, "true");
                }
                parser.SetItem(ConnectionManager.ConnectionStringPart.MARS, "true");
                m_ConnectionStringFinal = parser.ConnectionString;
            }
            return (m_ConnectionStringFinal);
        }

        public string ConnectionString
        {
            get
            {
                if (m_ConnectionStringFinal == null)
                {
                    CreateConnectionString();
                }
                return m_ConnectionStringFinal;
            }
        }

        private ConfigWriter config = new ConfigWriter();
        public void Load(string configFile)
        {
            config.Read(configFile);
            if (Utils.Str(configFile) == "")
            {
                m_SQLConnectionString = BaseSettings.ConnectionString;
                m_SQLUser = BaseSettings.SQLUser;
                m_SQLPassword = BaseSettings.SQLPassword;
                m_SQLDatabase = BaseSettings.SQLDatabase;
                m_SQLServer = BaseSettings.SqlServer;
            }
            else
            {
                m_SQLConnectionString = config.Item("SQLConnectionString");
                m_SQLUser = config.Item("SQLUser");
                m_SQLPassword = config.Item("SQLPassword");
                m_SQLDatabase = config.Item("SQLDatabase");
                m_SQLServer = config.Item("SQLServer");
            }
            //Dbg.Assert(Utils.Str(Me.m_SQLConnectionString) <> "", "connection string is not defined")
            if (!(m_SQLUser == null))
            {
                m_SQLUser = Cryptor.Decrypt(m_SQLUser);
            }
            if ((!(m_SQLPassword == null)) && (!(m_SQLUser == null)))
            {
                m_SQLPassword = Cryptor.Decrypt(m_SQLPassword, m_SQLUser);
            }
            ///'' TO DO
            if (string.IsNullOrEmpty(m_SQLConnectionString))
            {
                m_SQLConnectionString = config.Item("ConnectionString");
            }
            if (string.IsNullOrEmpty(m_SQLConnectionString))
            {
                m_SQLConnectionString = "Persist Security Info=False;User ID={0};Password={1};Initial Catalog={2};Data Source={3}";
            }
        }
        private string[] m_ConfigFilesToSave;
        public string[] ConfigFilesToSave
        {
            get
            {
                return m_ConfigFilesToSave;
            }
            set
            {
                m_ConfigFilesToSave = value;
            }
        }

        public void Save()
        {
            SaveToFile(null);
            if (m_ConfigFilesToSave != null)
            {
                foreach (string configFile in m_ConfigFilesToSave)
                {
                    SaveToFile(configFile);
                }
            }
        }
        public void SaveToFile(string configFile)
        {
            if (configFile != null)
            {
                if (System.IO.File.Exists(configFile))
                {
                    config.Read(configFile);
                }
            }
            if (config == null)
            {
                config = ConfigWriter.Instance;
            }
            Dbg.ConditionalDebug((int)DebugDetalizationLevel.High, "Saving connection to file {0}", config.FileName);
            config.SetItem("SQLConnectionString", m_SQLConnectionString);
            if (!(m_SQLUser == null))
            {
                config.SetItem("SQLUser", Cryptor.Encrypt(m_SQLUser));
            }
            if ((!(m_SQLPassword == null)) && (!(m_SQLUser == null)))
            {
                config.SetItem("SQLPassword", Cryptor.Encrypt(m_SQLPassword, m_SQLUser));
            }
            config.SetItem("SQLDatabase", m_SQLDatabase);
            config.SetItem("SQLServer", m_SQLServer);
            config.Save();
        }

        public int CompareTo(object obj)
        {
            ConnectionCredentials anvil = obj as ConnectionCredentials;
            if (anvil == null)
            {
                return (-1);
            }

            return (m_ConnectionStringFinal.CompareTo(anvil.m_ConnectionStringFinal));
        }
        protected bool m_UseAsyncConnection;
        public virtual bool UseAsyncConnection
        {
            get
            {
                return m_UseAsyncConnection;
            }
            set
            {
                m_UseAsyncConnection = value;
            }
        }
        public string SQLUser
        {
            get
            {
                return m_SQLUser;
            }
        }
        public string SQLDatabase
        {
            get
            {
                return m_SQLDatabase;
            }
        }
        public string SQLServer
        {
            get
            {
                return m_SQLServer;
            }
        }
        public string SQLPassword
        {
            get
            {
                return m_SQLPassword;
            }
        }

        public string SQLConnectionString
        {
            get
            {
                return m_SQLConnectionString;
            }
        }
        public bool IsCorrect
        {
            get
            {
                if ((string.IsNullOrEmpty(m_SQLUser)) || (string.IsNullOrEmpty(m_SQLPassword)) 
                        || (string.IsNullOrEmpty(m_SQLDatabase)) || (string.IsNullOrEmpty(m_SQLServer)))
                {
                    return (false);
                }
                return (true);
            }
        }
    }

    public class ConnectionManager : ConnectionCredentials
    {
        private static readonly ArrayList s_ConnectionSlots = new ArrayList();
        private static List<ConnectionManager> s_Connections;

        protected SqlConnection m_Connection;
        protected SqlConnection m_AsyncConnection;

        protected ConnectionManager(string configFileName)
            : base(configFileName)
        {
            s_Connections = new List<ConnectionManager>();

        }

        protected ConnectionManager(string server, string database, string user, string password, string connectionString)
            : base(server, database, user, password, connectionString)
        {
            ReleaseConnection();
            s_Connections = new List<ConnectionManager>();

        }

        public static ConnectionManager Create()
        {
            return (DefaultInstance);
        }

        public static ConnectionManager Create(string configFileName)
        {
            ConnectionManager manager = new ConnectionManager(configFileName);
            ConnectionManager found = null;
            foreach (ConnectionManager entry in s_ConnectionSlots)
            {
                if (entry.CompareTo(manager) == 0)
                {
                    found = entry;
                    break;
                }
            }
            if (found == null)
            {
                s_ConnectionSlots.Add(manager);
                s_Connections.Add(manager);
            }
            else
            {
                manager = found;
            }
            return (manager);
        }

        public static ConnectionManager Create(string server, string database, string user, string password, string connectionString)
        {
            ConnectionManager found = null;
            ConnectionManager manager = new ConnectionManager(server, database, user, password, connectionString);
            foreach (ConnectionManager entry in s_ConnectionSlots)
            {
                if (entry.CompareTo(manager) == 0)
                {
                    found = entry;
                    break;
                }
            }
            if (found == null)
            {
                s_ConnectionSlots.Add(manager);
                s_Connections.Add(manager);
            }
            else
            {
                manager = found;
            }
            return (manager);
        }

        public static ConnectionManager CreateNew()
        {
            ConnectionManager manager = new ConnectionManager(null);
            s_Connections.Add(manager);
            return (manager);
        }

        public static ConnectionManager CreateNew(bool UseAsyncConnection)
        {
            ConnectionManager manager = new ConnectionManager(null);
            s_Connections.Add(manager);
            manager.UseAsyncConnection = UseAsyncConnection;
            return (manager);
        }

        public static ConnectionManager CreateNew(string server, string database, string user, string password, string connectionString)
        {
            ConnectionManager manager = new ConnectionManager(server, database, user, password, connectionString);
            s_Connections.Add(manager);
            return (manager);
        }

        public override bool UseAsyncConnection
        {
            get
            {
                return base.UseAsyncConnection;
            }
            set
            {
                if (value != base.UseAsyncConnection)
                {
                    base.UseAsyncConnection = value;
                    CloseConnection();
                    m_ConnectionStringFinal = null;
                    Connection.ConnectionString = CreateConnectionString();
                }
            }
        }

        public static ConnectionManager DefaultInstance
        {
            get
            {
                ConnectionManager anvil;
                if (s_ConnectionSlots.Count == 0)
                {
                    anvil = new ConnectionManager(null);
                    //anvil.Owner = "Default"
                    s_ConnectionSlots.Add(anvil);
                    s_Connections.Add(anvil);
                }
                anvil = (ConnectionManager)(s_ConnectionSlots[0]);
                return anvil;
            }
            set
            {
                s_ConnectionSlots.Insert(0, value);
                s_Connections.Insert(0, value);
            }
        }

        public IDbConnection Connection
        {
            get
            {
                if (m_Connection == null)
                {
                    m_Connection = new SqlConnection(ConnectionString);
                    m_Connection.StateChange += OnStateChange;
                    AttachInfoMessageHandler(m_Connection);
                }
                return (m_Connection);
            }
        }

        public void OpenConnection()
        {
            if (Connection.State != ConnectionState.Open)
            {
                Connection.Open();
            }
        }

        public void CloseConnection()
        {
            if ((!(m_Connection == null)) && (Connection.State != ConnectionState.Closed))
            {
                Connection.Close();
            }
        }

        public void ClearPool()
        {
            CloseConnection();
            if (m_Connection != null)
            {
                SqlConnection.ClearPool(m_Connection);
            }

        }

        public void ReleaseConnection()
        {
            CloseConnection();
            if (m_Connection != null)
            {
                lock(m_Connection)
                {
                    Dbg.Debug("disposing connection {0}", m_Connection.GetHashCode());
                    m_Connection.Dispose();
                }
                m_Connection = null;
            }
        }
        public static void CloseAllConnections()
        {
            foreach (ConnectionManager manager in s_Connections)
            {
                manager.CloseConnection();
            }
        }

        public static void ReleaseAllConnections()
        {
            while (s_Connections.Count > 0)
            {
                s_Connections[0].ReleaseConnection();
                s_Connections.RemoveAt(0);
            }
            while (s_ConnectionSlots.Count > 0)
            {
                s_ConnectionSlots.RemoveAt(0);
            }
        }

        private static int m_OpenConnectionsCount;
        protected static void OnStateChange(object sender, StateChangeEventArgs args)
        {
            if (args.CurrentState == ConnectionState.Open)
            {
                IDbCommand command = DbHelper.CreateSPCommand("spSetContext", ((IDbConnection)sender), null);
                DbHelper.AddParam(command, "@ContextString", "AUM"/*ApplicationSettings.ClientID*/, ParameterDirection.Input);
                DbHelper.ExecCommand(command, ((IDbConnection)sender), null, false);
                Interlocked.Increment(ref m_OpenConnectionsCount);
                Dbg.Debug(DebugDetalizationLevel.EventDebug.ToString(), "connection is opened. {0} connections is currently open", m_OpenConnectionsCount);
            }
            else if (args.CurrentState == ConnectionState.Closed)
            {
                Interlocked.Decrement(ref m_OpenConnectionsCount);
                Dbg.Debug(DebugDetalizationLevel.EventDebug.ToString(), "connection is closed. {0} connections is currently open", m_OpenConnectionsCount);
            }
            else
            {
                Dbg.Debug(DebugDetalizationLevel.EventDebug.ToString(), "connection is state is changed. Current connection state is {0}", args.CurrentState.ToString());
            }
        }
        private static void AttachInfoMessageHandler(IDbConnection cn)
        {
            ((SqlConnection)cn).InfoMessage += OnInfoMessage;
        }

        private static void OnInfoMessage(object sender, SqlInfoMessageEventArgs args)
        {

            foreach (SqlError err in args.Errors)
            {
                int ErrorLevel;
                if (err.Class <= 10)
                {
                    ErrorLevel = (int)DebugDetalizationLevel.EventDebug;
                }
                else if (err.Class < 17) //user defined errors
                {
                    ErrorLevel = (int)DebugDetalizationLevel.Low;
                }
                else
                {
                    ErrorLevel = 0;
                }
                Dbg.ConditionalDebug(ErrorLevel, "The {0} has received a severity {1}, state {2} error number {3}" + "\r\n" + "on line {4} of procedure {5} on server {6}:" + "\r\n" + "{7}", err.Source, err.Class.ToString(), err.State.ToString(), err.Number.ToString(), err.LineNumber.ToString(), err.Procedure, err.Server, err.Message);
            }
        }
        public enum ConnectionStringPart
        {
            Provider,
            DataSource,
            Database,
            Password,
            UserID,
            MARS,
            Async,
            IntegratedSecurity,
            ConnectionTimeOut
        }


        public class ConnectionStringParser
        {

            private string m_ConnectionString;
            public ConnectionStringParser(string aConnectionString)
            {
                m_ConnectionString = aConnectionString;
            }
            public string ConnectionString
            {
                get
                {
                    return m_ConnectionString;
                }
                set
                {
                    m_ConnectionString = value;
                }
            }
            private struct ConnectionStringItem
            {
                public readonly string Name;
                public readonly string Mask;
                public ConnectionStringItem(string aName, string aMask)
                {
                    Name = aName;
                    Mask = aMask;
                }
            }
            private static readonly Dictionary<ConnectionStringPart, ConnectionStringItem> m_Parts = new Dictionary<ConnectionStringPart, ConnectionStringItem>();
            private static bool m_initiated;
            private static void Init()
            {
                if (m_initiated)
                {
                    return;
                }
                m_initiated = true;
                m_Parts.Add(ConnectionStringPart.Async, new ConnectionStringItem("Asynchronous Processing", "Asynchronous\\sProcessing|async"));
                m_Parts.Add(ConnectionStringPart.DataSource, new ConnectionStringItem("Data Source", "Data\\sSource"));
                m_Parts.Add(ConnectionStringPart.Database, new ConnectionStringItem("Initial Catalog", "Initial\\sCatalog"));
                m_Parts.Add(ConnectionStringPart.MARS, new ConnectionStringItem("MultipleActiveResultSets", "MultipleActiveResultSets"));
                m_Parts.Add(ConnectionStringPart.Password, new ConnectionStringItem("Password", "Password|pwd"));
                m_Parts.Add(ConnectionStringPart.Provider, new ConnectionStringItem("Provider", "Provider"));
                m_Parts.Add(ConnectionStringPart.UserID, new ConnectionStringItem("Initial Catalog", "Initial\\sCatalog"));
                m_Parts.Add(ConnectionStringPart.IntegratedSecurity, new ConnectionStringItem("Integrated Security", "Integrated\\sSecurity"));
                m_Parts.Add(ConnectionStringPart.ConnectionTimeOut, new ConnectionStringItem("Connection TimeOut", "Connection\\sTimeOut"));
            }

            private const string m_RegExpTemplate = "(?:({0})[\\s]*=[\\s]*\"??(?<{1}>[^;\\n]+)\"??[;\\n\"]??)";
            public string Item(ConnectionStringPart index)
            {
                Init();
                if (Utils.IsEmpty(m_ConnectionString))
                {
                    return "";
                }
                Regex rExp = GetRegEx(index);
                Match m = rExp.Match(m_ConnectionString);
                if (m.Success)
                {
                    return m.Value;
                }
                return "";
            }
            public void SetItem(ConnectionStringPart index, string value)
            {
                Init();
                if (Utils.IsEmpty(m_ConnectionString))
                {
                    return;
                }
                Regex rExp = GetRegEx(index);
                Match m = rExp.Match(m_ConnectionString);
                if (m.Success)
                {
                    m_ConnectionString = rExp.Replace(m_ConnectionString, string.Format("{0}={1}", m_Parts[index].Name, value));
                }
                else
                {
                    if (!m_ConnectionString.Trim().EndsWith(";"))
                    {
                        m_ConnectionString += ";";
                    }
                    m_ConnectionString += string.Format("{0}={1};", m_Parts[index].Name, value);
                }
            }
            private static Regex GetRegEx(ConnectionStringPart index)
            {
                return new Regex(string.Format(m_RegExpTemplate, m_Parts[index].Mask, index));
            }

        }
    }
}

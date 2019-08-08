using System;
using AUM.Configuration;
using System.Data;
using AUM.Core;
using AUM.Diagnostics;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Threading;

namespace AUM.db
{
  using Core.Diagnostics;


  public class StoredProcParamsCache
    {
        private static readonly Dictionary<string, DataTable> m_cache = new Dictionary<string, DataTable>();

        private static DataTable CreateItem(string name, IDbConnection conn, IDbTransaction trans)
        {
            IDbCommand command = DbHelper.CreateCommand("select * from INFORMATION_SCHEMA.PARAMETERS where SPECIFIC_NAME = \'" + name + "\'", conn, trans);
            command.CommandTimeout = BaseSettings.SqlCommandTimeout;
            DbDataAdapter da = DbHelper.CreateAdapter(command, false);
            DataTable table = new DataTable();
            Dbg.Debug("Receiving parameters for procedure {0}.Working thread ID - {1}, name - {2}", name, Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.Name);
            lock (command.Connection)
            {
                try
                {
                    da.Fill(table);
                    Dbg.Debug("Parameters for procedure {0} are received. Parameters count - {1}", name, table.Rows.Count);
                }
                catch (Exception ex)
                {
                    Dbg.Debug("Error during retreving procedure {0} parameters. Working thread ID - {1}, name - {2} : {3}", name, Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.Name, ex);
                    Dbg.Trace(null);
                    throw;
                }
            }
            foreach (DataRow row in table.Rows)
            {
                Dbg.Debug("    {0}", row["PARAMETER_NAME"]);
            }
            return table;
        }

        private static DataTable Item(string name, IDbConnection conn, IDbTransaction trans)
        {
            lock(m_cache)
            {
                if (m_cache.ContainsKey(name))
                {
                    return m_cache[name];
                }
                DataTable table = CreateItem(name, conn, trans);
                m_cache.Add(name, table);
                return table;
            }
        }

        private static SqlParameter CreateParameter(DataRow row)
        {
            SqlParameter param = new SqlParameter();

            param.ParameterName = row["PARAMETER_NAME"].ToString();

            switch (row["PARAMETER_MODE"].ToString().ToLowerInvariant())
            {
                case "in":
                    param.Direction = ParameterDirection.Input;
                    break;
                case "inout":
                    param.Direction = ParameterDirection.InputOutput;
                    param.Value = DBNull.Value;
                    break;
                default:
                    param.Direction = ParameterDirection.Input;
                    break;
            }
            
            switch (row["DATA_TYPE"].ToString().ToLowerInvariant())
            {
                case "nvarchar":
                    param.SqlDbType = SqlDbType.NVarChar;
                    break;
                case "datetime":
                    param.SqlDbType = SqlDbType.DateTime;
                    break;
                case "bit":
                    param.SqlDbType = SqlDbType.Bit;
                    break;
                case "money":
                    param.SqlDbType = SqlDbType.Money;
                    break;
                case "float":
                    param.SqlDbType = SqlDbType.Float;
                    break;
                case "int":
                    param.SqlDbType = SqlDbType.Int;
                    break;
                case "bigint":
                    param.SqlDbType = SqlDbType.BigInt;
                    break;
                case "uniqueidentifier":
                    param.SqlDbType = SqlDbType.UniqueIdentifier;
                    break;
            }

            if (row["CHARACTER_MAXIMUM_LENGTH"]!=DBNull.Value)
            {
                param.Size = Convert.ToInt32(row["CHARACTER_MAXIMUM_LENGTH"]);
            }
            param.Value = DBNull.Value;

            return param;
        }

        private static IDataParameter CreateReturnParameter()
        {
            SqlParameter resultParam = new SqlParameter("RETURN_VALUE", SqlDbType.Int);
            resultParam.Direction = ParameterDirection.ReturnValue;
            return resultParam;
        }

        public static void CreateParameters(IDbCommand cmd, Dictionary<string, object> paramValues)
        {
            string[] split_names = cmd.CommandText.Split('.');
            DataTable tbl = Item(split_names[split_names.Length - 1], cmd.Connection, cmd.Transaction);
            foreach (DataRow row in tbl.Rows)
            {
                SqlParameter param = CreateParameter(row);
                if (paramValues != null && paramValues.ContainsKey(param.ParameterName) && !Utils.IsEmpty(paramValues[param.ParameterName]))
                {
                    param.Value = paramValues[param.ParameterName];
                }
                cmd.Parameters.Add(param);
            }
            cmd.Parameters.Add(CreateReturnParameter());
        }
        public static bool Contains(string procName)
        {
            string[] split_names = procName.Split('.');
            return m_cache.ContainsKey(split_names[split_names.Length - 1]);
        }
    }
}

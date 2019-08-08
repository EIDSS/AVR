using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using AUM.Core;
using AUM.Diagnostics;

namespace AUM.db
{
  using Core.Diagnostics;


  public class DbHelper
    {
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Executes <b>IDbCommand</b> that should not return any data.
        /// </summary>
        /// <param name="cmd">
        /// Instance of <b>IDbCommand</b> to execute
        /// </param>
        /// <param name="sqlConnection">
        /// connection object that should be used for this command
        /// </param>
        /// <param name="Transaction">
        /// Optional <b>IDbTransaction</b> object. If it is passed, the command is executed as part of this
        /// transaction and entire transaction will be roll backed if execution fails.
        /// </param>
        /// <param name="ThrowExceptionOnError">
        /// </param>
        /// <returns>
        /// <i>ErrorMessage</i> object if error occurs during command execution or <b>Nothing</b> if command executed successfully.
        /// </returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[Mike]	06.04.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static ErrorMessage ExecCommand(IDbCommand cmd, IDbConnection sqlConnection, IDbTransaction Transaction, bool ThrowExceptionOnError)
        {
            if (cmd == null)
            {
                return new ErrorMessage(StandardError.InvalidParameter.ToString());
            }
            bool CloseConnection = false;
            if (sqlConnection == null)
            {
                sqlConnection = ConnectionManager.DefaultInstance.Connection;
            }
            if (Transaction != null && Transaction.Connection != null)
            {
                cmd.Transaction = Transaction;
                cmd.Connection = Transaction.Connection;
            }
            else
            {
                cmd.Connection = sqlConnection;
            }
            lock (cmd.Connection)
            {
                try
                {
                    if (cmd.Connection.State != ConnectionState.Open)
                    {
                        cmd.Connection.Open();
                        CloseConnection = true;
                    }
                    cmd.ExecuteNonQuery();
                    return null;
                }
                catch (SqlException e)
                {
                    if (ThrowExceptionOnError)
                    {
                        Dbg.Debug( "sql command error: {0}", e);
                        throw;
                    }
                    if (e.Number == 15211)
                    {
                        return new ErrorMessage(StandardError.InvalidOldPassword.ToString());
                    }
                    else if (e.Number == 18456)
                    {
                        return new ErrorMessage(StandardError.InvalidLogin.ToString());
                    } //this is a workaround for sp4 bug
                    else if ((e.Number == 229) || (e.Number == 916))
                    {
                        //drop SELECT permission denied on object 'sysjobs', database 'msdb', owner 'dbo'
                        return null;
                    }
                    else
                    {
                       Dbg.Debug( "sql command error: {0}", e);
                        if (cmd.CommandType == CommandType.StoredProcedure)
                        {
                            return new ErrorMessage(StandardError.StoredProcedureError, e);
                        }
                        else
                        {
                            return new ErrorMessage(StandardError.SqlQueryError, e);
                        }
                    }
                }
                catch (Exception e)
                {
                    Dbg.Debug( "sql command error: {0}", e);
                    if (ThrowExceptionOnError)
                    {
                        throw;
                    }
                    if (cmd.CommandType == CommandType.StoredProcedure)
                    {
                        return new ErrorMessage(StandardError.StoredProcedureError, e);
                    }
                    else
                    {
                        return new ErrorMessage(StandardError.SqlQueryError, e);
                    }
                }
                finally
                {
                    if ((Transaction == null || Transaction.Connection == null) && CloseConnection)
                    {
                        cmd.Connection.Close();
                    }
                }
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Executes query defined by the <b>IDbCommand</b> object, and returns the first column of the first row in the result set returned by the query. Extra columns or rows are ignored.
        /// </summary>
        /// <param name="cmd">
        /// <b>IDbCommand</b> object containing query to execute
        /// </param>
        /// <param name="sqlConnection">
        /// connection object that should be used for this command
        /// </param>
        /// <param name="errMsg">
        /// returns <i>ErrorMessage</i> object if error occurs during command execution or <b>Nothing</b> if command executed successfully.
        /// </param>
        /// <param name="Transaction">
        /// Optional <b>IDbTransaction</b> object. If it is passed, the command is executed as part of this
        /// transaction and entire transaction will be roll backed if execution fails.
        /// </param>
        /// <param name="ThrowExceptionOnError">
        /// </param>
        /// <returns>
        /// The first column of the first row in the result set, or <b>Nothing</b> if the result set is empty.
        ///</returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[Mike]	06.04.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static object ExecScalar(IDbCommand cmd, IDbConnection sqlConnection, ref ErrorMessage errMsg, IDbTransaction Transaction, bool ThrowExceptionOnError)
        {

            if (cmd == null)
            {
                return new ErrorMessage(StandardError.InvalidParameter.ToString());
            }
            if (sqlConnection == null)
            {
                sqlConnection = ConnectionManager.DefaultInstance.Connection;
            }
            if (Transaction != null && Transaction.Connection != null)
            {
                cmd.Transaction = Transaction;
                cmd.Connection = Transaction.Connection;
            }
            else
            {
                cmd.Connection = sqlConnection;
            }

            lock (cmd.Connection)
            {
                try
                {
                    if (cmd.Connection.State != ConnectionState.Open)
                    {
                        cmd.Connection.Open();
                    }
                    return cmd.ExecuteScalar();
                }
                catch (Exception e)
                {
                    if (ThrowExceptionOnError)
                    {
                        throw;
                    }
                    if (cmd.CommandType == CommandType.StoredProcedure)
                    {
                        errMsg = new ErrorMessage(StandardError.StoredProcedureError, e);
                    }
                    else
                    {
                        errMsg = new ErrorMessage(StandardError.SqlQueryError, e);
                    }
                    return null;
                }
                finally
                {
                    if (Transaction == null || Transaction.Connection == null)
                    {
                        cmd.Connection.Close();
                    }
                }
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Creates <i>IDbCommand</i> object using <i>SqlText</i> as SQL query that should be executed.
        /// Use this method to create <i>IDbCommand</i> instances that are independent
        /// from database currently used by the system.
        /// </summary>
        /// <param name="SqlText">
        /// the text of SQL query for the <i>IDbCommand</i> object
        /// </param>
        /// <param name="Connection">
        /// <i>IDbConnection</i> for the created command
        /// </param>
        /// <param name="Transaction">
        /// Optional <b>IDbTransaction</b> object for the created command. If transaction
        /// is specified, it will be roll backed if the error during command execution occurred.
        /// </param>
        /// <returns>
        /// New <i>IDbCommand</i> object
        /// </returns>
        /// <remarks>
        /// In general this method can create the command of any type, but current implementation
        /// creates <b>SqlCommand</b> instances only.
        /// Using this method is more preferable than using direct command constructor call because this
        /// allows concentrating all database specific codes in one place.
        /// </remarks>
        /// <history>
        /// 	[Mike]	07.04.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static IDbCommand CreateCommand(string SqlText, IDbConnection Connection, IDbTransaction Transaction)
        {
            SqlConnection cn;
            if (Connection != null)
            {
                cn = (SqlConnection)Connection;
            }
            else
            {
                cn = null;
            }
            if (Transaction != null)
            {
                if (Transaction.Connection != null)
                {
                    cn = (SqlConnection)Transaction.Connection;
                }
            }
            SqlCommand cmd = new SqlCommand(SqlText, cn, ((SqlTransaction)Transaction));
            cmd.CommandTimeout = 300;
            return cmd;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Creates <i>IDbCommand</i> object using <i>SqlText</i> as name of stored procedure that should be executed.
        /// Use this method to create <i>IDbCommand</i> instances that are independent
        /// from database currently used by the system.
        /// </summary>
        /// <param name="SqlText">
        /// the name of stored procedure.
        /// </param>
        /// <param name="Connection">
        /// <i>IDbConnection</i> for the created command
        /// </param>
        /// <param name="Transaction">
        /// Optional <b>IDbTransaction</b> object for the created command. If transaction
        /// is specified, it will be roll backed if the error during command execution occurred.
        /// </param>
        /// <returns>
        /// New <i>IDbCommand</i> object
        /// </returns>
        /// <remarks>
        /// In general this method can create the command of any type, but current implementation
        /// creates <b>SqlCommand</b> instances only.
        /// Using this method is more preferable than using direct command constructor call because this
        /// allows concentrating all database specific codes in one place.
        /// </remarks>
        /// <history>
        /// 	[Mike]	07.04.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static IDbCommand CreateSPCommand(string SqlText, IDbConnection Connection, IDbTransaction Transaction)
        {
            SqlConnection cn = (SqlConnection)Connection;
            if (Transaction != null)
            {
                if (Transaction.Connection != null)
                {
                    cn = (SqlConnection)Transaction.Connection;
                }
            }
            SqlCommand cmd = new SqlCommand(SqlText, cn, ((SqlTransaction)Transaction));
            cmd.CommandTimeout = 300;
            cmd.CommandType = CommandType.StoredProcedure;
            return cmd;
        }
        public static IDbCommand CreateSPCommandWithParams(string SqlText, IDbConnection Connection, IDbTransaction Transaction, Dictionary<string, object> paramValues)
        {
            IDbCommand cmd = CreateSPCommand(SqlText, Connection, Transaction);
            StoredProcParamsCache.CreateParameters(cmd, paramValues);
            return cmd;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Creates the instance of <b>DbDataAdapter</b> using passed command as <b>SelectCommand</b>.
        /// </summary>
        /// <param name="cmd">
        /// <b>IDbCommand</b> object that will be used as <b>SelectCommand</b> for new <b>DbDataAdapter</b>
        /// </param>
        /// <param name="UseCommandBuilder">
        /// If <b>True</b>, creates <b>Insert</b>, <b>Update</b> and <b>Delete</b> commands for data adapter using passed command as the source Select command.
        /// </param>
        /// <returns>
        /// new instance of <b>DbDataAdapter</b> object
        /// </returns>
        /// <remarks>
        /// In general this method can create the <b>DbDataAdapter</b> of any type, but current implementation
        /// creates <b>SqlDataAdapter</b> instances only.
        /// Using this method is more preferable than using direct data adapter constructor call because this
        /// allows concentrating all database specific codes in one place.
        /// </remarks>
        /// <history>
        /// 	[Mike]	07.04.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static DbDataAdapter CreateAdapter(IDbCommand cmd, bool UseCommandBuilder)
        {
            if (cmd == null)
            {
                return null;
            }
            SqlDataAdapter da = new SqlDataAdapter((SqlCommand)cmd);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            if (UseCommandBuilder)
            {
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.InsertCommand = cb.GetInsertCommand();
                da.DeleteCommand = cb.GetDeleteCommand();
                da.UpdateCommand = cb.GetUpdateCommand();
            }
            return da;
        }


        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Creates the instance of <b>DbDataAdapter</b> using passed sql query as base for <b>SelectCommand</b>.
        /// </summary>
        /// <param name="SelectSql">
        /// the sql query that should be used for creating <b>SelectCommand</b>.
        /// </param>
        /// <param name="Connection">
        /// <i>IDbConnection</i> for the created <b>SelectCommand</b>
        /// </param>
        /// <param name="UseCommandBuilder">
        /// If <b>True</b>, creates <b>Insert</b>, <b>Update</b> and <b>Delete</b> commands for data adapter using passed command as the source Select command.
        /// </param>
        /// <param name="Transaction">
        /// Optional <b>IDbTransaction</b> object for the created <b>SelectCommand</b>. If transaction
        /// is specified, it will be roll backed if the error during command execution occurred.
        /// </param>
        /// <returns>
        /// new instance of <b>DbDataAdapter</b> object
        /// </returns>
        /// <remarks>
        /// In general this method can create the <b>DbDataAdapter</b> of any type, but current implementation
        /// creates <b>SqlDataAdapter</b> instances only.
        /// Using this method is more preferable than using direct data adapter constructor call because this
        /// allows concentrating all database specific codes in one place.
        /// </remarks>
        /// <history>
        /// 	[Mike]	07.04.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static DbDataAdapter CreateAdapter(string SelectSql, IDbConnection Connection, bool UseCommandBuilder, IDbTransaction Transaction)
        {
            IDbCommand cmd = CreateCommand(SelectSql, Connection, Transaction);
            return CreateAdapter(cmd, UseCommandBuilder);
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Creates the instance of <b>DbDataAdapter</b> using columns of <b>DataTable</b> as source for generating <b>SelectCommand</b>.
        /// </summary>
        /// <param name="dt">
        /// <b>DataTable</b> object which structure will be used as source for generating data adapter <b>SelectCommand</b>.
        /// </param>
        /// <param name="TableName">
        /// the name of source table in the database
        /// </param>
        /// <param name="Connection">
        /// <i>IDbConnection</i> for the created <b>SelectCommand</b>
        /// </param>
        /// <param name="UseCommandBuilder">
        /// If <b>True</b>, creates <b>Insert</b>, <b>Update</b> and <b>Delete</b> commands for data adapter using passed command as the source Select command.
        /// </param>
        /// <param name="Transaction1">
        /// Optional <b>IDbTransaction</b> object for the created <b>SelectCommand</b>. If transaction
        /// is specified, it will be roll backed if the error during command execution occurred.
        /// </param>
        /// <returns>
        /// new instance of <b>DbDataAdapter</b> object
        /// </returns>
        /// <remarks>
        /// This method generates Select SQL query using the names of editable <b>DataTable</b> columns to construct SELECT part of the query
        /// and <i>TableName</i> parameter for FROM clause. No WHERE clause is used for the generated command.
        /// Usually this method is used with <i>UseCommandBuilder</i> parameter set to <b>True</b> to create data adapter
        /// for posting data from passed <b>DataTable</b> into the database.
        /// In general this method can create the <b>DbDataAdapter</b> of any type, but current implementation
        /// creates <b>SqlDataAdapter</b> instances only.
        /// Using this method is more preferable than using direct data adapter constructor call because this
        /// allows concentrating all database specific codes in one place.
        /// </remarks>
        /// <history>
        /// 	[Mike]	07.04.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static DbDataAdapter CreateAdapter(DataTable dt, string TableName, IDbConnection Connection, bool UseCommandBuilder, IDbTransaction Transaction1)
        {
            string Fields = "";
            foreach (DataColumn col in dt.Columns)
            {
                if (col.ReadOnly == false)
                {
                    if (Fields.Length == 0)
                    {
                        Fields = col.ColumnName;
                    }
                    else
                    {
                        Fields += string.Format(", {0}", col.ColumnName);
                    }
                }
            }
            string sql = string.Format("Select {0} from {1}", Fields, TableName);
            return CreateAdapter(sql, Connection, UseCommandBuilder, Transaction1);
        }
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Adds new parameter to the <b>IDbCommand</b> parameters list
        /// </summary>
        /// <param name="cmd">
        /// instance of <b>IDbCommand</b> to which the parameter should be added
        /// </param>
        /// <param name="ParamName">
        /// the parameter name
        /// </param>
        /// <param name="ParamValue">
        /// the parameter value
        /// </param>
        /// <param name="Direction">
        /// the parameter direction
        /// </param>
        /// <returns>
        /// Returns instance of created parameter object.
        /// </returns>
        /// <remarks>
        /// This function has no error handling inside, so exception will be thrown if the error occurs inside the function.
        /// Use this function if you want process exceptions outside of function body. The <b>Type</b> of parameter is defined
        /// by the <i>ParamValue</i> object <b>Type</b>, so you should not use this function with <i>ParamValue</i>
        /// that is set to <b>Nothing</b> or <b>DBNull.Value</b>, use SetTypedParam function instead in this case.
        /// In general this function can create the parameter object of any type, but current implementation
        /// creates <b>SqlParameter</b> instances only.
        /// Using this function is more preferable than using direct parameter constructor call because this
        /// allows concentrating all database specific codes in one place.
        /// </remarks>
        /// <history>
        /// 	[Mike]	10.04.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static object AddParam(IDbCommand cmd, string ParamName, object ParamValue, ParameterDirection Direction)
        {
            if (cmd == null)
            {
                return null;
            }
            if (ParamValue == null)
            {
                ParamValue = DBNull.Value;
            }
            SqlParameter p = new SqlParameter(ParamName, ParamValue);
            p.Direction = Direction;
            cmd.Parameters.Add(p);
            return p;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Sets the value of specific <b>IDbCommand</b> parameter
        /// </summary>
        /// <param name="cmd">
        /// instance of <b>IDbCommand</b> which parameter value should be modified
        /// </param>
        /// <param name="ParamName">
        /// the parameter name
        /// </param>
        /// <param name="ParamValue">
        /// the parameter value
        /// </param>
        /// <param name="Direction">
        /// the parameter direction
        /// </param>
        /// <returns>
        /// Returns instance of the parameter object.
        /// </returns>
        /// <remarks>
        /// If the parameter with name <i>ParamName</i> doesn't exist it is added to the command parameters list,
        /// in other case the attributes of existing parameter is modified. The <b>Type</b> of parameter is defined
        /// by the <i>ParamValue</i> object <b>Type</b>, so you should not use this function with <i>ParamValue</i>
        /// that is set to <b>Nothing</b> or <b>DBNull.Value</b>, use SetTypedParam function instead in this case.
        /// In general this function can work with the parameter object of any type, but current implementation
        /// creates <b>SqlParameter</b> instances only.
        /// Using this function is more preferable than using direct parameter constructor call because this
        /// allows concentrating all database specific codes in one place.
        /// </remarks>
        /// <history>
        /// 	[Mike]	10.04.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static object SetParam(IDbCommand cmd, string ParamName, object ParamValue, ParameterDirection Direction)
        {
            if (cmd == null)
                return null;
            bool parameterExists = cmd.Parameters.Contains(ParamName);
            object p = SetParam(cmd, ParamName, ParamValue);
            if (!parameterExists && p != null)
                ((SqlParameter)p).Direction = Direction;
            return p;
        }
        public static object SetParam(IDbCommand cmd, string ParamName, object ParamValue)
        {
            if (cmd == null)
            {
                return null;
            }
            if (ParamValue == null)
            {
                ParamValue = DBNull.Value;
            }
            SqlParameter p;
            if (cmd.Parameters.Contains(ParamName))
            {
                p = (SqlParameter)(cmd.Parameters[ParamName]);
                p.Value = ParamValue;
            }
            else
            {
                p = new SqlParameter(ParamName, ParamValue);
                cmd.Parameters.Add(p);
            }
            return p;
        }
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Sets the value of specific <b>IDbCommand</b> parameter to the <b>DBNull.Value</b>
        /// </summary>
        /// <param name="cmd">
        /// instance of <b>IDbCommand</b> which parameter value should be modified
        /// </param>
        /// <param name="ParamName">
        /// the parameter name
        /// </param>
        /// <param name="ParamType">
        /// the <b>SqlDbType</b> of the parameter
        /// </param>
        /// <param name="Direction">
        /// the parameter direction
        /// </param>
        /// <returns>
        /// Returns instance of the parameter object.
        /// </returns>
        /// <remarks>
        /// If the parameter with name <i>ParamName</i> doesn't exist it is added to the command parameters list,
        /// in other case the value of existing parameter is set to <b>DBNull.Value</b>.
        /// In general this function can work with the parameter object of any type, but current implementation
        /// creates <b>SqlParameter</b> instances only.
        /// Using this function is more preferable than using direct parameter constructor call because this
        /// allows concentrating all database specific codes in one place.
        /// </remarks>
        /// <history>
        /// 	[Mike]	10.04.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static object SetTypedParam(IDbCommand cmd, string ParamName, SqlDbType ParamType, ParameterDirection Direction)
        {
            if (cmd == null)
            {
                return null;
            }
            SqlParameter p;
            if (cmd.Parameters.Contains(ParamName))
            {
                p = (SqlParameter)(cmd.Parameters[ParamName]);
                p.Value = DBNull.Value;
            }
            else
            {
                return AddTypedParam(cmd, ParamName, ParamType, Direction);
            }
            return p;
        }


        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Adds new parameter to the <b>IDbCommand</b> parameters list
        /// </summary>
        /// <param name="cmd">
        /// instance of <b>IDbCommand</b> to which the parameter should be added
        /// </param>
        /// <param name="ParamName">
        /// the parameter name
        /// </param>
        /// <param name="ParamValue">
        /// the parameter value
        /// </param>
        /// <param name="errMsg"></param>
        /// <param name="Direction">
        /// the parameter direction
        /// </param>
        /// <returns>
        /// Returns instance of created parameter object.
        /// </returns>
        /// <remarks>
        /// This function handles the error inside and returns the error in <i>errMsg</i> parameter. Check <i>errMsg</i> parameter
        /// to find that error occurs inside the function.
        /// The <b>Type</b> of parameter is defined
        /// by the <i>ParamValue</i> object <b>Type</b>, so you should not use this function with <i>ParamValue</i>
        /// that is set to <b>Nothing</b> or <b>DBNull.Value</b>, use SetTypedParam function instead in this case.
        /// In general this function can create the parameter object of any type, but current implementation
        /// creates <b>SqlParameter</b> instances only.
        /// Using this function is more preferable than using direct parameter constructor call because this
        /// allows concentrating all database specific codes in one place.
        /// </remarks>
        /// <history>
        /// 	[Mike]	10.04.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static object AddParam(IDbCommand cmd, string ParamName, object ParamValue, ref ErrorMessage errMsg, ParameterDirection Direction)
        {
            try
            {
                return AddParam(cmd, ParamName, ParamValue, Direction);
            }
            catch (Exception ex)
            {
                errMsg = new ErrorMessage(StandardError.CreateParameterError, ex);
            }
            return null;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Adds the new parameter of specific type to the <b>IDbCommand</b> object and sets it to the <b>DbNull.Value</b>
        /// </summary>
        /// <param name="cmd">
        /// instance of <b>IDbCommand</b> which parameter value should be modified
        /// </param>
        /// <param name="ParamName">
        /// the parameter name
        /// </param>
        /// <param name="ParamType">
        /// the <b>SqlDbType</b> of the parameter
        /// </param>
        /// <param name="Direction">
        /// the parameter direction
        /// </param>
        /// <returns>
        /// Returns instance of created parameter object.
        /// </returns>
        /// <remarks>
        /// This function should be called if new parameter without defined value should be added.
        /// There is no error handling inside this function, so exception will be thrown if the error occurs inside the function.
        /// Use this function if you want process exceptions outside of function body.
        /// In general this function can create the parameter object of any type, but current implementation
        /// creates <b>SqlParameter</b> instances only.
        /// Using this function is more preferable than using direct parameter constructor call because this
        /// allows concentrating all database specific codes in one place.
        /// </remarks>
        /// <history>
        /// 	[Mike]	10.04.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static object AddTypedParam(IDbCommand cmd, string ParamName, SqlDbType ParamType, ParameterDirection Direction)
        {
            if (cmd == null)
            {
                return null;
            }
            SqlParameter p = new SqlParameter(ParamName, ParamType);
            p.Direction = Direction;
            p.Value = DBNull.Value;
            p.IsNullable = true;
            cmd.Parameters.Add(p);
            return p;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Adds the new parameter of specific type to the <b>IDbCommand</b> object and sets it to the <b>DbNull.Value</b>
        /// </summary>
        /// <param name="cmd">
        /// instance of <b>IDbCommand</b> which parameter value should be modified
        /// </param>
        /// <param name="ParamName">
        /// the parameter name
        /// </param>
        /// <param name="ParamType">
        /// the <b>SqlDbType</b> of the parameter
        /// </param>
        /// <param name="strSrcColumn">
        /// the column in the related <b>DataTable</b> to which this parameter should be linked
        /// </param>
        /// <param name="Direction">
        /// the parameter direction
        /// </param>
        /// <returns>
        /// Returns instance of created parameter object.
        /// </returns>
        /// <remarks>
        /// This function should be called if new parameter without defined value should be added and you want to link the parameter with the specific column in the related <b>DataTable</b>.
        /// There is no error handling inside this function, so exception will be thrown if the error occurs inside the function.
        /// Use this function if you want process exceptions outside of function body.
        /// In general this function can create the parameter object of any type, but current implementation
        /// creates <b>SqlParameter</b> instances only.
        /// Using this function is more preferable than using direct parameter constructor call because this
        /// allows concentrating all database specific codes in one place.
        /// </remarks>
        /// <history>
        /// 	[Mike]	12.04.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static object AddTypedParam(IDbCommand cmd, string ParamName, SqlDbType ParamType, string strSrcColumn, ParameterDirection Direction)
        {
            if (cmd == null)
            {
                return null;
            }
            SqlParameter p = new SqlParameter(ParamName, ParamType);
            p.Direction = Direction;
            p.Value = DBNull.Value;
            p.IsNullable = true;
            p.SourceColumn = strSrcColumn;
            cmd.Parameters.Add(p);
            return p;
        }

        public static object AddTypedParam(IDbCommand cmd, string ParamName, SqlDbType ParamType, int Size, string strSrcColumn, ParameterDirection Direction)
        {
            if (cmd == null)
            {
                return null;
            }
            SqlParameter p = new SqlParameter(ParamName, ParamType, Size);
            p.Direction = Direction;
            p.Value = DBNull.Value;
            p.IsNullable = true;
            p.SourceColumn = strSrcColumn;
            cmd.Parameters.Add(p);
            return p;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Adds the new parameter of specific type to the <b>IDbCommand</b> object and sets it to the <b>DbNull.Value</b>
        /// </summary>
        /// <param name="cmd">
        /// instance of <b>IDbCommand</b> which parameter value should be modified
        /// </param>
        /// <param name="ParamName">
        /// the parameter name
        /// </param>
        /// <param name="ParamType">
        /// the <b>SqlDbType</b> of the parameter
        /// </param>
        /// <param name="strSrcColumn">
        /// the column in the related <b>DataTable</b> to which this parameter should be linked
        /// </param>
        /// <param name="SourceType">
        /// the source of parameter like current, original, etc
        /// </param>
        /// <param name="Direction">
        /// the parameter direction
        /// </param>
        /// <returns>
        /// Returns instance of created parameter object.
        /// </returns>
        /// <remarks>
        /// This function should be called if new parameter without defined value should be added and you want to link the parameter with the specific column in the related <b>DataTable</b>.
        /// There is no error handling inside this function, so exception will be thrown if the error occurs inside the function.
        /// Use this function if you want process exceptions outside of function body.
        /// In general this function can create the parameter object of any type, but current implementation
        /// creates <b>SqlParameter</b> instances only.
        /// Using this function is more preferable than using direct parameter constructor call because this
        /// allows concentrating all database specific codes in one place.
        /// </remarks>
        /// <history>
        /// 	[Andrey]	09.03.2007	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static object AddTypedParam(IDbCommand cmd, string ParamName, SqlDbType ParamType, string strSrcColumn, DataRowVersion SourceType, ParameterDirection Direction)
        {
            if (cmd == null)
            {
                return null;
            }
            SqlParameter p = new SqlParameter(ParamName, ParamType);
            p.Direction = Direction;
            p.Value = DBNull.Value;
            p.IsNullable = true;
            p.SourceColumn = strSrcColumn;
            p.SourceVersion = SourceType;
            cmd.Parameters.Add(p);
            return p;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Adds the new parameter of specific type to the <b>IDbCommand</b> object and sets it to the <b>DbNull.Value</b> returning <i>ErrorMessage</i> if error occurred.
        /// </summary>
        /// <param name="cmd">
        /// instance of <b>IDbCommand</b> which parameter value should be modified
        /// </param>
        /// <param name="ParamName">
        /// the parameter name
        /// </param>
        /// <param name="ParamType">
        /// the <b>SqlDbType</b> of the parameter
        /// </param>
        /// <param name="errMsg">
        /// returns <i>ErrorMessage</i> object if error occur or <b>Nothing</b> in other case.
        /// </param>
        /// <param name="Direction">
        /// the parameter direction
        /// </param>
        /// <returns>
        /// Returns instance of created parameter object.
        /// </returns>
        /// <remarks>
        /// This function should be called if new parameter without defined value should be added.
        /// In general this function can create the parameter object of any type, but current implementation
        /// creates <b>SqlParameter</b> instances only.
        /// Using this function is more preferable than using direct parameter constructor call because this
        /// allows concentrating all database specific codes in one place.
        /// </remarks>
        /// <history>
        /// 	[Mike]	12.04.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static object AddTypedParam(IDbCommand cmd, string ParamName, SqlDbType ParamType, ref ErrorMessage errMsg, ParameterDirection Direction)
        {
            try
            {
                return AddTypedParam(cmd, ParamName, ParamType, Direction);
            }
            catch (Exception ex)
            {
                errMsg = new ErrorMessage(StandardError.CreateParameterError, ex);
            }
            return null;
        }
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Adds the new parameter of specific type and size to the <b>IDbCommand</b> object and sets it to the <b>DbNull.Value</b>
        /// </summary>
        /// <param name="cmd">
        /// instance of <b>IDbCommand</b> which parameter value should be modified
        /// </param>
        /// <param name="ParamName">
        /// the parameter name
        /// </param>
        /// <param name="ParamType">
        /// the <b>SqlDbType</b> of the parameter
        /// </param>
        /// <param name="aSize">
        /// size of the created parameter
        /// </param>
        /// <param name="Direction">
        /// the parameter direction
        /// </param>
        /// <returns>
        /// Returns instance of created parameter object.
        /// </returns>
        /// <remarks>
        /// This function should be called if new parameter without defined value should be added and not default size for this parameter type should be used.
        /// There is no error handling inside this function, so exception will be thrown if the error occurs inside the function.
        /// Use this function if you want process exceptions outside of function body.
        /// In general this function can create the parameter object of any type, but current implementation
        /// creates <b>SqlParameter</b> instances only.
        /// Using this function is more preferable than using direct parameter constructor call because this
        /// allows concentrating all database specific codes in one place.
        /// </remarks>
        /// <history>
        /// 	[Mike]	12.04.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static object AddTypedParam(IDbCommand cmd, string ParamName, SqlDbType ParamType, int aSize, ParameterDirection Direction)
        {
            if (cmd == null)
            {
                return null;
            }
            SqlParameter p = new SqlParameter(ParamName, ParamType);
            p.Direction = Direction;
            p.Value = DBNull.Value;
            p.Size = aSize;
            cmd.Parameters.Add(p);
            return p;
        }

        /// -----------------------------------------------------------------------------
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Adds the new parameter of specific type and size to the <b>IDbCommand</b> object and sets it to the <b>DbNull.Value</b>
        /// </summary>
        /// <param name="cmd">
        /// instance of <b>IDbCommand</b> which parameter value should be modified
        /// </param>
        /// <param name="ParamName">
        /// the parameter name
        /// </param>
        /// <param name="ParamType">
        /// the <b>SqlDbType</b> of the parameter
        /// </param>
        /// <param name="aSize">
        /// size of the created parameter
        /// </param>
        /// <param name="errMsg">
        /// returns <i>ErrorMessage</i> object if error occur or <b>Nothing</b> in other case.
        /// </param>
        /// <param name="Direction">
        /// the parameter direction
        /// </param>
        /// <returns>
        /// Returns instance of created parameter object.
        /// </returns>
        /// <remarks>
        /// This function should be called if new parameter without defined value should be added and not default size for this parameter type should be used.
        /// In general this function can create the parameter object of any type, but current implementation
        /// creates <b>SqlParameter</b> instances only.
        /// Using this function is more preferable than using direct parameter constructor call because this
        /// allows concentrating all database specific codes in one place.
        /// </remarks>
        /// <history>
        /// 	[Mike]	12.04.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static object AddTypedParam(IDbCommand cmd, string ParamName, SqlDbType ParamType, int aSize, ref ErrorMessage errMsg, ParameterDirection Direction)
        {
            try
            {
                return AddTypedParam(cmd, ParamName, ParamType, aSize, Direction);
            }
            catch (Exception ex)
            {
                errMsg = new ErrorMessage(StandardError.CreateParameterError, ex);
            }
            return null;
        }



        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Returns the of specified parameter from <b>IDbCommand</b> parameters list
        /// </summary>
        /// <param name="cmd">
        /// instance of <b>IDbCommand</b> which parameter should be retrieved
        /// </param>
        /// <param name="ParamName">
        /// the name of parameter to return
        /// </param>
        /// <returns>
        /// returns the parameter defined by <i>ParamName</i>.
        /// </returns>
        /// <remarks>
        /// No error processing is performed inside this method. If you pass the <i>ParamName</i>
        /// that points to the absent parameter the exception will be thrown.
        /// </remarks>
        /// <history>
        /// 	[Mike]	12.04.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static object GetParam(IDbCommand cmd, string ParamName)
        {
            if (cmd == null)
            {
                return null;
            }
            return cmd.Parameters[ParamName];
        }
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Returns the value stored in the specific parameter of <i>IDbCommand</i> object.
        /// </summary>
        /// <param name="cmd">
        /// instance of <b>IDbCommand</b> which parameter value should be retrieved
        /// </param>
        /// <param name="ParamName">
        /// the name of parameter to return
        /// </param>
        /// <returns>
        /// returns the value of parameter defined by <i>ParamName</i>.
        /// </returns>
        /// <remarks>
        /// No error processing is performed inside this method. If you pass the <i>ParamName</i>
        /// that points to the absent parameter the exception will be thrown.
        /// </remarks>
        /// <history>
        /// 	[Mike]	12.04.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static object GetParamValue(IDbCommand cmd, string ParamName)
        {
            if (cmd == null)
            {
                return null;
            }
            return ((SqlParameter)(cmd.Parameters[ParamName])).Value;
        }

        public static void CorrectTableEx(DataTable dt, string TableName, string[] PKFieldNames)
        {
            if (TableName != null)
            {
                dt.TableName = TableName;
            }
            if (dt.PrimaryKey.Length == 0)
            {
                if (PKFieldNames != null && PKFieldNames.Length > 0)
                {
                    List<DataColumn> cols = new List<DataColumn>();
                    foreach (string fieldName in PKFieldNames)
                    {
                        cols.Add(dt.Columns[fieldName]);
                    }
                    dt.PrimaryKey = cols.ToArray();
                }
                else
                {
                    dt.PrimaryKey = new DataColumn[] { dt.Columns[0] };
                }
            }
        }
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Executes SQL statement against the Connection object of a .NET Framework data provider
        /// and returns the results inside <b>DataTable</b> object.
        /// </summary>
        /// <param name="queryText">
        /// SQL statement that should be executed
        /// </param>
        /// <param name="dt">
        /// <b>DataTable</b> object that will be filled by returned data
        /// </param>
        /// <param name="Connection">
        /// connection object that should be used for executing this command
        /// </param>
        /// <param name="Transaction">
        /// Optional <b>IDbTransaction</b> object. If it is passed, the command is executed as part of this
        /// transaction and entire transaction will be roll backed if execution fails.
        /// </param>
        /// <param name="SkipDebugOutput">
        /// </param>
        /// <returns>
        /// <i>ErrorMessage</i> object if error occurs during command execution or <b>Nothing</b> if command executed successfully.
        /// </returns>
        /// <remarks>
        /// The data containing in the <b>DataTable</b> are not cleared but appended with the new one.
        /// </remarks>
        /// <history>
        /// 	[Mike]	12.04.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static ErrorMessage FillTable(string queryText, DataTable dt, IDbConnection Connection, IDbTransaction Transaction, bool SkipDebugOutput)
        {
            //if (!SkipDebugOutput)
            //{
            //    DebugTimer.Start(string.Format("FillTable call, query={0}", queryText));
            //}
            try
            {
                DbDataAdapter da = CreateAdapter(queryText, Connection, false, Transaction);
                da.Fill(dt);
                return null;
            }
            catch (Exception ex)
            {
                return new ErrorMessage(StandardError.FillDatasetError, ex);
            }
            finally
            {
                //if (!SkipDebugOutput)
                //{
                //    DebugTimer.Stop();
                //}
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Executes command against the Connection object of a .NET Framework data provider
        /// and returns the results inside <b>DataTable</b> object.
        /// </summary>
        /// <param name="cmd">
        /// instance of <b>IDbCommand</b> that should be executed
        /// </param>
        /// <param name="dt">
        /// <b>DataTable</b> object that will be filled by returned data
        /// </param>
        /// <param name="Transaction">
        /// Optional <b>IDbTransaction</b> object. If it is passed, the command is executed as part of this
        /// transaction and entire transaction will be roll backed if execution fails.
        /// </param>
        /// <param name="SkipDebugOutput">
        /// </param>
        /// <returns>
        /// <i>ErrorMessage</i> object if error occurs during command execution or <b>Nothing</b> if command executed successfully.
        /// </returns>
        /// <remarks>
        /// The data containing in the <b>DataTable</b> are not cleared but appended with the new one.
        /// </remarks>
        /// <history>
        /// 	[Mike]	12.04.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static ErrorMessage FillTable(IDbCommand cmd, DataTable dt, IDbTransaction Transaction, bool SkipDebugOutput)
        {
            //if (!SkipDebugOutput)
            //{
            //    DebugTimer.Start(string.Format("FillTable call, commandText={0}", cmd.CommandText));
            //}
            try
            {
                cmd.Transaction = Transaction;
                DbDataAdapter da = CreateAdapter(cmd, false);
                da.Fill(dt);
                return null;
            }
            catch (Exception ex)
            {
                return new ErrorMessage(StandardError.FillDatasetError, ex);
            }
            finally
            {
                //if (!SkipDebugOutput)
                //{
                //    DebugTimer.Stop();
                //}
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Executes SQL statement against the Connection object of a .NET Framework data provider
        /// and returns the results inside specific table of <b>DataSet</b> object.
        /// </summary>
        /// <param name="queryText">
        /// SQL statement that should be executed
        /// </param>
        /// <param name="ds">
        /// <b>DataSet</b> object that will contain returned results
        /// </param>
        /// <param name="TableName">
        /// the name of table in the <b>DataSet.Tables</b> collection that will contain returned results
        /// </param>
        /// <param name="Connection">
        /// connection object that should be used for executing this command
        /// </param>
        /// <param name="Transaction">
        /// Optional <b>IDbTransaction</b> object. If it is passed, the command is executed as part of this
        /// transaction and entire transaction will be roll backed if execution fails.
        /// </param>
        /// <returns>
        /// <i>ErrorMessage</i> object if error occurs during command execution or <b>Nothing</b> if command executed successfully.
        /// </returns>
        /// <remarks>
        /// The data containing in the dataset table are not cleared but appended with the new one. If table with passed name doesn't not exist in the <b>DataSet</b>, it is added to the dataset's <b>Tables</b> collection.
        /// </remarks>
        /// <history>
        /// 	[Mike]	12.04.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static ErrorMessage FillDataset(string queryText, DataSet ds, string TableName, IDbConnection Connection, IDbTransaction Transaction)
        {
            try
            {
                DbDataAdapter da = CreateAdapter(queryText, Connection, false, Transaction);
                da.Fill(ds, TableName);
                return null;
            }
            catch (Exception ex)
            {
                return new ErrorMessage(StandardError.FillDatasetError, ex);
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Sets the transaction for each command in the <b>DbDataAdapter</b> object.
        /// </summary>
        /// <param name="da">
        /// <b>DbDataAdapter</b> object to which the transaction should be applied
        /// </param>
        /// <param name="transaction">
        /// <b>IDbTransaction</b> object that should be applied to the data adapter commands
        /// </param>
        /// <remarks>
        /// The transaction is applied to each defined command in the data adapter.
        /// </remarks>
        /// <history>
        /// 	[Mike]	12.04.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static void ApplyTransaction(DbDataAdapter da, IDbTransaction transaction)
        {

            IDbDataAdapter ida = da;
            if (ida.SelectCommand != null)
            {
                ida.SelectCommand.Transaction = transaction;
            }
            if (ida.InsertCommand != null)
            {
                ida.InsertCommand.Transaction = transaction;
            }
            if (ida.UpdateCommand != null)
            {
                ida.UpdateCommand.Transaction = transaction;
            }
            if (ida.DeleteCommand != null)
            {
                ida.DeleteCommand.Transaction = transaction;
            }
            if (transaction != null)
            {
                if (ida.SelectCommand != null)
                {
                    ida.SelectCommand.Connection = transaction.Connection;
                }
                if (ida.InsertCommand != null)
                {
                    ida.InsertCommand.Connection = transaction.Connection;
                }
                if (ida.UpdateCommand != null)
                {
                    ida.UpdateCommand.Connection = transaction.Connection;
                }
                if (ida.DeleteCommand != null)
                {
                    ida.DeleteCommand.Connection = transaction.Connection;
                }

            }

        }
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Posts changes stored in the <b>DataSet</b> to the database using passed <b>DbDataAdapter</b>
        /// </summary>
        /// <param name="da">
        /// <b>DbDataAdapter</b> object that should perform data posting
        /// </param>
        /// <param name="ds">
        /// <b>DataSet</b> object that contains data to post
        /// </param>
        /// <param name="TableName">
        /// the name of <b>DataTable</b> in the <b>DataSet.Tables</b> collection, which data should be posted to the database
        /// </param>
        /// <param name="transaction">
        /// The <b>IDbTransaction</b> object that should be applied to each defined command in the data adapter.
        /// </param>
        /// <returns>
        ///The number of rows successfully updated from the <b>DataSet</b>.
        /// </returns>
        /// <remarks>
        /// No exceptions are processed inside this method. You should process all exceptions in the codes that use this method.
        /// </remarks>
        /// <history>
        /// 	[Mike]	12.04.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static int Update(DbDataAdapter da, DataSet ds, string TableName, IDbTransaction transaction)
        {
            if (da == null || ds == null || TableName == null)
            {
                return -1;
            }
            ApplyTransaction(da, transaction);
            return da.Update(ds, TableName);
        }
        public static int Update(DbDataAdapter da, DataTable dt, IDbTransaction transaction)
        {
            if (da == null || dt == null)
            {
                return -1;
            }
            ApplyTransaction(da, transaction);
            return da.Update(dt);
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Searches the <b>DataRow</b> in the <b>DataTable</b> by the value of <b>DataRow</b> key field
        /// </summary>
        /// <param name="table">
        ///  <b>DataTable</b> object to search
        /// </param>
        /// <param name="aKey">
        /// the value of the key field.
        /// </param>
        /// <param name="keyFieldName">
        /// the name of the key field. If not specified the table primary key field is used as key field.
        /// </param>
        /// <returns>
        /// Returns the <b>DataRow</b> object, or nothing if there is no <b>DataRow</b> with such key.
        /// </returns>
        /// <remarks>
        /// It is assumed that <b>DataTable</b> has the only primary key field.
        /// If <i>keyFieldName</i> parameter is specified the function returns the first row that matches the search criteria.
        /// </remarks>
        /// <history>
        /// 	[Mike]	13.04.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static DataRow FindRow(DataTable table, object aKey, string keyFieldName)
        {
            if ((table == null) || (aKey == null))
            {
                return null;
            }
            try
            {
                if (keyFieldName == null)
                {
                    return table.Rows.Find(aKey);
                }
                if (table.Columns.Contains(keyFieldName) == false)
                {
                    return null;
                }
                foreach (DataRow row in table.Rows)
                {
                    if (row.RowState != DataRowState.Deleted && row[keyFieldName].Equals(aKey))
                    {
                        return row;
                    }
                }
            }
            catch
            {
                return null;
            }
            return null;
        }

        private static IDbCommand m_IDCommand;
        public static object NewIntID(IDbTransaction transaction)
        {
            if (m_IDCommand == null)
            {
                try
                {
                    m_IDCommand = CreateSPCommand("spsysGetNewID", ConnectionManager.DefaultInstance.Connection, transaction);
                    StoredProcParamsCache.CreateParameters(m_IDCommand, null);
                }
                catch (Exception ex)
                {

                    Dbg.Debug("Error during spsysGetNewID creation: {0}", ex);
                    m_IDCommand = null;
                    throw;
                }
            }
            if (transaction == null)
                m_IDCommand.Connection = ConnectionManager.DefaultInstance.Connection;
            else
            {
                m_IDCommand.Connection = transaction.Connection;
                m_IDCommand.Transaction = transaction;
            }
            if (m_IDCommand.Connection.State != ConnectionState.Open)
                m_IDCommand.Connection.Open();
            m_IDCommand.ExecuteNonQuery();
            return Convert.ToInt64(((SqlParameter)m_IDCommand.Parameters[0]).Value);
        }
        public static void BindParamsToColumns(IDbCommand cmd, DataTable sourceTable)
        {
            foreach (IDataParameter param in cmd.Parameters)
            {
                if (param.ParameterName.ToLowerInvariant() == "@action")
                    continue;
                if ((param.ParameterName.ToLowerInvariant() == "@langid") || (param.ParameterName.ToLowerInvariant() == "@languageid"))
                    param.Value = "en";//Localizer.Language;

                if (sourceTable.Columns.Contains(param.ParameterName.Substring(1)))
                    param.SourceColumn = param.ParameterName.Substring(1);
                else
                    Dbg.Debug("parameter {0} has no correspondent column in table {1}", param.ParameterName,
                              sourceTable.TableName);
            }
        }

        public static void ExecPostProcedure(string postProcedureName, DataTable sourceTable, IDbConnection connection, IDbTransaction transaction, Dictionary<String, Object> args)
        {
            IDbCommand cmd = CreateSPCommand(postProcedureName, connection, transaction);
            StoredProcParamsCache.CreateParameters(cmd, args);
            BindParamsToColumns(cmd, sourceTable);
            DbDataAdapter da = CreateAdapter(cmd, false);
            if (cmd.Parameters.Contains("@Action"))
            {
                (da as IDbDataAdapter).InsertCommand = CloneCommand(cmd);
                SetParam((da as IDbDataAdapter).InsertCommand, "@Action", DataRowState.Added);
                (da as IDbDataAdapter).DeleteCommand = CloneCommand(cmd);
                SetParam((da as IDbDataAdapter).DeleteCommand, "@Action", DataRowState.Deleted);
                (da as IDbDataAdapter).UpdateCommand = CloneCommand(cmd);
                SetParam((da as IDbDataAdapter).UpdateCommand, "@Action", DataRowState.Modified);
            }
            else
            {
                (da as IDbDataAdapter).InsertCommand = cmd;
                (da as IDbDataAdapter).DeleteCommand = cmd;
                (da as IDbDataAdapter).UpdateCommand = cmd;

            }
            Update(da, sourceTable, transaction);
        }

        private static IDbCommand CloneCommand(IDbCommand cmd)
        {
            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = cmd.CommandText;
            cmd1.CommandTimeout = cmd.CommandTimeout;
            cmd1.CommandType = cmd.CommandType;
            cmd1.Connection = (SqlConnection)cmd.Connection;
            cmd1.Transaction = (SqlTransaction)cmd.Transaction;
            foreach (SqlParameter p in cmd.Parameters)
                cmd1.Parameters.Add(CloneParam(p));
            return cmd1;
        }

        private static IDbDataParameter CloneParam(IDbDataParameter param)
        {
            SqlParameter p = new SqlParameter();
            p.ParameterName = param.ParameterName;
            p.SourceColumn = param.SourceColumn;
            p.SqlDbType = ((SqlParameter)param).SqlDbType;
            p.Size = param.Size;
            p.Value = param.Value;
            p.Direction = param.Direction;
            p.DbType = param.DbType;
            return p;
        }
    }
}
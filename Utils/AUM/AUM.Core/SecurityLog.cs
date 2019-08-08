namespace AUM.Core
{
  using System;
  using System.Data;
  using System.Data.SqlClient;
  using System.Diagnostics;
  using System.Globalization;
  using System.Threading;


  public static class SecurityLog
    {
    public static void WriteToEventLogWindows(EventLogEntryType eventLogEntryType, string format, params object[] args)
    {
      var message = string.Format(CultureInfo.InvariantCulture, format, args);
      using (var eventLog = new EventLog())
      {
        try
        {
          eventLog.Source = "AUM60";
          eventLog.WriteEntry(message, eventLogEntryType);
        }
        //писать более некуда
        // ReSharper disable EmptyGeneralCatchClause
        catch
        {
        }
        // ReSharper restore EmptyGeneralCatchClause
      }
    }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="idfsAction"></param>
        /// <param name="success"></param>
        /// <param name="errString"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public static bool WriteToEventLogDB(SqlConnection connection/*, long? userID*/, Operations idfsAction, bool success, string errString, string description)
        {
            var result = false;

            using (var cmd = new SqlCommand("spLogSecurityEvent", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@idfUserID", SqlDbType.BigInt);
                cmd.Parameters.Add("@idfsAction", SqlDbType.BigInt);
                cmd.Parameters.Add("@success", SqlDbType.Bit);
                cmd.Parameters.Add("@strErrorText", SqlDbType.NVarChar);
                cmd.Parameters.Add("@strDescription", SqlDbType.NVarChar);
                cmd.Parameters.Add("@idfObjectID", SqlDbType.BigInt);

                //cmd.Parameters["@idfUserID"].Value = userID;
                cmd.Parameters["@idfsAction"].Value = (long) idfsAction;
                cmd.Parameters["@success"].Value = success;
                cmd.Parameters["@strErrorText"].Value = errString;
                cmd.Parameters["@strDescription"].Value = description;

                try
                {
                    if (!connection.State.Equals(ConnectionState.Open)) connection.Open();
                    cmd.ExecuteNonQuery();
                    result = true;
                }
                catch (Exception e)
                {
                    WriteToEventLogWindows(
                      EventLogEntryType.Error,
                      "Can't write in DB Log: idfsAction='{0}', success='{1}', strErrorText = '{2}', Description = '{3}', Error = '{4}'",
                      idfsAction,
                      success,
                      errString,
                      description,
                      e.Message);
                }
            }
            return result;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public enum Operations
    {
        Login = 10110000,
        Logoff = 10110001,
        Update = 10110005
    }
}

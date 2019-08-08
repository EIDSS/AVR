using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AUM.Core;

namespace AUM.db
{
    /// <summary>
    /// Обеспечивает пересылку сообщений в EventLog
    /// </summary>
    public static class EventLogMessageHelper
    {
        /// <summary>
        /// Создает сообщение в EIDSS.Event_Log
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="objectID"></param>
        /// <param name="processed"></param>
        /// <param name="clientID"></param>
        /// <param name="userID"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public static object CreateProcessedEvent(EventType eventType, object objectID, int processed, object clientID, object userID, IDbConnection connection, IDbTransaction transaction)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@idfsEventTypeID", (long) eventType);
            parameters.Add("@idfObjectID", objectID);
            parameters.Add("@strInformationString", String.Empty);
            parameters.Add("@strNote", String.Empty);
            parameters.Add("@ClientID", clientID);
            parameters.Add("@intProcessed", processed);
            parameters.Add("@idfUserID", userID);

            SqlCommand cmd = (SqlCommand) DbHelper.CreateSPCommandWithParams("spEventLog_CreateNewEvent", connection, transaction, parameters);

            DbHelper.AddTypedParam(cmd, "@EventID", SqlDbType.BigInt, ParameterDirection.InputOutput);
            //TODO вставить корректную обработку сообщений
            ErrorMessage errorMessage = DbHelper.ExecCommand(cmd, connection, transaction, true);
            //TODO возможно, надо что-то писать в SecurityLog
            
            return null;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public enum EventType
    {
        ApplicationExit = 10025027
        , EIDSSDBDisconnect = 10025028
    }
}

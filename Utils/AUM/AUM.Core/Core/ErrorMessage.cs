using System;
using System.Diagnostics;
using System.IO;

namespace AUM.Core
{
    public enum StandardError
    {
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Displays the text 'Error during database command creation'. Should be used for processing errors that occur during IDbCommand object creation
        /// </summary>
        /// <history>
        /// 	[Mike]	28.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CreateCommandError,
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Displays the text 'Error during command parameter creation'. Should be used for processing errors that occur during IDbCommand Parameter object creation
        /// </summary>
        /// <history>
        /// 	[Mike]	28.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CreateParameterError,
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Displays the text 'Error during database operation'. Should be used for common database errors.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[Mike]	28.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        DatabaseError,
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Displays the text 'Some field contains invalid data'. Should be used for common displaying data validation errors.
        /// </summary>
        /// <history>
        /// 	[Mike]	28.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        DataValidationError,
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Displays the text 'Error during retrieving data from dataset'. Should be used when error occurs during retrieving data from database and filling form <b>DataSet</b> with this data.
        /// </summary>
        /// <history>
        /// 	[Mike]	28.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        FillDatasetError,
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Displays the text 'Invalid login name/password'. Should be used when user tried to login with invalid credentials.
        /// </summary>
        /// <history>
        /// 	[Mike]	28.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        InvalidLogin,
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Displays the text 'Old (current) password incorrect for user. The password was not changed'. Should be used when user tried to change password and without valid old password.
        /// </summary>
        /// <history>
        /// 	[Mike]	28.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        InvalidOldPassword,
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Displays the text 'Invalid value passed to the sql command parameter'. Should be used when invalid value is used as parameter for the sql command.
        /// </summary>
        /// <history>
        /// 	[Mike]	28.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        InvalidParameter,
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Displays the text 'Multi-Language resource is not found'. Should be used when resource file containing requested resource is not found.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[Mike]	28.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        MissingResource,
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Displays the text 'Error during saving data to database'. Should be used when errors occur during saving data to database.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[Mike]	28.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        PostError,
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Displays the text 'Error during executing sql query'. Should be used when sql error occurs other then <i>FillDatasetError</i>, <i>PostError</i> or <i>StoredProcedureError</i>.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[Mike]	28.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        SqlQueryError,
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Displays the text 'Error during executing sql stored procedure'. Should be used when error during stored procedure execution occurs.
        /// </summary>
        /// <history>
        /// 	[Mike]	28.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StoredProcedureError,
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Displays the text 'Some error occurs in the application. Please send information about this error to developers team.'. Should be used when unprocessed error occur in application.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[Mike]	28.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        UnprocessedError
    }

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Defines the dangerous level of <i>ErrorMessage</i> object.
    /// </summary>
    /// <history>
    /// 	[Mike]	28.03.2006	Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [Flags]
    public enum ErrorKind
    {
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Assigned to <i>ErrorMessage</i> object created for processed errors.
        /// </summary>
        /// <history>
        /// 	[Mike]	28.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        NotificationError = 1,
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Assigned to <i>ErrorMessage</i> object created for unprocessed errors that don't crush the application.
        /// </summary>
        /// <history>
        /// 	[Mike]	28.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        UnprocessedError = 2,
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Assigned to <i>ErrorMessage</i> object created for fatal errors that require application restarting.
        /// </summary>
        /// <history>
        /// 	[Mike]	28.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        FatalError = 4
    }

    /// -----------------------------------------------------------------------------
    /// Project	 : bv_common
    /// Class	 : common.ErrorMessage
    ///
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// This class is used as wrapper for all error messages that should be displayed for end users.
    /// It contains built in translation mechanism and allow displaying the error messages translated to native language.
    /// </summary>
    /// <remarks>
    /// This class is assumed to be used as error wrapper everywhere in the application where the translated user friendly error message should be displayed for end user.
    /// It contains several levels of error details and allows showing for end user as translated user friendly part of the error
    /// as detailed error information needed for developers.
    /// Internally it uses <i>StringsStorage</i> class to translate error text and put it automatically to resource file during application development.
    /// Use <i>ErrorForm</i> class to display error wrapped by <i>ErrorMessage</i> for end user.
    /// </remarks>
    /// <history>
    /// 	[Mike]	28.03.2006	Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class ErrorMessage
    {
        public Exception @Exception;
        private ErrorKind m_ErrorKind = ErrorKind.NotificationError;
        protected string m_FriendlyError;
        protected string m_FriendlyErrorResourceName;
        protected string m_FullError;

        #region "Constructor"

        private readonly object[] m_formatArgs;

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Creates the empty <i>ErrorMessage</i> class without any error information
        /// </summary>
        /// <remarks>
        /// This is default constructor that can be used when you want to define error information directly through the <i>ErrorMessage</i> properties.
        /// </remarks>
        /// <history>
        /// 	[Mike]	28.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ErrorMessage()
        {
            m_FriendlyErrorResourceName = "";
            m_FriendlyError = "";
            m_FullError = null;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Creates the new  <i>ErrorMessage</i> object initialized only by message that should be displayed for end user.
        /// </summary>
        /// <param name="errMsg">
        /// the text that should be displayed for end user
        /// </param>
        /// <remarks>
        ///  <i>ErrorMessage</i> contains no detail error information in this case.
        /// If the passed error text is not contained in the resource file
        /// associated with <i>ErrorMessage</i> class, it
        /// is added there using <i>errMsg</i> parameter as resource key name.
        /// </remarks>
        /// <history>
        /// 	[Mike]	28.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ErrorMessage(string errMsg)
        {
            m_FriendlyErrorResourceName = errMsg;
            m_FriendlyError = errMsg;
            m_FullError = null;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Creates the new  <i>ErrorMessage</i> object initialized only by message that should be displayed for end user.
        /// </summary>
        /// <param name="errResourceName">
        /// the key name of the resource string in the related resource file
        /// </param>
        /// <param name="errMsg">
        /// the text that should be displayed for end user
        /// </param>
        /// <remarks>
        /// <i>ErrorMessage</i> contains no detail error information in this case.
        /// If the passed error text is not contained in the resource file
        /// associated with <i>ErrorMessage</i> class, it
        /// is added there using <i>errResourceName</i> parameter as resource key name and <i>errMsg</i> as resource value.
        /// </remarks>
        /// <history>
        /// 	[Mike]	30.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ErrorMessage(string errResourceName, string errMsg)
        {
            m_FriendlyErrorResourceName = errResourceName;
            m_FriendlyError = errMsg;
            m_FullError = null;
        }

        public ErrorMessage(string errResourceName, string errMsg, params object[] args)
        {
            m_FriendlyErrorResourceName = errResourceName;
            if (args == null || args.Length == 0)
            {
                m_FriendlyError = errMsg;
            }
            else
            {
                m_formatArgs = args;
                m_FriendlyError = string.Format(errMsg, args);
            }
            m_FullError = null;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Creates the new  <i>ErrorMessage</i> object initialized using standard error text and <b>Exception</b> object that caused this error.
        /// </summary>
        /// <param name="errType">
        ///     <i>StandardError</i> enumeration member that defines the standard user friendly error message.
        /// </param>
        /// <param name="ex">
        /// <b>Exception</b> object that caused this error
        /// </param>
        /// <remarks>
        /// <i>ErrorMessage</i> contains the detail error information in this case.
        /// If the text associated with <i>errType</i> is not contained in the <i>ErrorMessage</i> related resource file
        /// it is added there.
        /// </remarks>
        /// <history>
        /// 	[Mike]	30.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ErrorMessage(StandardError errType, Exception ex)
        {
            ErrorKind ErrKind = ErrorKind.UnprocessedError;
            SetStdErrorText(errType, ref ErrKind);
            if (ex != null)
            {
                m_FullError = GetFullErrorText(ex, null, (ErrKind & ~ErrorKind.NotificationError) != 0);
                Exception = ex;
            }
            else
            {
                m_FullError = null;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Creates the new <i>ErrorMessage</i> object initialized by message that should be displayed
        /// for end user and by <b>Exception</b> object that caused this error.
        /// </summary>
        /// <param name="errResourceName">
        /// the key name of the resource string in the related resource file
        /// </param>
        /// <param name="errMsg">
        /// the text that should be displayed for end user
        /// </param>
        /// <param name="ex">
        /// <b>Exception</b> object that caused this error
        /// </param>
        /// <remarks>
        /// <i>ErrorMessage</i> contains detail error information in this case.
        /// If the passed error text is not contained in the resource file
        /// associated with <i>ErrorMessage</i> class, it
        /// is added there using <i>errResourceName</i> parameter as resource key name and <i>errMsg</i> as resource value.
        /// </remarks>
        /// <history>
        /// 	[Mike]	30.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ErrorMessage(string errResourceName, string errMsg, Exception ex)
        {
            m_FriendlyErrorResourceName = errResourceName;
            m_FriendlyError = errMsg;
            m_FullError = GetFullErrorText(ex, null, false);
            Exception = ex;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Creates the new <i>ErrorMessage</i> object initialized by message that should be displayed
        /// for end user and by <b>Exception</b> object that caused this error.
        /// </summary>
        /// <param name="errMsg">
        /// the text that should be displayed for end user
        /// </param>
        /// <param name="ex">
        /// <b>Exception</b> object that caused this error
        /// </param>
        /// <remarks>
        /// <i>ErrorMessage</i> contains the detail error information in this case.
        /// If the passed error text is not contained in the resource file
        /// associated with <i>ErrorMessage</i> class, it
        /// is added there using <i>errMsg</i> parameter as resource key name.
        /// </remarks>
        /// <history>
        /// 	[Mike]	30.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ErrorMessage(string errMsg, Exception ex)
        {
            m_FriendlyErrorResourceName = errMsg;
            m_FriendlyError = errMsg;
            m_FullError = GetFullErrorText(ex, null, false);
            Exception = ex;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Creates the new <i>ErrorMessage</i> object initialized by <b>Exception</b> object that caused this error.
        /// </summary>
        /// <param name="ex">
        /// <b>Exception</b> object that caused this error
        /// </param>
        /// <remarks>
        /// <i>ErrorMessage</i> contains the detail error information in this case.
        /// The message related with <i>StandardError.UnknownError</i> is used as user friendly error message in this case
        /// </remarks>
        /// <history>
        /// 	[Mike]	30.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ErrorMessage(Exception ex)
        {
            m_FriendlyErrorResourceName = "errUnknownError";
            m_FriendlyError = "Some error occurred in application";
            m_FullError = GetFullErrorText(ex, null, true);
            Exception = ex;
        }

        #endregion

        #region "Public properties"

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the text that should be displayed for end user
        /// </summary>
        /// <remarks>
        /// The text retrieved using this property is translated using current application language.
        /// The text passed to Set method is used as key for further translation
        /// </remarks>
        /// <history>
        /// 	[Mike]	30.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public string Text
        {
            get { return GetErrorText(); }
            set
            {
                m_FriendlyErrorResourceName = value;
                m_FriendlyError = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets not translated detailed error information including error stack trace
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[Mike]	30.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public string DetailError
        {
            get { return m_FullError; }
            set { m_FullError = value; }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the <i>ErrorKind</i> of the <i>ErrorMessage</i> object
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[Mike]	30.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ErrorKind Kind
        {
            get { return m_ErrorKind; }
            set { m_ErrorKind = value; }
        }


        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Returns the <b>True</b> for critical errors with <i>UnprocessedError</i> or <i>FatalError</i> <i>ErrorKind</i>
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[Mike]	30.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public bool IsCriticalError
        {
            get { return m_ErrorKind > ErrorKind.NotificationError; }
        }

        protected virtual string GetErrorText()
        {
            if (m_formatArgs == null)
            {
                return m_FriendlyError;
                //return StringsStorage.Get(m_FriendlyErrorResourceName, m_FriendlyError, null);
            }
            return string.Format(m_FriendlyError, m_formatArgs);
            //return string.Format(StringsStorage.Get(m_FriendlyErrorResourceName, m_FriendlyError, null),
            //                     m_formatArgs);
        }

        //Public Function SendMessageToDevelopers() As Boolean
        //    Return False
        //End Function

        #endregion

        #region "Shared methods"

        private static void PrintString(StringWriter writer, string title, object value)
        {
            if (value != null && value.ToString().Trim() != "")
            {
                writer.WriteLine("{0,-30}{1}", title + ":", value);
            }
        }

        private static string GetFullErrorText(Exception e, string msg, bool ShowStackTrace)
        {
            //Shared method that builds error message text from an exception or web service error text/
            //Override this method if you need display error in some other manner
            StringWriter errorMsg = new StringWriter();
            if (e == null)
            {
                errorMsg.WriteLine(msg);
            }
            else
            {
                errorMsg.WriteLine(e.Message);
            }

            // add stack trace to the report
            if (e == null)
            {
                StackTrace trace = new StackTrace();
                errorMsg.WriteLine("\r\n" + "Local Stack Trace:");
                errorMsg.WriteLine(trace.ToString());
            }
            else
            {
                errorMsg.WriteLine("\r\n" + "Stack Trace:");
                errorMsg.WriteLine("\r\n" + e.StackTrace);
                // show inner exception if necessary
                if (e.InnerException != null)
                {
                    errorMsg.WriteLine("\r\n" + "Inner Exception:");
                    errorMsg.WriteLine("\r\n" + e.InnerException.Message);
                    if (e.InnerException.InnerException != null)
                    {
                        errorMsg.WriteLine("\r\n" + "Inner Exception:");
                        errorMsg.WriteLine("\r\n" + e.InnerException.InnerException.Message);
                    }
                }
            }

            return errorMsg.ToString();
        }

        private string SetStdErrorText(StandardError se, ref ErrorKind errKind)
        {
            switch (se)
            {
                case StandardError.CreateCommandError:
                    m_FriendlyErrorResourceName = "ErrCreateCommand";
                    m_FriendlyError = "Error during database command creation.";
                    break;
                case StandardError.CreateParameterError:
                    m_FriendlyErrorResourceName = "ErrCreateParameter";
                    m_FriendlyError = "Error during command parameter creation.";
                    break;
                case StandardError.DatabaseError:
                    m_FriendlyErrorResourceName = "ErrDatabase";
                    m_FriendlyError = "Error during database operation.";
                    break;
                case StandardError.DataValidationError:
                    m_FriendlyErrorResourceName = "ErrDataValidation";
                    m_FriendlyError = "Some field contains invalid data.";
                    break;
                case StandardError.FillDatasetError:
                    m_FriendlyErrorResourceName = "ErrFillDataset";
                    m_FriendlyError = "Error during retrieving data from database.";
                    break;
                case StandardError.InvalidLogin:
                    m_FriendlyErrorResourceName = "ErrInvalidLogin";
                    m_FriendlyError = "Invalid login name/password.";
                    m_FullError = "";
                    break;
                case StandardError.InvalidOldPassword:
                    m_FriendlyErrorResourceName = "ErrOldPassword";
                    m_FriendlyError = "	Old (current) password incorrect for user. The password was not changed.";
                    m_FullError = "";
                    break;
                case StandardError.InvalidParameter:
                    m_FriendlyErrorResourceName = "ErrInvalidParameter";
                    m_FriendlyError = "Invalid value passed to the sql command parameter.";
                    break;
                case StandardError.MissingResource:
                    m_FriendlyErrorResourceName = "ErrMissingResource";
                    m_FriendlyError = "Multi-Language resource is not found.";
                    break;
                case StandardError.PostError:
                    m_FriendlyErrorResourceName = "ErrPost";
                    m_FriendlyError = "Error during saving data to database.";
                    break;
                case StandardError.SqlQueryError:
                    m_FriendlyErrorResourceName = "ErrSqlQuery";
                    m_FriendlyError = "Error during executing sql query.";
                    break;
                case StandardError.StoredProcedureError:
                    m_FriendlyErrorResourceName = "ErrStoredProcedure";
                    m_FriendlyError = "Error during executing sql stored procedure.";
                    break;
                case StandardError.UnprocessedError:
                    m_FriendlyErrorResourceName = "ErrUnprocessedError";
                    m_FriendlyError =
                        "Some error occurs in the application. Please send information about this error to developers team.";
                    break;
                default:
                    m_FriendlyErrorResourceName = "ErrUndefinedStdError";
                    m_FriendlyError =
                        "Some error occurs in the application. Please send information about this error to developers team.";
                    break;
            }
            return m_FriendlyError;
        }

        #endregion
    }
}
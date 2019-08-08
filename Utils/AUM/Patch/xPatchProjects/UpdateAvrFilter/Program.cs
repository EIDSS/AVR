using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using AUM.Core.Enums;
using AUM.Core.Helper;
using Ionic.Zip;

namespace UpdateAvrFilter
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // List of strings with execution log
            // Start logging 
            var logStrings = new List<string>
            {
                "Update AVR layouts"
            };
            AddInfoString(ref logStrings, "Starting...");
            bool res = false;

            try
            {
                List<LayoutDTO> globalList = GetGlobalLayoutV6IdList();
                AddInfoString(ref logStrings, string.Format("{0} global layouts need to be updated", globalList.Count));
                foreach (LayoutDTO layout in globalList)
                {
                    AddInfoString(ref logStrings, string.Format("{0} - starting update", layout));

                    if (layout.ZippedSettings != null && layout.ZippedSettings.Length > 0)
                    {
                        layout.Settings = Unzip(layout.ZippedSettings);
                    }
                    UpdateGlobalLayoutV6(layout);
                    AddInfoString(ref logStrings, string.Format("{0} - update finished", layout));
                }


                List<LayoutDTO> localList = GetLocalLayoutV6IdList();
                AddInfoString(ref logStrings, string.Format("{0} local layouts need to be updated", localList.Count));
                foreach (LayoutDTO layout in localList)
                {
                    AddInfoString(ref logStrings, string.Format("{0} - starting update", layout));

                    if (layout.ZippedSettings != null && layout.ZippedSettings.Length > 0)
                    {
                        layout.Settings = Unzip(layout.ZippedSettings);
                    }
                    UpdateLocalLayoutV6(layout);
                    AddInfoString(ref logStrings, string.Format("{0} - update finished", layout));
                }

                res = true;
            }
            catch (Exception ex)
            {
                // Log error
                AddErrorString(ref logStrings, GetFullError(ex));
            }
            finally
            {
                // Finish logging
                AddInfoString(ref logStrings, "Finish");

                //Create execution log
                FileHelper.WriteLogFileForExecuteApp(GetExecutableFilePath(), GetExecutableFileName(), res, logStrings);
            }
        }

        private static List<LayoutDTO> GetLocalLayoutV6IdList()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection(UpdateDatabases.DbMain))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"select	l.idflLayout, 
		                                    tr.strTextString,
		                                    l.blbPivotGridSettings
                                    from	tasLayout l
                                    inner join locStringNameTranslation tr
                                    on l.idflLayout = tr.idflBaseReference
                                    and tr.idfsLanguage = 10049003
                                    where	l.intPivotGridXmlVersion = 6";
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    var result = new List<LayoutDTO>();
                    while (reader.Read())
                    {
                        var layout = new LayoutDTO
                        {
                            Id = (long) reader["idflLayout"],
                            Name = reader["strTextString"] as string,
                            ZippedSettings = reader["blbPivotGridSettings"] is byte[]
                                ? (byte[]) reader["blbPivotGridSettings"]
                                : new byte[0]
                        };

                        result.Add(layout);
                    }
                    return result;
                }
            }
        }

        private static List<LayoutDTO> GetGlobalLayoutV6IdList()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection(UpdateDatabases.DbMain))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"select	l.idfsLayout, 
		                                    tr.strTextString,
		                                    l.blbPivotGridSettings
		
                                    from	tasglLayout l
                                    inner join trtStringNameTranslation tr
                                    on l.idfsLayout = tr.idfsBaseReference
                                    and tr.idfsLanguage = 10049003
                                    where	l.intPivotGridXmlVersion = 6";
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    var result = new List<LayoutDTO>();
                    while (reader.Read())
                    {
                        var layout = new LayoutDTO
                        {
                            Id = (long) reader["idfsLayout"],
                            Name = reader["strTextString"] as string,
                            ZippedSettings = reader["blbPivotGridSettings"] is byte[]
                                ? (byte[]) reader["blbPivotGridSettings"]
                                : new byte[0]
                        };

                        result.Add(layout);
                    }
                    return result;
                }
            }
        }

        private static void UpdateLocalLayoutV6(LayoutDTO layout)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection(UpdateDatabases.DbMain))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"update	tasLayout
                                    set		intPivotGridXmlVersion = 7,
		                                    blbPivotGridSettings = @blbPivotGridSettings
                                    where	idflLayout = @idflLayout";
                cmd.Parameters.AddWithValue("idflLayout", layout.Id);
                cmd.Parameters.AddWithValue("blbPivotGridSettings", layout.Settings ?? new byte[0]);
                cmd.ExecuteNonQuery();
            }
        }

        private static void UpdateGlobalLayoutV6(LayoutDTO layout)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection(UpdateDatabases.DbMain))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"update	tasglLayout
                                    set		intPivotGridXmlVersion = 7,
		                                    blbPivotGridSettings = @blbPivotGridSettings
                                    where	idfsLayout = @idfsLayout";
                cmd.Parameters.AddWithValue("idfsLayout", layout.Id);
                cmd.Parameters.AddWithValue("blbPivotGridSettings", layout.Settings ?? new byte[0]);
                cmd.ExecuteNonQuery();
            }
        }

        private static byte[] Unzip(byte[] sourceBuffer)
        {
            const string entryName = "EntryName";
            using (Stream stream = new MemoryStream())
            {
                stream.Write(sourceBuffer, 0, sourceBuffer.Length);
                stream.Flush();
                stream.Seek(0, SeekOrigin.Begin);

                using (ZipFile zip = ZipFile.Read(stream))
                {
                    ZipEntry e = zip[entryName];
                    using (Stream outputStream = new MemoryStream())
                    {
                        e.Extract(outputStream);
                        outputStream.Flush();
                        outputStream.Seek(0, SeekOrigin.Begin);
                        var uncompressedBuffer = new byte[outputStream.Length];
                        int readed = outputStream.Read(uncompressedBuffer, 0, (int) outputStream.Length);
                        Debug.Assert(outputStream.Length == readed, "not all bytes readed");
                        return uncompressedBuffer;
                    }
                }
            }
        }

//        public static List<long> GetLayoutV6IdList()
//        {
//            using (SqlConnection conn = DatabaseHelper.GetConnection(UpdateDatabases.DbMain))
//            {
//                conn.Open();
//                SqlCommand cmd = conn.CreateCommand();
//                cmd.CommandText = "spAsLayoutSelectLookup";
//                cmd.CommandType = CommandType.StoredProcedure;
//                cmd.Parameters.AddWithValue("LangID", "en");
//                using (SqlDataReader reader = cmd.ExecuteReader())
//                {
//                    var result = new List<long>();
//                    while (reader.Read())
//                    {
//                        if (reader["intPivotGridXmlVersion"] is int && (int)reader["intPivotGridXmlVersion"] == 6)
//                        {
//                            result.Add((long)reader["idflLayout"]);
//                        }
//                    }
//                    return result;
//                }
//            }
//        }

        #region Log Methods

        /// <summary>
        ///     Adds information string to the log
        /// </summary>
        /// <param name="logStrings">List of log strings</param>
        /// <param name="infoString">String containg information to include to the log</param>
        public static void AddInfoString(ref List<string> logStrings, string infoString)
        {
            if (logStrings == null)
            {
                logStrings = new List<string>();
            }

            logStrings.Add(string.Format("{0}: {1}", DateTime.Now.ToString(CultureInfo.InvariantCulture), infoString));
        }

        /// <summary>
        ///     Adds error message to the log
        /// </summary>
        /// <param name="logStrings">List of log strings</param>
        /// <param name="errorMessage">String containg error message to include to the log</param>
        public static void AddErrorString(ref List<string> logStrings, string errorMessage)
        {
            if (logStrings == null)
            {
                logStrings = new List<string>();
            }

            logStrings.Add(string.Format("Creating sql command task error {0}: {1}", DateTime.Now.ToString(CultureInfo.InvariantCulture),
                errorMessage));
        }

        #region Useful methods

        /// <summary>
        ///     Returns source string if it is not empty, otherwise returns default string.
        /// </summary>
        /// <param name="val">Source string</param>
        /// <param name="defVal">Default string</param>
        /// <returns>Returns source string if it is not empty, otherwise returns default string</returns>
        public static string IsNull
            (
            string val,
            string defVal
            )
        {
            string res = val;

            if (defVal == null)
            {
                defVal = "";
            }

            if (string.IsNullOrEmpty(val))
            {
                res = defVal;
            }
            return res;
        }

        /// <summary>
        ///     Returns string with exception message including messages of all inner exceptions.
        /// </summary>
        /// <param name="exception">Application exception</param>
        /// <returns>Returns string with exception message including messages of all inner exceptions</returns>
        public static string GetFullError
            (
            Exception exception
            )
        {
            string msgError = "";

            Exception ex = exception;
            if (ex == null)
            {
                return (msgError);
            }

            msgError = string.Format("Exception: {0}", ex.Message);

            int i = 0;
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
                i = i + 1;
                msgError = string.Format("{0} \n {1} {2}: {3}", msgError, "Inner exception", i.ToString(CultureInfo.InvariantCulture),
                    ex.Message);
            }

            return (msgError);
        }

        /// <summary>
        ///     Returns name of application executable file
        /// </summary>
        /// <returns>Returns name of application executable file</returns>
        public static string GetExecutableFileName()
        {
            return (Path.GetFileName(Assembly.GetEntryAssembly().Location));
        }

        /// <summary>
        ///     Returns name of directory containing application executable file
        /// </summary>
        /// <returns>Returns name of directory containing application executable file</returns>
        public static string GetExecutableFilePath()
        {
            return (Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }

        /// <summary>
        ///     Returns file path with application startup path in the beggining.
        /// </summary>
        /// <param name="fileName">File name</param>
        /// <returns>Returns String value containing file path with application startup path in the beggining</returns>
        public static string CombineAppStartUpPathWithFileName(string fileName)
        {
            return (Path.Combine(IsNull(GetExecutableFilePath(), String.Empty), fileName));
        }

        #endregion

        #endregion
    }
}
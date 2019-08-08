using bv.model.BLToolkit;
using eidss.model.Core;
using eidss.model.Resources;
using eidss.model.Schema;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using bv.common.Configuration;
using System.Globalization;

namespace eidss.model.Helpers
{
    public enum SourceType
    {
        Excel,
        Access,
        DBase
    }
    class Upload506FileProcessor : IDisposable
    {
        const int MaxItemsCount = 20000;
        const int ThaiCodePage = 874;
        private static readonly HashSet<string> m_Upload506Cells = new HashSet<string>()
		{
		   "E0", "E1", "PE0", "PE1", "DISEASE", "NAME", "HN", "SEX", "YEAR", "MONTH", "DAY", "MARIETAL", "RACE", "RACE1", "OCCUPAT", "ADDRESS", "ADDRCODE", "PROVINCE", "METROPOL", "HOSPITAL", "TYPE", "RESULT", "HSERV", "SCHOOL", "DATESICK", "DATEDEFINE", "DATEDEATH", "DATERECORD", "COMPLICA"
		};
        private static int m_NameIndex = 5;
        private static int m_AddressIndex = 15;

        private readonly Dictionary<string, int> m_CellsMap = new Dictionary<string, int>();
        private readonly List<string> m_FieldsList = new List<string>();
        private static readonly Dictionary<string, int> m_MaxCellLengths = new Dictionary<string, int>() 
		{
		   {"DISEASE", 10}, {"HN",200}, {"MAME",200}, {"ADDRESS",200}, {"ADDRCODE",6}, {"PROVINCE",2}, {"HSERV",100}, {"SCHOOL",200},{"COMPLICA",10}
		};

        private readonly List<string> m_HeaderErrors = new List<string>();
        public string HeaderError
        {
            get
            {
                if (m_HeaderErrors.Count == 0)
                    return null;
                if (m_HeaderErrors.Count == 1)
                    return string.Format(EidssMessages.Get("msg506BadHeader"), m_HeaderErrors[0]);
                return string.Format(EidssMessages.Get("msg506BadHeader"), "\r\n" + string.Join("\r\n", m_HeaderErrors) + "\r\n");
            }
        }
        #region Constructors
        public Upload506FileProcessor(string filePath, Upload506Master uploadMaster)
        {
            UploadMaster = uploadMaster;
            FilePath = filePath;
            Init();
            m_ExcelFileWrapper = new ExcelFileWrapper();
        }
        public Upload506FileProcessor(Stream stream, string fileName, Upload506Master uploadMaster)
        {
            UploadMaster = uploadMaster;
            FilePath = fileName;
            m_InputStream = stream;
            //UploadMaster.InputStream = m_InputStream;
            Init();
            m_ExcelFileWrapper = new ExcelFileWrapper();
        }
        public Upload506FileProcessor(Upload506Master uploadMaster)
        {
            UploadMaster = uploadMaster;
            if (UploadMaster.StoredData is IWorkbook)
            {
                m_ExcelFileWrapper = new ExcelFileWrapper((IWorkbook)UploadMaster.StoredData);
                m_ExcelFileWrapper.ShoudDisposeWorkbook = false;
                InitCellIndicesFromWorkbook();
            }
            else
            {
                m_ExcelFileWrapper = new ExcelFileWrapper();
                m_DbaseFile = (FlatDatabase.DBase.File)UploadMaster.StoredData;
                ValidateHeader(m_DbaseFile);
            }
            Init();
        }

        private SourceType m_SourceType;
        public void Dispose()
        {
            m_ExcelFileWrapper.Dispose();
            UploadMaster.FileName = FilePath;
            UploadMaster = null;
            m_CellsMap.Clear();
            m_FieldsList.Clear();
            m_HeaderErrors.Clear();
        }

        private void Init()
        {
            m_SourceType = UploadMaster.SourceType;
            if(string.IsNullOrEmpty(FilePath))
                FilePath = UploadMaster.FileName;
        }

        #endregion

        #region Properties
        private Stream m_InputStream;
        private ExcelFileWrapper m_ExcelFileWrapper;
        private FlatDatabase.DBase.File m_DbaseFile;
        public string FilePath { get; set; }
        private Upload506Master UploadMaster { get; set; }

        public IWorkbook Workbook
        {
            get
            {
                if (m_ExcelFileWrapper != null)
                    return m_ExcelFileWrapper.Workbook;
                return null;
            }
        }
        #endregion

        #region Public methods
        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// Error code:
        /// 0 - no errors
        /// 1 - file doesn't exists
        /// 2 - usupported extension
        /// 3 - Ivalid header format (some column names don't match 506 format column names)
        /// 4 - incorrect data format in some cells
        /// 5 - invalid file format, error duirng file reading
        /// </returns>
        public Upload506FileError GetItems(long startRecord = 0, long count = -1)
        {

            if (m_InputStream == null && (string.IsNullOrEmpty(FilePath) || !File.Exists(FilePath)))
                return Upload506FileError.NullFile;

            var ext = Path.GetExtension(FilePath);

            try
            {
                Upload506FileError result = Upload506FileError.UsupportedExtension;
                if (ext == ".xls" || ext == ".xlsx")
                {
                    if (m_InputStream == null)
                    {
                        m_InputStream = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
                    }
                    m_ExcelFileWrapper.Read(m_InputStream);
                    result = GetItemsFromWorkbook();
                    UploadMaster.StoredData = m_ExcelFileWrapper.Workbook;
                    m_ExcelFileWrapper.ShoudDisposeWorkbook = false;
                }
                else if (ext == ".dbf")
                {
                    result = GetItemsFromDbf(ext, FilePath, startRecord, count);
                    UploadMaster.StoredData = m_DbaseFile;
                }
                //else if (ext == ".mdb")
                //{
                //    result = GetItemsFromDatabase(ext, FilePath, startRecord, count);
                //}
                //if (result == Upload506FileError.IncorrectDataFormat)
                //    FlushErrors();
                UploadMaster.SourceType = m_SourceType;
                return result;
            }
            catch (Exception ex)
            {
                LogError(ex);
                return Upload506FileError.InvalidFileFormat;
            }
        }

        private Upload506FileError GetItemsFromDbf(string ext, string filePath, long startRecord, long count)
        {
            m_SourceType = SourceType.DBase;
            Upload506FileError result = Upload506FileError.Success;
            UploadMaster.Items.Clear();
            m_DbaseFile = new FlatDatabase.DBase.File();
            if (m_InputStream != null)
                m_DbaseFile.Attach(m_InputStream, Path.GetFileName(filePath), true);
            else
                m_DbaseFile.Open(filePath, System.IO.FileMode.Open);
            if (m_DbaseFile.RecordCount > MaxItemsCount)
                return Upload506FileError.TooManyRows;

            if (!ValidateHeader(m_DbaseFile))
            {
                return Upload506FileError.IvalidHeaderFormat;
            }
            try
            {
                for (m_DbaseFile.Position = 0; m_DbaseFile.Position < m_DbaseFile.RecordCount; m_DbaseFile.Position++)
                {
                    var itemResult = AddItemFromDbfFile(m_DbaseFile);
                    if (itemResult > 0)
                        result = Upload506FileError.IncorrectDataFormat;
                }
               //m_DbaseFile.Close();
                
            }
            catch (Exception ex)
            {
                LogError(ex);
                result = Upload506FileError.Unknown;
            }
            return result;
        }

        private int AddItemFromDbfFile(FlatDatabase.DBase.File dbfFile)
        {
            int result = 0;
            using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var item = Upload506Item.Accessor.Instance(null).CreateNewT(manager, UploadMaster);
                for (int i = 0; i < dbfFile.Columns.Count; i++)
                {
                    try
                    {
                        var col = dbfFile.Columns[i];
                        var value = dbfFile.GetData(col);
                        var caption = m_FieldsList[i];
                        if (m_Upload506Cells.Contains(caption))
                        {
                            string strValue = null;
                            if (value != null)
                                strValue = value.ToString().TrimEnd();
                            if (!string.IsNullOrEmpty(strValue))
                            {
                                if ((i == m_NameIndex || i == m_AddressIndex))
                                {
                                    strValue = ConvertThaiToUTF8(strValue);
                                }
                                item.SetValue(caption, strValue);
                                if (item.GetValue(caption) == null)
                                {
                                    item.AddError(caption,
                                        string.Format(EidssMessages.Get("msg506DataTypeError"), caption));
                                    result = 4;
                                }
                                else
                                {
                                    if (m_MaxCellLengths.ContainsKey(caption) &&
                                        m_MaxCellLengths[caption] < strValue.Length)
                                    {
                                        item.AddError(caption,
                                            string.Format(EidssMessages.Get("msg506MaxLengthError"), caption));
                                        result = 4;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (value is string)
                            {
                                value = ConvertThaiToUTF8(value.ToString());
                            }
                            item.RawValues.Add(caption, value);
                        }

                    }
                    catch (Exception ex)
                    {
                        LogError(ex);
                        result = 4;
                    }
                }
                UploadMaster.Items.Add(item);
            }
            return result;

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <returns>
        /// 0 - success
        /// 1 - error
        /// </returns>
        public int WriteErrorsToStream(Stream stream)
        {
            try
            {
                FlushErrors(); 
                m_ExcelFileWrapper.Workbook.Write(stream);
                stream.Close();
                return 0;
            }
            catch (Exception ex)
            {
                LogError(ex);
                return 1;
            }
        }
        //public void FlushDataToWorkbook(bool addResultColumns)
        //{
        //    try
        //    {
        //        if (m_ExcelFileWrapper.Workbook == null)
        //            return;
        //        m_ExcelFileWrapper.Workbook.RemoveSheetAt(0);
        //        m_ExcelFileWrapper.CreateHeaderRow(m_FieldsList);
        //        for (int i = 0; i < UploadMaster.Items.Count; i++)
        //        {
        //            var item = UploadMaster.Items[i];
        //            var row = sheet.GetRow(i + 1);
        //            if (row == null)
        //            {
        //                row = m_ExcelFileWrapper.CreateRow(i + 1);
        //                for (int j = 0; j < m_FieldsList.Count; j++)
        //                {
        //                    object value = m_Upload506Cells.Contains(m_FieldsList[j]) ? item.GetValue(m_FieldsList[j]) : item.RawValues[m_FieldsList[j]];
        //                    m_ExcelFileWrapper.SetCellValue(row.CreateCell(j), value);
        //                }
        //            }
        //            foreach (var error in item.validationErrors)
        //            {
        //                if (error.Item1 == "Duplicate")
        //                {
        //                    m_ExcelFileWrapper.SetupErrorRow(row, error.Item2);
        //                    continue;
        //                }
        //                var index = m_CellsMap[error.Item1];
        //                var cell = row.GetCell(index, MissingCellPolicy.CREATE_NULL_AS_BLANK);
        //                m_ExcelFileWrapper.SetupErrorCell(cell, error.Item2);
        //            }
        //        }
        //        return 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        LogError(ex);
        //        return 1;
        //    }
        //}

        public int FlushErrors()
        {
            try
            {
                if (m_ExcelFileWrapper.Workbook == null)
                    return 1;
                m_ExcelFileWrapper.ClearCommentStyles();
                var sheet = m_ExcelFileWrapper.Workbook.GetSheetAt(0);
                if (sheet.PhysicalNumberOfRows == 0)
                    m_ExcelFileWrapper.CreateHeaderRow(m_FieldsList, BaseSettings.Uploading506ReturnOnlyErrorRows);
                for (int i = 0; i < UploadMaster.Items.Count; i++)
                {
                    var item = UploadMaster.Items[i];
                    var row = GetRow(sheet, i, BaseSettings.Uploading506ReturnOnlyErrorRows);
                    foreach (var error in item.validationErrors)
                    {
                        if (error.Item1 == "Duplicate")
                        {
                            m_ExcelFileWrapper.SetupErrorRow(row, error.Item2);
                            continue;
                        }
                        var index = m_CellsMap[error.Item1];
                        var cell = row.GetCell(index, MissingCellPolicy.CREATE_NULL_AS_BLANK);
                        m_ExcelFileWrapper.SetupErrorCell(cell, error.Item2);
                    }
                }
                //UploadMaster.StoredData = m_ExcelFileWrapper.Workbook;
                return 0;
            }
            catch (Exception ex)
            {
                LogError(ex);
                return 1;
            }

        }
        private static string[] Resolutions = { "rsUpdated", "rsCreated", "rsDismissed" };
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <returns>
        /// 0 - success
        /// 1 - error
        /// </returns>
        public int WriteResultToStream(Stream stream)
        {
            if (BaseSettings.Uploading506ResultToExcel || m_SourceType == SourceType.Excel)
                return WriteResultToExcelStream(stream);
            else if (m_SourceType == SourceType.DBase)
                return WriteResultToDbfStream(stream);
            //else if (m_SourceType == SourceType.Access)
            //    return WriteResultToAccessStream(stream);
            return 1;
        }



        #endregion

        #region Private methods
        private void LogError(Exception ex)
        {
            bv.common.Core.LogError.Log("ErrorLog", ex);
        }
        private Upload506FileError GetItemsFromWorkbook()
        {
            m_SourceType = SourceType.Excel;
            UploadMaster.Items.Clear();
            if (!ValidateHeader())
                return Upload506FileError.IvalidHeaderFormat;
            try
            {
                var sheet = m_ExcelFileWrapper.Workbook.GetSheetAt(0);
                if (sheet.PhysicalNumberOfRows > MaxItemsCount + 1)
                    return Upload506FileError.TooManyRows;
                Upload506FileError result = Upload506FileError.Success;
                for (int i = sheet.FirstRowNum + 1; i <= sheet.LastRowNum; i++)
                {
                    var row = sheet.GetRow(i);
                    var itemResult = AddItemFromSheetRow(row);
                    if (itemResult > 0)
                        result = Upload506FileError.IncorrectDataFormat;
                    if (itemResult == -1)//read data until first empty line
                        break;

                }
                return result;
            }
            catch (Exception ex)
            {
                LogError(ex);
                return Upload506FileError.InvalidFileFormat;
            }
        }


        private int AddItemFromSheetRow(IRow row)
        {
            int result = 0;
            using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var item = Upload506Item.Accessor.Instance(null).CreateNewT(manager, UploadMaster);
                bool emptyLine = true;
                foreach (var caption in m_Upload506Cells)
                {
                    try
                    {
                        var cell = row.GetCell(m_CellsMap[caption], MissingCellPolicy.RETURN_NULL_AND_BLANK);
                        if (cell == null)
                            continue;
                        var value = m_ExcelFileWrapper.GetCellValue(cell);
                        if (value != null && value.ToString() != string.Empty)
                        {
                            item.SetValue(caption, value.ToString());
                            if (item.GetValue(caption) == null)
                            {
                                item.AddError(caption,
                                    string.Format(EidssMessages.Get("msg506DataTypeError"), caption));
                                result = 4;
                            }
                            else
                            {
                                emptyLine = false;
                                if (m_MaxCellLengths.ContainsKey(caption) &&
                                    m_MaxCellLengths[caption] < value.ToString().Length)
                                {
                                    item.AddError(caption,
                                        string.Format(EidssMessages.Get("msg506MaxLengthError"), caption));
                                    result = 4;
                                }
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        LogError(ex);
                        result = 4;
                    }
                }
                if (!emptyLine)
                {
                    item.idfsUpload506Item = UploadMaster.Items.Count;
                    UploadMaster.Items.Add(item);
                }
                else
                    return -1;
            }
            return result;
        }

        public static string Convert(string value, Encoding src, Encoding trg)
        {
            Decoder dec = src.GetDecoder();
            byte[] ba = trg.GetBytes(value);
            int len = dec.GetCharCount(ba, 0, ba.Length);
            char[] ca = new char[len];
            dec.GetChars(ba, 0, ba.Length, ca, 0);
            return new string(ca);
        }

        public static string Convert(string value, Encoding src, Encoding trg, Encoding bytesEncoding)
        {
            var buffer = bytesEncoding.GetBytes(value);
            var buffer1 = Encoding.Convert(src, trg, buffer);
            return trg.GetString(buffer1);
        }
        public static string ConvertThaiToUTF8(string value)
        {
            return Convert(value.ToString(), Encoding.GetEncoding(ThaiCodePage), Encoding.UTF8, Encoding.GetEncoding(BaseSettings.Uploading506DbfCodePage));
        }

        //private static DateTime MinDbaseDate = new DateTime(1900, 1, 1);

        //private int AddItemFromDataReader(IDataReader reader)
        //{
        //    int result = 0;
        //    using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
        //    {
        //        var item = Upload506Item.Accessor.Instance(null).CreateNewT(manager, UploadMaster);
        //        bool emptyLine = true;

        //        for (int i = 0; i < reader.FieldCount; i++)
        //        {
        //            try
        //            {

        //                var value = reader.GetValue(i);
        //                var caption = m_FieldsList[i];
        //                if (m_Upload506Cells.Contains(caption))
        //                {
        //                    string strValue = null;
        //                    if (value is decimal)
        //                        strValue = string.Format("{0:F0}", value);
        //                    else if (value is DateTime && ((DateTime)value) < MinDbaseDate)
        //                        value = null;
        //                    else if (value != null)
        //                        strValue = value.ToString().TrimEnd();
        //                    if (!string.IsNullOrEmpty(strValue))
        //                    {
        //                        if (m_SourceType == SourceType.DBase && (i == m_NameIndex || i == m_AddressIndex))
        //                        {
        //                            strValue = ConvertThaiToUTF8(strValue);
        //                        }
        //                        item.SetValue(caption, strValue);
        //                        if (item.GetValue(caption) == null)
        //                        {
        //                            item.AddError(caption,
        //                                string.Format(EidssMessages.Get("msg506DataTypeError"), caption));
        //                            result = 4;
        //                        }
        //                        else
        //                        {
        //                            emptyLine = false;
        //                            if (m_MaxCellLengths.ContainsKey(caption) &&
        //                                m_MaxCellLengths[caption] < strValue.Length)
        //                            {
        //                                item.AddError(caption,
        //                                    string.Format(EidssMessages.Get("msg506MaxLengthError"), caption));
        //                                result = 4;
        //                            }
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    if (m_SourceType == SourceType.DBase && value is string)
        //                    {
        //                        value = ConvertThaiToUTF8(value.ToString());
        //                    }
        //                    item.RawValues.Add(caption, value);
        //                }

        //            }
        //            catch (Exception ex)
        //            {
        //                LogError(ex);
        //                result = 4;
        //            }
        //        }
        //        if (!emptyLine)
        //            UploadMaster.Items.Add(item);
        //        else
        //            return -1;
        //    }
        //    return result;
        //}

        private List<string> InitCellIndicesFromWorkbook()
        {
            m_CellsMap.Clear();
            var sheet = m_ExcelFileWrapper.Workbook.GetSheetAt(0);
            if (sheet == null)
                return m_FieldsList;
            var headerRow = sheet.GetRow(sheet.FirstRowNum);
            for (int i = 0; i < headerRow.Cells.Count; i++)
            {
                var cell = headerRow.Cells[i];
                var caption = cell.StringCellValue;
                if (i == 0 && caption == "Row #")
                    continue;
                if (!string.IsNullOrEmpty(caption) && !m_CellsMap.ContainsKey(caption))
                    m_CellsMap.Add(caption, cell.ColumnIndex);
                m_FieldsList.Add(caption);
            }
            return m_FieldsList;
        }

        public int WriteResultToExcelStream(Stream stream)
        {
            try
            {
                var sheet = m_ExcelFileWrapper.Workbook.GetSheetAt(0);
                var headerRow = m_ExcelFileWrapper.CreateHeaderRow(m_FieldsList, false);
                var cellCaseID = headerRow.CreateCell(headerRow.LastCellNum);
                cellCaseID.SetCellValue("EIDSS Case ID");
                var cellResult = headerRow.CreateCell(headerRow.LastCellNum);
                cellResult.SetCellValue("Status");
                for (int i = 0; i < UploadMaster.Items.Count; i++)
                {
                    var item = UploadMaster.Items[i];
                    var row = GetRow(sheet, i, false);
                    cellCaseID = row.CreateCell(row.LastCellNum);
                    cellCaseID.SetCellValue(item.strCaseID);
                    cellResult = row.CreateCell(row.LastCellNum);
                    if (item.Resolution.HasValue)
                    {
                        cellResult.SetCellValue(EidssMessages.Get(Resolutions[item.Resolution.Value]));
                    }
                }
                m_ExcelFileWrapper.Workbook.Write(stream);
                stream.Close();
                return 0;

            }
            catch (Exception ex)
            {
                LogError(ex);
                return 1;
            }

        }

        //private int WriteResultToDatabase(string filePath, Stream stream)
        //{
        //    var ext = Path.GetExtension(filePath);
        //    string resultFile = Path.ChangeExtension(Path.GetTempFileName(), ext);
        //    File.Copy(filePath, resultFile);
        //    File.SetAttributes(resultFile, FileAttributes.Archive);
        //    var connection = GetConnection(ext, resultFile, true);
        //    using (connection)
        //    {
        //        try
        //        {
        //            connection.Open();
        //            AddResultColumns(ext, connection, resultFile);
        //            var command = CreateUpdateCommand(ext, connection, resultFile);
        //            for (int i = 0; i < UploadMaster.Items.Count; i++)
        //            {
        //                var item = UploadMaster.Items[i];
        //                (command.Parameters["@CaseID"] as OleDbParameter).Value = item.strCaseID;
        //                (command.Parameters["@Status"] as OleDbParameter).Value = item.strStatus;
        //                (command.Parameters["@RecNo"] as OleDbParameter).Value = i + 1;
        //                command.ExecuteNonQuery();
        //            }

        //            connection.Close();
        //            using (FileStream fs = new FileStream(resultFile, FileMode.Open, FileAccess.Read))
        //            {
        //                CopyStream(fs, stream);
        //            }
        //            File.Delete(resultFile);
        //        }
        //        catch (Exception ex)
        //        {
        //            LogError(ex);
        //            return 1;
        //        }
        //        return 0;
        //    }
        //}


        //private int WriteResultToAccessStream(Stream stream)
        //{
        //    throw new Exception("Writing of upload results to mdb file is not supported");
        //}

        private int WriteResultToDbfStream(Stream stream)
        {
            try
            {
                var dbfFile = m_DbaseFile;
                var output = new FlatDatabase.DBase.File();
                var out_columns = new List<FlatDatabase.ColumnInfo>(dbfFile.Columns);
                out_columns.Add(new FlatDatabase.ColumnInfo() { Name = "caseid", DataType = typeof(string), Length = 20 });
                out_columns.Add(new FlatDatabase.ColumnInfo() { Name = "status", DataType = typeof(string), Length = 20 });
                string outFileName = Path.ChangeExtension(Path.GetTempFileName(), ".dbf");
                output.Create(outFileName, out_columns, stream);
                for (dbfFile.Position = 0; dbfFile.Position < dbfFile.RecordCount; dbfFile.Position++)
                {
                    output.AppendRecord();
                    int i = 0;
                    for (i = 0; i < dbfFile.Columns.Count; i++)
                    {
                        var col = dbfFile.Columns[i];
                        var value = dbfFile.GetData(col);
                        output.WriteField(output.Columns[i], dbfFile.GetString(col));
                    }
                    var item = UploadMaster.Items[(int)dbfFile.Position];
                    output.WriteField(output.Columns[i++], item.strCaseID);
                    output.WriteField(output.Columns[i], item.strStatus);
                    output.SaveRecord();
                }

                dbfFile.Close();
                output.Flush();
                output.Close();
                return 0;
            }
            catch (Exception ex)
            {
                LogError(ex);
                return 1;
            }

        }


        private IRow GetRow(ISheet sheet, int itemIndex, bool showErrorRowsOnly)
        {
            var row = sheet.GetRow(itemIndex + 1);
            var item = UploadMaster.Items[itemIndex];
            if (row == null && (!showErrorRowsOnly || item.validationErrors.Count > 0))
            {
                row = m_ExcelFileWrapper.CreateRow(itemIndex + 1);
                if (showErrorRowsOnly)
                    m_ExcelFileWrapper.SetCellValue(row.CreateCell(0), itemIndex);
                int shift = showErrorRowsOnly ? 1 : 0;
                for (int i = 0; i < m_FieldsList.Count; i++)
                {
                    object value = m_Upload506Cells.Contains(m_FieldsList[i]) ? item.GetValue(m_FieldsList[i]) : item.RawValues[m_FieldsList[i]];
                    m_ExcelFileWrapper.SetCellValue(row.CreateCell(i + shift), value);
                }
            }
            return row;
        }
        #endregion

        #region Database reading

        private void CopyStream(Stream input, Stream output)
        {
            byte[] buffer = new byte[8192];
            int bytesRead = 1;
            long length = input.Length;
            // This will finish silently if we couldn't read "length" bytes.
            // An alternative would be to throw an exception
            input.Position = 0;
            while (length > 0 && bytesRead > 0)
            {
                bytesRead = input.Read(buffer, 0, (int)Math.Min(length, buffer.Length));
                output.Write(buffer, 0, bytesRead);
                length -= bytesRead;
            }
            output.Position = 0;
        }
        //private Upload506FileError GetItemsFromDatabase(string ext, string filePath, long startRecord = 0, long count = -1)
        //{
        //    Upload506FileError result = Upload506FileError.Success;
        //    UploadMaster.Items.Clear();
        //    if (m_InputStream != null)
        //    {
        //        filePath = Path.ChangeExtension(Path.GetTempFileName(), ext);
        //        byte[] buffer = new byte[8192];

        //        using (Stream output = File.OpenWrite(filePath))
        //        {
        //            CopyStream(m_InputStream, output);
        //        }
        //    }
        //    var connection = GetConnection(ext, filePath, true);
        //    if (connection == null)
        //        return Upload506FileError.UsupportedExtension;
        //    using (connection)
        //    {
        //        try
        //        {
        //            connection.Open();
        //            var command = CreateSelectCommand(ext, connection, filePath);
        //            var reader = command.ExecuteReader();
        //            if (reader != null)
        //            {
        //                if (!ValidateHeader(reader.GetSchemaTable()))
        //                {
        //                    return Upload506FileError.IvalidHeaderFormat;
        //                }
        //                long i = -1;
        //                long lastRecord = startRecord + count - 1;
        //                while (reader.Read())
        //                {
        //                    i++;
        //                    if (count > 0 && i < startRecord)
        //                        continue;
        //                    if (count > 0 && i > lastRecord)
        //                        break;
        //                    var itemResult = AddItemFromDataReader(reader);
        //                    if (itemResult > 0)
        //                        result = Upload506FileError.IncorrectDataFormat;
        //                }
        //                reader.Close();
        //            }
        //            connection.Close();
        //        }
        //        catch (Exception ex)
        //        {
        //            LogError(ex);
        //            result = Upload506FileError.Unknown;
        //        }
        //    }
        //    return result;

        //}


        //private IDbCommand CreateSelectCommand(string ext, DbConnection connection, string filePath)
        //{
        //    switch (ext)
        //    {
        //        case ".mdb":
        //            var oleConnection = connection as OleDbConnection;
        //            var schemaTable = oleConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables,
        //                new object[] { null, null, null, "TABLE" });
        //            var tableName = schemaTable.Rows[0]["TABLE_NAME"];
        //            var cmd = new OleDbCommand("Select * From [" + tableName + "]", oleConnection);
        //            cmd.CommandType = CommandType.Text;
        //            return cmd;
        //        case ".dbf":
        //            var dbfConnection = connection as OleDbConnection;
        //            var dbfCmd = new OleDbCommand("Select * From [" + Path.GetFileName(filePath) + "]", dbfConnection);
        //            dbfCmd.CommandType = CommandType.Text;
        //            return dbfCmd;
        //    }
        //    return null;
        //}
        //private IDbCommand CreateUpdateCommand(string ext, DbConnection connection, string filePath)
        //{
        //    switch (ext)
        //    {
        //        case ".mdb":
        //            var oleConnection = connection as OleDbConnection;
        //            var schemaTable = oleConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables,
        //                new object[] { null, null, null, "TABLE" });
        //            var tableName = schemaTable.Rows[0]["TABLE_NAME"];
        //            var cmd = new OleDbCommand("Select * From [" + tableName + "]", oleConnection);
        //            cmd.CommandType = CommandType.Text;
        //            return cmd;
        //        case ".dbf":
        //            var dbfConnection = connection as OleDbConnection;
        //            var dbfCmd = new OleDbCommand("UPDATE [" + Path.GetFileName(filePath) + "] SET CaseID = ?, Status = ? Where RECNO() = ?", dbfConnection);
        //            dbfCmd.Parameters.Add("@CaseID", OleDbType.Char);
        //            dbfCmd.Parameters.Add("@Status", OleDbType.Char);
        //            dbfCmd.Parameters.Add("@RecNo", OleDbType.Integer);
        //            dbfCmd.CommandType = CommandType.Text;
        //            return dbfCmd;
        //    }
        //    return null;
        //}

        //private void AddResultColumns(string ext, DbConnection connection, string filePath)
        //{
        //    switch (ext)
        //    {
        //        case ".mdb":
        //            var oleConnection = connection as OleDbConnection;
        //            var schemaTable = oleConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables,
        //                new object[] { null, null, null, "TABLE" });
        //            var tableName = schemaTable.Rows[0]["TABLE_NAME"];
        //            var cmd = new OleDbCommand("Select * From [" + tableName + "]", oleConnection);
        //            cmd.CommandType = CommandType.Text;
        //            break;
        //        case ".dbf":
        //            //var connectionStringDbf = string.Format(@"Data Source={0}; Provider=vfpoledb.1;Exclusive=No;Collating Sequence=Machine;CODEPAGE = 1251", Path.GetDirectoryName(filePath));
        //            //using (var dbfConnection = new OleDbConnection(connectionStringDbf))
        //            //{
        //            //if (connection.State == ConnectionState.Open)
        //            //    connection.Close();
        //            //dbfConnection.Open();
        //            var dbfConnection = (OleDbConnection)connection;
        //            OleDbCommand dbfCmd = new OleDbCommand("", dbfConnection);
        //            string sql = "ALTER TABLE [" + Path.GetFileName(filePath) + "] ADD COLUMN [CaseID] VARCHAR(200) NULL";
        //            dbfCmd.CommandType = CommandType.Text;
        //            dbfCmd.CommandText = "ALTER TABLE [" + Path.GetFileName(filePath) + "] ADD COLUMN [CaseID] VARCHAR(200) NULL";
        //            dbfCmd.ExecuteNonQuery();
        //            dbfCmd.CommandText = "ALTER TABLE [" + Path.GetFileName(filePath) + "] ADD COLUMN [Status] VARCHAR(200) NULL";
        //            dbfCmd.ExecuteNonQuery();
        //            //dbfConnection.Close();
        //            //connection.Open();
        //            //}
        //            break;
        //    }
        //}
        //private DbConnection GetConnection(string ext, string filePath, bool useVpf = false)
        //{
        //    switch (ext)
        //    {
        //        case ".mdb":
        //            m_SourceType = SourceType.Access;
        //            var connectionString = string.Format(@"Data Source={0}; Provider=Microsoft.JET.OLEDB.4.0", filePath);
        //            return new OleDbConnection(connectionString);
        //        case ".dbf":
        //            m_SourceType = SourceType.DBase;
        //            var connectionStringDbf = useVpf ?
        //                string.Format(@"Data Source={0}; Provider=vfpoledb.1;Exclusive=No;Collating Sequence=Machine;CODEPAGE = 1251", Path.GetDirectoryName(filePath)) :
        //                string.Format(@"Data Source={0}; Provider=Microsoft.JET.OLEDB.4.0;Extended Properties=DBase IV; User ID=;Password=;", Path.GetDirectoryName(filePath));
        //            return new OleDbConnection(connectionStringDbf);
        //    }
        //    return null;
        //}

        #endregion

        #region unused methods
        //this method of initialization is fast and empty, but can cause problem on 64 bit PC because of absent 64 bit drivers.
        //it is left as one of possible variants for future
        //private int GetItemsFromExcel(string filePath)
        //{
        //    int result = 0;
        //    string connectionString =
        //        string.Format(
        //            "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0;HDR=No;IMEX=1\"",
        //            filePath);
        //    UploadMaster.Items.Clear();
        //    var oleExcelConnection = new OleDbConnection(connectionString);
        //    try
        //    {
        //        oleExcelConnection.Open();
        //        string sheetName = null;
        //        using (var dtTablesList = oleExcelConnection.GetSchema("Tables"))
        //        {
        //            if (dtTablesList.Rows.Count > 0)
        //            {
        //                sheetName = dtTablesList.Rows[0]["TABLE_NAME"].ToString();
        //            }
        //            dtTablesList.Clear();
        //        }
        //        if (!string.IsNullOrEmpty(sheetName))
        //        {
        //            var oleExcelCommand = oleExcelConnection.CreateCommand();
        //            oleExcelCommand.CommandText = "Select * From [" + sheetName + "]";
        //            oleExcelCommand.CommandType = CommandType.Text;
        //            var oleExcelReader = oleExcelCommand.ExecuteReader();
        //            if (oleExcelReader != null)
        //            {
        //                if (oleExcelReader.Read())
        //                {
        //                    if (!ValidateHeader(oleExcelReader))
        //                    {
        //                        return 3;
        //                    }
        //                    while (oleExcelReader.Read())
        //                    {
        //                        var itemResult = AddItemFromDataReader(oleExcelReader);
        //                        if (itemResult > 0)
        //                            result = 4;
        //                        if (itemResult == -1)//read data until first empty line
        //                            break;
        //                    }
        //                }
        //                oleExcelReader.Close();
        //            }
        //        }
        //        oleExcelConnection.Close();
        //        m_ExcelFileWrapper.Read(filePath);
        //    }
        //    catch (Exception ex)
        //    {
        //        LogError(ex);
        //        result = 5;
        //    }
        //    return result;
        //}

        /// <summary>
        /// </summary>
        /// <param name="allCaptions"></param>
        /// <returns></returns>
        private bool ValidateHeaderInternal(List<string> allCaptions)
        {
            m_HeaderErrors.Clear();
            foreach (var cell in m_Upload506Cells)
            {
                int count = allCaptions.Count(c => c == cell);
                if (count == 0)
                    m_HeaderErrors.Add(string.Format(EidssMessages.Get("msg506AbsentColumn"), cell));
                if (count > 1)
                    m_HeaderErrors.Add(string.Format(EidssMessages.Get("msg506DuplicateColumn"), cell));
            }
            return m_HeaderErrors.Count == 0;
        }

        /// <summary>
        /// Method is called to validate headers in excel upload file
        /// </summary>
        /// <returns></returns>
        private bool ValidateHeader()
        {
            var allCaptions = InitCellIndicesFromWorkbook();
            return ValidateHeaderInternal(allCaptions);
        }

        private bool ValidateHeader(FlatDatabase.DBase.File dbfFile)
        {
            m_CellsMap.Clear();
            m_FieldsList.Clear();
            for (int i = 0; i < dbfFile.Columns.Count; i++)
            {
                var caption = dbfFile.Columns[i].Name.ToUpperInvariant();
                if (!m_CellsMap.ContainsKey(caption))
                {
                    m_CellsMap.Add(caption, i);
                }
                m_FieldsList.Add(caption);
            }
            m_ExcelFileWrapper.CreateHeaderRow(m_FieldsList, BaseSettings.Uploading506ReturnOnlyErrorRows);
            return ValidateHeaderInternal(m_FieldsList);
        }

        /// <summary>
        /// Method is called to validate headers in database upload file
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        //private bool ValidateHeader(DataTable dataTable)
        //{
        //    m_CellsMap.Clear();
        //    m_FieldsList.Clear();
        //    for (int i = 0; i < dataTable.Rows.Count; i++)
        //    {
        //        DataRow row = dataTable.Rows[i];
        //        var caption = row.Field<string>("ColumnName").ToUpperInvariant();
        //        if (!m_CellsMap.ContainsKey(caption))
        //        {
        //            m_CellsMap.Add(caption, i);
        //        }
        //        m_FieldsList.Add(caption);
        //    }
        //    m_ExcelFileWrapper.CreateHeaderRow(m_FieldsList, BaseSettings.Uploading506ReturnOnlyErrorRows);
        //    return ValidateHeaderInternal(m_FieldsList);
        //}

        /// <summary>
        /// Method is called to validate headers in execel upload file if OLEDB provider is used to read excel file
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        //private bool ValidateHeader(IDataReader reader)
        //{
        //    m_CellsMap.Clear();
        //    m_FieldsList.Clear();
        //    for (int i = 0; i < reader.FieldCount; i++)
        //    {
        //        var caption = reader.GetString(i);
        //        if (!m_CellsMap.ContainsKey(caption))
        //        {
        //            m_CellsMap.Add(caption, i);
        //        }
        //        m_FieldsList.Add(caption);
        //    }
        //    return ValidateHeaderInternal(m_FieldsList);
        //}
        #endregion
    }
}

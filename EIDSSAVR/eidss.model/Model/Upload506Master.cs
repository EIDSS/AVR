using bv.common.Configuration;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.model.Helpers;
using eidss.model.Resources;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using bv.common.Core;

namespace eidss.model.Schema
{
    public partial class Upload506Master
    {
        partial void Disposed()
        {
            Clear();
        }

        public class Upload506AfterPostItem
        {
            public long idfHumanCase;
            public long idfsUpload506Item;
            public string strCaseID;
        }

        public object StoredData { get; set; }
        private Upload506MasterState m_state = Upload506MasterState.ReadyForUpload;
        private Upload506FileError m_lastError = Upload506FileError.Success;
        private string m_lastErrorMessage;
        private string m_errorFileName;
        private string m_resultFileName;
        private MemoryStream m_errorsFile;
        private MemoryStream m_resultFile;

        public MemoryStream ErrorsFile
        {
            get { return m_errorsFile; }
        }

        public MemoryStream ResultFile
        {
            get { return m_resultFile; }
        }

        public SourceType SourceType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// Error code:
        /// 0 - no errors
        /// 1 - file doesn't exists
        /// 2 - usupported extension
        /// 3 - Ivalid header format (some 506 column names are absent or duplicated)
        /// 4 - incorrect data format in some cells
        /// 5 - invalid file format, error duirng file reading
        /// </returns>
        public void GetItems(string fileName, Stream fileStream)
        {
            using (var fileProcessor = new Upload506FileProcessor(fileStream, fileName, this))
            {
                Clear();
                FileName = fileName;
                var result = fileProcessor.GetItems();
                switch (result)
                {
                    case Upload506FileError.Success:
                        SetState(Upload506MasterState.ReadyForValidation);
                        break;
                    case Upload506FileError.IvalidHeaderFormat:
                        SetError(result, fileProcessor.HeaderError);
                        break;
                    default:
                        SetError(result);
                        break;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// Error code:
        /// 0 - no errors
        /// 1 - file doesn't exists
        /// 2 - usupported extension
        /// 3 - Ivalid header format (some 506 column names are absent or duplicated)
        /// 4 - incorrect data format in some cells
        /// 5 - invalid file format, error duirng file reading
        /// </returns>
        public Upload506FileError GetItems(string filePath, long startRecord = 0, long count = -1)
        {
            using (var fileProcessor = new Upload506FileProcessor(filePath, this))
            {
                Clear();
                FileName = filePath;
                var result = fileProcessor.GetItems(startRecord, count);
                switch (result)
                {
                    case Upload506FileError.Success:
                        SetState(Upload506MasterState.ReadyForValidation);
                        break;
                    case Upload506FileError.IvalidHeaderFormat:
                        SetError(result, fileProcessor.HeaderError);
                        break;
                    default:
                        SetError(result);
                        break;
                }

                return result;
            }
        }

        /// <summary>
        /// Writes errors found during 506 file parsing into output stream in xlsx format
        /// Stream must be created in calling method
        /// </summary>
        /// <param name="stream"></param>
        /// <returns>
        /// 0 - success
        /// 1 - error
        /// </returns>
        public int WriteErrorsToStream(Stream stream)
        {
            using (var fileProcessor = new Upload506FileProcessor(this))
            {
                return fileProcessor.WriteErrorsToStream(stream);
            }
        }

        /// <summary>
        /// Writes errors found during 506 file parsing into output file in xlsx format
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>
        /// 0 - success
        /// 1 - error
        /// </returns>
        public int WriteErrorsToFile(string filePath)
        {
            try
            {
                using (var fileProcessor = new Upload506FileProcessor(this))
                {
                    using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite))
                    {
                        return fileProcessor.WriteErrorsToStream(stream);
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.Log("ErrorLog", ex);
                return 1;
            }
        }

        /// <summary>
        /// Updates original file content with Eidss Case ID/Status columns and writes result to output stream in original format
        /// Stream must be created in calling method
        /// </summary>
        /// <param name="stream"></param>
        /// <returns>
        /// 0 - success
        /// 1 - error
        /// </returns>
        public int WriteResultToStream(Stream stream)
        {
            if (StoredData == null)
            {
                return 1;
            }
            using (var fileProcessor = new Upload506FileProcessor(this))
            {
                return fileProcessor.WriteResultToStream(stream);
            }
        }

        ///  <summary>
        /// Updates original file content with Eidss Case ID/Status columns and writes result to output file in original format
        ///  </summary>
        /// <param name="filePath"></param>
        /// <returns>
        ///  0 - success
        ///  1 - error
        ///  </returns>
        public int WriteResultToFile(string filePath)
        {
            try
            {
                using (var fileProcessor = new Upload506FileProcessor(this))
                {
                    using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite))
                    {
                        var result = fileProcessor.WriteResultToStream(stream);
                        stream.Close();
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.Log("ErrorLog", ex);
                return 1;
            }
        }

        public bool ValidateItems()
        {
            var dict = new Dictionary<string, int>();
            Items.ForEach(i =>
            {
                if (dict.ContainsKey(i.HSERV)) dict[i.HSERV] = dict[i.HSERV] + 1;
                else dict.Add(i.HSERV, 1);
            });

            var HSERVmaster = BaseSettings.Uploading506HSERVUnique 
                ? dict.OrderByDescending(i => i.Value).FirstOrDefault().Key
                : "";
            var result = true;
            Items.ForEach(i => { var t = i.ValidateItem(HSERVmaster); result = result && t; });
            if (!ValidateDuplicates())
                result = false;
            if (result)
                SetState(Upload506MasterState.ReadyForCheckDuplicates);
            else
            {
                //using (var fileProcessor = new Upload506FileProcessor(this))
                //{
                //    fileProcessor.FlushErrors();
                //}
                SetError(Upload506FileError.ValidationError, string.Format(EidssMessages.Get("msgUploadFileValidationError"), GetErrorFileName()));
            }

            return result;
        }
        private readonly Dictionary<int, HashSet<Upload506Item>> m_DuplicatedItems = new Dictionary<int, HashSet<Upload506Item>>();//hash->List of items with this hash dictionary
        private bool ValidateDuplicates()
        {
            PrepareDuplicatesHashes();
            var duplicates = m_DuplicatedItems.Where(d => d.Value.Count > 1).ToList();
            bool result = true;
            foreach (var d in duplicates)
            {
                if (!MarkDuplicatedItems(d.Value))
                    result = false;
            }
            return result;
        }

        private bool MarkDuplicatedItems(HashSet<Upload506Item> items)
        {
            bool result = true;
            using (var e = items.GetEnumerator())
            {
                var buffer = new List<Upload506Item>();

                while (e.MoveNext())
                {
                    foreach (var item in buffer)
                    {
                        if (Math.Abs((item.DATEDEFINE - e.Current.DATEDEFINE).GetValueOrDefault().Days) <= 30)
                        {
                            item.AddError("Duplicate",
                                String.Format(EidssMessages.Get("msg506RecordIsDuplicate"),
                                    e.Current.idfsUpload506Item + 2));
                            e.Current.AddError("Duplicate",
                                String.Format(EidssMessages.Get("msg506RecordIsDuplicate"),
                                    item.idfsUpload506Item + 2));
                            result = false;
                        }
                    }
                    buffer.Add(e.Current);
                }
            }
            return result;
        }

        private void PrepareDuplicatesHashes()
        {
            m_DuplicatedItems.Clear();
            foreach (var item in Items)
            {
                int hash = CalculateDuplicationHash(item);
                AddDuplicatedItemHash(hash, item);
            }
        }

        private int CalculateDuplicationHash(Upload506Item item)
        {
            var s = Utils.Str(item.NAME) + Utils.Str(item.DISEASE) + Utils.Str(item.HSERV);
            return s.GetHashCode();
        }

        private void AddDuplicatedItemHash(int hash, Upload506Item item)
        {
            if (m_DuplicatedItems.ContainsKey(hash))
            {
                if (!m_DuplicatedItems[hash].Contains(item))
                    m_DuplicatedItems[hash].Add(item);
            }
            else
                m_DuplicatedItems.Add(hash, new HashSet<Upload506Item>() { item });
        }


        private static List<string> g_listUploadingSessions = new List<string>();
        public void EnterUploadingSession()
        {
            lock (g_listUploadingSessions)
            {
                if (!g_listUploadingSessions.Contains(ModelUserContext.ClientID))
                    g_listUploadingSessions.Add(ModelUserContext.ClientID);
            }
        }
        public void LeaveUploadingSession()
        {
            lock (g_listUploadingSessions)
            {
                if (g_listUploadingSessions.Contains(ModelUserContext.ClientID))
                    g_listUploadingSessions.Remove(ModelUserContext.ClientID);
            }
        }
        public bool IsUploadingSessionAvailable()
        {
            lock (g_listUploadingSessions)
            {
                return g_listUploadingSessions.Count < BaseSettings.UploadingSessionsCount;
            }
        }

        public void SetResolutionForDuplicate(long id, Upload506Resolution resolution)
        {
            var updateItem = Duplicates.FirstOrDefault(i => i.idfCase == id);

            if (updateItem != null)
                updateItem.Item.Resolution = (int)resolution;
        }

        public void DismissAllDuplicates()
        {
            if (m_state != Upload506MasterState.HasDuplicates && m_state != Upload506MasterState.HasDuplicatesResolutionErrors)
                return;

            var duplicates = Duplicates.Where(d => !d.Resolved).ToList();

            duplicates.ForEach(d =>
            {
                d.Item.Resolution = (int)Upload506Resolution.Dismissed;
                d.Resolved = true;
                d.Item.strCaseID = d.strCaseID;
                d.Item.idfCase = d.idfCase;
            }
            );

            SetState(Upload506MasterState.ReadyForSave);
        }

        public void FinalizeResolveDuplicates()
        {
            if (m_state != Upload506MasterState.HasDuplicates && m_state != Upload506MasterState.HasDuplicatesResolutionErrors)
                return;

            Duplicates.Where(d => d.Item.Resolution == (int)Upload506Resolution.Dismissed
                                  || d.Item.Resolution == (int)Upload506Resolution.Created
                                  || d.Item.Resolution == (int)Upload506Resolution.Updated)
                .ToList()
                .ForEach(d =>
                {
                    d.Resolved = true;
                    d.Item.strCaseID = d.strCaseID;
                    d.Item.idfCase = d.idfCase;
                });

            if (Duplicates.Any(d => !d.Resolved))
                SetState(Upload506MasterState.HasDuplicatesResolutionErrors);
            else
                SetState(Upload506MasterState.ReadyForSave);
        }

        public bool CheckForDuplicates()
        {
            if (m_state != Upload506MasterState.ReadyForCheckDuplicates)
                return false;

            Duplicates.Clear();

            using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                foreach (var upload506Item in Items)
                {
                    var updateItem = Upload506Duplicate.Accessor.Instance(null).SelectByItem(manager, upload506Item);

                    if (updateItem != null)
                    {
                        Duplicates.Add(updateItem);
                    }
                    else
                    {
                        upload506Item.Resolution = (int)Upload506Resolution.Created;
                    }
                }
            }

            if (Duplicates.Count > 0)
            {
                SetState(Upload506MasterState.HasDuplicates);
                return false;
            }

            SetState(Upload506MasterState.ReadyForSave);

            return true;
        }

        public void Cancel()
        {
            SetState(Upload506MasterState.Canceled);
        }

        private string GetMessageByCode(Upload506FileError errorCode)
        {
            string errorMessage;

            switch (errorCode)
            {
                case Upload506FileError.Success:
                    errorMessage = null;
                    break;
                case Upload506FileError.NullFile:				 // file doesn't exists
                    errorMessage = EidssMessages.Get("msgUploadFileNullFile");
                    break;
                case Upload506FileError.IncorrectDataFormat:	// incorrect data format in some cells
                    errorMessage = string.Format(EidssMessages.Get("msgUploadFileValidationError"), GetErrorFileName());
                    break;
                case Upload506FileError.UsupportedExtension:	// usupported extension
                    errorMessage = EidssMessages.Get("msg506UnsupportedExtention");
                    break;
                case Upload506FileError.InvalidFileFormat:		// invalid file format, error duirng file reading
                    errorMessage = EidssMessages.Get("msgUploadFileInvalidFormat");
                    break;
                case Upload506FileError.TooManyRows:		// invalid file format, error duirng file reading
                    errorMessage = EidssMessages.Get("msgUploadFileTooManyRows");
                    break;
                default:
                    errorMessage = EidssMessages.Get("msgUploadFileError");
                    break;
            }

            return errorMessage;
        }

        public bool HasFileWithErrors()
        {
            return (m_state == Upload506MasterState.HasErrors && m_errorsFile != null);

            //return (m_state == Upload506MasterState.HasErrors &&
            //	(m_lastError == Upload506FileError.IncorrectDataFormat ||
            //	 m_lastError == Upload506FileError.ValidationError));
        }

        public string[] GetLastError()
        {
            if (m_state != Upload506MasterState.HasErrors)
            {
                m_lastErrorMessage = string.Empty;
                m_lastError = Upload506FileError.Success;
            }

            return m_lastErrorMessage.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        }

        private void SetError(Upload506FileError errorCode, string errorMessage)
        {
            SetState(Upload506MasterState.HasErrors);
            m_lastError = errorCode;
            m_lastErrorMessage = errorMessage;

            if (errorCode == Upload506FileError.IncorrectDataFormat || errorCode == Upload506FileError.ValidationError)
            {
                m_errorsFile = new MemoryStream();
                WriteErrorsToStream(m_errorsFile);
            }
        }

        private void SetError(Upload506FileError errorCode)
        {
            SetError(errorCode, GetMessageByCode(errorCode));
        }

        public void SetError(string errorMessage)
        {
            SetError(Upload506FileError.Unknown, errorMessage);
        }

        public Upload506MasterState GetState()
        {
            return m_state;
        }

        private void SetState(Upload506MasterState newState)
        {
            m_state = newState;

            if (newState != Upload506MasterState.HasErrors)
                m_errorsFile = null;

            if (newState != Upload506MasterState.Saved)
                m_resultFile = null;
        }

        public void Clear()
        {
            try
            {
                Items.Clear();
                Duplicates.Clear();

                m_lastErrorMessage = string.Empty;
                m_lastError = Upload506FileError.Success;

                FileName = null;
                FileContent = null;
                m_resultFileName = null;
                m_errorFileName = null;
                var disposable = StoredData as IDisposable;
                if (disposable != null)
                    disposable.Dispose();
                StoredData = null;
                if (m_errorsFile != null)
                {
                    m_errorsFile.Dispose();
                    m_errorsFile = null;
                }
                if (m_resultFile != null)
                {
                    m_resultFile.Dispose();
                    m_resultFile = null;
                }

                SetState(Upload506MasterState.ReadyForUpload);

            }
            catch (Exception ex)
            {
                LogError.Log("ErrorLog", ex);
            }
        }

        public string GetErrorFileName()
        {
            var clearFileName = string.IsNullOrWhiteSpace(FileName) ? string.Empty : Path.GetFileNameWithoutExtension(FileName);

            if (string.IsNullOrWhiteSpace(m_errorFileName) || !m_errorFileName.Contains(clearFileName))
            {
                string ext = ".xls";
                if (!string.IsNullOrWhiteSpace(FileName))
                {
                    ext = Path.GetExtension(FileName);
                    if (ext != ".xls" && ext != ".xlsx")
                        ext = ".xls";
                }
                m_errorFileName = string.Format("{0}_Errors_{1}{2}", clearFileName, DateTime.Now.ToString("yyyyMMddHHmmss"), ext);
            }

            return m_errorFileName;
        }

        public string GetResultFileName()
        {
            var clearFileName = string.IsNullOrWhiteSpace(FileName) ? string.Empty : Path.GetFileNameWithoutExtension(FileName);

            if (string.IsNullOrWhiteSpace(m_resultFileName) || !m_resultFileName.Contains(clearFileName))
            {
                string ext = ".xls";
                if (!string.IsNullOrWhiteSpace(FileName))
                {
                    ext = Path.GetExtension(FileName);
                    if (BaseSettings.Uploading506ResultToExcel && ext != ".xls" && ext != ".xlsx")
                        ext = ".xls";
                }

                m_resultFileName = string.Format("{0}_Results_{1}{2}", clearFileName, DateTime.Now.ToString("yyyyMMddHHmmss"), ext);
            }

            return m_resultFileName;
        }
    }

    /*WorkFlow:
	  
     ReadyForUpload->HasErrors
     *			|
     *			->ReadyForValidation->HasErrors->ReadyForUpload
     *							|
     *							->ReadyForCheckDuplicates->HasDuplicates->ReadyForSave
     *												|				|
     *												|				->HasDuplicatesResolutionErrors->ReadyForSave
     *												->ReadyForSave->Saved
     *															|
     *															->Canceled
     *															
     * When the user begins upload a new file the sate is ReadyForUpload
    */
    public enum Upload506MasterState
    {
        ReadyForUpload = 0,
        HasErrors = 1,
        ReadyForValidation = 2,
        //HasValidationErrors = 3,
        ReadyForCheckDuplicates = 4,
        HasDuplicates = 5,
        HasDuplicatesResolutionErrors = 6,
        ReadyForSave = 7,
        Saved = 8,
        Canceled = 9
    }

    public enum Upload506FileError
    {
        Unknown = -1,
        Success = 0,
        NullFile = 1,
        UsupportedExtension = 2,
        IvalidHeaderFormat = 3,
        IncorrectDataFormat = 4,
        InvalidFileFormat = 5,
        ValidationError = 6,
        TooManyRows = 7
    }
}

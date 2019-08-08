using System.IO;
using AUM.Core.Helper;

namespace AUM.Core.Transactions
{
    /// <summary>
    /// Rollbackable operation which deletes a file. An exception is not thrown if the file does not exist.
    /// </summary>
    sealed class DeleteFileOperation : SingleFileOperation
    {
        /// <summary>
        /// Instantiates the class.
        /// </summary>
        /// <param name="path">The file to be deleted.</param>
        public DeleteFileOperation(string path)
            : base(path)
        {
        }

        public override void Execute()
        {
            if (File.Exists(m_Path))
            {
                var temp = FileUtils.GetTempFileName(Path.GetExtension(m_Path));
                File.Copy(m_Path, temp);
                m_BackupPath = temp;
            }

            FileHelper.DeleteFile(m_Path);
            //File.Delete(path);
        }
    }
}

using System.IO;
using AUM.Core.Helper;

namespace AUM.Core.Transactions
{
    /// <summary>
    /// Rollbackable operation which copies a file.
    /// </summary>
    sealed class CopyOperation : SingleFileOperation
    {
        private readonly string m_SourceFileName;

        /// <summary>
        /// Instantiates the class.
        /// </summary>
        /// <param name="sourceFileName">The file to copy.</param>
        /// <param name="destFileName">The name of the destination file.</param>
        public CopyOperation(string sourceFileName, string destFileName)
            : base(destFileName)
        {
            m_SourceFileName = sourceFileName;
        }

        public override void Execute()
        {
            if (File.Exists(m_Path))
            {
                var temp = FileUtils.GetTempFileName(Path.GetExtension(m_Path));
                File.Copy(m_Path, temp);
                m_BackupPath = temp;
            }
            FileHelper.CopyFile(m_SourceFileName, m_Path);
            //File.Copy(m_SourceFileName, path, m_Overwrite);
        }
    }
}

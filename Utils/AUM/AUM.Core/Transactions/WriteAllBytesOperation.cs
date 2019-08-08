using System.IO;

namespace AUM.Core.Transactions
{
    /// <summary>
    /// Creates a file, and writes the specified contents to it.
    /// </summary>
    sealed class WriteAllBytesOperation : SingleFileOperation
    {
        private readonly byte[] m_Contents;

        /// <summary>
        /// Instantiates the class.
        /// </summary>
        /// <param name="path">The file to write to.</param>
        /// <param name="contents">The string to write to the file.</param>
        public WriteAllBytesOperation(string path, byte[] contents)
            : base(path)
        {
            m_Contents = contents;
        }

        public override void Execute()
        {
            if (File.Exists(m_Path))
            {
                var temp = FileUtils.GetTempFileName(Path.GetExtension(m_Path));
                File.Copy(m_Path, temp);
                m_BackupPath = temp;
            }

            File.WriteAllBytes(m_Path, m_Contents);
        }
    }
}
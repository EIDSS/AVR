using System.IO;

namespace AUM.Core.Transactions
{
    /// <summary>
    /// Rollbackable operation which appends a string to an existing file, or creates the file if it doesn't exist.
    /// </summary>
    sealed class AppendAllTextOperation : SingleFileOperation
    {
        private readonly string m_Contents;

        /// <summary>
        /// Instantiates the class.
        /// </summary>
        /// <param name="path">The file to append the string to.</param>
        /// <param name="contents">The string to append to the file.</param>
        public AppendAllTextOperation(string path, string contents)
            : base(path)
        {
            this.m_Contents = contents;
        }

        public override void Execute()
        {
            if (File.Exists(m_Path))
            {
                var temp = FileUtils.GetTempFileName(Path.GetExtension(m_Path));
                File.Copy(m_Path, temp);
                m_BackupPath = temp;
            }

            File.AppendAllText(m_Path, m_Contents);
        }
    }
}

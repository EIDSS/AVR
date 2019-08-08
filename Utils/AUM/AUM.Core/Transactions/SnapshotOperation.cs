using System.IO;

namespace AUM.Core.Transactions
{
    /// <summary>
    /// Rollbackable operation which takes a snapshot of a file. The snapshot is used to rollback the file later if needed.
    /// </summary>
    sealed class SnapshotOperation: SingleFileOperation
    {
        /// <summary>
        /// Instantiates the class.
        /// </summary>
        /// <param name="path">The file to take a snapshot for.</param>
        public SnapshotOperation(string path) : base(path)
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
        }
    }
}

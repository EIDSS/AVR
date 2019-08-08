using System.IO;

namespace AUM.Core.Transactions
{
    /// <summary>
    /// Creates all directories in the specified path.
    /// </summary>
    sealed class CreateDirectoryOperation : IRollbackableOperation
    {
        private readonly string m_Path;
        private string m_BackupPath;

        /// <summary>
        /// Instantiates the class.
        /// </summary>
        /// <param name="path">The directory path to create.</param>
        public CreateDirectoryOperation(string path)
        {
            m_Path = path;
        }

        public void Execute()
        {
            // find the topmost directory which must be created
            var children = Path.GetFullPath(m_Path).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
            var parent = Path.GetDirectoryName(children);
            while (parent != null /* children is a root directory */
                && !Directory.Exists(parent))
            {
                children = parent;
                parent = Path.GetDirectoryName(children);
            }

            if (Directory.Exists(children))
            {
                // nothing to do
                return;
            }
            Directory.CreateDirectory(m_Path);
            m_BackupPath = children;
        }

        public void Rollback()
        {
            if (m_BackupPath != null)
            {
                Directory.Delete(m_BackupPath, true);
            }
        }
    }
}

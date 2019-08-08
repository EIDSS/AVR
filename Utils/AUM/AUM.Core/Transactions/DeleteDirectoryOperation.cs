using System;
using System.IO;
using AUM.Core.Helper;

namespace AUM.Core.Transactions
{
    /// <summary>
    /// Deletes the specified directory and all its contents.
    /// </summary>
    sealed class DeleteDirectoryOperation : IRollbackableOperation, IDisposable
    {
        private readonly string m_Path;
        private string m_BackupPath;
        // tracks whether Dispose has been called
        private bool m_Disposed;

        /// <summary>
        /// Instantiates the class.
        /// </summary>
        /// <param name="path">The directory path to delete.</param>
        public DeleteDirectoryOperation(string path)
        {
            m_Path = path;
        }

        /// <summary>
        /// Disposes the resources used by this class.
        /// </summary>
        ~DeleteDirectoryOperation()
        {
            InnerDispose();
        }

        public void Execute()
        {
            if (Directory.Exists(m_Path))
            {
                var temp = FileUtils.GetTempFileName(String.Empty);
                MoveDirectory(m_Path, temp);
                m_BackupPath = temp;
            }
        }

        public void Rollback()
        {
            if (Directory.Exists(m_BackupPath))
            {
                var parentDirectory = Path.GetDirectoryName(m_Path);
                if ((parentDirectory != null) && !Directory.Exists(parentDirectory))
                {
                    Directory.CreateDirectory(parentDirectory);
                }
                MoveDirectory(m_BackupPath, m_Path);
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            InnerDispose();
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Moves a directory, recursively, from one path to another.
		/// This is a version of <see cref="Directory.Move"/> that works across volumes.
        /// </summary>
        private static void MoveDirectory(string sourcePath, string destinationPath)
        {
            if (Directory.GetDirectoryRoot(sourcePath) == Directory.GetDirectoryRoot(destinationPath))
            {
                // The source and destination volumes are the same, so we can do the much less expensive Directory.Move.
                Directory.Move(sourcePath, destinationPath);
            }
            else
            {
                // The source and destination volumes are different, so we have to resort to a copy/delete.
                CopyDirectory(new DirectoryInfo(sourcePath), new DirectoryInfo(destinationPath));
                Directory.Delete(sourcePath, true);
            }
        }

        private static void CopyDirectory(DirectoryInfo sourceDirectory, DirectoryInfo destinationDirectory)
        {
            FileHelper.CopyDirs(sourceDirectory.FullName, destinationDirectory.FullName);
        }
		
        /// <summary>
        /// Disposes the resources of this class.
        /// </summary>
        private void InnerDispose()
        {
            if (!m_Disposed)
            {
                if (Directory.Exists(m_BackupPath))
                {
                    Directory.Delete(m_BackupPath, true);
                }

                m_Disposed = true;
            }
        }
    }
}

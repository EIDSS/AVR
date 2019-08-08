using System;
using System.IO;
using AUM.Core.Helper;

namespace AUM.Core.Transactions
{
    /// <summary>
    /// Class that contains common code for those rollbackable file operations which need
    /// to backup a single file and restore it when Rollback() is called.
    /// </summary>
    abstract class SingleFileOperation : IRollbackableOperation, IDisposable
    {
        protected readonly string m_Path;
        protected string m_BackupPath;
        // tracks whether Dispose has been called
        private bool m_Disposed;

        protected SingleFileOperation(string path)
        {
            m_Path = path;
        }

        /// <summary>
        /// Disposes the resources used by this class.
        /// </summary>
        ~SingleFileOperation()
        {
            InnerDispose();
        }

        public abstract void Execute();

        public void Rollback()
        {
            if (m_BackupPath != null)
            {
                var directory = Path.GetDirectoryName(m_Path);
                if ((directory != null) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                File.Copy(m_BackupPath, m_Path, true);
            }
            else
            {
                FileHelper.DeleteFile(m_Path);
                /*
                if (File.Exists(m_Path))
                {
                    File.Delete(m_Path);
                }
                */
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
        /// Disposes the resources of this class.
        /// </summary>
        private void InnerDispose()
        {
            if (!m_Disposed)
            {
                if (m_BackupPath != null)
                {
                    var fi = new FileInfo(m_BackupPath);
                    if (fi.IsReadOnly)
                    {
                        fi.Attributes = FileAttributes.Normal;
                    }
                    File.Delete(m_BackupPath);
                }

                m_Disposed = true;
            }
        }
    }
}

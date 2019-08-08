using System.IO;

namespace AUM.Core.Transactions
{
    /// <summary>
    /// Rollbackable operation which moves a file to a new location.
    /// </summary>
    sealed class MoveOperation : IRollbackableOperation
    {
        private readonly string m_SourceFileName;
        private readonly string m_DestFileName;

        /// <summary>
        /// Instantiates the class.
        /// </summary>
        /// <param name="sourceFileName">The name of the file to move.</param>
        /// <param name="destFileName">The new path for the file.</param>
        public MoveOperation(string sourceFileName, string destFileName)
        {
            m_SourceFileName = sourceFileName;
            m_DestFileName = destFileName;
        }

        public void Execute()
        {
            File.Move(m_SourceFileName, m_DestFileName);
        }

        public void Rollback()
        {
            File.Move(m_DestFileName, m_SourceFileName);
        }
    }
}

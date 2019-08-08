using System;
using System.IO;

namespace AUM.Core.Transactions
{
    static class FileUtils
    {
        private static readonly string m_TempFolder = Path.Combine(Path.GetTempPath(), "CdFileMgr");

        /// <summary>
        /// Ensures that the folder that contains the temporary files exists.
        /// </summary>
        public static void EnsureTempFolderExists()
        {
            if (!Directory.Exists(m_TempFolder))
            {
                Directory.CreateDirectory(m_TempFolder);
            }
        }

        /// <summary>
        /// Returns a unique temporary file name.
        /// </summary>
        /// <param name="extension"></param>
        /// <returns></returns>
        public static string GetTempFileName(string extension)
        {
            var g = Guid.NewGuid();
            var retVal = Path.Combine(m_TempFolder, g.ToString().Substring(0, 16)) + extension;

            return retVal;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Transactions;
using AUM.Core.Helper;
using AUM.Core.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AUMTestProject
{
    [TestClass]
    [Ignore]
    public class TransactionTest
    {
        [TestMethod]
        public void DeleteTest()
        {
            const string dir = @"C:\1\";
            const string file3 = "test3.txt";
            var fileManager = new TxFileManager();
            using (var ts = new TransactionScope())
            {
                fileManager.Delete(Path.Combine(dir, file3));
                //ts.Complete();
            }

        }

        [TestMethod]
        public void SimpleTransactionTest()
        {
            const string dir = @"C:\1\";
            const string file1 = "test1.txt";
            const string file2 = "test2.txt";
            using (var ts = new TransactionScope())
            {
                FileHelper.CopyFile(Path.Combine(dir, file1), Path.Combine(dir, file2));
                //ts.Complete();
            }
            
        }

        [TestMethod]
        public void TxTransactionTest()
        {
            const string dir = @"C:\1\";
            var file1 = Path.Combine(dir, "test1.txt");
            var file2 = Path.Combine(dir, "test2.txt");
            var fileManager = new TxFileManager();
            try
            {
                using (var ts = new TransactionScope())
                {
                    //fileManager.Delete(file1);
                    fileManager.Copy(file1, file2, true);
                    ts.Complete();
                }
            }
            catch (Exception)
            {
            }
        }

        [TestMethod]
        public void SMOProcTest()
        {
            //var parameters = new List<object> { version };
        }
    }
}

using System;
using System.Data;
using System.IO;
using System.Threading;
using AUM.Administrator;
using AUM.Core.Enums;
using AUM.Core.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Win32.TaskScheduler;

namespace AUMTestProject
{
    [TestClass]
    //[Ignore]
    public class EIDSSAdminTests
    {
        [TestMethod]
        [Ignore]
        public void RegPatchesTest()
        {
            var conn = DatabaseHelper.GetConnection(UpdateDatabases.DbAdmin);
            if (conn.State != ConnectionState.Open) conn.Open();
            using (var trans = conn.BeginTransaction())
            {
                var patchVersion = VersionFactory.NewVersion("1.0.0.0");
                var componentVersion = VersionFactory.NewVersion("1.2.2.2");
                var idPatchVersion = AdminHelper.RegistryPatch(patchVersion, true, trans);
                Assert.IsTrue(idPatchVersion > 0);
                var result = AdminHelper.RegistryPatchProduct(patchVersion, EIDSSComponents.avrs, componentVersion, trans);
                Assert.IsTrue(result);
                trans.Rollback();
            }
        }

        [TestMethod]
        [Ignore]
        public void RegPatchesFromFilesTest()
        {
            AdminHelper.RegistryAllPatches("C:\\AUM\\aumupdate");
        }

        [TestMethod]
        [Ignore]
        public void SaveStateTest()
        {
            var conn = DatabaseHelper.GetConnection(UpdateDatabases.DbAdmin);
            if (conn.State != ConnectionState.Open) conn.Open();
            using (var trans = conn.BeginTransaction())
            {
                AdminHelper.SaveState("test comment", trans);
                trans.Rollback();
            }
        }

        [TestMethod]
        [Ignore]
        public void SaveLogTest()
        {
          const string programID = "ns";
          var sourceVersion = VersionFactory.NewVersion("1.0.0.0");
          var targetVersion = VersionFactory.NewVersion("2.0.0.0");

          const string fileContent = "test file content ქართული";
          var fileContentUnicode = FileHelper.ConvertToUnicode(fileContent);
          Assert.IsTrue(fileContentUnicode.Length > 0);

          //сохранение файлов-логов обновления продуктов в БД
          var conn = DatabaseHelper.GetConnection(UpdateDatabases.DbAdmin);
          if (conn.State != ConnectionState.Open)
            conn.Open();
          using (var trans = conn.BeginTransaction())
          {
            var idfUpdatedComponent = AdminHelper.WriteUpdateStartedToAdminDB(programID, sourceVersion, targetVersion, trans);
            Assert.IsTrue(idfUpdatedComponent > 0);

            Thread.Sleep(3000);

            AdminHelper.WriteUpdateFinishedToAdminDB(idfUpdatedComponent, targetVersion, true, fileContentUnicode, trans);

            //trans.Commit();
            trans.Rollback();
          }
        }

        [TestMethod]
        [Ignore]
        public void SaveFakeLogTest()
        {
            var conn = DatabaseHelper.GetConnection(UpdateDatabases.DbAdmin);
            if (conn.State != ConnectionState.Open) conn.Open();
            using (var trans = conn.BeginTransaction())
            {
                var id = AdminHelper.GetUpdateFromAdminDB("e", "6.0.0.0", "6.0.0.1");
                
                trans.Rollback();
            }
        }
        #region Task testing
        [TestMethod]
        [Ignore]
        public void ReplicationTaskTest()
        {
            const string testTaskName = "testAdminReplication";
            using (var ts = new TaskService())
            {
                TaskProvider.DeleteTask(testTaskName);
                var jobAccessor = new JobAccessor("", "", "");
                int result = jobAccessor.RunReplicationJob(testTaskName);
                Assert.AreEqual(1, result);
                Assert.AreEqual(string.Format("Task for job {0} is not found.", testTaskName), jobAccessor.JobProvider.LastError);

                TaskProvider.CreateTask(testTaskName, CreateFailedTask(), null, null, DateTime.Today, 2, 2);
                result = jobAccessor.RunReplicationJob(testTaskName);
                Assert.AreEqual(0, result);
                while (jobAccessor.IsJobRuning(testTaskName))
                    Thread.Sleep(100);
                Assert.IsNotNull(jobAccessor.JobProvider.LastError);
                Thread.Sleep(1000);
                TaskProvider.DeleteTask(testTaskName);
                DeleteFile(m_FailedTaskFileName);
                
                TaskProvider.CreateTask(testTaskName, CreateSuccessTask(), null, null, DateTime.Today, 2, 2);
                result = jobAccessor.RunReplicationJob(testTaskName);
                Assert.AreEqual(0, result);
                while (jobAccessor.IsJobRuning(testTaskName))
                    Thread.Sleep(100);
                Assert.IsNull(jobAccessor.JobProvider.LastError,"last error:" + jobAccessor.JobProvider.LastError);
                Thread.Sleep(1000);
                DeleteFile(m_SuccessTaskFileName);

            }
            
            
        }

        private static string m_SuccessTaskFileName;
        private static string m_FailedTaskFileName;
        private string CreateSuccessTask()
        {
            m_SuccessTaskFileName = string.Format("{0}\\{1}",
                                                  Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments),
                                                  "success_task.cmd");
            CreateCmdFile(m_SuccessTaskFileName,"exit 0");
            return m_SuccessTaskFileName;
        }
        private string CreateFailedTask()
        {
            m_FailedTaskFileName = string.Format("{0}{1}",
                                                  Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments),
                                                  "failed_task.cmd");
            CreateCmdFile(m_FailedTaskFileName, "exit 1");
            return m_FailedTaskFileName;
        }
        private void CreateCmdFile(string fileName, string text)
        {
            DeleteFile(fileName);
            using (var f =  new StreamWriter(fileName, false))
            {
                f.Write(text);
                f.Flush();
                f.Close();
            }

        }
        private void DeleteFile(string fileName)
        {
            if (File.Exists(fileName))
                File.Delete(fileName);
        }
        #endregion
        #region SQL job testing

        [TestMethod]
        public void ReplicationJobTest()
        {
            var conn = DatabaseHelper.GetConnection(UpdateDatabases.DbAdmin);
            var jobAccessor = new JobAccessor(conn.DataSource, "sa", "btrp!2010");
            int result = jobAccessor.RunReplicationJob("absentJob");
            Assert.AreEqual(1,result);
            var provider = (SqlClentAgentJobProvider)jobAccessor.JobProvider;
            provider.CreateJob("errorAdminJob", "RAISERROR(33000, 16, 1)");
            provider.CreateJob("testAdminJob", "select 1");
            result = jobAccessor.RunReplicationJob("testAdminJob");
            Assert.AreEqual(0, result);
            while (jobAccessor.IsJobRuning("testAdminJob"))
                Thread.Sleep(100);
            Assert.IsNull(jobAccessor.JobProvider.LastError);

            result = jobAccessor.RunReplicationJob("errorAdminJob");
            Assert.AreEqual(0, result);
            while (jobAccessor.IsJobRuning("errorAdminJob"))
                Thread.Sleep(100);
            Assert.IsNotNull(jobAccessor.JobProvider.LastError);
        }

        #endregion
    }
}

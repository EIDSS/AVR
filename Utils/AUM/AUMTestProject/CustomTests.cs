using Microsoft.SqlServer.Management.Smo;

namespace AUMTestProject
{
    using System;
    using System.IO;
    using System.Threading;
    using AUM.Core;
    using AUM.Core.Enums;
    using AUM.Core.Helper;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using UpdateStatus = AUM.Core.Enums.UpdateStatus;


    [TestClass]
    //[Ignore]
    public class CustomTests
    {
        [TestMethod]
        public void AumLogBackupTest()
        {
            const string appPath = @"C:\3\";
            BackupHelper.BackupAumLog(appPath);
        }

        [TestMethod]
        [Ignore]
        public void CheckAvrServiceVersions()
        {
            Assert.IsTrue(UpdHelper.AvrServicePath.Length > 0);
            var currentVersion = DatabaseHelper.GetCurrentDBVersion(UpdateDatabases.AVRServiceDb);
            Assert.IsTrue(currentVersion.Major > 0);
            currentVersion = FileHelper.GetAvrServiceVersion(UpdHelper.AvrServicePath);
            Assert.IsTrue(currentVersion.Major > 0);
        }

        [TestMethod]
        [Ignore]
        public void StopAndStartServices()
        {
            Assert.IsTrue(UpdHelper.AVRServiceName.Length > 0);
            ServiceHelper.NotificationServiceChangeState(false);
            ServiceHelper.AvrServiceChangeState(false);
            Thread.Sleep(5000);
            ServiceHelper.NotificationServiceChangeState(true);
            ServiceHelper.AvrServiceChangeState(true);
        }

        [TestMethod]
        [Ignore]
        public void SetUpdateStateTest()
        {
            Updater.SetUpdateState("test!!!", "e", VersionFactory.NewVersion("2.0.0.0"), MachineLevel.Level.Cdr);
        }

        [TestMethod]
        [Ignore]
        public void CalculateStatusTest()
        {
            string errorString;
            var tui = AdminHelper.GetTotalUpdateInfo(Path.Combine(@"C:\AUM60\Aumupdate", FileHelper.UpdatesInfoFileName), out errorString);
            Assert.IsTrue(errorString.Length == 0);
            Assert.IsTrue(tui.Count == 5);
            var t = tui[1];
            var s1 = tui[2];
            var s2 = tui[3];

            t.Updates[0].VersionStart = VersionFactory.NewVersion("1.0.0.0");
            t.Updates[0].VersionFinish = VersionFactory.NewVersion("2.0.0.0");
            var result = AdminHelper.GetStatusForLastTotalUpdate(tui);
            Assert.IsTrue(result == UpdateStatus.Error);

            t.Updates[0].VersionStart = VersionFactory.NewVersion("0.0.0.0");
            result = AdminHelper.GetStatusForLastTotalUpdate(tui);
            Assert.IsTrue(result == UpdateStatus.Unknown);

            foreach (var u in t.Updates)
            {
                u.VersionStart = VersionFactory.NewVersion("1.0.0.0");
                u.VersionFinish = VersionFactory.NewVersion("2.0.0.0");
                u.Success = true;
            }

            s1.Updates[0].VersionStart = VersionFactory.NewVersion("1.0.0.0");
            s1.Updates[0].VersionFinish = VersionFactory.NewVersion("2.0.0.0");
            s1.Updates[0].Success = false;
            result = AdminHelper.GetStatusForLastTotalUpdate(tui);
            Assert.IsTrue(result == UpdateStatus.Error);

            s1.Updates[0].VersionStart = VersionFactory.NewVersion("0.0.0.0");
            result = AdminHelper.GetStatusForLastTotalUpdate(tui);
            Assert.IsTrue(result == UpdateStatus.Unknown);

            foreach (var u in s1.Updates)
            {
                u.VersionStart = VersionFactory.NewVersion("1.0.0.0");
                u.VersionFinish = VersionFactory.NewVersion("2.0.0.0");
                u.Success = true;
            }

            foreach (var u in s2.Updates)
            {
                u.VersionStart = VersionFactory.NewVersion("1.0.0.0");
                u.VersionFinish = VersionFactory.NewVersion("2.0.0.0");
                u.Success = true;
            }

            result = AdminHelper.GetStatusForLastTotalUpdate(tui);
            Assert.IsTrue(result == UpdateStatus.Success);
        }

        [TestMethod]
        [Ignore]
        public void CheckCRC()
        {
            const string dir1 = @"C:\temp\test\test1\";
            const string dir2 = @"C:\temp\test\test2\";
            const string dir3 = @"C:\temp\test\test3\";
            var updatePackageFileName = Path.Combine(dir3, "update_e_1.0.0.0.zip");
            long updatePackageCRC;
            //проверим контрольную сумму
            var crcFileInfo = new FileInfo(FileHelper.GetCRCFilename(updatePackageFileName));
            Assert.IsTrue(crcFileInfo.Exists);

            using (var sr = crcFileInfo.OpenText())
            {
                if (!long.TryParse(sr.ReadLine(), out updatePackageCRC))
                {
                }
            }
            Assert.IsTrue(updatePackageCRC > 0);
            Assert.IsTrue(updatePackageCRC == FileHelper.CaclulateCRC(updatePackageFileName));
        }

        [TestMethod]
        public void DatabaseConnectionTest()
        {
            var conn = DatabaseHelper.GetConnection(UpdateDatabases.AVRServiceDb);
        }

        [TestMethod]
        public void DownloadSimpleTest2()
        {
            const string PrimaryUrl = "https://update.eidss.info/";
            const string SecondaryUrl = "http://update.eidss.info/";
            const string Dir = @"C:\temp\BloodHoundSource\download\";
            const string UpdatesXmlFile = "updates.xml";
            new UpdateDownloader(
              new UrlWrapper(PrimaryUrl, SecondaryUrl),
              3,
              TimeSpan.FromSeconds(10),
              32768).DownloadFile(UpdatesXmlFile, Dir);
        }

        [TestMethod]
        public void DownloadSimpleTest3()
        {
            var settings = new ConfigSettings
                {
                    UpdateUrl = new UrlWrapper("https://update.eidss.info", string.Empty),
                    Level = MachineLevel.Level.SlvlNsslvl
                };

            if (!Directory.Exists(settings.UpdateLocal))
            {
                Directory.CreateDirectory(settings.UpdateLocal);
            }
            Synchronizer.TransferData(settings);
        }



        [TestMethod]
        [Ignore]
        public void DownloadSimpleTest()
        {
            var fileName = "http://aum.testing.info/updates/update_total_6.0.72.2600.zip";
            // ReSharper disable PossibleNullReferenceException
            var fileHeaderName = Path.GetFileName(fileName).Replace(' ', '-');
            // ReSharper restore PossibleNullReferenceException
            var down = new ResumeDownload();

            // Start downloading
            var state = down.ProcessDownload(fileName, fileHeaderName);

            if (state == DownloadState.fsDownloadFinished)
            {
                // Your code
            }

        }

        [TestMethod]
        public void AutorunRegistryTest()
        {
            RegistryHelper.WriteToRegistryAutorun("test", "test.exe");
            var value = RegistryHelper.ReadFromRegistryAutorun("test");
            Assert.AreEqual("test.exe", value);
            RegistryHelper.DeleteFromAutorun("test");
            value = RegistryHelper.ReadFromRegistryAutorun("test");
            Assert.AreEqual(string.Empty, value);
            RegistryHelper.DeleteFromAutorun("test");
            value = RegistryHelper.ReadFromRegistryAutorun("test");
            Assert.AreEqual(string.Empty, value);
        }

        [TestMethod]
        [Ignore]
        public void ChangeServiceStartupMode()
        {
            string err = ServiceHelper.ChangeStartModeWithoutThrow("EIDSS30_Ntfy", System.ServiceProcess.ServiceStartMode.Automatic);
            Assert.AreEqual(null, err);
            err = ServiceHelper.ChangeStartModeWithoutThrow("EIDSS30_Ntfy1", System.ServiceProcess.ServiceStartMode.Disabled);
            Assert.AreNotEqual(null, err);
        }
        [TestMethod]
        public void MutexTest()
        {
            bool created;
            bool mutexExists = MutexHelper.MutexExists(MutexType.DbUpdate);
            Assert.AreEqual(false, mutexExists);
            using (var mutex = MutexHelper.CreateMutex(MutexType.DbUpdate, out created))
            {
                mutexExists = MutexHelper.MutexExists(MutexType.DbUpdate);
                Assert.AreEqual(true, mutexExists);
                Assert.AreEqual(true, created);
                using (var mutex1 = MutexHelper.CreateMutex(MutexType.DbUpdate, out created))
                {
                    Assert.AreEqual(false, created);
                }
                mutex.ReleaseMutex();
                mutexExists = MutexHelper.MutexExists(MutexType.DbUpdate);
                Assert.AreEqual(true, mutexExists);
                mutex.Close();
            }
            mutexExists = MutexHelper.MutexExists(MutexType.DbUpdate);
            Assert.AreEqual(false, mutexExists);

        }
    }
}

using System;
using System.IO;
using AUM.Core;
using AUM.Core.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AUMTestProject
{
    [TestClass]
    public class UpdaterTests
    {
        [TestMethod]
        [Ignore]
        public void AUMSelfUpdateTest()
        {
          const string AppPath = @"C:\AUM\temp\AUM635139760723856127\";
          new Updater(
            new ConfigSettings(Path.Combine(AppPath, FileHelper.BVUpdaterConfigFileName)))
            .RunAUMUpdate("update_aum_5.0.23.930", 1105);
        }

        [TestMethod]
        [Ignore]
        public void RunUpdateForAllProductsTest()
        {
            Updater.RunUpdateForAllProducts(new ConfigSettings(Path.Combine(
              UpdHelper.AUMPath,
              FileHelper.BVUpdaterConfigFileName)));
        }

        [TestMethod]
        [Ignore]
        public void AUMDBUpdateTest()
        {
          const string AppPath = @"C:\AUM\";
          new Updater(
            new ConfigSettings(Path.Combine(AppPath, FileHelper.BVUpdaterConfigFileName)))
            .RunAUMUpdate("update_db_5.0.23.4009", 1105);
        }

        [TestMethod]
        [Ignore]
        public void AUMAnyProductTest()
        {
          const string AppPath = @"C:\AUM60\";
          new Updater(
            new ConfigSettings(
              Path.Combine(AppPath, FileHelper.BVUpdaterConfigFileName))).RunUpdate(
              "update_x_6.0.300.zip",
              new Version("6.0.300.0"));
        }

        //[TestMethod]
        //[Ignore]
        //public void AUMWebWksUpdateTest()
        //{
        //  const string AppPath = @"C:\AUM60\";
        //    new UpdaterWebWks( new ConfigSettings(
        //      Path.Combine(AppPath, FileHelper.BVUpdaterConfigFileName))).RunUpdate(
        //      "update_x_6.0.300.zip",
        //      new Version("6.1.0.9"));
        //}
        //[TestMethod]
        ////[Ignore]
        //public void RunTotalUpdate()
        //{
        //  const string AppPath = @"C:\AUM60\";
        //    Updater.RunUpdateForAllProducts(new ConfigSettings(Path.Combine(
        //      AppPath,
        //      FileHelper.BVUpdaterConfigFileName)));
        //}
    }
}

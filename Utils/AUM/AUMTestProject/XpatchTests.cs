using System.IO;
using System.Text;
using AUM.XPatch;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AUMTestProject
{
    [TestClass]
    public class XpatchTests
    {
        [TestMethod]
        public void SetNewDownloadStrategyTest()
        {
            string configFileText = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<config></config>";
            string configFileName = "test.config";
            File.WriteAllText(configFileName, configFileText,Encoding.UTF8);
            var task = new SetNewDownloadStrategy();
            string expected1 = string.Format("<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<config>"+"\r\n  <updateurl url=\"https://{0}\" reserve=\"http://{0}\" />\r\n</config>", task.UpdateUrl);
            string expected2 = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<config>" + "\r\n  <updateurl url=\"https://aaa\" reserve=\"http://aaa\" />\r\n</config>";
            task.UpdateConfigFile(configFileName);
            var text = File.ReadAllText(configFileName);
            Assert.AreEqual(expected1, text);
            task.UpdateUrl = "aaa";
            task.UpdateConfigFile(configFileName);
            text = File.ReadAllText(configFileName);
            Assert.AreEqual(expected2, text);
            task.UpdateUrl = "";
            task.UpdateConfigFile(configFileName);
            text = File.ReadAllText(configFileName);
            Assert.AreEqual(expected2, text);
            task.UpdateUrl = null;
            task.UpdateConfigFile(configFileName);
            text = File.ReadAllText(configFileName);
            Assert.AreEqual(expected2, text);
        }
        //[TestMethod]
        //public void UpdateAvrLoggingTest()
        //{
        //    string configFileText = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n" +
        //    "<configuration>\r\n"+
        //    "  <configSections>\r\n"+
        //    "    <section name=\"loggingConfiguration\" type=\"Microsoft.Practices.EnterpriseLibrary.Logging.Configuration.LoggingSettings, Microsoft.Practices.EnterpriseLibrary.Logging, Version=3.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a\" />\r\n" +
        //    "    <section name=\"schedulerConfiguration\" type=\"eidss.model.WindowsService.SchedulerConfigurationSection, eidss.core\" />\r\n"+
        //    "  </configSections>\r\n" +
        //    "</configuration>";
        //    string expected = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n" +
        //    "<configuration>\r\n" +
        //    "  <configSections>\r\n" +
        //    "    <section name=\"loggingConfiguration\" type=\"Microsoft.Practices.EnterpriseLibrary.Logging.Configuration.LoggingSettings, Microsoft.Practices.EnterpriseLibrary.Logging, Version=5.0.414.0, Culture=neutral, PublicKeyToken=null\" />\r\n" +
        //    "    <section name=\"schedulerConfiguration\" type=\"eidss.model.WindowsService.SchedulerConfigurationSection, eidss.core\" />\r\n" +
        //    "  </configSections>\r\n" +
        //    "</configuration>";
        //    string configFileName = "test1.config";
        //    File.WriteAllText(configFileName, configFileText, Encoding.UTF8);
        //    var task = new UpdateAvrLoggingConfig();
        //    task.UpdateConfigFile(configFileName);
        //    var text = File.ReadAllText(configFileName);
        //    Assert.AreEqual(expected, text);
        //}

    }
}

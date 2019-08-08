using bv.common.Configuration;
using bv.model.BLToolkit;
using bv.WinTests.panels.FakeControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bv.WinTests.panels
{
    [TestClass]
    public class HumanCaseListUITests
    {
        [TestInitialize]
        public void MyTestInitialize()
        {
            DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString"));
        }

        [TestMethod]
        [Ignore]
        public void HumanCaseWinTest()
        {
            var form = new HumanCaseWinForm();
            form.ShowDialog();
        }
    }
}
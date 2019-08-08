using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using bv.common.Configuration;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bv.WinTests.panels
{
    [TestClass]
    public class TestPanelUITest
    {
        [TestMethod]
        public void TestMethod1()
        {
            DbManagerFactory.SetSqlFactory(Config.GetSetting("TestConnectionString",""));
            long? id = null;
            BaseFormManager.ShowNormal(typeof (TestPanelUI), ref id);
        }
    }
}

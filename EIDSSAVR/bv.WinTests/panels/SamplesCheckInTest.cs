using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using bv.common.Configuration;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.winclient.BasePanel;
using bv.WinTests.panels.FakeControls;
using EIDSS;
using eidss.model.Core;
using eidss.model.Core.Security;
using eidss.winclient.Vet;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace bv.WinTests.panels
{
    /// <summary>
    /// Summary description for SamplesCheckInTest
    /// </summary>
    [TestClass]
    //[CodedUITest]
    public class SamplesCheckInTest
    {
        [TestInitialize]
        public void MyTestInitialize()
        {
            //DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString", ""));
            //ClassLoader.Init("eidss*.dll", Environment.MachineName.Equals("LEONOV") ? @"c:\Projects\EIDSS4\eidss.main\bin\Debug\" : null);
            ClassLoader.Init("eidss*.dll", null);
            DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString", ""));
            EidssUserContext.Init();
            var target = new EidssSecurityManager();

            const string organizaton = "NCDC&PH";
            const string admin = "test_admin";
            //const string User = "test_user";
            const string adminPassword = "test";
            //const string UserPassword = "test";

            int result = target.LogIn(organizaton, admin, adminPassword);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
       //[Ignore]
        public void SamplesCheckInPanelTest()
        {
            var panel = new SamplesCheckIn(EIDSS.HACode.Human, false);
            panel.LoadData();
            BaseFormManager.ShowSimpleFormModal(panel);
        }
        
    }
}

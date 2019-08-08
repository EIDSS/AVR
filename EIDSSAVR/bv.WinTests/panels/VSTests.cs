using System.Drawing;
using System.Windows.Forms;
using bv.common.Configuration;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.model.Model.Validators;
using bv.tests.db.tests;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using DevExpress.XtraNavBar;
using eidss.model.Core;
using eidss.model.Core.Security;
using eidss.model.Model;
using eidss.model.Resources;
using eidss.winclient.VectorSurveillance;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bv.WinTests.panels
{
    [TestClass]
    public class VsTests
    {
        [TestMethod]
        //[Ignore]
        public void VsSessionListPanelTest()
        {
            var panel = new VsSessionListPanel();
            panel.LoadData();
            BaseFormManager.ShowSimpleFormModal(panel);
            //Control container = panel.Activate();
            //BaseListPanelUITest.ShowControlOnForm(container);
        }

        [TestInitialize]
        public void MyTestInitialize()
        {
            //ClassLoader.Init("eidss*.dll", Environment.MachineName.Equals("LEONOV") ? @"c:\Projects\EIDSS4\eidss.main\bin\Debug\" : null);
            ClassLoader.Init("eidss*.dll", null);
            DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString"));
            EidssUserContext.Init();
            var target = new EidssSecurityManager();

            const string organizaton = "NCDC&PH";
            const string admin = "test_admin";
            //const string User = "test_user";
            const string adminPassword = "test";
            //const string UserPassword = "test";

            int result = target.LogIn(organizaton, admin, adminPassword);
            Assert.AreEqual(0, result);

            WinClientContext.FieldCaptions = EidssFields.Instance;
            RequiredValidator.FieldCaptions = EidssFields.Instance;
            ErrorForm.Messages = EidssMessages.Instance;
        }

        [TestMethod]
        [Ignore]
        public void VectorDetailShowTest()
        {
            var panel = new VectorDetail();
            object id = null;
            panel.LoadData(ref id);
            BaseFormManager.ShowSimpleFormModal(panel);
        }

        [TestMethod]
        [Ignore]
        public void VsSessionDetailShowTest()
        {
            //BaseDetailPanelTest.ShowControlOnForm((new VsSessionDetail()).Activate());

            var panel = new VsSessionDetail();
            object id = null;
            panel.LoadData(ref id);
            BaseFormManager.ShowSimpleFormModal(panel);
        }

        [TestMethod]
        [Ignore]
        public void vsSessionToVectorTypeDetailTest()
        {
            //var sessionToVectorType = new EditableList<SessionToVectorTypeItem>();
            ////var item = SessionToVectorTypeItem.Accessor.Instance(null).cre;
            ////item.

            //VectorSurveillanceHelper.ShowSessionToVectorTypeForm(4578680000000, sessionToVectorType);
            //var acc = SessionToVectorTypeItem.Accessor.Instance(null);
            //foreach (var sessionToVectorTypeItem in sessionToVectorType)
            //{
            //    using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
            //    {
            //        acc.Post(manager, sessionToVectorTypeItem);
            //    }
            //}
        }

        [TestMethod]
        //[Ignore]
        public void VsSummaryTableTest()
        {
            EidssUserContext.Init();
            var session = VsSessionTest.GetTestSession();

            var frm = new Form
            {
                Size = new Size(500, 300),
                StartPosition = FormStartPosition.CenterScreen,
            };

            var navBarControl = new NavBarControl();
            frm.Controls.Add(navBarControl);
            navBarControl.Dock = DockStyle.Fill;
            navBarControl.FillTestSummary(SummaryTable.GetSummaryTables(session.FieldTests));

            frm.ShowDialog();
            EidssUserContext.Clear();
        }
    }
}

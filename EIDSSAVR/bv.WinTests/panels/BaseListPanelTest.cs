using System.Drawing;
using System.Windows.Forms;
using bv.common.Configuration;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.tests.db.tests;
using bv.winclient.BasePanel;
using bv.WinTests.panels.FakeControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bv.WinTests.panels
{
    [TestClass]
    public class BaseListPanelUITest
    {
        [TestInitialize]
        public void MyTestInitialize()
        {
            DbManagerFactory.SetSqlFactory(Config.GetSetting("TestConnectionString"));
        }

        [TestMethod]
        //[Ignore]
        public void ListPanelTest()
        {
            var panel = new TestListPanelUI
                            {
                                Dock = DockStyle.Fill,
                            };
            panel.LoadData();
            ShowControlOnForm(panel);
        }

        [TestMethod]
        //[Ignore]
        public void ListPanelTestWithLayout()
        {
            var panel = new TestListPanelUI();
            panel.LoadData();
            BaseFormManager.ShowSimpleFormModal(panel);
        }

        [TestMethod]
        //[Ignore]
        public void LookupPanelTestWithLayout()
        {
            var panel = new TestLookupPanelUI();
            panel.LoadData();
            BaseFormManager.ShowSimpleFormModal(panel);
        }

        [TestMethod]
       // [Ignore]
        public void LookupPanelTestWithLayoutWithPermissions()
        {
            //показ листовой формы с учётом полномочий
            TestUserContext.Init();
            using (ModelUserContext context = ModelUserContext.Instance)
            {
                //Lookup2ListItem bo = Lookup2ListItem.CreateInstance();
                var panel = new TestLookupPanelUI();
                panel.LoadData();
                BaseFormManager.ShowSimpleFormModal(panel);
            }
            TestUserContext.Clear();
        }

        public static void ShowControlOnForm(Control control)
        {
            control.Dock = DockStyle.Fill;
            var frm = new Form
                          {
                              Size = new Size(800, 600),
                              StartPosition = FormStartPosition.CenterScreen,
                          };
            frm.Controls.Add(control);
            frm.ShowDialog();
        }
    }
}
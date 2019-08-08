using System;
using System.Drawing;
using System.Windows.Forms;
using bv.common.Configuration;
using bv.common.Enums;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.tests.Schema;
using bv.winclient.BasePanel;
using bv.winclient.Layout;
using bv.WinTests.panels.FakeControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bv.WinTests.panels
{
    /// <summary>
    /// Summary description for BaseFormManagerTest
    /// </summary>
    [TestClass]
    public class BaseFormManagerTest
    {
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void MyTestInitialize()
        {
            DbManagerFactory.SetSqlFactory(Config.GetSetting("TestConnectionString", ""));
        }

        #region Additional test attributes

        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //

        #endregion

        [TestMethod]
        [Ignore]
        public void RunNormalTest()
        {
            BaseFormManager.ShowNormal(typeof (TestPanelUI), TestTable.CreateInstance(), null, 700, 500);
            //BaseFormManager.ShowNormal(typeof(TestTable), null, null, 700, 500);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        private static TestPanelUI SetTestPanelUIBO(IObject o)
        {
            return new TestPanelUI { BusinessObject = o };
        }

        [TestMethod]
        [Ignore]
        public void RunActionShowFormTest()
        {
            TestTable testTable = TestTable.CreateInstance();
            TestTable.Accessor accessor = TestTable.Accessor.Instance(null);
            //наполняем тестовыми действиями
            var action = new ActionMetaItem("Action1", ActionTypes.Action, true, null, null, null, null, null);
            /*
            var action = new ActionMetaItem("Action1", "Show another form", "icon 1", "tooltip 1", String.Empty, String.Empty, String.Empty, String.Empty, null, ActionsAlignment.Right,
                                            ActionsPanelType.Main, ActionsAppType.All, true, true, false, null, null, null, ActionTypes.ShowForm, ActionTypes.ShowForm, ActionTypes.Unknown, String.Empty)
                             {BasePanelTypeName = "TestPanelAdvancedUI"};
            accessor.Actions.Add(action);
            */
            //TODO здесь должен быть BaseFormManager, который создаст Layout и поместит на него панель
            var pn = SetTestPanelUIBO(testTable);
            object id = null;
            pn.LoadData(ref id);

            ILayout currentLayout = pn.GetLayout();
            Control container;
            if (currentLayout != null)
            {
                currentLayout.AddControlToMainContainer(pn);
                currentLayout.AddActions(pn, testTable);
                container = (Control) currentLayout;
            }
            else
            {
                container = pn;
            }

            var frm = new Form
                          {
                              StartPosition = FormStartPosition.CenterScreen,
                              Location = new Point(50, 50),
                              Size = new Size(700, 600)
                          };
            frm.Controls.Add(container);
            container.Dock = DockStyle.Fill;
            frm.ShowDialog();

            //BaseFormManager.ShowNormal(typeof(testPanelUI), null, null, 700, 500);
            //BaseFormManager.ShowNormal(typeof(TestTable), null, null, 700, 500);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using bv.common.Configuration;
using bv.common.Enums;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.tests.Schema;
using bv.winclient.ActionPanel;
using bv.winclient.BasePanel;
using bv.winclient.Layout;
using bv.WinTests.panels;
using bv.WinTests.panels.FakeControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bv.WinTests.layout
{
    /// <summary>
    /// Summary description for BaseLayoutTest
    /// </summary>
    [TestClass]
    public class LayoutTest
    {
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static TestPanelUI CreateTestPanelUI()
        {
            TestTable testTable = TestTable.CreateInstance();
            TestTable.Accessor accessor = TestTable.Accessor.Instance(null);
            //наполняем тестовыми действиями
            accessor.Actions.Add(new ActionMetaItem("Action1", ActionTypes.Action, true, null, null, null, null, null));
            accessor.Actions.Add(new ActionMetaItem("Action2", ActionTypes.Action, true, null, null, null, null, null));
            accessor.Actions.Add(new ActionMetaItem("Action3", ActionTypes.Action, true, null, null, null, null, null));
            /*
            accessor.Actions.Add(new ActionMetaItem("Action1", "This is action 1", "icon 1", "tooltip 1", String.Empty, String.Empty, String.Empty, String.Empty, null, ActionsAlignment.Left, ActionsPanelType.Main, ActionsAppType.All, true,
                                                    true, false, null, null, null, ActionTypes.Action, ActionTypes.Action, ActionTypes.Unknown, String.Empty));
            accessor.Actions.Add(new ActionMetaItem("Action2", "This is action 2", "icon 2", "tooltip 2", String.Empty, String.Empty, String.Empty, String.Empty, null, ActionsAlignment.Left, ActionsPanelType.Main, ActionsAppType.All, true,
                                                    true, false, null, null, null, ActionTypes.Action, ActionTypes.Action, ActionTypes.Unknown, String.Empty));
            accessor.Actions.Add(new ActionMetaItem("Action3", "Some another action 3", "icon 3", "tooltip 3", String.Empty, String.Empty, String.Empty, String.Empty, null, ActionsAlignment.Left, ActionsPanelType.Main, ActionsAppType.All,
                                                    true, true, false, null, null, null, ActionTypes.Action, ActionTypes.Action, ActionTypes.Unknown, String.Empty));
            */
            //TODO здесь должен быть BaseFormManager, который создаст Layout и поместит на него панель
            return SetTestPanelUIBO(testTable);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        private static TestPanelUI SetTestPanelUIBO(IObject o)
        {
            return new TestPanelUI {BusinessObject = o};
        }

        /// <summary>
        /// Показ формы и Layout с несколькими кнопками на разных ActionPanel
        /// </summary>
        [TestMethod]
        [Ignore]
        public void ShowBaseLayoutTest()
        {
            TestTable testTable = TestTable.CreateInstance();
            TestTable.Accessor accessor = TestTable.Accessor.Instance(null);
            //наполняем тестовыми действиями
            accessor.Actions.Add(new ActionMetaItem("Action1", ActionTypes.Action, true, null, null, null, null, null));
            accessor.Actions.Add(new ActionMetaItem("Action2", ActionTypes.Action, true, null, null, null, null, null));
            accessor.Actions.Add(new ActionMetaItem("Action3", ActionTypes.Action, true, null, null, null, null, null));
            /*
            accessor.Actions.Add(new ActionMetaItem("Action1", "This is action 1", "icon 1", "tooltip 1", String.Empty, String.Empty, String.Empty, String.Empty, null, ActionsAlignment.Left, ActionsPanelType.Main, ActionsAppType.All, true,
                                                    true, false, null, null, null, ActionTypes.Action, ActionTypes.Action, ActionTypes.Unknown, String.Empty));
            accessor.Actions.Add(new ActionMetaItem("Action2", "This is action 2", "icon 2", "tooltip 2", String.Empty, String.Empty, String.Empty, String.Empty, null, ActionsAlignment.Left, ActionsPanelType.Main, ActionsAppType.All, true,
                                                    true, false, null, null, null, ActionTypes.Action, ActionTypes.Action, ActionTypes.Unknown, String.Empty));
            accessor.Actions.Add(new ActionMetaItem("Action3", "Some another action 3", "icon 3", "tooltip 3", String.Empty, String.Empty, String.Empty, String.Empty, null, ActionsAlignment.Left, ActionsPanelType.Top, ActionsAppType.All, true,
                                                    true, false, null, null, null, ActionTypes.Action, ActionTypes.Action, ActionTypes.Unknown, String.Empty));
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
        }

        [TestInitialize]
        public void MyTestInitialize()
        {
            DbManagerFactory.SetSqlFactory(Config.GetSetting("TestConnectionString", ""));
        }

        /// <summary>
        /// Показ формы и Layout с несколькими кнопками на разных ActionPanel
        /// </summary>
        [TestMethod]
        [Ignore]
        public void ShowSimpleNormalFormTest()
        {
            TestTable testTable = TestTable.CreateInstance();
            TestTable.Accessor accessor = TestTable.Accessor.Instance(null);
            //наполняем тестовыми действиями
            accessor.Actions.Add(new ActionMetaItem("Action1", ActionTypes.Action, true, null, null, null, null, null));
            accessor.Actions.Add(new ActionMetaItem("Action2", ActionTypes.Action, true, null, null, null, null, null));
            accessor.Actions.Add(new ActionMetaItem("Action3", ActionTypes.Action, true, null, null, null, null, null));
            /*
            accessor.Actions.Add(new ActionMetaItem("Action1", "This is action 1", "icon 1", "tooltip 1", String.Empty, String.Empty, String.Empty, String.Empty, null, ActionsAlignment.Left, ActionsPanelType.Main, ActionsAppType.All, true,
                                                    true, false, null, null, null, ActionTypes.Action, ActionTypes.Action, ActionTypes.Unknown, String.Empty));
            accessor.Actions.Add(new ActionMetaItem("Action2", "This is action 2", "icon 2", "tooltip 2", String.Empty, String.Empty, String.Empty, String.Empty, null, ActionsAlignment.Left, ActionsPanelType.Main, ActionsAppType.All, true,
                                                    true, false, null, null, null, ActionTypes.Action, ActionTypes.Action, ActionTypes.Unknown, String.Empty));
            accessor.Actions.Add(new ActionMetaItem("Action3", "Some another action 3", "icon 3", "tooltip 3", String.Empty, String.Empty, String.Empty, String.Empty, null, ActionsAlignment.Left, ActionsPanelType.Top, ActionsAppType.All, true,
                                                    true, false, null, null, null, ActionTypes.Action, ActionTypes.Action, ActionTypes.Unknown, String.Empty));
            */
            var pn = SetTestPanelUIBO(testTable);
            ILayout container = pn.GetLayout();
            container.AddActions(pn, testTable);
            BaseFormManager.ShowSimpleFormModal(pn);
        }

        /// <summary>
        /// Показ формы и Layout в самом простом варианте (без панелей)
        /// </summary>
        [TestMethod]
        [Ignore]
        public void ShowLayoutSimpleTest()
        {
            TestTable testTable = TestTable.CreateInstance();
            var pn = SetTestPanelUIBO(testTable);
            object id = null;
            pn.LoadData(ref id);
            ILayout currentLayout = pn.GetLayout();
            Control container;
            if (currentLayout != null)
            {
                currentLayout.AddControlToMainContainer(pn);

                //pn.CreateActionPanels();

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
        }

        /// <summary>
        /// Показ формы и Layout с несколькими кнопками на разных ActionPanel
        /// </summary>
        [TestMethod]
        [Ignore]
        public void ShowButtonsRightTest()
        {
            TestTable testTable = TestTable.CreateInstance();
            TestTable.Accessor accessor = TestTable.Accessor.Instance(null);
            //наполняем тестовыми действиями
            accessor.Actions.Add(new ActionMetaItem("Action1", ActionTypes.Action, true, null, null, null, null, null));
            accessor.Actions.Add(new ActionMetaItem("Action2", ActionTypes.Action, true, null, null, null, null, null));
            accessor.Actions.Add(new ActionMetaItem("Action3", ActionTypes.Action, true, null, null, null, null, null));
            accessor.Actions.Add(new ActionMetaItem("Action4", ActionTypes.Action, true, null, null, null, null, null));
            accessor.Actions.Add(new ActionMetaItem("Action7", ActionTypes.Action, true, null, null, null, null, null));
            /*
            accessor.Actions.Add(new ActionMetaItem("Action1", "This is action 1", "icon 1", "tooltip 1", String.Empty, String.Empty, String.Empty, String.Empty, null, ActionsAlignment.Left, ActionsPanelType.Main, ActionsAppType.All, true,
                                                    true, false, null, null, null, ActionTypes.Action, ActionTypes.Action, ActionTypes.Unknown, String.Empty));
            accessor.Actions.Add(new ActionMetaItem("Action2", "test2", "icon 2", "tooltip 2", String.Empty, String.Empty, String.Empty, String.Empty, null, ActionsAlignment.Right, ActionsPanelType.Main, ActionsAppType.All, true, true, false,
                                                    null, null, null, ActionTypes.Action, ActionTypes.Action, ActionTypes.Unknown, String.Empty));
            accessor.Actions.Add(new ActionMetaItem("Action3", "This is action 3", "icon 3", "tooltip 3", String.Empty, String.Empty, String.Empty, String.Empty, null, ActionsAlignment.Left, ActionsPanelType.Main, ActionsAppType.All, true,
                                                    true, false, null, null, null, ActionTypes.Action, ActionTypes.Action, ActionTypes.Unknown, String.Empty));
            accessor.Actions.Add(new ActionMetaItem("Action4", "This is action 4", "icon 4", "tooltip 4", String.Empty, String.Empty, String.Empty, String.Empty, null, ActionsAlignment.Right, ActionsPanelType.Main, ActionsAppType.All, true,
                                                    true, false, null, null, null, ActionTypes.Action, ActionTypes.Action, ActionTypes.Unknown, String.Empty));

            accessor.Actions.Add(new ActionMetaItem("Action7", "Some another action 7", "icon 7", "tooltip 7", String.Empty, String.Empty, String.Empty, String.Empty, null, ActionsAlignment.Left, ActionsPanelType.Top, ActionsAppType.All, true,
                                                    true, false, null, null, null, ActionTypes.Action, ActionTypes.Action, ActionTypes.Unknown, String.Empty));
            */
            var pn = SetTestPanelUIBO(testTable);
            ILayout container = pn.GetLayout();
            container.AddActions(pn, testTable);
            BaseFormManager.ShowSimpleFormModal(pn);
        }

        /// <summary>
        /// Показ формы и Layout с несколькими кнопками на разных ActionPanel
        /// </summary>
        [TestMethod]
        [Ignore]
        public void ShowAdvancedLayoutTest()
        {
            TestTable testTable = TestTable.CreateInstance();
            //TestTable.Accessor accessor = TestTable.Accessor.Instance(null);
            ////наполняем тестовыми действиями
            //accessor.Actions.Add(new ActionMetaItem("Action1", "This is action 1", "icon 1", ActionsAlignment.Left, ActionsPanelType.Main, true, true, false, null, null, ActionTypes.Action));
            //accessor.Actions.Add(new ActionMetaItem("Action2", "test2", "icon 2", ActionsAlignment.Right, ActionsPanelType.Main, true, true, false, null, null, ActionTypes.Action));
            //accessor.Actions.Add(new ActionMetaItem("Action3", "This is action 3", "icon 3", ActionsAlignment.Left, ActionsPanelType.Main, true, true, false, null, null, ActionTypes.Action));
            //accessor.Actions.Add(new ActionMetaItem("Action4", "This is action 4", "icon 4", ActionsAlignment.Right, ActionsPanelType.Main, true, true, false, null, null, ActionTypes.Action));

            //accessor.Actions.Add(new ActionMetaItem("Action7", "Some another action 7", "icon 7", ActionsAlignment.Left, ActionsPanelType.Top, true, true, false, null, null, ActionTypes.Action));
            //accessor.Actions.Add(new ActionMetaItem("Action8", "Some another action 8", "icon 8", ActionsAlignment.Right, ActionsPanelType.Top, true, true, false, null, null, ActionTypes.Action));
            //accessor.Actions.Add(new ActionMetaItem("Action9", "Some another action 9", "icon 9", ActionsAlignment.Left, ActionsPanelType.Top, true, true, false, null, null, ActionTypes.Action));
            //accessor.Actions.Add(new ActionMetaItem("Action10", "Some another action 10", "icon 10", ActionsAlignment.Right, ActionsPanelType.Top, true, true, false, null, null, ActionTypes.Action));

            var pn = new TestPanelAdvancedUI {BusinessObject = testTable};
            ILayout container = pn.GetLayout();
            container.AddActions(pn, testTable);
            BaseFormManager.ShowSimpleFormModal(pn);
        }

        [TestMethod]
        [Ignore]
        public void ShowLayoutEmpty()
        {
        }

        /// <summary>
        /// Показ формы и Layout с несколькими кнопками на разных ActionPanel, а также действиями, определёнными в наследнике
        /// </summary>
        [TestMethod]
        [Ignore]
        public void ShowAdvancedLayoutWithCustomActions()
        {
            var testTable = TestTable.CreateInstance();

            var pn = new TestPanelAdvancedWithCustomActions {BusinessObject = testTable};
            BaseFormManager.ShowSimpleFormModal(pn);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bo"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private static bool Action1Function(DbManagerProxy manager, IObject bo, List<object> parameters)
        {
            MessageBox.Show(@"This is action1", @"Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bo"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private static bool Action2Function(DbManagerProxy manager, IObject bo, List<object> parameters)
        {
            MessageBox.Show(@"action2. :))", @"Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }

        /// <summary>
        /// Показ формы и Layout с несколькими кнопками на разных ActionPanel, а также действиями, упакованными в группы
        /// </summary>
        [TestMethod]
        [Ignore]
        public void ShowAdvancedLayoutWithActionGroups()
        {
            var testTable = TestTable.CreateInstance();

            var pn = new TestPanelAdvancedWithActionGroups {BusinessObject = testTable};
            BaseFormManager.ShowSimpleFormModal(pn);
        }
    }
}

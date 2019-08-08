using System;
using System.Collections.Generic;
using System.Windows.Forms;
using bv.common.Enums;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.winclient.Layout;

namespace bv.WinTests.panels.FakeControls
{
    public partial class TestPanelAdvancedWithCustomActions : TestPanelAdvancedUI
    {
        public TestPanelAdvancedWithCustomActions()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ILayout GetLayout()
        {
            return ParentLayout ??
                   (ParentLayout =
                    this.CreateLayoutAdvanced(BusinessObject, "Test Advanced Layout (with custom actions)", "F05", null));
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
        /// Добавление произвольных действий
        /// </summary>
        public override void SetCustomActions(List<ActionMetaItem> actions)
        {
            base.SetCustomActions(actions);
            var action1 = new ActionMetaItem("action1", ActionTypes.Action, true, null, null, null, null, null);
            var action2 = new ActionMetaItem("action2", ActionTypes.Action, true, null, null, null, null, null);
            /*
            var action1 = new ActionMetaItem("action1", "This is action1", "icon 1"
                                             , "Press me (action1)", String.Empty, String.Empty, String.Empty, String.Empty, null, ActionsAlignment.Left, ActionsPanelType.Main, ActionsAppType.All
                                             , true, true, false, Action1Function, null, null, ActionTypes.Action, ActionTypes.Action, ActionTypes.Unknown,
                                             String.Empty);

            var action2 = new ActionMetaItem("action2", "This is action2", "icon 2"
                                             , "Press me (action2)", String.Empty, String.Empty, String.Empty, String.Empty, null, ActionsAlignment.Right, ActionsPanelType.Top, ActionsAppType.All
                                             , true, true, false, Action2Function, null, null, ActionTypes.Action, ActionTypes.Action, ActionTypes.Unknown,
                                             String.Empty);
            */
            AddCustomAction(action1);
            AddCustomAction(action2);
        }
    }
}
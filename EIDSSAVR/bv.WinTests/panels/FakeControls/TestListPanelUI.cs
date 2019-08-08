using bv.tests.Schema;
using bv.winclient.BasePanel;
using bv.winclient.Layout;

namespace bv.WinTests.panels.FakeControls
{
    public partial class TestListPanelUI : BaseListPanel<ListPanelItem>
    {
        public TestListPanelUI()
        {
            InitializeComponent();
        }

        public TestListPanelUI(ListPanelItem bo)
        {
            InitializeComponent();
        }

        public override void DefineBinding()
        {
        }

        public override ILayout GetLayout()
        {
            base.GetLayout();
            ((LayoutSimple) ParentLayout).SetProperties("Test Layout", "F02", null);
            return ParentLayout;
        }
    }
}
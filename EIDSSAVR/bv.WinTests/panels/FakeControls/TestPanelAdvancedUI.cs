using bv.winclient.Layout;

namespace bv.WinTests.panels.FakeControls
{
    public partial class TestPanelAdvancedUI : TestPanelUI
    {
        /// <summary>
        /// 
        /// </summary>
        public TestPanelAdvancedUI()
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
                   (ParentLayout = this.CreateLayoutAdvanced(BusinessObject, "Test Advanced Layout", "F02", null));
        }
    }
}
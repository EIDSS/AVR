using bv.winclient.Layout;

namespace bv.WinTests.panels.FakeControls
{
    public partial class TestLookupPanelUI : TestListPanelGeneric
    {
        public TestLookupPanelUI()
        {
            InitializeComponent();
        }

        //public TestLookupPanelUI(Lookup2ListItem bo)
        //    : base(bo)
        //{
        //    InitializeComponent();
        //}

        public override void DefineBinding()
        {
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
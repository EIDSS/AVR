using bv.winclient.Layout;

namespace bv.WinTests.panels.FakeControls
{
    public partial class TestPanelEmptyUI : TestPanelUI
    {
        public TestPanelEmptyUI()
        {
            InitializeComponent();
        }

        public override ILayout GetLayout()
        {
            //для базовой панели создаём самый простой Layout
            if (ParentLayout == null)
            {
                ParentLayout = new LayoutGroup(BusinessObject);
                ParentLayout.Init(this);
                ParentLayout.AddControlToMainContainer(this);
                //TODO где надо проставлять лейауту реальный заголовок, иконку, номер формы?
            }

            return ParentLayout;
        }
    }
}
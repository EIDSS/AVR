using System.Drawing;
using System.Windows.Forms;
using bv.WinTests.panels.FakeControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bv.WinTests.panels
{
    /// <summary>
    ///This is a test class for BaseDetailPanelTest and is intended
    ///to contain all BaseDetailPanelTest Unit Tests
    ///</summary>
    [TestClass]
    //[CodedUITest]
    public class BaseDetailPanelTest
    {
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        #region Additional test attributes

        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //

        #endregion

        /// <summary>
        ///A test for BaseDetailPanel`1 Constructor
        ///</summary>
        //public void BaseDetailPanelConstructorTestHelper<T>()
        //{
        //    BaseDetailPanel<T> target = new BaseDetailPanel<T>();
        //    Assert.Inconclusive("TODO: Implement code to verify target");
        //}
        //[TestMethod()]
        //public void BaseDetailPanelConstructorTest()
        //{
        //    BaseDetailPanelConstructorTestHelper<GenericParameterHelper>();
        //}
        [Ignore]
        [TestMethod]
        public void PanelTest()
        {
            var pn = new TestPanelUI();
            object id = null;
            pn.LoadData(ref id);
            var frm = new Form();
            frm.Controls.Add(pn);
            frm.ShowDialog();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
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
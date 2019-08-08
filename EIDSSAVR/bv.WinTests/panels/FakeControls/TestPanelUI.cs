using System;
using System.Windows.Forms;
using BLToolkit.ComponentModel;
using bv.tests.Schema;
using bv.winclient.Layout;

namespace bv.WinTests.panels.FakeControls
{
    //public class TestPanelGeneric : BaseDetailPanel<TestTable>
    //{
    //    public TestPanelGeneric()
    //    {
    //        //InitializeComponent();
    //    }
    //    public TestPanelGeneric(TestTable bo)
    //        : base(bo)
    //    {
    //    }
    //    /// <summary> 
    //    /// Required designer variable.
    //    /// </summary>
    //    private System.ComponentModel.IContainer components = null;

    //    /// <summary> 
    //    /// Clean up any resources being used.
    //    /// </summary>
    //    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    //    protected override void Dispose(bool disposing)
    //    {
    //        if (disposing && (components != null))
    //        {
    //            components.Dispose();
    //        }
    //        base.Dispose(disposing);
    //    }

    //    #region Component Designer generated code

    //    /// <summary> 
    //    /// Required method for Designer support - do not modify 
    //    /// the contents of this method with the code editor.
    //    /// </summary>
    //    private void InitializeComponent()
    //    {
    //        components = new System.ComponentModel.Container();
    //        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    //    }

    //    #endregion
    //}

    public partial class TestPanelUI : TestPanelGeneric
    {
        public TestPanelUI()
        {
            InitializeComponent();
        }

        public override void DefineBinding()
        {
            var testTable = BusinessObject as TestTable;
            textBox1.DataBindings.Add(new Binding("Text", BusinessObject, "MasterID"));
            //lookUpEdit1.Properties.DataSource = testTable.Lookup1Lookup;
            //lookUpEdit1.Properties.DisplayMember = "Lookup1Field1";
            //lookUpEdit1.DataBindings.Add("EditValue", testTable, "Lookup1");
            objectBinder1.Object = testTable;
            objectBinder1.ItemType = typeof (TestTable);
            if (testTable != null)
            {
                var objectBinder2 = new ObjectBinder {ItemType = typeof (Lookup1Table), List = testTable.Lookup1Lookup};
            }
            //lookUpEdit1.Properties.DataSource = objectBinder2;
            //lookUpEdit1.Properties.DisplayMember = "Lookup1Field1";
            //lookUpEdit1.DataBindings.Add("EditValue", objectBinder1, "Lookup1");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ILayout GetLayout()
        {
            base.GetLayout();
            ((LayoutSimple) ParentLayout).SetProperties("Test Layout", "F01", null);
            return ParentLayout;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var testTable = BusinessObject as TestTable;
            testTable.Lookup1 = testTable.Lookup1Lookup[2];
            testTable.MasterID = 111;
        }
    }
}
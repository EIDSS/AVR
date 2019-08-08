using System;
using System.Diagnostics;
using System.Windows.Forms;
using bv.common.Configuration;
using bv.model.BLToolkit;
using eidss.model.Schema;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bv.WinTests.panels.FakeControls
{
    public partial class LookupBindingTest : Form
    {
        private Address m_Address;

        public LookupBindingTest()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString"));
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
            {
                m_Address = Address.Accessor.Instance(null).CreateNewT(manager, null);
                m_Address.Country = m_Address.CountryLookup[0];
            }

            lookUpEdit1.Properties.DataSource = m_Address.CountryLookup;
            lookUpEdit1.Properties.DisplayMember = "strCountryName";
            lookUpEdit1.Properties.ValueMember = null;
            lookUpEdit1.DataBindings.Add("EditValue", m_Address, "Country", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            m_Address.Country = null;
            Debug.Assert(lookUpEdit1.EditValue == null || lookUpEdit1.EditValue == DBNull.Value);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            m_Address.Country = m_Address.CountryLookup[1];
            Debug.Assert(lookUpEdit1.EditValue == m_Address.Country);
        }
    }

    [TestClass]
    public class HumanCaseListUITests
    {
        [TestInitialize]
        public void MyTestInitialize()
        {
        }

        [TestMethod]
        [Ignore]
        public void HumanCaseWinTest()
        {
            var form = new LookupBindingTest();
            form.ShowDialog();
        }
    }
}
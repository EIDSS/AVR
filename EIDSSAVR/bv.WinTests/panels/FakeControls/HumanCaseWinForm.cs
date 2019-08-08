using System;
using System.Linq;
using System.Windows.Forms;
using bv.model.BLToolkit;
using eidss.model.Schema;

namespace bv.WinTests.panels.FakeControls
{
    public partial class HumanCaseWinForm : Form
    {
        private HumanCase m_Case;

        public HumanCaseWinForm()
        {
            InitializeComponent();
        }

        private void HumanCaseWinForm_Load(object sender, EventArgs e)
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
            {
                HumanCase.Accessor acc = HumanCase.Accessor.Instance(null);
                m_Case = acc.CreateNewT(manager, null);
            }

            m_Case.TentativeDiagnosis = m_Case.TentativeDiagnosisLookup.FirstOrDefault();

            //diagnosisLookupBindingSource.DataSource
            //comboBoxEdit1.DataBindings.Add(new Binding("EditValue", this.diagnosisLookupBindingSource, "name", true));

            //this.diagnosisLookupBindingSource.D

            //comboBox1.DataSource = m_case.TentativeDiagnosisLookup;
            //comboBox1.DisplayMember = "name";
            //comboBox1.ValueMember = "idfsDiagnosis";
            //comboBox1.DataBindings.Add(new Binding("idfsTentativeDiagnosis", m_case, "SelectedValue"));
            //comboBox1.DataBindings.Add(new Binding("SelectedValue", m_case, "TentativeDiagnosis"));
            //false, DataSourceUpdateMode.OnPropertyChanged, "", null, null));
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            object selected = comboBox1.SelectedValue;
            object selectedItem = comboBox1.SelectedItem;
        }
    }
}
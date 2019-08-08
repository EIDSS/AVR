using System;
using System.Windows.Forms;
using AUM.Core.Helper;

namespace AUM.UpdateCreator
{
    public partial class FSetCortege : Form
    {
        public FSetCortege()
        {
            InitializeComponent();
        }

        /// <summary>
        /// /
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBTestClick(object sender, EventArgs e)
        {
            if (!UpdHelper.CheckUpdateVersions(tbCortege.Text))
            {
                MessageBox.Show("There are errors in Version string!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Version string is correct!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBApplyClick(object sender, EventArgs e)
        {
            cortegeVersion = tbCortege.Text;
            Close();
        }

        /// <summary>
        /// 
        /// </summary>
        public string cortegeVersion { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFSetCortegeLoad(object sender, EventArgs e)
        {
            tbCortege.Text = cortegeVersion;
        }
    }
}

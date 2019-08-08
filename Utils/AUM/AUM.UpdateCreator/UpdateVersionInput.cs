using System;
using System.Windows.Forms;

namespace AUM.UpdateCreator
{
    public partial class UpdateVersionInput : UserControl
    {
        public UpdateVersionInput()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        public string CortegeVersion { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBVersionCompareClick(object sender, EventArgs e)
        {
            var form = new FSetCortege {cortegeVersion = CortegeVersion};
            form.ShowDialog();
            tbVersion.Text = CortegeVersion = form.cortegeVersion;
        }
    }
}

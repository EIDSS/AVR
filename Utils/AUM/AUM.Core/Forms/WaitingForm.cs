using System;
using System.Windows.Forms;
using AUM.Core.Helper;

namespace AUM.Core.Forms
{
    /// <summary>
    /// 
    /// </summary>
    public partial class WaitingForm : Form
    {
        private TerminateEIDSSHelper m_TerminateEIDSSHelper;

        public WaitingForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTimerTick(object sender, EventArgs e)
        {
            if (m_TerminateEIDSSHelper == null) return;
            bClose.Text = String.Format("{0} ({1})", ResourceHelper.Get("CloseCaption"), m_TerminateEIDSSHelper.TimeSpanRemain);
            if (m_TerminateEIDSSHelper.CanClose) Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWaitingFormLoad(object sender, EventArgs e)
        {
            m_TerminateEIDSSHelper = new TerminateEIDSSHelper();
            timer.Enabled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBCloseClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
using System;
using System.Windows.Forms;
using AUM.Core;
using AUM.Core.Enums;
using AUM.Core.Helper;

namespace AUM
{
    public partial class TerminateProcessesForm : Form
    {
        public TerminateDbHelper TerminateDbHelper { get; set; }

        private ITerminateForm ParentTermForm { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TerminateProcessesForm(ITerminateForm parentForm, bool isDbUpdate, UpdateDatabases updateDatabase)
        {
            InitializeComponent();
            ParentTermForm = parentForm;
            //немедленно запустим проверку
            TerminateDbHelper = new TerminateDbHelper(isDbUpdate, updateDatabase);
            TimerListener.Enabled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        public void StartCheckConnections()
        {
            TerminateDbHelper.StartCheckConnections();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBCancelUpdateClick(object sender, EventArgs e)
        {
            CloseForm();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTimerListenerTick(object sender, EventArgs e)
        {
            if (TerminateDbHelper == null) return;
            ParentTermForm.WasError = TerminateDbHelper.WasError;
            ParentTermForm.ErrorString = TerminateDbHelper.ErrorString;
            if (TerminateDbHelper.CanClose || ParentTermForm.WasError) CloseForm();
        }

        /// <summary>
        /// 
        /// </summary>
        private void CloseForm()
        {
            TimerListener.Enabled = false;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
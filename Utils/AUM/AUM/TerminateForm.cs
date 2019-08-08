using System.Windows.Forms;
using AUM.Core;
using AUM.Core.Enums;

namespace AUM
{
    class TerminateForm : ITerminateForm
    {
        private TerminateProcessesForm terminateProcessesForm { get; set; }

        public TerminateForm(bool isDbUpdate, UpdateDatabases updateDatabase)
        {
            terminateProcessesForm = new TerminateProcessesForm(this, isDbUpdate, updateDatabase);
        }

        public DialogResult ShowDialog()
        {
            
            return terminateProcessesForm.ShowDialog();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool NeedShowForm()
        {
            return !CanClose; // terminateProcessesForm.TerminateDbHelper.CanClose;
        }

        /// <summary>
        /// 
        /// </summary>
        public void StartCheckConnections()
        {
            terminateProcessesForm.StartCheckConnections();
        }

        public bool WasError{get;set;}
        public bool CanClose
        {
            get { return terminateProcessesForm.TerminateDbHelper.CanClose; }
            set { terminateProcessesForm.TerminateDbHelper.CanClose = value; }
        }

        public string ErrorString{get;set;}
    }
}

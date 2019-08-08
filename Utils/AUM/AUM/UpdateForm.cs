using System;
using System.Text;
using System.Windows.Forms;
using AUM.Core;
using AUM.Core.Helper;

namespace AUM
{
    public partial class UpdateForm : Form
    {
        public UpdateForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Добавляет строку в отчёт
        /// </summary>
        /// <param name="text"></param>
        public void AddReportString(string text)
        {
            lbReport.Items.Add(text);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="active"></param>
        internal void ButtonCloseEnabled(bool active)
        {
            bClose.Enabled = active;
            ControlBox = active;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetLog()
        {
            var result = new StringBuilder();
            foreach (string s in lbReport.Items)
            {
                result.AppendLine(s);
            }

            return result.ToString();
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

        /// <summary>
        /// 
        /// </summary>
        public void SetProgressbarMin()
        {
            progressBar.Value = progressBar.Minimum;
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetProgressbarMax()
        {
            progressBar.Value = progressBar.Maximum;
        }

        /// <summary>
        /// 
        /// </summary>
        public void ProgressbarStep()
        {
            progressBar.PerformStep();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="maxValue"></param>
        public void SetProgressBarMaxValue(int maxValue)
        {
            progressBar.Maximum = maxValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args">аргументы командной строки</param>
        public void SetWindowCaption(string args)
        {
            Text = String.Format(ResourceHelper.Get("TaskCaption"), UpdHelper.GetRegimeCaption(args));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTimerStartUpdateTick(object sender, EventArgs e)
        {
            //каждый раз проверяем, можно ли производить апдейт (все ли отключились)

        }

        private int m_WaitSeconds;
        private const int AllTimeWaiting = 30; 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTimerWaitingCloseTick(object sender, EventArgs e)
        {
            m_WaitSeconds++;
            bClose.Text = String.Format("{0} ({1})", ResourceHelper.Get("CloseCaption"), AllTimeWaiting - m_WaitSeconds);
            if (m_WaitSeconds > AllTimeWaiting)
            {
                TimerWaitingClose.Enabled = false;
                Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void StartAutoClose()
        {
            TimerWaitingClose.Enabled = true;
        }

        /// <summary>
        /// true-развернута панель детальной информации
        /// </summary>
        private bool m_DetailsEnabled;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBDetailsClick(object sender, EventArgs e)
        {
            m_DetailsEnabled = !m_DetailsEnabled;
            RefreshDetailsState();
        }

        /// <summary>
        /// 
        /// </summary>
        private void RefreshDetailsState()
        {
            gbReport.Visible = m_DetailsEnabled;
            if (m_DetailsEnabled)
            {
                Height = bDetails.Top + bDetails.Height + gbReport.Height + 50;
            }
            else
            {
                Height = bDetails.Top + bDetails.Height + 50;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnUpdateFormLoad(object sender, EventArgs e)
        {
            m_DetailsEnabled = false;
            RefreshDetailsState();
        }
    }
}
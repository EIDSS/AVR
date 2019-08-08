using System.Windows.Forms;
using EIDSS.Reports.BaseControls.Form;

namespace bv.WinTests.Reports
{
    public class FakeReportForm : IReportForm
    {
        public event FormClosedEventHandler FormClosed;
        public string Text { get; set; }

        public void OnFormClosed(FormClosedEventArgs e)
        {
            FormClosedEventHandler handler = FormClosed;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void ShowReport(Control reportKeeper)
        {
        }

        public void ApplyResources()
        {
        }

        public void Close()
        {
        }
    }
}
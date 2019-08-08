using System.Windows.Forms;

namespace AUM.Core
{
    public interface ITerminateForm
    {
        DialogResult ShowDialog();
        bool NeedShowForm();
        void StartCheckConnections();
        bool WasError { get; set; }
        bool CanClose { get; set; }
        string ErrorString { get; set; }
    }
}

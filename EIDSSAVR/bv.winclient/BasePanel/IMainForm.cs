using System.Windows.Forms;

namespace bv.winclient.BasePanel
{
    public interface IMainForm
    {
        string Text { get; set; }

        void AddButtons();
        void CallLogin();
        void InitAutoLogoutMonitor();
        void RegisterActions();
        void RegisterDefaultActions();
        void ResetLanguage(string langID);
        void SetRussianLanguage();
        void ShowEventDetail(object eventId);
        void RefreshLayout();    
    }
}

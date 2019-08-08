using System.Windows.Forms;
using AUM.Core.Forms;

namespace AUM.Core.Helper
{
    /// <summary>
    /// 
    /// </summary>
    public static class FormsHelper
    {
        /// <summary>
        /// Показ окна ввода логина и пароля к серверу обновлений
        /// </summary>
        public static DialogResult ShowUpdateServerWindow()
        {
            return (new LoginForm(LoginFormRegime.UpdateServer)).ShowDialog();
        }


        /// <summary>
        /// Показ окна ввода логина и пароля к юзеру-администратору (Sql Server)
        /// </summary>
        public static DialogResult ShowSqlSettingsWindow()
        {
            return (new LoginForm(LoginFormRegime.MaintSqlSettings)).ShowDialog();
        }

        /// <summary>
        /// Показывает окно ожидания завершения EIDSS
        /// </summary>
        public static void ShowWaitingForm()
        {
            (new WaitingForm()).ShowDialog(null);
        }
    }
}

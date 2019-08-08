using System;
using System.Windows.Forms;
using AUM.Core.Helper;

namespace AUM.Core.Forms
{
    public enum LoginFormRegime
    {
        /// <summary>
        /// Доступ к серверу обновлений
        /// </summary>
        UpdateServer = 0,
        /// <summary>
        /// Администраторский логин и пароль (Sql Server)
        /// </summary>
        MaintSqlSettings = 2
    }

    /// <summary>
    /// 
    /// </summary>
    public partial class LoginForm : Form
    {
        private readonly LoginFormRegime m_FormRegime;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="regime"></param>
        public LoginForm(LoginFormRegime regime)
        {
            InitializeComponent();
            m_FormRegime = regime;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBCancelClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBokClick(object sender, EventArgs e)
        {
            if ((tbLogin.Text.Length == 0) || (tbPassword.Text.Length == 0)) return;

            var loginCrypted = Cryptor.Encrypt(tbLogin.Text);
            var passwordCrypted = Cryptor.Encrypt(tbPassword.Text);
            var domain = tbDomain.Text;
            var isValidUser = false;
            //пишем в реестр
            if (m_FormRegime.Equals(LoginFormRegime.UpdateServer))
            {
                RegistryHelper.WriteToRegistry("UpdateServerLogin", loginCrypted);
                RegistryHelper.WriteToRegistry("UpdateServerPassword", passwordCrypted);
                isValidUser = true;
            }
            else if (m_FormRegime.Equals(LoginFormRegime.MaintSqlSettings))
            {
                RegistryHelper.WriteToRegistry("MaintSqlLogin", loginCrypted);
                RegistryHelper.WriteToRegistry("MaintSqlPassword", passwordCrypted);
                isValidUser = true;
            }

            if (isValidUser)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoginFormLoad(object sender, EventArgs e)
        {
            if (m_FormRegime.Equals(LoginFormRegime.UpdateServer)) Text = "AUM. Connection to Update Server";
            if (m_FormRegime.Equals(LoginFormRegime.MaintSqlSettings)) Text = "AUM. SqlServer administrator password";

            //lDomain.Enabled = tbDomain.Enabled = (formRegime.Equals(LoginFormRegime.MaintSettings));

            userInfo.Text = String.Format("Current user: user domain name={0}; user name={1}; machine name={2}", Environment.UserDomainName,
                                          Environment.UserName, Environment.MachineName);
        }
    }
}
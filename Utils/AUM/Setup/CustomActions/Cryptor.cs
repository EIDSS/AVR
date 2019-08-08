namespace CustomActions
{
  using Microsoft.Deployment.WindowsInstaller;
  using Utils;


  public static class Cryptor
  {
    #region SQL
    [CustomAction]
    public static ActionResult EncryptAccountDetails(Session session)
    {
      session.Log("Begin EncryptAccountDetails");

      var cryptor = new CryptorWrapper(session);
      cryptor.EncryptAccountDetails(InstallerProperties.MaintSqlLogin, InstallerProperties.MaintSqlPassword);

      session[InstallerProperties.EncryptedMaintSqlLogin] = cryptor.ResultUser;
      session[InstallerProperties.EncryptedMaintSqlPassword] = cryptor.ResultPassword;

      return ActionResult.Success;
    }

    [CustomAction]
    public static ActionResult DecryptAccountDetails(Session session)
    {
      session.Log("Begin DecryptAccountDetails");

      var cryptor = new CryptorWrapper(session);
      cryptor.DecryptAccountDetails(InstallerProperties.EncryptedMaintSqlLogin, InstallerProperties.EncryptedMaintSqlPassword);

      session[InstallerProperties.MaintSqlLogin] = cryptor.ResultUser;
      session[InstallerProperties.MaintSqlPassword] = cryptor.ResultPassword;

      return ActionResult.Success;
    }
    #endregion SQL
  }
}

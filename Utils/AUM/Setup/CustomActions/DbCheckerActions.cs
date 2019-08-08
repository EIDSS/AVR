namespace CustomActions
{
  using Microsoft.Deployment.WindowsInstaller;
  using Utils;
  using Utils.PropertyContainers;


  public static class DbCheckerActions
  {
    [CustomAction]
    public static ActionResult TestDbConnection(Session session)
    {
      session.Log("Begin DbChecker.TestDbConnection");

      session[InstallerProperties.DbConnectionValid] = DbChecker.TestConnection(
        new SessionWrapper(session),
        InstallerProperties.DbServer,
        InstallerProperties.SqlDatabase,
        InstallerProperties.MaintSqlLogin,
        InstallerProperties.MaintSqlPassword) ? "1" : "0";

      return ActionResult.Success;
    }

    [CustomAction]
    public static ActionResult TestArchiveDbConnection(Session session)
    {
      session.Log("Begin DbChecker.TestArchiveDbConnection");

      session[InstallerProperties.ArchDbConnectionValid] = DbChecker.TestConnection(
        new SessionWrapper(session),
        InstallerProperties.ArchDbServer,
        InstallerProperties.ArchDatabase,
        InstallerProperties.MaintSqlLogin,
        InstallerProperties.MaintSqlPassword) ? "1" : "0";

      return ActionResult.Success;
    }
  }
}

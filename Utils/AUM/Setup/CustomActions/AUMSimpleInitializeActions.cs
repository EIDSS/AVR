namespace CustomActions
{
  using System;
  using Microsoft.Deployment.WindowsInstaller;
  using Utils;
  using Utils.PropertyContainers;


  public static class AUMSimpleInitializeActions
  {
    [CustomAction]
    public static ActionResult ReadConfig(Session session)
    {
      session.Log("Begin ReadConfig");

      new AUMConfigurator(new SessionWrapper(session), new InstallerLogger(session)).ReadConfig();

      return ActionResult.Success;
    }

    [CustomAction]
    public static ActionResult ValidateMisc(Session session)
    {
      session.Log("Begin ValidateMisc");

      new AUMConfigurator(new SessionWrapper(session), new InstallerLogger(session)).CheckTimeIntervals();

      return ActionResult.Success;
    }

    [CustomAction]
    public static ActionResult TestUpgradeUrls(Session session)
    {
      session.Log("Begin TestUpgradeUrls");

      new UpgradeUrlTester(new SessionWrapper(session), new InstallerLogger(session)).TestUpgradeUrls(
        session[InstallerProperties.MainUpgradeUrl],
        session[InstallerProperties.SecondaryUpgradeUrl],
        session[InstallerProperties.SecureUrl].Equals("1", StringComparison.OrdinalIgnoreCase));

      return ActionResult.Success;
    }
  }
}
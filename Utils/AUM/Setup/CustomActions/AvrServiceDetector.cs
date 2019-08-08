namespace CustomActions
{
  using System.Collections.Generic;
  using System.IO;
  using System.Linq;
  using Microsoft.Deployment.WindowsInstaller;
  using Utils;


  public static class AvrServiceDetector
  {
    private const string ComboBoxTable = "ComboBox";
    private const string ComboBoxPropertyColumn = "Property";


    [CustomAction]
    public static ActionResult FillAvrServices(Session session)
    {
      session.Log("Begin FillAvrServices");

      var avrServiceDetector = new AvrServiceRegistryDetector(session);
      var avrServiceInstances = avrServiceDetector.FilterInstancesByBase(session[InstallerProperties.ProductFamilyRegistryKey]);
      ParceReadAvrServices(session, avrServiceDetector.AddEmptyRecord(avrServiceInstances));
      return ActionResult.Success;
    }

    private static void ParceReadAvrServices(Session session, IList<AvrInstanceSettings> avrServices)
    {
      switch (avrServices.Count)
      {
        case 1:
          session[InstallerProperties.AvrServiceConfigurationRequired] = string.Empty;
          break;
        case 2:
          session[InstallerProperties.AvrServiceConfigurationRequired] = string.Empty;
          session[InstallerProperties.AvrServiceUpgradeCode] = avrServices[1].Value;
          break;
        default:
          session[InstallerProperties.AvrServiceConfigurationRequired] = "1";
          FillAvrServicesComboBox(session, avrServices);
          break;
      }
    }

    private static void FillAvrServicesComboBox(Session session, IList<AvrInstanceSettings> avrServices)
    {
      var msiDatabaseWrapper = new MsiDatabaseWrapper(session);
      msiDatabaseWrapper.DeleteRecord(ComboBoxTable, new MsiDatabaseWrapper.Field(ComboBoxPropertyColumn, InstallerProperties.AvrServiceUpgradeCode));
      for (var i = 0; i < avrServices.Count(); ++i)
      {
        msiDatabaseWrapper.InsertRecord(ComboBoxTable,
          new object[]
          {
            InstallerProperties.AvrServiceUpgradeCode,
            i + 1,
            avrServices[i].Value,
            avrServices[i].Text
          });
      }
    }

    [CustomAction]
    public static ActionResult ReadAvrSvcConfiguration(Session session)
    {
      session.Log("Begin ReadAvrSvcConfiguration");

      var avrServiceRegistryKey = Path.Combine(
        session[InstallerProperties.ProductFamilyRegistryKey],
        session[InstallerProperties.AvrServiceUpgradeCode]);

      new AvrServiceRegistryDetector(session).ReadAvrServiceSettings(avrServiceRegistryKey);

      return ActionResult.Success;
    }
  }
}
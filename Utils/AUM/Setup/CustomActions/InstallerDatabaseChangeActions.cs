namespace CustomActions
{
  using System.Collections.Generic;
  using Microsoft.Deployment.WindowsInstaller;
  using Utils;


  public static class InstallerDatabaseChangeActions
  {
    private const string ShortcutTable = "Shortcut";


    private enum ShortcutTableFormattedFields
    {
      Name = 3,
      Description = 7
    }

    [CustomAction]
    public static ActionResult FixShortcuts(Session session)
    {
      session.Log("Begin FixShortcuts");

      new MsiDatabaseWrapper(session).FormatFields(
        ShortcutTable,
        new List<int>
        {
          (int) ShortcutTableFormattedFields.Name,
          (int) ShortcutTableFormattedFields.Description
        });

      return ActionResult.Success;
    }
  }
}

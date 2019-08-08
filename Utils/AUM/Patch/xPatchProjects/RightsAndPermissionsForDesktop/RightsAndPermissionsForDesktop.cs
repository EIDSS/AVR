namespace AUM.XPatch
{
  using System;
  using System.Security.AccessControl;
  using System.Security.Principal;
  using Microsoft.Win32;


  public sealed class RightsAndPermissionsForDesktop : BaseTask
  {
    #region BaseTask
    protected override bool ExecuteInternal()
    {
      var success = false;
      try
      {
        using (var hklm = OpenBaseKey())
        {
          using (var eidsssKey = hklm.OpenSubKey(EIDSSSubKey, true))
          {
            if (null == eidsssKey)
            {
              AddInfoString("Subkey '{0}' not found. No action required.", EIDSSSubKey);
            }
            else
            {
              var regSec = eidsssKey.GetAccessControl(AccessControlSections.All);
              var rule = new RegistryAccessRule(
                  UsersGroup(),
                  RegistryRights.FullControl,
                  InheritanceFlags.None,
                  PropagationFlags.None,
                  AccessControlType.Allow);
              regSec.AddAccessRule(rule);
              eidsssKey.SetAccessControl(regSec);

              AddInfoString("Access rights granted.");
            }
          }
        }
        success = true;
      }
      catch (Exception ex)
      {
        AddErrorString(GetFullError(ex));
      }
      return success;
    }

    public override string GetName()
    {
      return "Rights & Permissions for a desktop application";
    }

    public override Guid GetID()
    {
      return new Guid("{9723D233-159B-43AC-AB97-C2F712D498E1}");
    }
    #endregion

    #region implementation
    private const string EIDSSSubKey = @"Software\EIDSS 6.0";
    private const string UsersSid = "S-1-5-32-545";

    private static RegistryKey OpenBaseKey()
    {
      return RegistryKey.OpenBaseKey(
          RegistryHive.LocalMachine,
          Environment.Is64BitOperatingSystem
              ? RegistryView.Registry32
              : RegistryView.Default);
    }

    private static IdentityReference UsersGroup()
    {
      var usersSid = new SecurityIdentifier(UsersSid);
      System.Diagnostics.Debug.Assert(usersSid.IsWellKnown(WellKnownSidType.BuiltinUsersSid));

      return usersSid.Translate(typeof(NTAccount));
    } 
    #endregion
  }
}
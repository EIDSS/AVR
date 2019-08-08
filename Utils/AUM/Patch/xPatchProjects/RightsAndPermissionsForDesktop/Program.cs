namespace RightsAndPermissionsForDesktop
{
  using System;
  using System.Collections.Generic;
  using System.Globalization;
  using System.IO;
  using System.Reflection;
  using System.Security.AccessControl;
  using System.Security.Principal;
  using AUM.Core.Helper;
  using Microsoft.Win32;


  internal static class Program
  {
    private const string EIDSSSubKey = @"Software\EIDSS 6.0";
    private const string UsersSid = "S-1-5-32-545";

    private static void Main()
    {
      var logStrings = new List<string> { "Start." };

      var result = false;
      try
      {
        using (var hklm = OpenBaseKey())
        using (var eidsssKey = hklm.OpenSubKey(EIDSSSubKey, true))
        {
          if (null == eidsssKey)
          {
            AddInfoString(ref logStrings, string.Format(CultureInfo.InvariantCulture, "Subkey '{0}' not found. No action required.", EIDSSSubKey));
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

            AddInfoString(ref logStrings, "Access rights granted.");
          }
        }
        result = true;
      }
      catch (Exception ex)
      {
        AddErrorString(ref logStrings, GetFullError(ex));
      }
      finally
      {
        AddInfoString(ref logStrings, "Finish");
        FileHelper.WriteLogFileForExecuteApp(GetExecutableFilePath(), GetExecutableFileName(), result, logStrings);
      }
    }

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

    /// <summary>
    /// Adds information string to the log
    /// </summary>
    /// <param name="logStrings">List of log strings</param>
    /// <param name="infoString">String containg information to include to the log</param>
    private static void AddInfoString(ref List<string> logStrings, string infoString)
    {
      if (logStrings == null)
      {
        logStrings = new List<string>();
      }

      logStrings.Add(string.Format("Seting registry access rights. {0}: {1}", DateTime.Now.ToString(CultureInfo.InvariantCulture), infoString));
    }

    /// <summary>
    /// Adds error message to the log
    /// </summary>
    /// <param name="logStrings">List of log strings</param>
    /// <param name="errorMessage">String containg error message to include to the log</param>
    private static void AddErrorString(ref List<string> logStrings, string errorMessage)
    {
      if (logStrings == null)
      {
        logStrings = new List<string>();
      }

      logStrings.Add(string.Format("Seting registry access rights. Error {0}: {1}", DateTime.Now.ToString(CultureInfo.InvariantCulture), errorMessage));
    }

    /// <summary>
    /// Returns string with exception message including messages of all inner exceptions.
    /// </summary>
    /// <param name="exception">Application exception</param>
    /// <returns>Returns string with exception message including messages of all inner exceptions</returns>
    private static string GetFullError
      (
      Exception exception
      )
    {
      var msgError = "";

      var ex = exception;
      if (ex == null)
      {
        return (msgError);
      }

      msgError = string.Format("Exception: {0}", ex.Message);

      var i = 0;
      while (ex.InnerException != null)
      {
        ex = ex.InnerException;
        i = i + 1;
        msgError = string.Format("{0} \n {1} {2}: {3}", msgError, "Inner exception", i.ToString(CultureInfo.InvariantCulture), ex.Message);
      }

      return (msgError);
    }

    /// <summary>
    /// Returns name of application executable file 
    /// </summary>
    /// <returns>Returns name of application executable file</returns>
    public static string GetExecutableFileName()
    {
      return (Path.GetFileName(Assembly.GetEntryAssembly().Location));
    }

    /// <summary>
    /// Returns name of directory containing application executable file
    /// </summary>
    /// <returns>Returns name of directory containing application executable file</returns>
    public static string GetExecutableFilePath()
    {
      return (Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
    }
  }
}
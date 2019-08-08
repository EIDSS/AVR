namespace AUM.XPatch
{
  using System;
  using Microsoft.Win32;


  //Let's create in registry this [HKEY_LOCAL_MACHINE]\SOFTWARE\AUM.TestXPatch:testParameter REG_SZ "This is a test string"
  internal sealed class WrightRegistrySubTask : SubTask
  {
    const string TestKey = @"SOFTWARE\AUM.TestXPatch";
    const string TestParameter = "testParameter";
    const string TestParameterValue = "This is a test string";

    protected override bool InternalRun()
    {
      using (var hklm = OpenBaseKey())
      {
        AddInfoString("Trying to open/create {0}", TestKey);
        using (var testKey = hklm.CreateSubKey(TestKey, RegistryKeyPermissionCheck.ReadWriteSubTree))
        {
          AddInfoString("Trying to set {0} to {1}", TestParameter, TestParameterValue);
          // ReSharper disable PossibleNullReferenceException
          testKey.SetValue(TestParameter, TestParameterValue);
          // ReSharper restore PossibleNullReferenceException
        }
      }
      return true;
    }

    private static RegistryKey OpenBaseKey()
    {
      return RegistryKey.OpenBaseKey(
        RegistryHive.LocalMachine,
        Environment.Is64BitOperatingSystem
          ? RegistryView.Registry64
          : RegistryView.Default);
    }
  }
}
namespace CustomActions.Utils
{
  using System;
  using Microsoft.Win32;


  internal sealed class RegistryOpener : IDisposable
  {
    private readonly RegistryKey m_hive;

    internal RegistryKey Subkey { get; private set; }

    internal RegistryOpener(string registryKey, RegistryHive rootHive = RegistryHive.LocalMachine)
    {
      m_hive = RegistryKey.OpenBaseKey(rootHive, RegistryView.Default);
      Subkey = m_hive.OpenSubKey(registryKey);
    }

    public void Dispose()
    {
      if (null != Subkey)
      {
        Subkey.Dispose();
      }

      if (null != m_hive)
      {
        m_hive.Dispose();
      }
    }
  }
}
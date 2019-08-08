namespace CustomActions.Utils
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using Microsoft.Deployment.WindowsInstaller;
  using Microsoft.Win32;


  internal sealed class AvrServiceRegistryDetector
  {
    private const string InstallPath = "InstallPath";
    private const string AvrServiceDisplayName = "AVR Service Display Name";
    private const string AvrServiceSystemName = "AVR Service";
    private const string AvrServiceServer = "AvrServiceServer";
    private const string AvrServiceDatabase = "AvrServiceDatabase";
    private const string AvrServiceUser = "AvrServiceUser";
    private const string AvrServicePassword = "AvrServicePassword";
    private const string SqlServer = "SQLServer";
    private const string SqlDatabase = "SQLDatabase";

    private readonly Session m_session;

    internal AvrServiceRegistryDetector(Session session)
    {
      m_session = session;
    }

    internal void ReadAvrServiceSettings(string registryKey)
    {
      using (var avrReg = new RegistryOpener(registryKey))
      {
        var avrRegKeyOpened = avrReg.Subkey;
        if (null == avrRegKeyOpened)
        {
          return;
        }

        InitAvrServiceProperties(avrRegKeyOpened);
      }
    }

    private void InitAvrServiceProperties(RegistryKey avrRegKeyOpened)
    {
      m_session[InstallerProperties.AvrSPath] = avrRegKeyOpened.GetValue(InstallPath, null) as string;
      m_session[InstallerProperties.AvrSName] = avrRegKeyOpened.GetValue(AvrServiceSystemName, null) as string;
      m_session[InstallerProperties.AvrServiceServer] = avrRegKeyOpened.GetValue(AvrServiceServer, null) as string;
      m_session[InstallerProperties.AvrServiceDatabase] = avrRegKeyOpened.GetValue(AvrServiceDatabase, null) as string;
      m_session[InstallerProperties.AvrServiceUser] = avrRegKeyOpened.GetValue(AvrServiceUser, null) as string;
      m_session[InstallerProperties.AvrServicePassword] = avrRegKeyOpened.GetValue(AvrServicePassword, null) as string;
    }

    internal IList<AvrInstanceSettings> FilterInstancesByBase(string key)
    {
      var dbServer = m_session[InstallerProperties.DbServer];
      var database = m_session[InstallerProperties.SqlDatabase];

      var instances = ReadAvrServices(key);
      return instances.Where(
          instance =>
            dbServer.Equals(instance.SqlServer, StringComparison.OrdinalIgnoreCase) &&
            database.Equals(instance.Database, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    private static IEnumerable<AvrInstanceSettings> ReadAvrServices(string key)
    {
      using (var instances = new RegistryOpener(key))
      {
        var instancesKey = instances.Subkey;
        if (null != instancesKey)
        {
          return ReadAvrServicesInstances(instancesKey);
        }
      }
      return new List<AvrInstanceSettings>(0);
    }

    private static IEnumerable<AvrInstanceSettings> ReadAvrServicesInstances(RegistryKey instancesKey)
    {
      var instances = new List<AvrInstanceSettings>();
      foreach (var subKeyName in instancesKey.GetSubKeyNames())
      {
        ReadAvrServicesInstance(instancesKey, subKeyName, instances);
      }
      return instances;
    }

    private static void ReadAvrServicesInstance(RegistryKey instancesKey, string subKeyName, List<AvrInstanceSettings> instances)
    {
      using (var instance = instancesKey.OpenSubKey(subKeyName))
      {
        if (null != instance)
        {
          var avrService = instance.GetValue(AvrServiceDisplayName, string.Empty) as string;
          var eidssDbServer = instance.GetValue(SqlServer, string.Empty) as string;
          var eidssDatabase = instance.GetValue(SqlDatabase, string.Empty) as string;

          if (!String.IsNullOrEmpty(avrService))
          {
            instances.Add(new AvrInstanceSettings
            {
              Value = subKeyName,
              Text = avrService,
              SqlServer = eidssDbServer,
              Database = eidssDatabase
            });
          }
        }
      }
    }

    internal IList<AvrInstanceSettings> AddEmptyRecord(IList<AvrInstanceSettings> instances)
    {
      instances.Insert(0, new AvrInstanceSettings
      {
        Value = m_session.Format(m_session[InstallerProperties.AvrServiceNotPresentValue]),
        Text = m_session.Format(m_session[InstallerProperties.AvrServiceNotPresentText]),
        SqlServer = string.Empty,
        Database = string.Empty
      });
      return instances;
    }
  }
}
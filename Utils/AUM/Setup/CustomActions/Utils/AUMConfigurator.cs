namespace CustomActions.Utils
{
  using System;
  using System.Globalization;
  using System.IO;
  using AUM.Core;
  using AUM.Core.Helper;
  using PropertyContainers;


  internal sealed class AUMConfigurator
  {
    private readonly ILogger m_logger;
    private IPropertyContainer PropertyContainer { get; set; }

    internal AUMConfigurator(IPropertyContainer propertyContainer, ILogger logger)
    {
      if (null == propertyContainer)
      {
        throw new ArgumentNullException("propertyContainer");
      }

      if (null == logger)
      {
        throw new ArgumentNullException("logger");
      }

      PropertyContainer = propertyContainer;
      m_logger = logger;
    }

    private void ResetMiscValidators()
    {
      PropertyContainer[InstallerProperties.MiscConfigurationValid] = "1";
      PropertyContainer[InstallerProperties.SyncIntervalValid] = "1";
      PropertyContainer[InstallerProperties.UpdateIntervalValid] = "1";
    }

    internal void ReadConfig()
    {
      var configPath = CombineConfigPath();

      if (File.Exists(configPath))
      {
        ReadConfig(configPath);
      }
    }

    private string CombineConfigPath()
    {
      return Path.Combine(
        PropertyContainer[InstallerProperties.ApplicationFolder],
        FileHelper.BVUpdaterConfigFileName);
    }

    private void ReadConfig(string configPath)
    {
      var settings = new ConfigSettings(configPath);

      PropertyContainer[InstallerProperties.MachineLevel] = settings.Level.ToString("d");
      PropertyContainer[InstallerProperties.SyncInterval] = settings.IntervalDownload;
      PropertyContainer[InstallerProperties.UpdateInterval] = settings.IntervalUpdate;
      PropertyContainer[InstallerProperties.BackupPath] = settings.BackupPath;
      PropertyContainer[InstallerProperties.MainUpgradeUrl] = settings.UpdateUrl.Primary;
      PropertyContainer[InstallerProperties.SecondaryUpgradeUrl] = settings.UpdateUrl.Secondary;
    }

    internal void CheckTimeIntervals()
    {
      ResetMiscValidators();

      var errorManager = new ErrorManager();
      CheckSyncInterval(errorManager);
      CheckUpdateInterval(errorManager);

      var errors = string.Join(Environment.NewLine, errorManager.Errors);
      if (!string.IsNullOrEmpty(errors))
      {
        PropertyContainer[InstallerProperties.MiscConfigurationValid] = "0";
        PropertyContainer[InstallerProperties.ErrorConfigurationText] = errors;
      }
    }

    private void CheckUpdateInterval(ErrorManager manager)
    {
      var hours = PropertyContainer[InstallerProperties.SyncIntervalHours];
      var minutes = PropertyContainer[InstallerProperties.SyncIntervalMinutes];

      if (string.IsNullOrEmpty(hours) || string.IsNullOrEmpty(minutes))
      {
        PropertyContainer[InstallerProperties.SyncIntervalValid] = "0";
        manager.Add(PropertyContainer[InstallerProperties.EmptyMandatoryFileds]);
      }
      else
      {
        TimeSpan interval;
        if (!TimeSpan.TryParse(hours + ":" + minutes, out interval))
        {
          PropertyContainer[InstallerProperties.SyncIntervalValid] = "0";
          manager.Add(PropertyContainer[InstallerProperties.BadTimeInterval]);
        }
      }
    }

    private void CheckSyncInterval(ErrorManager manager)
    {
      var hours = PropertyContainer[InstallerProperties.UpdateIntervalHours];
      var minutes = PropertyContainer[InstallerProperties.UpdateIntervalMinutes];

      if (string.IsNullOrEmpty(hours) || string.IsNullOrEmpty(minutes))
      {
        PropertyContainer[InstallerProperties.UpdateIntervalValid] = "0";
        manager.Add(PropertyContainer[InstallerProperties.EmptyMandatoryFileds]);
      }
      else
      {
        TimeSpan interval;
        if (!TimeSpan.TryParse(hours + ":" + minutes, out interval))
        {
          PropertyContainer[InstallerProperties.UpdateIntervalValid] = "0";
          manager.Add(PropertyContainer[InstallerProperties.BadTimeInterval]);
        }
      }
    }
  }
}
namespace AUM.XPatch
{
  using System;
  using System.Configuration;
  using System.Globalization;
  using System.IO;


  internal sealed class ExtendedConfiguration
  {
    internal ExtendedConfiguration(string configurationFile)
    {
      if (string.IsNullOrEmpty(configurationFile))
      {
        throw new ArgumentNullException("configurationFile");
      }
      if (!File.Exists(configurationFile))
      {
        throw new ConfigurationErrorsException(string.Format(
          CultureInfo.InvariantCulture,
          "XPatch configuration file '{0}' is not found. Probably it's not included in patch",
          configurationFile));
      }

      AppSettings = ConfigurationManager.OpenMappedExeConfiguration(
        new ExeConfigurationFileMap { ExeConfigFilename = configurationFile },
        ConfigurationUserLevel.None).AppSettings.Settings;
    }

    internal KeyValueConfigurationCollection AppSettings { get; private set; }
  }
}
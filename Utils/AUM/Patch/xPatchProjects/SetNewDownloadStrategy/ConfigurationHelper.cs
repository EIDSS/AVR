namespace AUM.XPatch
{
  using System;
  using System.Configuration;


  internal class ModuleConfigurationHelper
  {
    private readonly Configuration m_configuration;

    public ModuleConfigurationHelper(string moduleFullPath)
    {
      if (string.IsNullOrEmpty(moduleFullPath))
      {
        throw new ArgumentNullException("moduleFullPath");
      }

      var configFile = moduleFullPath + ".config";
      var map = new ExeConfigurationFileMap
      {
        ExeConfigFilename = configFile
      };
      m_configuration = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
    }

    internal string this[string configKey]
    {
      get
      {
        var key = m_configuration.AppSettings.Settings[configKey];

        if (null == key)
        {
          return string.Empty;
        }
        var value = key.Value;
        return !string.IsNullOrEmpty(value) ? value : string.Empty;
      }
    }
  }
}

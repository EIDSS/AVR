namespace AUM.Core.Configuration
{
  using System;
  using System.Collections.Generic;
  using System.Configuration;
  using System.IO;
  using System.Reflection;
  using Core;
  using Diagnostics;


  //This class loads configuration settings from <appSettings> section of several configuration classes using the next rules:
  //1. It searches the directory where the executable or bv_common.dll is placed (current directory)
  //2. It searches first machine dependant bv_MACHINEMAME.config file starting the current directory and 3 leveles up.
  //   if file is found the settings are readed from this file
  //3. It searches general bv.config file starting the current directory and 3 leveles up.
  //   if file is found the settings are readed from this file.
  //4. It searches local congig file (executableName.config for windows app and web.config for ASP.NET app)
  //   starting the current directory and 3 leveles up.
  //   if file is found the settings are readed from this file.
  //5. Existing settings that are read already and exist in the current file are not overritten.
  // Configuration file priority is bv_MACHINEMAME.config->bv.config->local config.
  public class Config
  {
    private static IDictionary<string, string> s_settings;
    private static string s_configFileName;
    private static string s_localConfigFileName;
    private static readonly string s_generalMachineConfigName = string.Format("general_{0}.config", Environment.MachineName);
    private const string _GeneralConfigName = "general.config";
    private static string s_localConfigName = string.Empty;

    private Config()
    {
      // NOOP
    }

    private static void InitSettings()
    {
      if (s_settings != null)
      {
        return;
      }
      s_settings = new Dictionary<string, string>();
      if (s_localConfigFileName == null)
      {
        LoadMachineGeneralSettings();
        LoadGeneralSettings();
      }
      LoadLocalSettings();
      IsInitialized = true;
    }
    public static bool IsInitialized { get; private set; }

    public static void ReloadSettings()
    {
      IsInitialized = false;
      s_settings = null;
      InitSettings();
    }

    private static void LoadSettings(string fileName)
    {
      var fileMap = new ExeConfigurationFileMap {ExeConfigFilename = fileName};
      var config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
      foreach (var key in config.AppSettings.Settings.AllKeys)
      {
        Dbg.Assert(!Utils.IsEmpty(key), "setting key not specified", null);
        var value = config.AppSettings.Settings[key].Value;
        //Dbg.Assert(Not Utils.IsEmpty(value), "setting value not specified")
        if (!s_settings.ContainsKey(key))
        {
          s_settings.Add(key, value);
        }
        else
        {
          Dbg.Debug("duplicate key <{0}> in file {1}", key, fileName);
        }
      }
    }

    private static void LoadGeneralSettings()
    {
      FindGeneralConfigFile();
      if (!Utils.IsEmpty(s_configFileName))
      {
        LoadSettings(s_configFileName);
      }
    }

    private static void LoadMachineGeneralSettings()
    {
      FindMachineGeneralConfigFile();
      if (!Utils.IsEmpty(s_configFileName))
      {
        LoadSettings(s_configFileName);
      }
    }

    private static void LoadLocalSettings()
    {
      if (Utils.IsEmpty(s_localConfigFileName))
      {
        FindLocalConfigFile();
      }
      else
      {
        s_configFileName = s_localConfigFileName;
      }
      if (!Utils.IsEmpty(s_configFileName))
      {
        LoadSettings(s_configFileName);
      }
    }

    internal static void FindGeneralConfigFile()
    {
      s_configFileName = null;
      var appLocation = GetConfigFileDir();
      var dir = new DirectoryInfo(Path.GetDirectoryName(appLocation));
      if ((FindConfigFileInFolder(dir.FullName, _GeneralConfigName)
        || (dir.Parent != null && FindConfigFileInFolder(dir.Parent.FullName, _GeneralConfigName))
        || (dir.Parent.Parent != null && FindConfigFileInFolder(dir.Parent.Parent.FullName, _GeneralConfigName))
        || (dir.Parent.Parent.Parent != null && FindConfigFileInFolder(dir.Parent.Parent.Parent.FullName, s_generalMachineConfigName))))
      {
      }
    }
    internal static void FindMachineGeneralConfigFile()
    {
      s_configFileName = null;
      var appLocation = GetConfigFileDir();
      var dir = new DirectoryInfo(Path.GetDirectoryName(appLocation));
      if ((FindConfigFileInFolder(dir.FullName, s_generalMachineConfigName)
        || (dir.Parent != null && FindConfigFileInFolder(dir.Parent.FullName, s_generalMachineConfigName))
        || (dir.Parent.Parent != null && FindConfigFileInFolder(dir.Parent.Parent.FullName, s_generalMachineConfigName))
        || (dir.Parent.Parent.Parent != null && FindConfigFileInFolder(dir.Parent.Parent.Parent.FullName, s_generalMachineConfigName))))
      {
      }
    }

    internal static void FindLocalConfigFile()
    {
      s_configFileName = null;
      var appLocation = GetConfigFileDir();
      var dir = new DirectoryInfo(Path.GetDirectoryName(appLocation));
      {
        var asm = Assembly.GetEntryAssembly();
        if (asm != null)
        {
          s_localConfigName = Path.GetFileName(asm.Location) + ".config";
        }
        else
        {
          return;
        }
      }
      if ((FindConfigFileInFolder(dir.FullName, s_localConfigName) || (dir.Parent != null && FindConfigFileInFolder(dir.Parent.FullName, s_localConfigName)) || (dir.Parent.Parent != null && FindConfigFileInFolder(dir.Parent.Parent.FullName, s_localConfigName))))
      {
        return;
      }
      else
      {
        //Dbg.Debug("unable to locate config via windows application root path")
      }

    }
    internal static string GetConfigFileDir()
    {
      return Utils.GetExecutingPath();
    }

    private static bool FindConfigFileInFolder(string dir, string fileName)
    {
      if (!dir.EndsWith("\\"))
      {
        dir = dir + "\\";
      }
      var configPath = dir + fileName;
      if (!File.Exists(configPath))
      {
        return false;
      }
      s_configFileName = configPath;
      return true;
    }

    public static string AppSetting(string key, string defaultValue)
    {
      InitSettings();
      return s_settings.ContainsKey(key) ? s_settings[key] : defaultValue;
    }

    public static bool BoolAppSetting(string key, bool defaultValue)
    {
      var setting = AppSetting(key, null);
      return Utils.Str(setting).ToLower(System.Globalization.CultureInfo.InvariantCulture) == "true" || defaultValue;
    }
    public static int IntAppSetting(string key, int defaultValue)
    {
      var setting = AppSetting(key, null);
      int value;
      return int.TryParse(setting, out value) ? value : defaultValue;
    }

    public static string FileName
    {
      get
      {
        return s_configFileName;
      }
      set
      {
        s_localConfigFileName = value;
      }
    }
    public static string GeneralConfigName
    {
      get
      {
        return _GeneralConfigName;
      }
    }
    public static string MachineConfigName
    {
      get
      {
        return s_generalMachineConfigName;
      }
    }
  }

}

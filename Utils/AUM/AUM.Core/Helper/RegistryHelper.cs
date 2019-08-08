using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;

namespace AUM.Core.Helper
{
  using System.Globalization;
  using System.Linq;


  /// <summary>
    /// 
    /// </summary>
    public static class RegistryHelper
    {
        /// <summary>
        /// 
        /// </summary>
        private const string EidssRegistryKey = "EIDSS 6.0";

        public const string ArchiveServerKey = "ArchiveServer";

        public const string AvrServiceServerKey = "AvrServiceServer";

        /// <summary>
        /// 
        /// </summary>
        private static string ExecuteSubKey
        {
            get { return String.Format("{0}\\{1}\\AUM", SoftwareKey, EidssRegistryKey); }
        }
        private static string XPatchSubKey
        {
            get { return String.Format("{0}\\{1}\\XPatch", SoftwareKey, EidssRegistryKey); }
        }

        /// <summary>
        /// 
        /// </summary>
        private static string SubKey
        {
            get { return String.Format("{0}\\{1}", SoftwareKey, EidssRegistryKey); }
        }

        /// <summary>
        /// 
        /// </summary>
        private static string WindowsAutorunKey
        {
            get { return String.Format("{0}\\Microsoft\\Windows\\CurrentVersion\\Run", SoftwareKey); }
        }

        /// <summary>
        /// 
        /// </summary>
        private static string SoftwareKey
        {
            get { return Environment.Is64BitOperatingSystem ? "SOFTWARE\\Wow6432Node" : "SOFTWARE"; }
        }

        /// <summary>
        /// Читает запись из системного реестра (раздел про EIDSS)
        /// </summary>
        /// <param name="valueName"></param>
        /// <returns></returns>
        public static string ReadFromRegistry(string valueName)
        {
          //var current = WindowsIdentity.GetCurrent();
          //TODO: Rework bitness detection
          var mainkey = Registry.LocalMachine.OpenSubKey(SoftwareKey);
          if (mainkey == null)
          {
            return string.Empty;
          }
          
          var key = mainkey.OpenSubKey(EidssRegistryKey);
          if (key == null)
          {
            return string.Empty;
          }
          var o = key.GetValue(valueName);
          return o != null ? o.ToString() : string.Empty;
        }

        /// <summary>
        /// Проверяет, есть ли в реестре ключ с номером версии
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        public static bool DoesExecuteRegistryKeyExist(Version version)
        {
            var result = false;
            using (var key = Registry.LocalMachine.OpenSubKey(ExecuteSubKey))
            {
                if (key != null)
                {
                    result = key.GetValue(version.ToString()) != null;
                }
            }
            return result;
        }
        public static bool IsXpatchInstalled(Guid id)
        {
            var result = false;
            using (var key = Registry.LocalMachine.OpenSubKey(XPatchSubKey))
            {
                if (key != null)
                {
                  result = key.GetValue(id.ToString("B").ToUpper(CultureInfo.InvariantCulture)) != null;
                }
            }
            return result;
        }
        public static void ClearXpatchInstallation(string id)
        {
            using (var key = Registry.LocalMachine.OpenSubKey(XPatchSubKey))
            {
                if (key != null && key.GetValue(id) != null)
                {
                    key.DeleteValue(id);
                }
            }
        }

        /// <summary>
        /// Получает перечень установленных x-обновлений
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Version> GetInstalledExecuteUpdates()
        {
          var installedUpdates = new List<Version>();
          using (var key = Registry.LocalMachine.OpenSubKey(ExecuteSubKey))
          {
            if (key != null)
            {
              installedUpdates.AddRange(from installedUpdate in key.GetValueNames()
                where !installedUpdate.Contains(".")
                select VersionFactory.NewVersion(installedUpdate));
            }
          }
          return installedUpdates;
        }

        /// <summary>
        /// Пишет в реестр метку, что состоялся апдейт (запуск программ, режим 'x') с указанной версией
        /// </summary>
        /// <param name="version"></param>
        public static void WriteExistExecuteRegistryKey(Version version)
        {
          using (var key = GetAUMXPatchKey())
          {
            if (key != null)
            {
              key.SetValue(version.ToString(), string.Empty);
            }
          }
        }

        public static void MarkXpatchSucceded(Guid id, string xpatchName)
        {
          using (var key = GetXPatchKey())
          {
            if (key != null)
            {
              key.SetValue(id.ToString("B").ToUpper(CultureInfo.InvariantCulture), xpatchName);
            }
          }
        }

    private static RegistryKey GetXPatchKey()
    {
      return Registry.LocalMachine.OpenSubKey(XPatchSubKey, RegistryKeyPermissionCheck.ReadWriteSubTree) ??
        Registry.LocalMachine.CreateSubKey(XPatchSubKey, RegistryKeyPermissionCheck.ReadWriteSubTree);
    }

    private static RegistryKey GetAUMXPatchKey()
    {
      return Registry.LocalMachine.OpenSubKey(ExecuteSubKey, RegistryKeyPermissionCheck.ReadWriteSubTree) ??
        Registry.LocalMachine.CreateSubKey(ExecuteSubKey, RegistryKeyPermissionCheck.ReadWriteSubTree);
    }

    /// <summary>
        /// 
        /// </summary>
        /// <param name="valueName"></param>
        /// <returns></returns>
        public static void CreateRegistryKey(string valueName)
        {
            try
            {
                using (var key = Registry.LocalMachine.OpenSubKey(SubKey, RegistryKeyPermissionCheck.ReadWriteSubTree))
                {
                    if (key != null)
                    {
                        using (var key2 = key.OpenSubKey(valueName))
                        {
                            if (key2 == null)
                            {
                                key.CreateSubKey(valueName);
                            }
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                var errStr = String.Format("Can't create registry subkey: {0}; reg subkey={1}", exc.Message, valueName);
                AUMLog.WriteInLog(errStr);
                SecurityLog.WriteToEventLogWindows(EventLogEntryType.Error, errStr);
            }
        }

        /// <summary>
        /// Чтение из реестра из раздела автозапуска
        /// </summary>
        /// <param name="valueName"></param>
        /// <returns></returns>
        public static string ReadFromRegistryAutorun(string valueName)
        {
            var result = String.Empty;
            using (var key = Registry.LocalMachine.OpenSubKey(WindowsAutorunKey))
            {
                if (key != null)
                {
                    var o = key.GetValue(valueName);
                    if (o != null) result = o.ToString();
                }
            }
            return result;
        }

        /// <summary>
        /// Пишет в реестр в раздел автозапуска
        /// </summary>
        /// <param name="valueName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void WriteToRegistryAutorun(string valueName, string value)
        {
            using (var key = Registry.LocalMachine.OpenSubKey(WindowsAutorunKey, true))
            {
                if (key != null)
                {
                    key.SetValue(valueName, value);
                }
            }
        }

        public static void WriteToRegistry(string valueName, string value)
        {
            WriteToRegistry(SubKey, valueName, value);
        }

        public static void WriteToRegistry(string subkey, string valueName, string value)
        {
            using (var key = Registry.LocalMachine.OpenSubKey(subkey, true))
            {
                if (key != null)
                {
                    key.SetValue(valueName, value);
                }
            }
        }

      public static void DeleteFromRegistry(string subkey, string valueName)
      {
          using (var key = Registry.LocalMachine.OpenSubKey(subkey, true))
          {
              if (key != null && key.GetValue(valueName)!=null)
              {
                  key.DeleteValue(valueName);
              }
          }
          
      }
      public static void DeleteFromAutorun(string valueName)
      {
          using (var key = Registry.LocalMachine.OpenSubKey(WindowsAutorunKey, true))
          {
              if (key != null && key.GetValue(valueName)!=null)
              {
                  key.DeleteValue(valueName);
              }
          }
          
      }
        public static bool IsSqlServerInstalled()
        {
            RegistryView registryView = Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32;
            using (RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView))
            {
                RegistryKey instanceKey = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL", false);
                if (instanceKey != null)
                {
                    foreach (var instanceName in instanceKey.GetValueNames())
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}

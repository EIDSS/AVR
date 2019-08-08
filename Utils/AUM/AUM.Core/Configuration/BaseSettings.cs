using AUM.Diagnostics;

namespace AUM.Configuration
{
  using Core.Configuration;
  using Core.Diagnostics;


  public class BaseSettings
    {

        private const int DefaultSqlTimeout = 200;

        public static bool DebugOutput
        {
            get
            {
                return Config.BoolAppSetting("DebugOutput", false);
            }
        }
        public static string DebugLogFile
        {
            get
            {
                return Config.AppSetting("DebugLogFile", null);
            }
        }
        public static int DebugDetailLevel
        {
            get
            {
                int level;
                if (int.TryParse(Config.AppSetting("DebugDetailLevel", "0"), out level))
                {
                    return level;
                }
                return 0;
            }
        }
        public static string ObjectsSchemaPath
        {
            get
            {
                string path = Config.AppSetting("SchemaPath", "..\\..\\Schema") + "\\Objects\\";
                Dbg.Assert(System.IO.Directory.Exists(path), "objects schema path <{0}> doesn\'t exists", path);
                return path;
            }
        }
        public static string ConnectionString
        {
            get
            {
                return Config.AppSetting("SQLConnectionString", null);
            }
        }
        public static int SqlCommandTimeout
        {
            get
            {
                return Config.IntAppSetting("SqlCommandTimeout", 200);
            }
        }
        public static bool UseDefaultLogin
        {
            get
            {
                return Config.BoolAppSetting("UseDefaultLogin", false);
            }
        }
        public static string DefaultOrganization
        {
            get
            {
                return Config.AppSetting("DefaultOrganization", null);
            }
        }
        public static string DefaultUser
        {
            get
            {
                return Config.AppSetting("DefaultUser", null);
            }
        }
        public static string DefaultPassword
        {
            get
            {
                return Config.AppSetting("DefaultPassword", null);
            }
        }
        public static string SqlServer
        {
            get
            {
                return Config.AppSetting("SQLServer", null);
            }
        }
        public static string SQLDatabase
        {
            get
            {
                return Config.AppSetting("SQLDatabase", null);
            }
        }
        public static string SQLUser
        {
            get
            {
                return Config.AppSetting("SQLUser", null);
            }
        }
        public static string SQLPassword
        {
            get
            {
                return Config.AppSetting("SQLPassword", null);
            }
        }

        public static string InplaceShowDropDown
        {
            get
            {
                return Config.AppSetting("InplaceShowDropDown", null);
            }
        }

        public static string ShowDropDown
        {
            get
            {
                return Config.AppSetting("ShowDropDown", null);
            }
        }
        public static int LookupCacheRefreshInterval
        {
            get
            {
                return Config.IntAppSetting("LookupCacheRefreshInterval", 500);
            }
        }

        public static int LookupCacheIdleRefreshInterval
        {
            get
            {
                return Config.IntAppSetting("LookupCacheIdleRefreshInterval", 500);
            }
        }
        public static bool ForceMemoryFlush
        {
            get
            {
                return Config.BoolAppSetting("ForceMemoryFlush", true);
            }
        }

        public static bool ForceFormsDisposing
        {
            get
            {
                return Config.BoolAppSetting("ForceFormsDisposing", true);
            }
        }
        public static int PagerPageSize
        {
            get
            {
                return Config.IntAppSetting("PagerPageSize", 50);
            }
        }
        public static int PagerPageCount
        {
            get
            {
                return Config.IntAppSetting("PagerPageCount", 10);
            }
        }


        public static string DefaultLanguage
        {
            get
            {
                return Config.AppSetting("DefaultLanguage", "en");
            }
        }

        public static string BarcodePrinter
        {
            get
            {
                return Config.AppSetting("BarcodePrinter", null);
            }
        }
        public static string DocumentPrinter
        {
            get
            {
                return Config.AppSetting("DocumentPrinter", null);
            }
        }
        public static int LookupCacheTimeout
        {
            get
            {
                return Config.IntAppSetting("LookupTimeout", 300);
            }
        }
        public static bool IgnoreAbsentResources
        {
            get
            {
                return Config.BoolAppSetting("IgnoreAbsentResources", false);
            }
        }

        public static bool ShowClearLookupButton
        {
            get { return Config.BoolAppSetting("ShowClearLookupButton", true); }
        }

        public static bool ShowClearRepositoryLookupButton
        {
            get { return Config.BoolAppSetting("ShowClearRepositoryLookupButton", false); }
        }

        public static string DetailFormType
        {
            get { return Config.AppSetting("DetailFormType", "Normal"); }
        }

        public static bool ShowDeleteButtonOnDetailForm
        {
            get { return Config.BoolAppSetting("ShowDeleteButtonOnDetailForm", false); }
        }

        public static bool ShowSaveButtonOnDetailForm
        {
            get { return Config.BoolAppSetting("ShowSaveButtonOnDetailForm", false); }
        }

        public static bool ShowNewButtonOnDetailForm
        {
            get { return Config.BoolAppSetting("ShowNewButtonOnDetailForm", false); }
        }

        public static bool DirectDataAccess
        {
            get { return Config.BoolAppSetting("DirectDataAccess", true); }
        }

        public static string OneInstanceMethod
        {
            get { return Config.AppSetting("OneInstanceMethod", ""); }
        }

        public static bool ShowCaptionOnToolbar
        {
            get { return Config.BoolAppSetting("ShowCaptionOnToolbar", false); }
        }

        public static bool ShowEmptyListOnSearch
        {
            get { return Config.BoolAppSetting("ShowEmptyListOnSearch", true); }
        }
    }
}

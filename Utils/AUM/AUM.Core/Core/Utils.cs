using System.Collections;
using System;
using System.IO;
using System.Text;
using System.Reflection;

namespace AUM.Core
{
    public class Utils
    {

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Returns safe string representation of object.
        /// </summary>
        /// <param name="o">
        /// object that should be converted to string
        /// </param>
        /// <returns>
        /// Returns string representation of passed object. If passed object is <b>Nothing</b> or <b>DBNull.Value</b> the method returns empty string.
        /// </returns>
        /// <history>
        /// 	[Mike]	03.04.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static string Str(object o)
        {
            return Str(o, "");
        }
        public static string Str(object o, string defaultString)
        {
            if (o == null || o == DBNull.Value)
            {
                return defaultString;
            }
            return o.ToString();
        }
        public static double Dbl(object o)
        {
            if (o == null || o == DBNull.Value)
            {
                return 0.0;
            }
            try
            {
                return System.Convert.ToDouble(o);
            }
            catch (Exception)
            {
                return 0.0;
            }
        }
		
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Checks if the passed object represents the valid typed object.
        /// </summary>
        /// <param name="o">
        /// object to check
        /// </param>
        /// <returns>
        /// False if passed object is <b>Nothing</b> or <b>DBNull.Value</b> or its string representation is empty string and True in other case.
        /// </returns>
        /// <history>
        /// 	[Mike]	03.04.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static bool IsEmpty(object o)
        {
            if (o == null || o == DBNull.Value)
            {
                return true;
            }
            if (o.ToString().Trim() == "")
            {
                return true;
            }
            return false;
        }
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Appends the default string with other separating them with some separator
        /// </summary>
        /// <param name="s">
        /// default string to append
        /// </param>
        /// <param name="val">
        /// string that should be appended
        /// </param>
        /// <param name="Separator">
        /// string that should separate default and appended strings
        /// </param>
        /// <remarks>
        /// method inserts the separator between strings only if default string is not empty.
        /// </remarks>
        /// <history>
        /// 	[Mike]	03.04.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static void AppendLine(ref string s, object val, string Separator)
        {
            if (val == DBNull.Value || val.ToString().Trim().Length == 0)
            {
                return;
            }
            if (s.Length == 0)
            {
                s += val.ToString();
            }
            else
            {
                s += Separator + val.ToString();
            }
        }
        public static string Join(string separator, IEnumerable collection)
        {
            StringBuilder result = new StringBuilder();
            object item;
            foreach (object tempLoopVar_item in collection)
            {
                item = tempLoopVar_item;
                if (result.Length > 0)
                {
                    result.Append(separator);
                }
				
                result.Append(item.ToString());
            }
			
            return result.ToString();
        }
		
		
		
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Checks if directory exists and creates it if it is absent
        /// </summary>
        /// <param name="dir">
        /// directory to check
        /// </param>
        /// <returns>
        /// Returns <b>True</b> if requested directory exists or was created successfully and <b>False</b> if requested directory can't be created
        /// </returns>
        /// <history>
        /// 	[Mike]	03.04.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static bool ForceDirectories(string dir)
        {
            int pos = 0;
			
            string dirName;
            try
            {
                do
                {
                    pos = dir.IndexOf(Path.DirectorySeparatorChar, pos);
                    if (pos < 0)
                    {
                        break;
                    }
                    dirName = dir.Substring(0, pos);
                    if (! Directory.Exists(dirName))
                    {
                        Directory.CreateDirectory(dirName);
                    }
                    pos++;
                } while (true);
                if (! Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                return Directory.Exists(dir);
            }
            catch
            {
                return false;
            }
        }
        public static System.Drawing.Bitmap LoadBitmapFromResource(string resName, Type aType)
        {
            System.IO.Stream oStream;
            System.Reflection.Assembly oAssembly;
            System.Drawing.Bitmap oBitmap;
			
            //open the executing assembly
            oAssembly = @System.Reflection.Assembly.GetAssembly(aType);
			
            //create stream for image (icon) in assembly
            oStream = oAssembly.GetManifestResourceStream(resName);
			
            //create new bitmap from stream
            oBitmap = (System.Drawing.Bitmap) (System.Drawing.Bitmap.FromStream(oStream));
            return oBitmap;
        }
        public static bool IsGuid(object g)
        {
            string s = Str(g);
            if (s.Length != 36)
            {
                return false;
            }
            try
            {
                Guid g1 = new Guid(s);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
		
        //public static bool IsEIDSS
        //{
        //    get
        //    {
        //        return (ApplicationSettings.AppName.ToLowerInvariant() == "eidss");
        //    }
        //}
		
        //public static bool IsPACS
        //{
        //    get
        //    {
        //        return (ApplicationSettings.AppName.ToLowerInvariant() == "pacs_main");
        //    }
        //}
		
        public static t CheckNotNull<t>(t param, string paramName)
        {
            if (ReferenceEquals(param, null))
            {
                throw (new ArgumentNullException(paramName));
            }
			
            return param;
        }
		
        public static string CheckNotNullOrEmpty(string param, string paramName)
        {
            if (CheckNotNull(param, paramName) == string.Empty)
            {
                throw (new ArgumentException(paramName + " cannot be empty string"));
            }
			
            return param;
        }
		
        public static string GetParentDirectoryPath(string DirName)
        {
            string appLocation = GetExecutingPath();
            DirName = DirName.ToLower(System.Globalization.CultureInfo.InvariantCulture);
            DirectoryInfo dir = new DirectoryInfo(Path.GetDirectoryName(appLocation));
            while (dir != null&& dir.Name.ToLower(System.Globalization.CultureInfo.InvariantCulture) != DirName)
            {
                foreach (DirectoryInfo subDir in dir.GetDirectories())
                {
                    if (subDir.Name.ToLower(System.Globalization.CultureInfo.InvariantCulture) == DirName)
                    {
                        return subDir.FullName + "\\";
                    }
                }
                dir = dir.Parent;
            }
            if (dir != null)
            {
                return string.Format("{0}\\", dir.FullName);
            }
            return null;
        }
		
        public static string GetExecutingPath()
        {
            DirectoryInfo appDir;
            //if (HttpContext.Current != null)
            //{
            //    appDir = new DirectoryInfo(HttpContext.Current.Request.PhysicalApplicationPath);
            //    if (appDir != null)
            //    {
            //        return string.Format("{0}\\", appDir.FullName);
            //    }
            //}
            Assembly asm = Assembly.GetExecutingAssembly();
            if (! asm.GetName().Name.StartsWith("nunit"))
            {
                appDir = new DirectoryInfo(Path.GetDirectoryName(GetAssemblyCodeBaseLocation(asm)));
                return string.Format("{0}\\", appDir.FullName);
            }
            asm = Assembly.GetCallingAssembly();
            appDir = new DirectoryInfo(Path.GetDirectoryName(GetAssemblyCodeBaseLocation(asm)));
            return string.Format("{0}\\", appDir.FullName);
        }
		
        private static string GetAssemblyCodeBaseLocation(Assembly asm)
        {
            if (asm.CodeBase.StartsWith("file:///"))
            {
                return asm.CodeBase.Substring(8).Replace("/", "\\");
            }
            return asm.Location;
        }

        public static string GetConfigFileName()
        {
            //if (HttpContext.Current != null)
            //{
            //    return "Web.config";
            //}
            Assembly asm = Assembly.GetEntryAssembly();
            if (asm != null)
            {
                return Path.GetFileName(asm.Location) + ".config";
            }
            return "";
        }
		
		
    }
}
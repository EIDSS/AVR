using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using bv.tests.Core;

namespace bv.WinTests.utils
{
    public class PathUtils
    {
        private static string GetAssemblyCodeBaseLocation(Assembly asm)
        {
            if (asm.CodeBase.StartsWith("file:///"))
            {
                return asm.CodeBase.Substring(8).Replace("/", "\\");
            }
            return asm.Location;
        }

        private static DirectoryInfo GetProjectFolder()
        {
            Assembly asm = Assembly.GetAssembly(typeof(PathUtils));
            if (asm != null)
            {
                var path = Path.GetDirectoryName(GetAssemblyCodeBaseLocation(asm));
                if(path != null && Directory.Exists(path))
                    return new DirectoryInfo(path);
            }
            return new DirectoryInfo("..\\");
            
        }
        public static string GetMainBinFolderPath()
        {
            var dir = GetProjectFolder();
            var result = string.Format("{0}\\", dir.FullName);
            if (Directory.Exists(result))
                return result;
            return "..\\";
        }
    }
}

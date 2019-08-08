namespace AUM.Core.Helper
{
    using System;
    using System.Linq;


    public static class VersionFactory
    {
        public static readonly Version EmptyVersion = new Version("0.0.0.0");

        public static Version NewVersion(string version)
        {
            if (string.IsNullOrEmpty(version))
                return EmptyVersion;
            var list = version.Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries).ToList();
            while (4 > list.Count)
            {
                list.Add("0");
            }
            return new Version(string.Join(".", list));
        }

        public static Version GetCorrectVersion(string version)
        {
            Version v;
            if (!Version.TryParse(version, out v))
            {
                v = EmptyVersion;
            }
            return v;
        }
    }
}

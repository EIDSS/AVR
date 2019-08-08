namespace AUM.Core.Helper
{
  using System;
  using System.DirectoryServices;
  using System.Net.NetworkInformation;


  public static class EnvironmentHelper
  {
    public static bool IsCurrentUserDomainUser()
    {
      return !DomainNameEqualsMachineName() && DomainNameEqualsNetbiosName();
    }

    public static bool IsMachineInDomain()
    {
      return !string.IsNullOrEmpty(GetDnsDomainName());
    }

    public static string GetNetbiosDomainName()
    {
      var netbiosDomainName = string.Empty;
      var dnsDomainName = GetDnsDomainName();

      var rootDse = new DirectoryEntry(string.Format("LDAP://{0}/RootDSE", dnsDomainName));

      var configurationNamingContext = rootDse.Properties["configurationNamingContext"][0].ToString();

      var searchRoot = new DirectoryEntry("LDAP://cn=Partitions," + configurationNamingContext);

      var searcher = new DirectorySearcher(searchRoot) { SearchScope = SearchScope.OneLevel };
      searcher.PropertiesToLoad.Add("netbiosname");
      searcher.Filter = string.Format("(&(objectcategory=Crossref)(dnsRoot={0})(netBIOSName=*))", dnsDomainName);

      var result = searcher.FindOne();

      if (result != null)
      {
        netbiosDomainName = result.Properties["netbiosname"][0].ToString();
      }

      return netbiosDomainName;
    }


    private static bool DomainNameEqualsNetbiosName()
    {
      return Environment.UserDomainName.Equals(GetNetbiosDomainName(), StringComparison.OrdinalIgnoreCase);
    }

    private static bool DomainNameEqualsMachineName()
    {
      return Environment.UserDomainName.Equals(Environment.MachineName, StringComparison.OrdinalIgnoreCase);
    }

    private static string GetDnsDomainName()
    {
      return IPGlobalProperties.GetIPGlobalProperties().DomainName;
    }
  }
}
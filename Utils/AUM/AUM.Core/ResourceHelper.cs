namespace AUM.Core
{
  using System.Reflection;
  using System.Resources;
  using System.Threading;


  public static class ResourceHelper
  {
    public static string Get(string key)
    {
      return (new ResourceManager(
        "AUM.Core.ResourceHelper",
        Assembly.GetExecutingAssembly())).GetString(key, Thread.CurrentThread.CurrentUICulture) ?? string.Empty;
    }
  }
}

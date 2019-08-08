namespace AUM.Core.Helper
{
  using System;


  public sealed class UrlWrapper
  {
    public string Primary { get; private set; }
    public string Secondary { get; private set; }

    internal UrlWrapper(string primaryUrl, string secondaryUrl)
    {
      Primary = AppendSlash(string.IsNullOrEmpty(primaryUrl) ? string.Empty : primaryUrl);
      Secondary = AppendSlash(string.IsNullOrEmpty(secondaryUrl) ? string.Empty : secondaryUrl);
    }

    private static string AppendSlash(string url)
    {
      return (url.Length > 0) && !url.EndsWith("/", StringComparison.OrdinalIgnoreCase) ? (url += "/") : url;
    }
  }
}
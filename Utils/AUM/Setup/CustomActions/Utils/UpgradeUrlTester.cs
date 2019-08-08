namespace CustomActions.Utils
{
  using System;
  using System.Globalization;
  using System.Net;
  using PropertyContainers;


  internal sealed class UpgradeUrlTester
  {
    private readonly ILogger m_logger;
    private IPropertyContainer PropertyContainer { get; set; }


    internal UpgradeUrlTester(IPropertyContainer propertyContainer, ILogger logger)
    {
      if (null == propertyContainer)
      {
        throw new ArgumentNullException("propertyContainer");
      }

      if (null == logger)
      {
        throw new ArgumentNullException("logger");
      }

      PropertyContainer = propertyContainer;
      m_logger = logger;
    }

    internal void TestUpgradeUrls(string mainUrl, string reserveUrl, bool secured)
    {
      ResetUrlValidators();

      if (secured)
      {
        SecuredTestUpgradeUrls(mainUrl, reserveUrl);
      }
      else
      {
        SimpleTestUpgradeUrls(mainUrl);
      }
    }

    private void SimpleTestUpgradeUrls(string mainUrl)
    {
      if (AreUrlsEmpty(mainUrl, "stub"))
      {
        return;
      }

      PropertyContainer[InstallerProperties.MainUpgradeUrlValid] = TestUrl(MakeHttp(mainUrl, true)) ? "1" : "0";
    }

    private void SecuredTestUpgradeUrls(string mainUrl, string reserveUrl)
    {
      if (AreUrlsEmpty(mainUrl, reserveUrl) || StartsWithHttp(mainUrl) || StartsWithHttps(reserveUrl))
      {
        return;
      }

      PropertyContainer[InstallerProperties.MainUpgradeUrlValid] = TestUrl(MakeHttps(mainUrl)) ? "1" : "0";
      PropertyContainer[InstallerProperties.SecondaryUpgradeUrlValid] = TestUrl(MakeHttp(reserveUrl, false)) ? "1" : "0";
    }

    private void ResetUrlValidators()
    {
      PropertyContainer[InstallerProperties.MainUpgradeUrlValid] = string.Empty;
      PropertyContainer[InstallerProperties.SecondaryUpgradeUrlValid] = string.Empty;
      PropertyContainer[InstallerProperties.ErrorConfigurationText] = string.Empty;
    }

    private bool StartsWithHttps(string reserveUrl)
    {
      if (!reserveUrl.StartsWith("https", StringComparison.OrdinalIgnoreCase))
      {
        return false;
      }

      PropertyContainer[InstallerProperties.ErrorConfigurationText] = PropertyContainer[InstallerProperties.WrongProtocol];
      PropertyContainer[InstallerProperties.SecondaryUpgradeUrlValid] = "0";
      return true;
    }

    private bool StartsWithHttp(string mainUrl)
    {
      if (!mainUrl.StartsWith("http:", StringComparison.OrdinalIgnoreCase))
      {
        return false;
      }

      PropertyContainer[InstallerProperties.ErrorConfigurationText] = PropertyContainer[InstallerProperties.WrongProtocol];
      PropertyContainer[InstallerProperties.MainUpgradeUrlValid] = "0";
      return true;
    }

    private bool AreUrlsEmpty(string mainUrl, string reserveUrl)
    {
      if (!string.IsNullOrEmpty(mainUrl) && !string.IsNullOrEmpty(reserveUrl))
      {
        return false;
      }

      PropertyContainer[InstallerProperties.ErrorConfigurationText] = PropertyContainer[InstallerProperties.EmptyMandatoryFileds];
      PropertyContainer[InstallerProperties.MainUpgradeUrlValid] = "0";
      PropertyContainer[InstallerProperties.SecondaryUpgradeUrlValid] = "0";
      return true;
    }

    private static string MakeHttps(string url)
    {
      const string Https = "https://";
      return string.IsNullOrEmpty(url) || url.StartsWith(Https, StringComparison.OrdinalIgnoreCase) ? url : Https + url;
    }

    private static string MakeHttp(string url, bool allowHttps)
    {
      const string Http = "http://";
      const string Https = "https://";
      return
        string.IsNullOrEmpty(url)
        || url.StartsWith(Http, StringComparison.OrdinalIgnoreCase)
        || (allowHttps && url.StartsWith(Https, StringComparison.OrdinalIgnoreCase))
        ? url
        : Http + url;
    }

    private bool TestUrl(string url)
    {
      try
      {
        var request = WebRequest.Create((new Uri(url)).AbsoluteUri);
        var response = (HttpWebResponse) request.GetResponse();
        if (response.StatusCode == HttpStatusCode.OK)
        {
          LogMessage(string.Format(CultureInfo.InvariantCulture, "Url \"{0}\" was pinged successfully.", url));
          return true;
        }
      }
      catch (UriFormatException ex)
      {
        LogMessage(ex.Message);
        PropertyContainer[InstallerProperties.ErrorConfigurationText] = PlusMessage(PropertyContainer[InstallerProperties.BadUrlFormat]);
      }
      catch (WebException ex)
      {
        LogMessage(ex.Message);
        PropertyContainer[InstallerProperties.ErrorConfigurationText] = PlusMessage(string.Format(
          CultureInfo.InvariantCulture,
          "{0}{1}{2}", PropertyContainer[InstallerProperties.WebRequestError],
          Environment.NewLine,
          ex.Message));
      }

      return false;
    }

    private void LogMessage(string message)
    {
      m_logger.Log(string.Format(
        CultureInfo.InvariantCulture,
        "{0}:\t{1}",
        System.Reflection.MethodBase.GetCurrentMethod().Name,
        message));
    }

    private string PlusMessage(string message)
    {
      return string.IsNullOrEmpty(PropertyContainer[InstallerProperties.ErrorConfigurationText])
        ? message
        : string.Format(
          CultureInfo.InvariantCulture,
          "{0}{1}{2}{3}", PropertyContainer[InstallerProperties.ErrorConfigurationText],
          Environment.NewLine,
          Environment.NewLine,
          message);
    }
  }
}
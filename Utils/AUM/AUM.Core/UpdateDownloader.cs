namespace AUM.Core
{
  using System;
  using System.IO;
  using System.Net;
  using System.Net.Security;
  using System.Security.Cryptography.X509Certificates;
  using System.Threading;
  using Helper;


  internal class UpdateDownloader
  {
    private readonly ushort m_downloadBufferSize;
    private readonly UrlWrapper m_urls;
    private readonly ushort m_downloadAttempts;
    private readonly TimeSpan m_downloadAttemptWaitTime;

    internal UpdateDownloader(UrlWrapper urls, ushort downloadAttempts, TimeSpan downloadAttemptWaitTime, ushort downloadBufferSize)
    {
      if (null == urls)
      {
        throw new ArgumentNullException("urls");
      }
      if (null == downloadAttemptWaitTime)
      {
        throw new ArgumentNullException("downloadAttemptWaitTime");
      }
      m_urls = urls;
      m_downloadAttempts = downloadAttempts;
      m_downloadAttemptWaitTime = downloadAttemptWaitTime;
      m_downloadBufferSize = downloadBufferSize;
    }

    internal bool DownloadFileAndCompareContent(string filename, string localPath)
    {
      return DownloadFileTemplate(filename, localPath, TryToDownloadFileAndCompareContent);
    }

    internal bool DownloadFile(string filename, string localPath)
    {
      return DownloadFileTemplate(filename, localPath, TryToDownloadFile);
    }

    private bool DownloadFileTemplate(string filename, string localPath, Func<string, string, string, bool> tryToDownloadDelegate)
    {
      AUMLog.WriteInLog("Trying to download file '{0}'{1}Attempt: {2} from {3}", filename, Environment.NewLine, 1, m_downloadAttempts);
      if (TryToDownloadFileTemplate(filename, localPath, tryToDownloadDelegate))
      {
        return true;
      }
      for (var i = 1; i < m_downloadAttempts; ++i)
      {
        AUMLog.WriteInLog("Pause between attempts: {0}", m_downloadAttemptWaitTime);
        Thread.Sleep(m_downloadAttemptWaitTime);
        AUMLog.WriteInLog("Attempt: {0} from {1}", i + 1, m_downloadAttempts);
        if (TryToDownloadFileTemplate(filename, localPath, tryToDownloadDelegate))
        {
          return true;
        }
      }

      return false;
    }

    private bool TryToDownloadFileTemplate(string filename, string localPath, Func<string, string, string, bool> tryToDownloadDelegate)
    {
      return tryToDownloadDelegate(m_urls.Primary, filename, localPath) ||
             !string.IsNullOrEmpty(m_urls.Secondary) && tryToDownloadDelegate(m_urls.Secondary, filename, localPath);
    }

    private static HttpWebResponse GetResponse(string url, int startPos)
    {
      HttpWebResponse response = null;
      try
      {
        var request = (HttpWebRequest) WebRequest.Create(url);
        if (startPos > 0)
        {
          request.AddRange(Convert.ToInt32(startPos));
        }
        response = (HttpWebResponse) request.GetResponse();
      }
      catch (Exception exc)
      {
        AUMLog.WriteInLog("Download file check. Code={0}. Error={1}",
          response != null ? response.StatusCode.ToString() : string.Empty,
          exc.Message);
        //удаляем файл-цель, чтобы начать закачку заново

        response = GetResponse(url, 0);
        /*
                if ((response != null) && response.StatusCode == HttpStatusCode.RequestedRangeNotSatisfiable)
                {
                    response = GetResponse(url, 0);
                }*/
      }
      return response;
    }

    private static bool RemoteCertificateValidate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors error)
    {
      var wasError = error != SslPolicyErrors.None;
      if (wasError)
      {
        AUMLog.WriteInLog("SSL certificate check fail: {0}. Cert = {1}. Chain = {2}", error, cert, chain);
      }
      return !wasError;
    }


    private static bool TryToDownloadFileAndCompareContent(string url, string filename, string localPath)
    {
      var fullurl = new Uri(new Uri(url), filename);
      try
      {
        using (var wc = new WebClient())
        {
          AUMLog.WriteInLog("Trying to download file \"{0}\"", fullurl);
            string tmpFileName = Path.GetTempFileName();
            string existingFileName = Path.Combine(localPath, filename);
            wc.DownloadFile(fullurl, tmpFileName);// Path.Combine(localPath, filename));
            //Do not replace existing file with downloaded one if they have the same content
            if (File.Exists(existingFileName) && new FileInfo(tmpFileName).Length == new FileInfo(existingFileName).Length)
            {
                string existingContent = File.ReadAllText(existingFileName);
                string downloadedContent = File.ReadAllText(tmpFileName);
                if (existingContent.Equals(downloadedContent))
                {
                    FileHelper.DeleteFile(tmpFileName);
                    return true;
                }
                                
            }
            FileHelper.CopyFile(tmpFileName, existingFileName);
            FileHelper.DeleteFile(tmpFileName);
          return true;
        }
      }
      catch (WebException exc)
      {
        AUMLog.WriteInLog("Can't download file \"{0}\". Error: {1}", fullurl, exc.Message);
      }
      return false;
    }

    private bool TryToDownloadFile(string url, string filename, string localPath)
    {
      Stream stream = null;
      FileStream fs = null;
      var localFileName = Path.Combine(localPath, filename);
      var result = false;
      try
      {
        ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;

        AUMLog.WriteInLog("Trying to download file \"{0}\" from \"{1}\"", filename, url);
        var uri = new Uri(url);
        var request = (HttpWebRequest) WebRequest.Create(uri);
        request.Method = WebRequestMethods.Http.Get;
        var resp = (HttpWebResponse) request.GetResponse();
        resp.Close();
       
        var fullurl = url + filename;
        //check the file size in the web site
        var wc = new WebClient();
        long bytesTotalWeb;
        using (var streamwc = wc.OpenRead(fullurl))
        {
          bytesTotalWeb = Convert.ToInt64(wc.ResponseHeaders["Content-Length"]);
          if (streamwc != null)
          {
            streamwc.Close();
          }
        }

        AUMLog.WriteInLog("Download file was found. Size = {0} bytes", bytesTotalWeb);
        //check local file size
        long bytesTotalLocal = 0;
        if (File.Exists(localFileName))
        {
          var fi = new FileInfo(localFileName);
          bytesTotalLocal = fi.Length;
        }
        if (bytesTotalLocal > bytesTotalWeb)
        {
          FileHelper.DeleteFile(localFileName);
        }

        //open the download files or new created file
        long lStartPos;
        fs = File.OpenWrite(localFileName);
        if (File.Exists(localFileName))
        {
          lStartPos = fs.Length;
          //current point within the stream
          fs.Seek(lStartPos, SeekOrigin.Current);
        }
        else
        {
          fs = new FileStream(localFileName, FileMode.Create);
          lStartPos = 0;
        }

        var response = GetResponse(fullurl, Convert.ToInt32(lStartPos));
        if (response != null)
        {
          stream = response.GetResponseStream();
          if (stream != null)
          {
            var nbytes = new byte[m_downloadBufferSize];
            var nReadSize = stream.Read(nbytes, 0, m_downloadBufferSize - 1);
            while (nReadSize > 0)
            {
              fs.Write(nbytes, 0, nReadSize);
              nReadSize = stream.Read(nbytes, 0, m_downloadBufferSize - 1);
            }
            stream.Close();
            result = true;
          }
          fs.Close();
        }
      }
      catch (Exception exc)
      {
        AUMLog.WriteInLog("Download file \"{0}\" from \"{1}\" error: {2}", filename, url, exc.Message);
        if (stream != null)
        {
          stream.Close();
        }
        if (fs != null)
        {
          fs.Close();
        }
      }
      return result;
    }
  }
}

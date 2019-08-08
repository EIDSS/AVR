namespace AUM.Core.Helper
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using Enums;


  public class SiteInfo
  {
    public SiteInfo(long idfsSite, long idfsParentSite, string computerName, UpdateStatus status)
    {
      IdfsSite = idfsSite;
      IdfsParentSite = idfsParentSite;
      ComputerName = computerName ?? string.Empty;
      Status = status;

      Updates = new List<UpdateInfo>();
    }

    public long IdfsSite { get; private set; }
    public long IdfsParentSite { get; private set; }
    public string ComputerName { get; private set; }
    public UpdateStatus Status { get; private set; }
    public List<UpdateInfo> Updates { get; private set; }

    public bool IsParent()
    {
      return 0 == IdfsParentSite;
    }
  }

  public class SiteInfoCompareByName : IComparer<SiteInfo>
  {
    public int Compare(SiteInfo x, SiteInfo y)
    {
      return string.Compare(x.ComputerName, y.ComputerName, StringComparison.Ordinal);
    }
  }

  public class SiteInfoCompareByStatus : IComparer<SiteInfo>
  {
    public int Compare(SiteInfo x, SiteInfo y)
    {
      if ((x.Updates == null) || (y.Updates == null) || (!x.Updates.Any()) || (!y.Updates.Any()))
      {
        return 0;
      }

      var isXSuccess = x.Updates.All(c => c.Success);
      var isYSuccess = y.Updates.All(c => c.Success);
      if (!isXSuccess && isYSuccess)
      {
        return -1;
      }
      if (isXSuccess && !isYSuccess)
      {
        return 1;
      }
      return !isXSuccess ? (new SiteInfoCompareByName()).Compare(x, y) : 0;
    }
  }
}
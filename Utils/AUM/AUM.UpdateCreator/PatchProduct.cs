namespace AUM.UpdateCreator
{
  using System;
  using System.Collections.Generic;
  using Core.Helper;


  internal class PatchProduct
  {
    internal PatchProduct(IEnumerable<string> version, IEnumerable<string> cortege)
      : this(null != version)
    {
      if (null == version)
      {
        return;
      }
      SetVersion(version);
      SetCortege(cortege);
    }

    protected PatchProduct(bool isIncluded)
    {
      IsIncluded = isIncluded;
      Version = VersionFactory.EmptyVersion;
      CortegeVersion = string.Empty;
    }


    internal bool IsIncluded { get; private set; }
    internal Version Version { get; set; }

    internal string CortegeVersion { get; private set; }

    private void SetVersion(IEnumerable<string> versionParts)
    {
      Version = FileHelper.ConvertToVersion(versionParts);
      if (VersionFactory.EmptyVersion == Version)
      {
        throw new ArgumentException("Bad version!");
      }
    }

    private void SetCortege(IEnumerable<string> cortege)
    {
      CortegeVersion = string.Empty;
      if (null != cortege)
      {
        throw new NotImplementedException();
      }
    }
  }
}
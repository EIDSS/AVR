namespace AUM.UpdateCreator
{
  using System;
  using System.Collections.Generic;
  using System.Text.RegularExpressions;
  using Core;


  public class SqlFileComparer : IComparer<RunScriptData>
  {
    #region IComparer<RunScriptData> Members

    public int Compare(RunScriptData x, RunScriptData y)
    {
      return ScriptComparer.Compare(x.FileName, y.FileName);
    }

    #endregion
  }

  public static class ScriptComparer
  {
    /*
    //        M.mm.bb.rr.nnn_gs_..._YYYYMMDD_CountryHASC, where
    //        M - major version number (i.e., 6)
    //        mm - minor version with leading zeros (i.e., 00)
    //        bb - build version leading zeros (i.e., 01)
    //        rr - revision number with leading zeros (i.e., 01)
    //        nnn - script number with leading zeros
    */

    private const string VersionPattern = @"(\d*\.){4}\d*";
    private const string DatePattern = @"\d{8}";

    public static int Compare(string x, string y)
    {
      var result = CompareVersions(x, y);
      if (0 != result)
      {
        return result;
      }

      result = ExtractAndCompareDates(x, y);

      return 0 != result ? result : CompareNames(x, y);
    }

    private static int CompareVersions(string x, string y)
    {
      var xVersion = Regex.Match(x, VersionPattern).Value.Split('.');
      var yVersion = Regex.Match(y, VersionPattern).Value.Split('.');

      if (xVersion.Length == 5 && yVersion.Length == 5)
      {
        for (var i = 0; i < xVersion.Length; ++i)
        {
          if (xVersion[i] != yVersion[i])
          {
            return Convert.ToInt32(xVersion[i]) - Convert.ToInt32(yVersion[i]);
          }
        }
      }
      return 0;
    }

    private static int ExtractAndCompareDates(string x, string y)
    {
      var xDate = Regex.Match(x, DatePattern).Value;
      var yDate = Regex.Match(y, DatePattern).Value;

      return string.IsNullOrEmpty(xDate) || string.IsNullOrEmpty(yDate) ? 0 : CompareDates(xDate, yDate);
    }

    private static int CompareDates(string xDate, string yDate)
    {
      var xSplittedDate = new[] { xDate.Substring(0, 4), xDate.Substring(4, 2), xDate.Substring(6, 2) };
      var ySplittedDate = new[] { yDate.Substring(0, 4), yDate.Substring(4, 2), yDate.Substring(6, 2) };

      for (var i = 0; i < xSplittedDate.Length; ++i)
      {
        if (xSplittedDate[i] != ySplittedDate[i])
        {
          return Convert.ToInt32(xSplittedDate[i]) - Convert.ToInt32(ySplittedDate[i]);
        }
      }
      return 0;
    }

    private static int CompareNames(string x, string y)
    {
      var xName = new Regex(VersionPattern + "(.*?)" + DatePattern).Match(x).Groups[1].Value;
      var yName = new Regex(VersionPattern + "(.*?)" + DatePattern).Match(y).Groups[1].Value;

      return string.Compare(xName, yName, StringComparison.OrdinalIgnoreCase);
    }
  }
}
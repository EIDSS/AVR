namespace AUM.UpdateCreator
{
  using System;
  using System.Collections.Generic;
  using Core.Helper;


  internal sealed class PatchOptions
  {
    private readonly bool m_isQuiet;

    internal PatchOptions(CommandLineOptions options)
    {
      m_isQuiet = options.IsQuiet;
      CheckRequiredOptions(options);

      UpdateSource = options.UpdateSource;
      OutputPath = options.OutputPath;

      IsTotal = options.IsTotal;

      Aum = new PatchProduct(options.AumVersion, options.AumCortege);
      CustomTasks = new ExtendedPatchProduct(options.CustomTasks, new ExecuteOrderBuilder(options.DbFiles));
      Db = new ExtendedPatchProduct(options.DbVersion, options.DbCortege, new ScriptOrderBuilder(options.DbFiles));
      DbArchive = new ExtendedPatchProduct(options.DbaVersion, options.DbaCortege, new ScriptOrderBuilder(options.DbaFiles));
      AvrDb = new ExtendedPatchProduct(options.DbAvrVersion, options.DbAvrCortege, new ScriptOrderBuilder(options.DbAvrFiles));
      AvrService = new PatchProduct(options.AvrsVersion, options.AvrsCortege);
      Desktop = new PatchProduct(options.EVersion, options.ECortege);
      NotificationService = new PatchProduct(options.NsVersion, options.NsCortege);

      SetTotalVersion(options.TotalVersion);
    }

    internal bool IsTotal { get; private set; }

    internal PatchProduct Aum { get; private set; }
    internal ExtendedPatchProduct CustomTasks { get; private set; }
    internal ExtendedPatchProduct Db { get; private set; }
    internal ExtendedPatchProduct DbArchive { get; private set; }
    internal ExtendedPatchProduct AvrDb { get; private set; }
    internal PatchProduct AvrService { get; private set; }
    internal PatchProduct Desktop { get; private set; }
    internal PatchProduct NotificationService { get; private set; }

    internal string UpdateSource { get; private set; }
    internal string OutputPath { get; private set; }

    internal Version TotalVersion { get; private set; }

    private void CheckRequiredOptions(CommandLineOptions options)
    {
      if (!m_isQuiet)
      {
        return;
      }

      if (null == options.TotalVersion)
      {
        throw new ArgumentException("Required argument Total version (--totalversion) not specified!");
      }
      if (string.IsNullOrEmpty(options.UpdateSource))
      {
        throw new ArgumentException("Required argument Update Source (--updatesource) not specified!");
      }
    }

    private void SetTotalVersion(IEnumerable<string> totalVersionList)
    {
      if (!m_isQuiet)
      {
        return;
      }

      TotalVersion = FileHelper.ConvertToVersion(totalVersionList);
      if (VersionFactory.EmptyVersion.Equals(TotalVersion))
      {
        throw new ArgumentException("Bad Total patch version!");
      }
    }
  }
}
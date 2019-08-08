namespace AUM.Core
{
  using System;
  using System.Collections.Generic;
  using System.Globalization;
  using Enums;
  using Helper;


  public class UpdateInfo
  {
    public long ID { get; set; }
    public string Alias { get; set; }
    public DateTime DateStart { get; set; }
    public DateTime? DateFinish { get; set; }
    public bool Success { get; set; }
    public Version VersionStart { get; set; }
    public Version VersionFinish { get; set; }
    public string ComputerName { get; set; }
    public List<string> Log { get; set; }
        
    public UpdateStatus Status { get; set; }

    public UpdateInfoEx ExtendedInfo {
      get
      {
        return new UpdateInfoEx(Alias, VersionFinish, Status);
      }
    }

    public UpdateInfo(string alias, string version) : this()
    {
      Alias = alias;
      VersionFinish = VersionFactory.NewVersion(version);
    }

    public UpdateInfo(string alias, Version version) : this()
    {
      Alias = alias;
      VersionFinish = version;
    }

    public UpdateInfo()
    {
      Alias = string.Empty;
      Success = false;
      Status = UpdateStatus.Unknown;
      VersionStart = VersionFactory.EmptyVersion;
      VersionFinish = VersionFactory.EmptyVersion;
      Log = new List<string>();
    }

    public string GetName()
    {
      var programName = NameOutOfAlias();
      return programName.Length > 0
        ? string.Format(CultureInfo.InvariantCulture, "{0} {1}", programName, VersionFinish)
        : VersionFinish.ToString();
    }

    private string NameOutOfAlias()
    {
      switch (Alias)
      {
        case ProductHelper.AumProgramId:
          return "AUM";
        case ProductHelper.CustomTasksProgramId:
          return "custom programs (x-regime)";
        case "customtasks":
          return string.Empty;
        case ProductHelper.DbProgramId:
          return "Database";
        case ProductHelper.DbaProgramId:
          return "Archive database";
        case ProductHelper.AvrServiceDbProgramId:
          return "AVR service database";
        case ProductHelper.AvrServiceProgramId:
          return "AVR service";
        case ProductHelper.EidssProgramId:
          return "EIDSS";
        case ProductHelper.NsProgramId:
          return "Notification service";

        //TODO: What is this case 2to3?
        case "2to3":
          return "Switch";
        default:
          return "Unknown";
      }
    }
  }
}
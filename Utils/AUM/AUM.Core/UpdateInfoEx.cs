namespace AUM.Core
{
  using System;
  using Enums;
  using Helper;


  /// <summary>
  ///   Метаинформация по апдейту
  /// </summary>
  public class UpdateInfoEx
  {
    public string ProgramID { get; set; }
    public Version Version { get; set; }
    public UpdateStatus Status { get; set; }

    public UpdateInfoEx(string programId, Version version, UpdateStatus status)
    {
      ProgramID = programId ?? string.Empty;
      Version = version;
      Status = status;
    }

    public string GetLogFilename(string computerName)
    {
      return FileHelper.GetLogFileName(ProgramID, computerName, Version.ToString());
    }
  }
}
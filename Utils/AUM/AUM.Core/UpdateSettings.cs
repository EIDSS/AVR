namespace AUM.Core
{
  using System;
  using System.Collections.Generic;
  using Helper;


  /// <summary>
  ///   Настройки из конфиг-файла
  /// </summary>
  public class UpdateSettings
  {
    public Version Version { get; set; }
    public bool IsSmallUpdate { get; set; }
    public string ProgramID { get; set; }
    public string CortegeVersion { get; set; }
    public List<RunScriptData> SqlScriptsList { get; set; }
    public List<ChangeConfigData> ConfigFilesList { get; set; }
    public List<string> DeleteFilesList { get; set; }
    public List<ExecuteData> ExecuteList { get; set; }

    public UpdateSettings()
    {
      Version = VersionFactory.EmptyVersion;
      SqlScriptsList = new List<RunScriptData>();
      ConfigFilesList = new List<ChangeConfigData>();
      DeleteFilesList = new List<string>();
      ExecuteList = new List<ExecuteData>();
    }
  }
}

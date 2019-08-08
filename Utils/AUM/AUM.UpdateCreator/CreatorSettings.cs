namespace AUM.UpdateCreator
{
  using System.IO;
  using System.Xml;
  using Core.Helper;


  public class CreatorSettings
  {
    private string m_updatePath;
    private string m_buildPath;

    public CreatorSettings(string configFilename)
    {
      ConfigFilename = configFilename;
      UpdatePath = string.Empty;
    }

    public string ConfigFilename { get; private set; }
    public string AUMPath { get; private set; }
    public string DBPath { get; private set; }
    public string DBaPath { get; private set; }
    public string AvrDbPath { get; private set; }
    public string AvrServicePath { get; private set; }
    public string EidssPath { get; private set; }
    public string NSPath { get; private set; }
    public string CustomTasksPath { get; private set; }

    public string BuildPath
    {
      get
      {
        if (string.IsNullOrEmpty(m_buildPath) && !string.IsNullOrEmpty(UpdatePath))
        {
          m_buildPath = Path.Combine(UpdatePath, "_build");
        }
        if (!(string.IsNullOrEmpty(m_buildPath) || Directory.Exists(m_buildPath)))
        {
          Directory.CreateDirectory(m_buildPath);
        }
        return m_buildPath;
      }

      set { m_buildPath = value; }
    }

    public string UpdatePath
    {
      get { return m_updatePath; }
      set
      {
        m_updatePath = value;
        AUMPath = Path.Combine(UpdatePath, ProductHelper.AumProgramId);
        DBPath = Path.Combine(UpdatePath, ProductHelper.DbProgramId);
        DBaPath = Path.Combine(UpdatePath, ProductHelper.DbaProgramId);
        AvrDbPath = Path.Combine(UpdatePath, ProductHelper.AvrServiceDbProgramId);
        AvrServicePath = Path.Combine(UpdatePath, ProductHelper.AvrServiceProgramId);
        EidssPath = Path.Combine(UpdatePath, ProductHelper.EidssProgramId);
        NSPath = Path.Combine(UpdatePath, ProductHelper.NsProgramId);
        CustomTasksPath = Path.Combine(UpdatePath, ProductHelper.CustomTasksProgramId);
      }
    }

    public void ReadConfigFile()
    {
      if (!File.Exists(ConfigFilename))
        return;
      using (var reader = new XmlTextReader(ConfigFilename))
      {
        while (reader.Read())
        {
          if (reader.NodeType != XmlNodeType.Element)
            continue;
          if (reader.Name.Equals("updatedir"))
          {
            UpdatePath = reader.GetAttribute("path");
          }
        }
      }
    }

    public void SaveSettings()
    {
      //используем обычную запись в текстовый файл, а не XmlTextWriter
      using (var file = new StreamWriter(ConfigFilename))
      {
        file.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
        file.WriteLine("<config>");
        file.WriteLine("<updatedir path=\"{0}\" />", UpdatePath);
        file.WriteLine("</config>");
      }
    }
  }
}
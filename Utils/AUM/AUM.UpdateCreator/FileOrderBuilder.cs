namespace AUM.UpdateCreator
{
  using System;
  using System.Collections.Generic;
  using System.IO;
  using System.Linq;
  using System.Xml;
  using Core;
  using Core.Helper;


  internal abstract class FileOrderBuilder : IFileManager
  {
    private readonly string m_config;
    protected List<IFile> m_files;

    internal FileOrderBuilder(string fileOrderConfig)
    {
      m_config = fileOrderConfig;
    }

    #region IFileManager Members

    public List<IFile> Files
    {
      get
      {
        if (null == m_files)
        {
          ReadConfig();
        }
        return m_files;
      }
    }

    #endregion

    private void ReadConfig()
    {
      m_files = new List<IFile>(0);

      if (null == m_config || File.Exists(m_config))
      {
        return;
      }

      var fileNodes = XmlHelper.GetElementsByTagName(m_config, "file");
      m_files = new List<IFile>(fileNodes.Count);
      foreach (XmlElement node in fileNodes)
      {
        ThrowIfNoAttribute(m_config, node);
        var file = node.Attributes["name"].Value;
        ThrowIfNotUniqueFile(file);
        var isChecked = IsChecked(node.Attributes);
        AddFile(file, isChecked);
      }
    }

    private static bool IsChecked(XmlAttributeCollection attributes)
    {
      const string Value = "checked";
      var value = attributes[Value].Value;
      if (null == value)
      {
        return true;
      }

      bool isChecked;
      if (!bool.TryParse(value, out isChecked))
      {
        throw new CommandLineArgumentException("Attribute '{0}' is boolean and should be either 'true' or 'false'!");
      }
      return isChecked;
    }

    protected abstract void AddFile(string file, bool isChecked);

    private void ThrowIfNotUniqueFile(string filePath)
    {
      if (Files.Any(file => file.FileName.Equals(filePath, StringComparison.OrdinalIgnoreCase)))
      {
        throw new CommandLineArgumentException("File \"{0}\" has been specified several times.", filePath);
      }
    }

    private static void ThrowIfNoAttribute(string fileOrderConfig, XmlNode node)
    {
      if (node.Attributes == null)
      {
        throw new CommandLineArgumentException("Config \"{0}\" contains empty <file .../> element", fileOrderConfig);
      }
    }
  }
}
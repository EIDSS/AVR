using System;
using System.IO;
using System.Xml;
using AUM.Core;
using AUM.Diagnostics;

namespace AUM.Configuration
{
  using Core.Configuration;
  using Core.Diagnostics;


  public class NodeAttribute
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public NodeAttribute(string aName, string aValue)
        {
            Name = aName;
            Value = aValue;
        }
    }

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Reads and writes the information form the xml configuration files
    /// </summary>
    /// <remarks>
    /// By default <i>ConfigWriter</i> reads/writes the settings of the configuration file <b>appSettings</b> section.
    /// If configuration file name is not specified, it works with application config file (app.config)
    /// Shared <i>Instance</i> method always works to the <i>ConfigWriter</i> instance related with application config file.
    /// </remarks>
    /// <history>
    /// 	[Mike]	22.03.2006	Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class ConfigWriter
    {
        private static ConfigWriter m_Instance;
        private readonly XmlDocument m_AppConfig = new XmlDocument();
        private string m_FileName;
        private bool m_Initialized;
        private bool m_Modified;
        private string m_DefaultConfigFileName = Utils.GetExecutingPath() + Utils.GetConfigFileName();


        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Defines whether <i>ConfigWriter</i> initialized by reading configuration file
        /// </summary>
        /// <returns>
        /// returns <b>True</b> if <i>Read</i> method was called successfully and <b>False</b> in other case.
        /// </returns>
        /// <remarks>
        /// Use this method to indicate was the data successfully read from configuration file or no.
        /// If <i>Read</i> method was called for absent configuration file for example the property will return <b>False</b>.
        /// </remarks>
        /// <history>
        /// 	[Mike]	23.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public bool Initialized
        {
            get { return m_Initialized; }
        }

        public string FileName
        {
            get { return m_FileName; }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Returns the default instance of <i>ConfigWriter</i> related with application configuration file.
        /// </summary>
        /// <returns>
        /// Returns the default instance of <i>ConfigWriter</i> related with application configuration file.
        /// </returns>
        /// <remarks>
        /// When requested first time the instance of <i>ConfigWriter</i> related with application configuration file is created and read.
        /// Any next call of this property returns this created instance and no additional read is performed.
        /// </remarks>
        /// <history>
        /// 	[Mike]	23.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static ConfigWriter Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new ConfigWriter();
                    m_Instance.Read(null);
                }
                return m_Instance;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Reads the configuration file and stores xml document inside the class
        /// </summary>
        /// <param name="FileName">
        /// Xml file name to read
        /// </param>
        /// <remarks>
        /// If <i>FileName</i> is not passed (or set to <b>Nothing</b>) the default application config file is read.
        /// If specified file doesn't exist new xml document with <i>&lt;configuration&gt;/&lt;appConfig&gt;</i> section is created.
        /// </remarks>
        /// <history>
        /// 	[Mike]	22.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public void Read(string FileName)
        {
            //Save settings in app config file
            if (FileName == null)
            {
                m_FileName = m_DefaultConfigFileName;
            }
            else
            {
                m_FileName = FileName;
            }

            if (File.Exists(m_FileName) == false)
            {
                GetAppSettingsNode();
                return;
            }
            m_AppConfig.Load(m_FileName);
            m_Modified = false;
            m_Initialized = true;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Sets the value for specific setting defined by parent node and setting's key.
        /// </summary>
        /// <param name="appSettingsNode">
        /// defines the <b>XmlNode</b> that contains the setting nodes.
        /// </param>
        /// <param name="nodeName">
        /// the value of <i>key</i> attribute of setting node
        /// </param>
        /// <param name="Value">
        /// the string that should be assigned to the <i>value</i> attribute of setting node
        /// </param>
        /// <returns>
        /// Returns <b>True</b> if setting node was modified and <b>False</b> in other case
        /// </returns>
        /// <remarks>
        /// This method is used to set the values of setting nodes with predefined node parameters: <br/>
        /// <i>add</i> - the tag name of setting node
        /// <b>key</b> - the attribute that defines the unique node identifier
        /// <b>value</b> - the attribute that defines the setting value <br/>
        /// If requested setting is absent the new setting node is added to the parent <b>XmlNode</b>
        /// </remarks>
        /// <history>
        /// 	[Mike]	23.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private bool SetAttributeValue(XmlNode appSettingsNode, string nodeName, string Value)
        {
            XmlNode node = appSettingsNode.OwnerDocument.SelectSingleNode("descendant::add[@key=\'" + nodeName + "\']");
            if (node == null)
            {
                node = appSettingsNode.OwnerDocument.CreateElement("add");
                node.Attributes.Append(appSettingsNode.OwnerDocument.CreateAttribute("key"));
                node.Attributes["key"].InnerText = nodeName;
                node.Attributes.Append(appSettingsNode.OwnerDocument.CreateAttribute("value"));
                node.Attributes["value"].InnerText = Value;
                appSettingsNode.AppendChild(node);
                Dbg.Debug(DebugDetalizationLevel.High.ToString(), "attribute value {0} for node {1} is added  ", Value,
                          nodeName);
                return true;
            }
            else
            {
                if (node.Attributes["value"].InnerText != Value)
                {
                    Dbg.Debug(DebugDetalizationLevel.High.ToString(),
                              "attribute value for node {0} was changed from {1} to {2}  ", nodeName,
                              node.Attributes["value"].InnerText, Value);
                    node.Attributes["value"].InnerText = Value;
                    return true;
                }
            }
            Dbg.Debug(DebugDetalizationLevel.High.ToString(), "attribute value for node {0} was changed not changed",
                      nodeName);
            return false;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Searches the <b>XmlNode</b> with specific name and specific attribute value in the section defined by <i>appSettingsNode</i> parameter.
        /// </summary>
        /// <param name="appSettingsNode">
        /// parent <b>XmlNode</b> node. The result node will be searched among the children of this node.
        /// </param>
        /// <param name="nodeName">
        /// the tag name of xml node to search
        /// </param>
        /// <param name="AttrName">
        /// the name of key attribute
        /// </param>
        /// <param name="AttrValue">
        /// the value of key attribute
        /// </param>
        /// <returns>
        /// Returns the first <b>XmlNode</b> that match to specified conditions or <b>Nothing</b> if node is not found
        /// </returns>
        /// <remarks>
        /// Use this method to find <b>XmlNode</b> with arbitrary tag name and key attribute
        /// </remarks>
        /// <history>
        /// 	[Mike]	23.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public XmlNode FindNodeByAttribute(XmlNode appSettingsNode, string nodeName, string AttrName, string AttrValue)
        {
            if (appSettingsNode == null)
            {
                XmlNode root = m_AppConfig.DocumentElement;
                appSettingsNode = root.SelectSingleNode("appSettings");
            }
            return
                appSettingsNode.SelectSingleNode(string.Format("descendant::{0}[@{1}=\'{2}\']", nodeName, AttrName,
                                                               AttrValue));
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Searches the <b>XmlNode</b> with specific name and specific attribute value in descendant nodes of parent node and sets values for the set of node attributes.
        /// </summary>
        /// <param name="appSettingsNode">
        /// parent <b>XmlNode</b> node. The node that should be modified will be searched among the children of this node.
        /// </param>
        /// <param name="nodeName">
        /// the tag name of xml node that should be modified
        /// </param>
        /// <param name="attr">
        /// the array of <i>NodeAttribute</i> objects that defines the name/value pairs for modified attributes
        /// </param>
        /// <returns>
        /// Returns <b>True</b> if any of the passed attributes values was modified or new node was created and <b>False</b> in other case.
        /// </returns>
        /// <remarks>
        /// Call this method if you need to modify several attributes of <i>XmlNode</i> with custom node name.
        /// </remarks>
        /// <history>
        /// 	[Mike]	23.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public bool SetAttributeValue(XmlNode appSettingsNode, string nodeName, NodeAttribute[] attr)
        {
            if (attr.Length == 0)
            {
                return false;
            }
            XmlNode node = FindNodeByAttribute(appSettingsNode, nodeName, attr[0].Name, attr[0].Value);
            if (node == null)
            {
                node = appSettingsNode.OwnerDocument.CreateElement(nodeName);
                for (int i = 0; i <= attr.Length - 1; i++)
                {
                    node.Attributes.Append(appSettingsNode.OwnerDocument.CreateAttribute(attr[i].Name));
                    node.Attributes[attr[i].Name].InnerText = attr[i].Value;
                    Dbg.Debug(DebugDetalizationLevel.High.ToString(), "attribute value {0} for node {1} is added  ",
                              attr[i].Value, attr[i].Name);
                }
                appSettingsNode.AppendChild(node);
                m_Modified = true;
                return true;
            }
            else
            {
                for (int i = 1; i <= attr.Length - 1; i++)
                {
                    if (node.Attributes[attr[i].Name] == null)
                    {
                        node.Attributes.Append(appSettingsNode.OwnerDocument.CreateAttribute(attr[i].Name));
                        Dbg.Debug(DebugDetalizationLevel.High.ToString(), "attribute value {0} for node {1} is added  ",
                                  attr[i].Value, attr[i].Name);
                        m_Modified = true;
                    }
                    if (node.Attributes[attr[i].Name].InnerText != attr[i].Value)
                    {
                        Dbg.Debug(DebugDetalizationLevel.High.ToString(),
                                  "attribute value for node {0} was changed from {1} to {2}  ", attr[i].Name,
                                  node.Attributes[attr[i].Name].InnerText, attr[i].Value);
                        node.Attributes[attr[i].Name].InnerText = attr[i].Value;
                        m_Modified = true;
                    }
                }
            }
            return m_Modified;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Sets several attribute values for the specific <b>XmlNode</b>.
        /// </summary>
        /// <param name="node">
        /// the <b>XmlNode</b> that should be modified
        /// </param>
        /// <param name="attr">
        /// the array of <i>NodeAttribute</i> objects that defines the name/value pairs for modified attributes
        /// </param>
        /// <returns>
        /// Returns <b>True</b> if any of the passed attributes values was modified or new node was created and <b>False</b> in other case.
        /// </returns>
        /// <remarks>
        /// Call this method if you need to modify several attributes of the specific <i>XmlNode</i>.
        /// </remarks>
        /// <history>
        /// 	[Mike]	23.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public bool SetAttributeValue(XmlNode node, NodeAttribute[] attr)
        {
            if (attr.Length == 0)
            {
                return false;
            }
            if (node != null)
            {
                for (int i = 0; i <= attr.Length - 1; i++)
                {
                    if (node.Attributes[attr[i].Name] == null)
                    {
                        node.Attributes.Append(node.OwnerDocument.CreateAttribute(attr[i].Name));
                    }
                    if (node.Attributes[attr[i].Name].InnerText != attr[i].Value)
                    {
                        node.Attributes[attr[i].Name].InnerText = attr[i].Value;
                        m_Modified = true;
                    }
                }
                return true;
            }
            return false;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the specific setting in the appSettings section of configuration file
        /// </summary>
        /// <param name="keyValue">
        /// the value key attribute of the appSettings node
        /// </param>
        /// <returns>
        /// the value attribute of the appSettings node
        /// </returns>
        /// <remarks>
        /// If requested settings node doesn't exist the <b>Nothing</b> is returned. If you set value for non existing setting node, the new setting is created.
        /// </remarks>
        /// <history>
        /// 	[Mike]	22.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public string Item(string keyValue)
        {
            XmlNode root = m_AppConfig.DocumentElement;
            XmlNode appSettingsNode = root.SelectSingleNode("/configuration/appSettings");

            if (appSettingsNode == null)
            {
                return null;
            }

            XmlNode node = appSettingsNode.OwnerDocument.SelectSingleNode("descendant::add[@key=\'" + keyValue + "\']");
            if (node != null)
            {
                return node.Attributes["value"].InnerText;
            }
            return null;
        }

        public void SetItem(string keyValue, string Value)
        {
            XmlNode appSettingsNode = GetAppSettingsNode();
            m_Modified = m_Modified || SetAttributeValue(appSettingsNode, keyValue, Value);
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Searches and returns <b>XmlNode</b> defined by node name and attribute name/value pair in the <b>appSettings</b> section of configuration file.
        /// </summary>
        /// <param name="nodeName">
        /// xml node name to find
        /// </param>
        /// <param name="AttrName">
        /// the key attribute name
        /// </param>
        /// <param name="AttrValue">
        /// the key attribute value
        /// </param>
        /// <returns>
        /// Returns <b>XmlNode</b> with specific node name and attribute name/value pair or <b>Nothing</b> is node is not found.
        /// </returns>
        /// <remarks>
        /// The node is searched inside <b>appSettings</b> section of configuration file only.
        /// </remarks>
        /// <history>
        /// 	[Mike]	23.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public XmlNode GetNode(string nodeName, string AttrName, string AttrValue)
        {
            return GetNode(null, nodeName, AttrName, AttrValue);
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Searches and returns <b>XmlNode</b> defined by node name and attribute name/value pair in the specific section of configuration file.
        /// </summary>
        /// <param name="ParentNode">
        /// <b>XmlNode</b> of section to search
        /// </param>
        /// <param name="nodeName">
        /// xml node name to find
        /// </param>
        /// <param name="AttrName">
        /// the key attribute name
        /// </param>
        /// <param name="AttrValue">
        /// the key attribute value
        /// </param>
        /// <returns>
        /// Returns <b>XmlNode</b> with specific node name and attribute name/value pair or <b>Nothing</b> is node is not found.
        /// </returns>
        /// <remarks>
        /// The node is searched inside section of configuration file defined by <i>ParentNode</i>.
        /// </remarks>
        /// <history>
        /// 	[Mike]	23.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public XmlNode GetNode(XmlNode ParentNode, string nodeName, string AttrName, string AttrValue)
        {
            if (ParentNode == null)
            {
                XmlNode root = m_AppConfig.DocumentElement;
                ParentNode = root.SelectSingleNode("appSettings");
            }
            XmlNode SectionNode = FindNodeByAttribute(ParentNode, nodeName, AttrName, AttrValue);
            if (SectionNode != null)
            {
                return SectionNode;
            }
            else
            {
                SectionNode = ParentNode.OwnerDocument.CreateElement(nodeName);
                SetAttributeValue(SectionNode, new NodeAttribute[] {new NodeAttribute(AttrName, AttrValue)});
                ParentNode.AppendChild(SectionNode);
                m_Modified = true;
            }
            return SectionNode;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Returns the string value of specific attribute for passed <b>XmlNode</b>
        /// </summary>
        /// <param name="node">
        /// <b>XmlNode</b> that contains the attribute
        /// </param>
        /// <param name="AttrName">
        /// the attribute name
        /// </param>
        /// <returns>
        /// the string representation of the requested attribute
        /// </returns>
        /// <remarks>
        /// No additional checks for existence of passed node or attribute is performed. If <i>node</i> is <b>Nothing</b> or contains no requested attribute the exception will be thrown
        /// </remarks>
        /// <history>
        /// 	[Mike]	23.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public string GetAttributeValue(XmlNode node, string AttrName)
        {
            return node.Attributes[AttrName].InnerText;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Saves the configuration file previously read using <i>Read</i> method.
        /// </summary>
        /// <returns>
        /// Returns <b>False</b> if error occur during saving or <b>True</b> in other case.
        /// </returns>
        /// <remarks>
        /// When the application is run from VS IDE the changes for default application configuration
        /// file are saved not only to configuration file in the <b>bin</b> folder but to the original
        /// <b>app.config</b> file too. If error occurs during saving the error is written to
        /// the application log but no error reported to end user
        /// </remarks>
        /// <history>
        /// 	[Mike]	23.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public bool Save()
        {
            if (m_Modified == false)
            {
                Dbg.Debug(DebugDetalizationLevel.High.ToString(),
                          "configuration file {0} is not saved, there is no changes", m_FileName);
                return true;
            }
            bool ret = true;
            try
            {
                m_AppConfig.Save(m_FileName);
                m_Modified = false;
            }
            catch (Exception ex)
            {
                ret = false;
                Dbg.Debug( "the changes to configuration file {0} was not written, {1}",
                                m_FileName, ex.Message);
            }
            string appConfigFileName = "";
            try
            {
                if (m_FileName == m_DefaultConfigFileName)
                {
                    appConfigFileName = Utils.GetExecutingPath() + "\\..\\app.config";
                    if (File.Exists(appConfigFileName))
                    {
                        m_AppConfig.Save(appConfigFileName);
                    }
                }
            }
            catch (Exception ex)
            {
                ret = false;
                Dbg.Debug("the changes to configuration file {0} was not written, {1}",
                                appConfigFileName, ex.Message);
            }
            Config.ReloadSettings();
            Instance.Read(null);
            return ret;
        }

        private XmlNode GetAppSettingsNode()
        {
            XmlNode appSettingsNode = m_AppConfig.SelectSingleNode("/configuration/appSettings");
            if (appSettingsNode == null)
            {
                XmlNode root = m_AppConfig.DocumentElement;
                if (root == null)
                {
                    root = m_AppConfig.CreateNode(XmlNodeType.XmlDeclaration, "", "");
                    m_AppConfig.AppendChild(root);
                }
                root = m_AppConfig.SelectSingleNode("/configuration");
                if (root == null)
                {
                    root = m_AppConfig.CreateNode(XmlNodeType.Element, "configuration", "");
                }
                appSettingsNode = m_AppConfig.CreateNode(XmlNodeType.Element, "appSettings", "");
                root.AppendChild(appSettingsNode);
                m_AppConfig.AppendChild(root);
            }
            return appSettingsNode;
        }
    }
}
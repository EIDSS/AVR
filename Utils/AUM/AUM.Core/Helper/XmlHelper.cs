using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace AUM.Core.Helper
{
    /// <summary>
    /// Метаинформация по апдейту
    /// </summary>
    public static class XmlHelper
    {
        /// <summary>
        /// Завершает запись в файл
        /// </summary>
        /// <param name="textWriter"></param>
        public static void CloseXmlTextWriter(XmlTextWriter textWriter)
        {
            textWriter.WriteEndElement(); //корневой элемент
            textWriter.Close();
        }

        /// <summary>
        /// Создаёт XmlTextWriter по имени файла
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="version"></param>
        /// <param name="programid">Программа, для которой предназначается апдейт</param>
        /// <param name="isSmallUpdate"></param>
        /// <param name="cortegeVersion">Кортеж версий, с которыми надо сравнивать</param>
        /// <returns></returns>
        public static XmlTextWriter CreateXmlTextWriter(string filename, Version version, string programid, bool isSmallUpdate, string cortegeVersion)
        {
            var dir = Path.GetDirectoryName(filename);
            if (dir != null && !Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            var textWriter = new XmlTextWriter(filename, null) {Formatting = Formatting.Indented};
            textWriter.WriteStartDocument(false);
            textWriter.WriteComment(String.Format("Created at {0} by AUM Update Creator", DateTime.Now));
            textWriter.WriteStartElement("update");
            textWriter.WriteAttributeString("version", version.ToString());
            textWriter.WriteAttributeString("program", programid);
            textWriter.WriteAttributeString("issmallupdate", isSmallUpdate ? "1" : "0");
            textWriter.WriteAttributeString("cortegeversion", cortegeVersion);
            return textWriter;
        }

        /// <summary>
        /// Читает атрибут в указанном XML
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="elementName"></param>
        /// <param name="attributeName"></param>
        public static string ReadAttributeFromXML(string fileName, string elementName, string attributeName)
        {
            var result = String.Empty;

            using (var reader = new XmlTextReader(fileName))
            {
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) && (reader.Name.Equals(elementName)))
                    {
                        result = reader.GetAttribute(attributeName) ?? String.Empty;
                        break;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Разбирает файл updates.xml
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static IEnumerable<TotalUpdateInfo> ReadUpdates(string fileName)
        {
            var result = new List<TotalUpdateInfo>();

            using (var reader = new XmlTextReader(fileName))
            {
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) && (reader.Name.Equals("update")))
                    {
                      var version = reader.GetAttribute("total");
                      var totalUpdateInfo = new TotalUpdateInfo
                      {
                        Version = string.IsNullOrEmpty(version) ? VersionFactory.EmptyVersion : VersionFactory.NewVersion(version)
                      };
                        totalUpdateInfo.Updates.Add(new UpdateInfo("aum", reader.GetAttribute("aum")));
                        totalUpdateInfo.Updates.Add(new UpdateInfo("db", reader.GetAttribute("db")));
                        totalUpdateInfo.Updates.Add(new UpdateInfo("dba", reader.GetAttribute("dba")));
                        totalUpdateInfo.Updates.Add(new UpdateInfo("e", reader.GetAttribute("e")));
                        totalUpdateInfo.Updates.Add(new UpdateInfo("ns", reader.GetAttribute("ns")));
                        totalUpdateInfo.Updates.Add(new UpdateInfo("x", reader.GetAttribute("x")));
                        totalUpdateInfo.Updates.Add(new UpdateInfo("avrs", reader.GetAttribute("avrs")));
                        totalUpdateInfo.Updates.Add(new UpdateInfo("dbavr", reader.GetAttribute("dbavr")));
                        totalUpdateInfo.Country = reader.GetAttribute("country") ?? string.Empty;
                        if (totalUpdateInfo.Country.Length > 0)
                        {
                            //если задана страна, то этот тотал-архив нужно выводить, если только эта страна -- текущая
                            if (!totalUpdateInfo.Country.Equals(AdminHelper.GetCurrentCountry())) continue;
                        }
                        totalUpdateInfo.IsSmall = reader.GetAttribute("issmall") == "1";
                        var crc = reader.GetAttribute("crc");
                        if (crc != null) totalUpdateInfo.CRC = Convert.ToInt64(crc);

                        result.Add(totalUpdateInfo);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Собирает с контрола значения и формирует секцию
        /// </summary>
        /// <param name="textWriter"></param>
        /// <param name="scriptDatas"></param>
        public static void AddSQLScriptSection(XmlTextWriter textWriter, List<RunScriptData> scriptDatas)
        {
            textWriter.WriteStartElement("sqlscripts");

            foreach (var scriptData in scriptDatas)
            {
                AddSQLScript(textWriter, scriptData.FileName);
            }

            textWriter.WriteEndElement();
        }

        /// <summary>
        /// Собирает с контрола значения и формирует секцию
        /// </summary>
        /// <param name="textWriter"></param>
        /// <param name="datas"></param>
        public static void AddExecuteSection(XmlTextWriter textWriter, List<ExecuteData> datas)
        {
            textWriter.WriteStartElement("executes");

            foreach (var data in datas)
            {
                AddExecute(textWriter, data);
            }

            textWriter.WriteEndElement();
        }

        /// <summary>
        /// Собирает с контрола значения и формирует секцию
        /// </summary>
        /// <param name="textWriter"></param>
        /// <param name="deleteFilesList"></param>
        public static void AddDeleteFilesSection(XmlTextWriter textWriter, ListBox deleteFilesList)
        {
            textWriter.WriteStartElement("deletefiles");

            foreach (string filename in deleteFilesList.Items)
            {
                var items = filename.Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (items.Length != 2) continue;
                AddDeleteFile(textWriter, items[0], items[1]);
            }

            textWriter.WriteEndElement();
        }

        /// <summary>
        /// Собирает с контрола значения и формирует секцию
        /// </summary>
        /// <param name="textWriter"></param>
        /// <param name="configDatas"></param>
        public static void AddChangeConfigValueSection(XmlTextWriter textWriter, List<ChangeConfigData> configDatas)
        {
            textWriter.WriteStartElement("changeconfigfiles");

            //собираем перечень изменений в конфиг-файлах
            foreach (var configData in configDatas)
            {
                AddChangeConfigValue(textWriter, configData);
            }

            textWriter.WriteEndElement();
        }


        /// <summary>
        /// Добавляет команду на выполнение SQL-скрипта
        /// </summary>
        /// <param name="textWriter"></param>
        /// <param name="filename"></param>
        public static void AddSQLScript(XmlTextWriter textWriter, string filename)
        {
            textWriter.WriteStartElement("runscript");
            textWriter.WriteAttributeString("filename", filename);
            textWriter.WriteEndElement();
        }

        /// <summary>
        /// Добавляет команду на выполнение запускаемого файла или его аналога
        /// </summary>
        /// <param name="textWriter"></param>
        /// <param name="data"></param>
        public static void AddExecute(XmlTextWriter textWriter, ExecuteData data)
        {
            textWriter.WriteStartElement("execute");
            textWriter.WriteAttributeString("filename", data.FileName);
            textWriter.WriteAttributeString("needwait", data.NeedWait ? "1" : "0");
            textWriter.WriteEndElement();
        }

        /// <summary>
        /// Добавляет команду на удаление файла
        /// </summary>
        /// <param name="textWriter"></param>
        /// <param name="programID"> </param>
        /// <param name="filename"></param>
        public static void AddDeleteFile(XmlTextWriter textWriter, string programID,  string filename)
        {
            textWriter.WriteStartElement("deletefile");
            textWriter.WriteAttributeString("programid", programID);
            textWriter.WriteAttributeString("filename", filename);
            textWriter.WriteEndElement();
        }

        /// <summary>
        /// Добавляет команду на изменение значения в конфиг-файле
        /// </summary>
        /// <param name="textWriter"></param>
        /// <param name="configData"></param>
        public static void AddChangeConfigValue(XmlTextWriter textWriter, ChangeConfigData configData)
        {
            textWriter.WriteStartElement("changeconfigvalue");
            textWriter.WriteAttributeString("filename", configData.FileName);
            textWriter.WriteAttributeString("path", configData.Path);
            textWriter.WriteAttributeString("attributekey", configData.AttributeKey);
            textWriter.WriteAttributeString("attributevalue", configData.AttributeValue);
            textWriter.WriteAttributeString("key", configData.Key);
            textWriter.WriteAttributeString("value", configData.Value);
            textWriter.WriteAttributeString("valueisregularexpression", configData.ValueIsRegularExpression ? "1" : "0");
            textWriter.WriteAttributeString("deletethisnode", configData.DeleteThisNode ? "1" : "0");
            textWriter.WriteEndElement();
        }

    public static XmlNodeList GetElementsByTagName(string xmlFile, string tagName)
    {
      var xmlDoc = new XmlDocument();
      xmlDoc.Load(xmlFile);
      var fileNodes = xmlDoc.GetElementsByTagName(tagName);
      return fileNodes;
    }
    }
}
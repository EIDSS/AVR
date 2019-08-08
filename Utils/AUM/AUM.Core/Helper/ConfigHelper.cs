using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;

namespace AUM.Core.Helper
{
    public enum ConfigChangeResult
    {
        FileNotFound,
        NodeNotFound,
        NodeChanged,
        SameAttributeValue,
        NodeCreated,
        NodeDeleted
    }
    /// <summary>
    /// –едактирование конфигов
    /// </summary>
    public static class ConfigHelper
    {
        /// <summary>
        /// —оздаЄт указанный путь в документе
        /// </summary>
        /// <param name="document"></param>
        /// <param name="path"></param>
        /// <param name="attributeKey"></param>
        /// <param name="key"></param>
        /// <param name="attributeValue"></param>
        /// <param name="value"></param>
        private static void CreatePath(XmlDocument document, string path, string attributeKey, string key, string attributeValue, string value)
        {
            if (document.HasChildNodes)
            {
                foreach (XmlNode node in document.ChildNodes)
                {
                    if ((node is XmlDeclaration) || (node is XmlDocument)) continue;
                    if (CreatePathParts(document, node, path, attributeKey, key, attributeValue, value) != null) break;
                }
            }
            else
            {
                var node = document.AppendChild(document.CreateElement("root"));
                CreatePathParts(document, node, path, attributeKey, key, attributeValue, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="document"></param>
        /// <param name="parentNode"></param>
        /// <param name="path"></param>
        /// <param name="attributeKey"></param>
        /// <param name="key"></param>
        /// <param name="attributeValue"></param>
        /// <param name="value"></param>
        private static XmlNode CreatePathParts(XmlDocument document, XmlNode parentNode, string path, string attributeKey, string key, string attributeValue, string value)
        {
            XmlNode result = null;

            //определим содержимое пути
            //ожидаетс€ разделитель "/"
            var pathParts = path.Split(new[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
            if (pathParts.Length == 0) return null;

            var nameElement = pathParts[0];
            //будем искать узел только по имени без атрибутов. ѕотому найдЄм первый попавшийс€ узел с таким именем.
            var node = GetNodeByPath(parentNode, nameElement, pathParts.Length == 1 ? attributeKey : string.Empty, pathParts.Length == 1 ? key : string.Empty);
            if (node == null)
            {
                node = parentNode.AppendChild(document.CreateElement(nameElement));
                //атрибуты выставл€ем только самому нижнему узлу (искомому)
                if ((pathParts.Length == 1) && (node.Attributes != null))
                {
                    var attribute = document.CreateAttribute(attributeKey);
                    attribute.Value = key;
                    node.Attributes.Append(attribute);
                    attribute = document.CreateAttribute(attributeValue);
                    attribute.Value = value;
                    node.Attributes.Append(attribute);
                }
            }

            //пробуем отыскать этот нод среди потомков переданного, если сам переданный не €вл€етс€ искомым
            //XmlNode node = parentNode.Name.Equals(nameElement)
            //                   ? parentNode
            //                   : SearchNodeByName(parentNode.ChildNodes, nameElement) ??
            //                     parentNode.AppendChild(document.CreateElement(nameElement));
            //рекурсивно его потомков
            if (path.Contains("/"))
                result = CreatePathParts(document, node,
                                         path.Substring(nameElement.Length + 1, path.Length - nameElement.Length - 1),
                                         attributeKey, key, attributeValue, value);

            return result;
        }

        /// <summary>
        /// ѕровер€ет, удовлетвор€ют ли атрибуты нода заданному условию
        /// </summary>
        /// <param name="node"></param>
        /// <param name="attributeKey"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private static bool CheckNodeAttributes(XmlNode node, string attributeKey, string key)
        {
            //если атрибуты не заданы, то они игнорируютс€ (это нужно, когда требуетс€ отыскать узел, невзира€ на его атрибуты)
            var result = ((attributeKey.Length == 0) && (key.Length == 0));

            if (!result && (node.Attributes != null))
            {
                var attribute = node.Attributes[attributeKey];
                if ((attribute != null) && (attribute.Value.Equals(key))) result = true;
            }
            return result;
        }

        /// <summary>
        /// ќтыскивает по пути нужный узел по имени рекурсивным способом
        /// </summary>
        /// <param name="node"></param>
        /// <param name="path"></param>
        /// <param name="attributeKey"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private static XmlNode GetNodeByPath(XmlNode node, string path, string attributeKey, string key)
        {
            XmlNode result = null;
            var pathParts = path.Split(new[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
            var nameElement = pathParts[0];
            //проверим переданный узел
            if (node.Name.Equals(nameElement) && CheckNodeAttributes(node, attributeKey, key))
            {
                result = node;
            }
            else
            {
                var newPath = pathParts.Length > 1
                                     ? path.Substring(nameElement.Length + 1, path.Length - nameElement.Length - 1)
                                     : path;
                foreach (XmlNode childNode in node.ChildNodes)
                {
                    //if (childNode.Name.Equals(nameElement))
                    //{
                    result = GetNodeByPath(childNode, newPath, attributeKey, key);
                    if (result != null) break;
                    //}
                }
            }
            return result;
        }

        /// <summary>
        /// ¬ыполн€ет одно элементарное обновление конфига
        /// </summary>
        /// <param name="config"></param>
        public static ConfigChangeResult ChangeValue(ChangeConfigData config)
        {
            var destinationDir = FileHelper.GetDestinationPath(config.FileName);
            if (!File.Exists(destinationDir)) return ConfigChangeResult.FileNotFound;
            var document = new XmlDocument();
            document.Load(destinationDir);

            var node = GetNodeByPath(document, config.Path, config.AttributeKey, config.Key);
            if ((node != null) && (node.Attributes != null))
            {
                var attribute = node.Attributes[config.AttributeValue];
                if (attribute != null)
                {
                    var val = config.ValueIsRegularExpression
                                  ? (new Regex(config.Value)).Replace(attribute.Value, config.Value)
                                  : config.Value;
                    if (attribute.Value.Equals(val))
                        return ConfigChangeResult.SameAttributeValue;
                    attribute.Value = val;
                    document.Save(destinationDir);
                    return ConfigChangeResult.NodeChanged;
                }
            }
            CreatePath(document, config.Path, config.AttributeKey, config.Key, config.AttributeValue, config.Value);
            document.Save(destinationDir);
            return ConfigChangeResult.NodeCreated;
        }

        /// <summary>
        /// ”даление узла со значени€ми
        /// </summary>
        /// <param name="config"></param>
        public static ConfigChangeResult DeleteValue(ChangeConfigData config)
        {
            var destinationDir = FileHelper.GetDestinationPath(config.FileName);
            if (!File.Exists(destinationDir)) return ConfigChangeResult.FileNotFound;
            var document = new XmlDocument();
            document.Load(destinationDir);
            var navigator = document.CreateNavigator();
            navigator = navigator.SelectSingleNode(config.Path);
            if (navigator != null)
            {
                navigator.DeleteSelf();
                document.Save(destinationDir);
                return ConfigChangeResult.NodeDeleted;
            }
            return ConfigChangeResult.NodeNotFound;
        }

        /// <summary>
        /// –асчитывает интервал таймера
        /// </summary>
        /// <param name="interval"></param>
        /// <returns></returns>
        public static int GetTimerInterval(string interval)
        {
            var result = 0;
            try
            {
                var pos = interval.IndexOf(":");
                if (pos >= 0)
                {
                    //HH:MM
                    result = (Convert.ToInt32(interval.Substring(0, pos)) * 60 * 60 +
                              Convert.ToInt32(interval.Substring(pos + 1, interval.Length - (pos + 1))) * 60) * 1000;
                }
            }
            // ReSharper disable EmptyGeneralCatchClause
            catch { }
            // ReSharper restore EmptyGeneralCatchClause
            return result;
        }
    }
}

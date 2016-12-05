using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;

namespace Assets.Project.Scripts._01_Common.ParseXML
{
    public class ParseXml
    {
        private static ParseXml _instance;
        public readonly List<InfoData> infoList;
        private readonly XmlDocument xmlDoc;
        private XmlNodeList infoNodeList;

        public ParseXml()
        {
            infoList = new List<InfoData>();
            xmlDoc = new XmlDocument();
        }

        public static ParseXml GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ParseXml();
            }
            return _instance;
        }

        /// <summary>


        ///     从 Stream、URL、TextReader 或 XmlReader 加载指定的 XML 数据。


        /// </summary>


        /// <param name="path"></param>


        public void ReadXml(TextAsset path)
        {
            //            xmlDoc.Load(path);


            xmlDoc.Load(new MemoryStream(path.bytes));
            GetRoots();
        }

        /// <summary>


        ///     获取节点数据


        /// </summary>


        private void GetRoots()
        {
            var rootNode = xmlDoc.FirstChild;
            infoNodeList = rootNode.ChildNodes;
            GetRootData();
        }

        /// <summary>


        ///     获的节点下的信息


        /// </summary>


        private void GetRootData()
        {
            foreach (XmlNode infoNode in infoNodeList)
            {
                var fieldNodeList = infoNode.ChildNodes;

                foreach (XmlNode node in fieldNodeList)
                {
                    var infoData = new InfoData();
                    if (infoNode.Name == "Tips")
                    {
                        if (node.Name == "Info")
                        {
                            var Info = node.InnerText;
                            infoData.Info = Info;
                            infoData.page = int.Parse(node.Attributes[0].Value);
                        }
                    }
                    else if (infoNode.Name == "Helps")
                    {
                        if (node.Name == "Info")
                        {
                            var Info = node.InnerText;
                            infoData.Info = Info;
                            infoData.name = node.Attributes[0].Value;
                        }
                    }
                    infoList.Add(infoData);
                }
            }

            //            foreach (var infoData in infoList)


            //            {


            //                if (infoData.page == 01)


            //                {


            //                    Debug.Log(infoData.Info);


            //                }


            //                


            //            }


        }
    }
}


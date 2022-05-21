using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Xml.Serialization;

namespace HomeworkLeak
{
    class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();
            while (true)
            {
                var obj = new XmlObj() { Nodes = new List<XmlNode>() { new() { Value = rand.Next(int.MaxValue) } } };
                var xmlSerializer = new XmlSerializer(typeof(XmlObj), new XmlRootAttribute("rootNode"));
                using (StringWriter textWriter = new StringWriter())
                {
                    xmlSerializer.Serialize(textWriter, obj);
                    Console.WriteLine(textWriter.ToString());
                }
                Thread.Sleep(100);
            }
        }
    }

    [Serializable]
    public class XmlObj
    {
        [XmlElement("block")]
        public List<XmlNode> Nodes { get; set; }
    }

    [Serializable]
    public class XmlNode
    {
        public int Value { get; set; }
    }
}

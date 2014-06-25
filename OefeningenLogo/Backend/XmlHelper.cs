using System;
using System.Xml.Linq;

namespace OefeningenLogo.Backend
{
    public static class XmlHelper
    {
        const string XmlFilename = @"C:\Temp\logo\exercises.xml";

        public static void ReadXml(Action<XDocument> action)
        {
            var doc = XDocument.Load(XmlFilename);
            action(doc);
        }

        public static void SaveXml(Action<XDocument> action)
        {
            var doc = XDocument.Load(XmlFilename);
            action(doc);
            doc.Save(XmlFilename);
        }
    }
}
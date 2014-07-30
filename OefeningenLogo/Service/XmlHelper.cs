using System;
using System.Xml.Linq;

namespace OefeningenLogo.Service
{
    public static class XmlHelper
    {
        private static readonly string XmlFilename;

        static XmlHelper()
        {
            XmlFilename = ConfigSettings.ExerciseFile;
        }

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
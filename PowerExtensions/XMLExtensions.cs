using System.Xml;

namespace PowerExtensions
{
    public static class XMLExtensions
    {
        /// <summary>
        /// Merge two XMLs into one
        /// </summary>
        /// <param name="xml">XML</param>
        /// <param name="anotherXml">Another XML</param>
        /// <returns></returns>
        public static string AppendXml(this string xml, string anotherXml)
        {
            if (string.IsNullOrEmpty(anotherXml))
                return xml;

            XmlDocument documentA = new XmlDocument();
            documentA.LoadXml(xml);

            XmlDocument documentB = new XmlDocument();
            documentB.LoadXml(anotherXml);

            foreach (XmlNode node in documentB.DocumentElement.ChildNodes)
            {
                XmlNode imported = documentA.ImportNode(node, true);
                documentA.DocumentElement.AppendChild(imported);
            }

            return documentA.InnerXml;
        }

        public static string AppendXmls(this string baseXml, params string[] xmls)
        {
            if (baseXml.IsNullOrEmpty() || xmls == null || xmls.Length < 1)
                return baseXml;

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(baseXml);

            foreach (var xml in xmls)
            {
                var docs = new XmlDocument();
                docs.LoadXml(xml);

                if (docs.DocumentElement == null || docs.DocumentElement.ChildNodes == null)
                    continue;

                foreach (XmlNode node in docs.DocumentElement.ChildNodes)
                {
                    XmlNode imported = xmlDoc.ImportNode(node, true);
                    xmlDoc.DocumentElement.AppendChild(imported);
                }
            }

            return xmlDoc.InnerXml;
        }
    }
}

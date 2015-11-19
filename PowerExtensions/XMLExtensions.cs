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
        public static string MergeXmls(this string xml, string anotherXml)
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
    }
}

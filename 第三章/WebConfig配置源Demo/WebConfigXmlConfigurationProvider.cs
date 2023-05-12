using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WebConfig配置源Demo
{
    public class WebConfigXmlConfigurationProvider : FileConfigurationProvider
    {
        public WebConfigXmlConfigurationProvider(WebConfigXmlConfigurationSource source) : base(source)
        {
        }

        public override void Load(Stream stream)
        {
            var data = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(stream);
            var csNodes = xmlDocument.SelectNodes("/configuration/connectionStrings/add");
            foreach (XmlNode xmlNode in csNodes.Cast<XmlNode>())
            {
                string name = xmlNode.Attributes["name"].Value;
                string connectionString = xmlNode.Attributes["connectionString"].Value;
            }
        }
    }
}

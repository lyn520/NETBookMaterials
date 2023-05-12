using Microsoft.Extensions.Configuration;

namespace WebConfig配置源Demo
{
    public class WebConfigXmlConfigurationSource : FileConfigurationSource
    {
        public override IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new WebConfigXmlConfigurationProvider(this);
        }
    }
}

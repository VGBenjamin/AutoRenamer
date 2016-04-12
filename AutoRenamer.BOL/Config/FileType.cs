using System.Configuration;

namespace AutoRenamer.BOL.Config
{
    public class FileType : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get
            {
                return (string)base["name"];
            }
        }

        [ConfigurationProperty("extensions", IsRequired = true)]
        public string Extensions
        {
            get
            {
                return (string)base["extensions"];
            }
        }

        [ConfigurationProperty("checked", IsRequired = true)]
        public bool Checked
        {
            get
            {
                return (bool)base["checked"];
            }
        }
    }
}
using System.Configuration;

namespace AutoRenamer.BOL.Config
{
    public class FolderToWatch : ConfigurationElement
    {
        [ConfigurationProperty("source", IsRequired = true)]
        public string Source
        {
            get
            {
                return (string)base["source"];
            }
        }

        [ConfigurationProperty("destination", IsRequired = true)]
        public string Destination
        {
            get
            {
                return (string)base["destination"];
            }
        }
    }
}
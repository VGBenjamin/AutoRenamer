using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRenamer.BOL.Config
{
    public class AutoRenamerConfig : ConfigurationSection
    {
        public static AutoRenamerConfig Instance
        {
            get
            {
                return (AutoRenamerConfig)ConfigurationManager.GetSection("autorenamer");
            }
        }

        [ConfigurationProperty("treatedXMlPath", IsRequired = true)]
        public string TreatedXMlPath
        {
            get
            {
                return (string)base["treatedXMlPath"];
            }
        }

        [ConfigurationProperty("foldersToWatch")]
        public FoldersToWatchCollection FoldersToWatch
        {
            get
            {
                return (FoldersToWatchCollection)this["foldersToWatch"];
            }
        }

        [ConfigurationProperty("filebotExpression")]
        public ConfigurationTextElement<string> FilebotExpression { get { return (ConfigurationTextElement<string>)this["filebotExpression"]; } }

        [ConfigurationProperty("filesTypes")]
        public FilesTypesCollection FilesTypes
        {
            get
            {
                return (FilesTypesCollection)this["filesTypes"];
            }
        }

        [ConfigurationProperty("preferenceSettigns")]
        public ConfigurationTextElement<string> PreferenceSettigns { get { return (ConfigurationTextElement<string>)this["preferenceSettigns"]; } }
        
    }
}

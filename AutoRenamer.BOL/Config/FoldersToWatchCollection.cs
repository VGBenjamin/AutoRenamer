using System;
using System.Configuration;

namespace AutoRenamer.BOL.Config
{
    [ConfigurationCollection(
        typeof(FolderToWatch),
        AddItemName = "folderToWatch",
        CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class FoldersToWatchCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new FolderToWatch();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            if (element == null)
                throw new ArgumentNullException("element");

            return ((FolderToWatch)element).Source;
        }

        new public FolderToWatch this[string name]
        {
            get { return (FolderToWatch)BaseGet(name); }
        }
    }
}
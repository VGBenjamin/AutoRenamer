using System;
using System.Configuration;

namespace AutoRenamer.BOL.Config
{
    [ConfigurationCollection(
        typeof(FileType),
        AddItemName = "fileType",
        CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class FilesTypesCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new FileType();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            if (element == null)
                throw new ArgumentNullException("element");

            return ((FileType)element).Name;
        }

        new public FileType this[string name]
        {
            get { return (FileType)BaseGet(name); }
        }
    }
}
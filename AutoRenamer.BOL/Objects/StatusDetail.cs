using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using AutoRenamer.BOL.Config;

namespace AutoRenamer.BOL.Objects
{
    public class StatusDetail : IEquatable<StatusDetail>
    {
        [XmlAttribute]
        public Guid Id { get; }
        [XmlAttribute]
        public string SourceFile { get; set; }

        private string _sourceFileForDirectory;
        private string _sourceFileWithoutDirectory;

        public string SourceFileWithoutDirectory
        {
            get
            {
                if (SourceFile == null)
                    return null;

                if (SourceFile == _sourceFileForDirectory && !string.IsNullOrEmpty(_sourceFileWithoutDirectory)) //Caching
                    return _sourceFileWithoutDirectory;
                else
                {
                    _sourceFileForDirectory = SourceFile;
                    var source = SourceFile;
                    foreach (FolderToWatch folderPath in AutoRenamerConfig.Instance.FoldersToWatch)
                    {
                        source = source.Replace($"{folderPath.Source}\\", "");
                    }
                    _sourceFileWithoutDirectory = source;
                    return SourceFile;
                }
            }
        }


        [XmlAttribute]
        public string DestinationFile { get; set; }

        private string _destinationFileForDirectory;
        private string _destinationFileWithoutDirectory;

        public string DestinationFileWithoutDirectory
        {
            get
            {
                if (DestinationFile == null)
                    return null;

                if (DestinationFile == _destinationFileForDirectory && !string.IsNullOrEmpty(_destinationFileWithoutDirectory)) //Caching
                    return _destinationFileWithoutDirectory;
                else
                {
                    _destinationFileForDirectory = DestinationFile;
                    var dest = DestinationFile;
                    

                    foreach (FolderToWatch folderPath in AutoRenamerConfig.Instance.FoldersToWatch)
                    {
                        dest = dest.Replace($"{folderPath.Destination}\\", "");
                    }
                    _destinationFileWithoutDirectory = dest;
                    return dest;
                }
            }
        }

        [XmlAttribute]
        public string DestinationFolder { get; set; }
        [XmlAttribute]
        public StatusEnum Status { get; set; } = StatusEnum.NotSynched;
        [XmlAttribute]
        public string Reason { get; set; }
        [XmlAttribute]
        public DateTime SynchDate { get; set; }

        [XmlAttribute]
        public bool SourceFileStillExist { get; set; }

        public bool ReChecked { get; set; }

        public StatusDetail(Guid id)
        {
            Id = id;
        }

        public StatusDetail()
        {
            Id = Guid.NewGuid();
        }

        public bool Equals(StatusDetail other)
        {
            return Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AutoRenamer.BOL.Objects
{
    public class StatusDetail : IEquatable<StatusDetail>
    {
        [XmlAttribute]
        public Guid Id { get; }
        [XmlAttribute]
        public string SourceFile { get; set; }
        [XmlAttribute]
        public string DestinationFile { get; set; }
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

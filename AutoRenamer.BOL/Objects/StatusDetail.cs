using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AutoRenamer.BOL.Objects
{
    public class StatusDetail
    {
        [XmlAttribute]
        public Guid Id { get; set; }
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

    }
}

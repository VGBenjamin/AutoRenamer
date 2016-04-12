using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using AutoRenamer.BOL.Base;

namespace AutoRenamer.BOL.Objects
{
    [Serializable]
    [XmlRoot("Synchronization")]
    public class Synchronization : XmlSerializable<Synchronization>
    {
        [XmlArray]
        public BindingList<StatusDetail> StatusList { get; set; }

        public Synchronization()
        {
            StatusList = new BindingList<StatusDetail>();
        }

        public static new Synchronization DeserializeFromXml(string filePath)
        {
            return XmlSerializable<Synchronization>.DeserializeFromXml(filePath);
        }
    }
}

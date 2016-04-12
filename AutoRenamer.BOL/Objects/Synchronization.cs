using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using AutoRenamer.BOL.Base;
using AutoRenamer.BOL.Config;
using AutoRenamer.BOL.Objects.EventArgs;

namespace AutoRenamer.BOL.Objects
{
    [Serializable]
    [XmlRoot("Synchronization")]
    public class Synchronization : XmlSerializable<Synchronization>
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
 
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

        public void Save()
        {
            log.Info($"Saving the info into '{AutoRenamerConfig.Instance.TreatedXMlPath}'");
            SerializeToXml(AutoRenamerConfig.Instance.TreatedXMlPath);
            log.Info($"Saved!");
        }

    }
}

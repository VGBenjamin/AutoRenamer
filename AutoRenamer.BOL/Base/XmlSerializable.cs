using System.IO;
using System.Xml.Serialization;

namespace AutoRenamer.BOL.Base
{
    public abstract class XmlSerializable<T>
    {
        public static T DeserializeFromXml(string filePath)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var sr = new StreamReader(filePath))
            {
                return (T)serializer.Deserialize(sr);
            }                
        }

        public virtual void SerializeToXml(string filePath)
        {
            XmlSerializer xs = new XmlSerializer(typeof(T));
            using (StreamWriter wr = new StreamWriter(filePath))
            {
                xs.Serialize(wr, this);
                wr.Close();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace AutoRenamer.BOL.Utils
{
    public static class XmlSerializationHelper
    {
        public static string SerializeObject<T>(T obj)
        {
            string result;
            try
            {
                MemoryStream memoryStream = new MemoryStream();
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
                xmlSerializer.Serialize(xmlTextWriter, obj);
                memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
                result = XmlSerializationHelper.Utf8ByteArrayToString(memoryStream.ToArray());
            }
            catch
            {
                result = string.Empty;
            }
            return result;
        }

        public static T DeserializeObject<T>(string xml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            MemoryStream stream = new MemoryStream(XmlSerializationHelper.StringToUtf8ByteArray(xml));
            return (T)((object)xmlSerializer.Deserialize(stream));
        }

        private static string Utf8ByteArrayToString(byte[] characters)
        {
            UTF8Encoding uTF8Encoding = new UTF8Encoding();
            return uTF8Encoding.GetString(characters);
        }

        private static byte[] StringToUtf8ByteArray(string xmlString)
        {
            return xmlString.ToUtf8ByteArray();
        }

        public static byte[] ToUtf8ByteArray(this string original)
        {
            if (original == null)
            {
                throw new NullReferenceException("ToUtf8ByteArray - The original string cannot be null");
            }
            UTF8Encoding uTF8Encoding = new UTF8Encoding();
            return uTF8Encoding.GetBytes(original);
        }
    }
}

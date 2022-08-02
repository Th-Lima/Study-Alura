using System.Xml.Serialization;

namespace Adapter.Cap8
{
    public class GeradorXml
    {
        public string GeraXml(object o)
        {
            XmlSerializer serializer = new XmlSerializer(o.GetType());
            StringWriter writer = new StringWriter();
            serializer.Serialize(writer, o);
            
            return writer.ToString();
        }
    }
}

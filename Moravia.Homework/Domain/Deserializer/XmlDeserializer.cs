using System.Xml.Serialization;

using Moravia.Homework.Domain.Interfaces;

namespace Moravia.Homework.Domain.Deserializer;
public class XmlDeserializer : IDeserializer
{
    public T? Deserialize<T>(string data)
    {
        if (string.IsNullOrWhiteSpace(data))
        {
            return default;
        }

        var ser = new XmlSerializer(typeof(T));
        using var reader = new StringReader(data);

        return (T?)ser.Deserialize(reader);
    }
}

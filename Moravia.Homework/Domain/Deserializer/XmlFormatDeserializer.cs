using System.Xml.Serialization;

using Moravia.Homework.Domain.Interfaces;

namespace Moravia.Homework.Domain.Deserializer;
public class XmlFormatDeserializer : IDeserializer
{
    public T? Deserialize<T>(string data)
    {
        if (string.IsNullOrWhiteSpace(data))
        {
            return default;
        }

        var serializer = new XmlSerializer(typeof(T));
        using var reader = new StringReader(data.Trim());

        return (T?)serializer.Deserialize(reader);
    }
}

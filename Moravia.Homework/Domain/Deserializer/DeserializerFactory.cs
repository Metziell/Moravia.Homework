using Moravia.Homework.Domain.Interfaces;

namespace Moravia.Homework.Domain.Deserializer;
public class DeserializerFactory : IDeserializerFactory
{
    public IDeserializer Create(FileFormat fileFormat)
    {
        return fileFormat switch
        {
            FileFormat.Xml => new XmlFormatDeserializer(),
            FileFormat.Json => new JsonFormatDeserializer(),
            _ => throw new ArgumentOutOfRangeException(nameof(fileFormat))
        };
    }
}

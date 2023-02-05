using Moravia.Homework.Domain.Interfaces;

namespace Moravia.Homework.Domain.Deserializer;
public class DeserializerFactory : IDeserializerFactory
{
    public IDeserializer Create(FileFormat fileFormat)
    {
        return fileFormat switch
        {
            FileFormat.Xml => new XmlDeserializer(),
            FileFormat.Json => new JsonDeserializer(),
            _ => throw new ArgumentOutOfRangeException(nameof(fileFormat))
        };
    }
}

using Moravia.Homework.Domain.Interfaces;

namespace Moravia.Homework.Domain.Serializer;
public class SerializerFactory : ISerializerFactory
{
    public ISerializer Create(FileFormat fileFormat)
    {
        return fileFormat switch
        {
            FileFormat.Xml => new XmlFormatSerializer(),
            FileFormat.Json => new JsonFormatSerializer(),
            _ => throw new ArgumentOutOfRangeException(nameof(fileFormat))
        };
    }
}

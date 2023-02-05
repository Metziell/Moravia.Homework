using Microsoft.Extensions.Logging;

using Moravia.Homework.Domain.Interfaces;
using Moravia.Homework.Domain.Types;

namespace Moravia.Homework.Domain.Deserializer;
public class DeserializerFactory : IDeserializerFactory
{
    private readonly ILoggerFactory loggerFactory;

    public DeserializerFactory(ILoggerFactory loggerFactory)
    {
        this.loggerFactory = loggerFactory;
    }

    public IDeserializer Create(FileFormat fileFormat)
    {
        return fileFormat switch
        {
            FileFormat.Xml => new XmlFormatDeserializer(loggerFactory.CreateLogger<XmlFormatDeserializer>()),
            FileFormat.Json => new JsonFormatDeserializer(loggerFactory.CreateLogger<JsonFormatDeserializer>()),
            _ => throw new ArgumentOutOfRangeException(nameof(fileFormat))
        };
    }
}

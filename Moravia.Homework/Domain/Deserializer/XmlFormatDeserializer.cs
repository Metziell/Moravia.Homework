using System.Xml.Serialization;

using Microsoft.Extensions.Logging;

using Moravia.Homework.Domain.Interfaces;

namespace Moravia.Homework.Domain.Deserializer;
public class XmlFormatDeserializer : IDeserializer
{
    private readonly ILogger<XmlFormatDeserializer> logger;

    public XmlFormatDeserializer(ILogger<XmlFormatDeserializer> logger)
    {
        this.logger = logger;
    }

    public T? Deserialize<T>(string data)
    {
        if (string.IsNullOrWhiteSpace(data))
        {
            return default;
        }

        var serializer = new XmlSerializer(typeof(T));
        using var reader = new StringReader(data.Trim());

        try
        {
            return (T?)serializer.Deserialize(reader);
        }
        catch (InvalidOperationException ex)
        {
            logger.LogError(ex, "Failed to deserialize XML {data}", data);
            return default;
        }
    }
}

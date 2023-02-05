using Microsoft.Extensions.Logging;

using Moravia.Homework.Domain.Interfaces;

using Newtonsoft.Json;

namespace Moravia.Homework.Domain.Deserializer;
public class JsonFormatDeserializer : IDeserializer
{
    private readonly ILogger<JsonFormatDeserializer> logger;

    public JsonFormatDeserializer(ILogger<JsonFormatDeserializer> logger)
    {
        this.logger = logger;
    }

    public T? Deserialize<T>(string data)
    {
        if (string.IsNullOrWhiteSpace(data))
        {
            return default;
        }

        try
        {
            return JsonConvert.DeserializeObject<T>(data);
        }
        catch (JsonReaderException ex)
        {
            logger.LogError(ex, "Failed to deserialize JSON {data}", data);
            return default;
        }
    }
}

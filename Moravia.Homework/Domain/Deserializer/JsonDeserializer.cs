using Moravia.Homework.Domain.Interfaces;

using Newtonsoft.Json;

namespace Moravia.Homework.Domain.Deserializer;
public class JsonDeserializer : IDeserializer
{
    public T? Deserialize<T>(string data)
    {
        if (string.IsNullOrWhiteSpace(data))
        {
            return default;
        }

        return JsonConvert.DeserializeObject<T>(data);
    }
}

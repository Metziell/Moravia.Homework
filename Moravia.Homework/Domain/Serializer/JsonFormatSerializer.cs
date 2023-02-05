using Moravia.Homework.Domain.Interfaces;

using Newtonsoft.Json;

namespace Moravia.Homework.Domain.Serializer;

internal class JsonFormatSerializer : ISerializer
{
    public string Serialize<T>(T data)
    {
        if (data == null)
        {
            return string.Empty;
        }

        return JsonConvert.SerializeObject(data);
    }
}
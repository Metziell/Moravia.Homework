namespace Moravia.Homework.Domain.Interfaces;
public interface IDeserializer
{
    T? Deserialize<T>(string data);
}

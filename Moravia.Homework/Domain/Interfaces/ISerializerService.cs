namespace Moravia.Homework.Domain.Interfaces;
public interface ISerializerService
{
    void Serialize<T>(T data, SerializationContext context);
}
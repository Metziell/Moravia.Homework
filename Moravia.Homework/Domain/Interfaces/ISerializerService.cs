using Moravia.Homework.Domain.Types;

namespace Moravia.Homework.Domain.Interfaces;
public interface ISerializerService
{
    bool Serialize<T>(T data, SerializationContext context);
}
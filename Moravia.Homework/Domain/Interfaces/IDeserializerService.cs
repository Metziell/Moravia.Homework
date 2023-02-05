using Moravia.Homework.Domain.Types;
using Moravia.Homework.Infrastructure;

namespace Moravia.Homework.Domain.Interfaces;
public interface IDeserializerService
{
    T? Deserialize<T>(SerializationContext serializationContext);
}
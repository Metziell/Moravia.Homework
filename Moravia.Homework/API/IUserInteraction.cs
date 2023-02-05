using Moravia.Homework.Domain.Types;

namespace Moravia.Homework.API;
public interface IUserInteraction
{
    SerializationContext GetSourceSerializationContext();
    SerializationContext GetTargetSerializationContext();
    void PrintError(string message);
    void PrintResult(string message);
}
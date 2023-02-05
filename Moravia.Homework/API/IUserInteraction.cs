using Moravia.Homework.Domain;

namespace Moravia.Homework.API;
public interface IUserInteraction
{
    SerializationContext GetSourceSerializationContext();
    SerializationContext GetTargetSerializationContext();
    void PrintError(string message);
    void PrintResult(string message);
}
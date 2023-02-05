namespace Moravia.Homework.Domain.Interfaces;
public interface ISerializer
{
    string Serialize<T>(T data);
}

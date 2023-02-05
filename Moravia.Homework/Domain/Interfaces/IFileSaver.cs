namespace Moravia.Homework.Domain.Interfaces;
public interface IFileSaver
{
    bool SaveFileFromString(string path, string data);
}

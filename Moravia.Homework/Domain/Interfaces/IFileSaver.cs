namespace Moravia.Homework.Domain.Interfaces;
public interface IFileSaver
{
    void SaveFileFromString(string path, string data);
}

namespace Moravia.Homework.Domain.Interfaces;
public interface IFileLoader
{
    bool TryLoadFileAsString(string path, out string data);
}

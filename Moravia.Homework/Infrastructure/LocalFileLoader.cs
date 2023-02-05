using Moravia.Homework.Domain.Interfaces;

namespace Moravia.Homework.Infrastructure;
public class LocalFileLoader : IFileLoader
{
    public string LoadFileAsString(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            return string.Empty;
        }

        using var stream = File.Open(path, FileMode.Open);
        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }
}

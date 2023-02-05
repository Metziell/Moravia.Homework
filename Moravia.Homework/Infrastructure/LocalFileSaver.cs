using Moravia.Homework.Domain.Interfaces;

namespace Moravia.Homework.Infrastructure;
public class LocalFileSaver : IFileSaver
{
    public void SaveFileFromString(string path, string data)
    {
        if (string.IsNullOrWhiteSpace(path) || string.IsNullOrWhiteSpace(data))
        {
            return;
        }

        using var stream = File.Open(path, FileMode.Create, FileAccess.Write);
        using var writer = new StreamWriter(stream);
        writer.Write(data);
    }
}

using Microsoft.Extensions.Logging;

using Moravia.Homework.Domain.Interfaces;

namespace Moravia.Homework.Infrastructure;
public class LocalFileSaver : IFileSaver
{
    private readonly ILogger<LocalFileSaver> logger;

    public LocalFileSaver(ILogger<LocalFileSaver> logger)
    {
        this.logger = logger;
    }

    public bool SaveFileFromString(string path, string data)
    {
        if (string.IsNullOrWhiteSpace(path) || string.IsNullOrWhiteSpace(data))
        {
            return false;
        }

        try 
        { 
            using var stream = File.Open(path, FileMode.Create, FileAccess.Write);
            using var writer = new StreamWriter(stream);
            writer.Write(data);

            return true;
        }
        catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException || ex is FileNotFoundException)
        {
            logger.LogError(ex, "Couldn't read data file");
            return false;
        }
    }
}

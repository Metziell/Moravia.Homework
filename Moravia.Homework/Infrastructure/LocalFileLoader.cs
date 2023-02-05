using Microsoft.Extensions.Logging;

using Moravia.Homework.Domain.Interfaces;

namespace Moravia.Homework.Infrastructure;
public class LocalFileLoader : IFileLoader
{
    private readonly ILogger<LocalFileLoader> logger;

    public LocalFileLoader(ILogger<LocalFileLoader> logger)
    {
        this.logger = logger;
    }

    public string LoadFileAsString(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            return string.Empty;
        }

        try
        {
            using var stream = File.Open(path, FileMode.Open);
            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }
        catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException || ex is FileNotFoundException)
        {
            logger.LogError(ex, "Couldn't read data file");
            return string.Empty;
        }
    }
}

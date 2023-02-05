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

    public bool TryLoadFileAsString(string path, out string data)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            data = default!;
            return false;
        }

        try
        {
            using var stream = File.Open(path, FileMode.Open);
            using var reader = new StreamReader(stream);
            
            data = reader.ReadToEnd();
            return true;
        }
        catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException || ex is FileNotFoundException)
        {
            logger.LogError(ex, "Couldn't read data file at local path {path}", path);
            data = default!;
            return false;
        }
    }
}

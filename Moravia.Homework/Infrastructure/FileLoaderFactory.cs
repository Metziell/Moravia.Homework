using Microsoft.Extensions.Logging;

using Moravia.Homework.Domain.Interfaces;
using Moravia.Homework.Domain.Types;

namespace Moravia.Homework.Infrastructure;
public class FileLoaderFactory : IFileLoaderFactory
{
    private readonly ILoggerFactory loggerFactory;

    public FileLoaderFactory(ILoggerFactory loggerFactory)
    {
        this.loggerFactory = loggerFactory;
    }

    public IFileLoader Create(LocationType locationType)
    {
        return locationType switch
        {
            LocationType.Local => new LocalFileLoader(loggerFactory.CreateLogger<LocalFileLoader>()),
            LocationType.Cloud => throw new NotImplementedException(),
            LocationType.Http => throw new NotImplementedException(),
            _ => throw new NotImplementedException(nameof(locationType))
        };
    }
}
using Microsoft.Extensions.Logging;

using Moravia.Homework.Domain.Interfaces;
using Moravia.Homework.Domain.Types;

namespace Moravia.Homework.Infrastructure;
public class FileSaverFactory : IFileSaverFactory
{
    private readonly ILoggerFactory loggerFactory;

    public FileSaverFactory(ILoggerFactory loggerFactory)
    {
        this.loggerFactory = loggerFactory;
    }

    public IFileSaver Create(LocationType locationType)
    {
        return locationType switch
        {
            LocationType.Local => new LocalFileSaver(loggerFactory.CreateLogger<LocalFileSaver>()),
            LocationType.Cloud => throw new NotImplementedException(),
            LocationType.Http => throw new NotImplementedException(),
            _ => throw new NotImplementedException(nameof(locationType)),
        };
    }
}

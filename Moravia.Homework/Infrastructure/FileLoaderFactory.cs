using Moravia.Homework.Domain;
using Moravia.Homework.Domain.Interfaces;

namespace Moravia.Homework.Infrastructure;
public class FileLoaderFactory : IFileLoaderFactory
{
    public IFileLoader Create(LocationType locationType)
    {
        return locationType switch
        {
            LocationType.Local => new LocalFileLoader(),
            LocationType.Cloud => throw new NotImplementedException(),
            LocationType.Http => throw new NotImplementedException(),
            _ => throw new NotImplementedException(nameof(locationType))
        };
    }
}
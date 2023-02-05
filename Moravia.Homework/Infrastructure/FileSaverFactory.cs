using Moravia.Homework.Domain.Interfaces;
using Moravia.Homework.Domain.Types;

namespace Moravia.Homework.Infrastructure;
public class FileSaverFactory : IFileSaverFactory
{
    public IFileSaver Create(LocationType locationType)
    {
        return locationType switch
        {
            LocationType.Local => new LocalFileSaver(),
            LocationType.Cloud => throw new NotImplementedException(),
            LocationType.Http => throw new NotImplementedException(),
            _ => throw new NotImplementedException(nameof(locationType)),
        };
    }
}

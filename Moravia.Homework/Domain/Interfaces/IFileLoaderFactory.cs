using Moravia.Homework.Domain.Types;

namespace Moravia.Homework.Domain.Interfaces;
public interface IFileLoaderFactory
{
    IFileLoader Create(LocationType locationType);
}

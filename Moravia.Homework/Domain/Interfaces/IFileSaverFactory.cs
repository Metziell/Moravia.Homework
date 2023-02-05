using Moravia.Homework.Domain.Types;

namespace Moravia.Homework.Domain.Interfaces;
public interface IFileSaverFactory
{
    IFileSaver Create(LocationType locationType);
}

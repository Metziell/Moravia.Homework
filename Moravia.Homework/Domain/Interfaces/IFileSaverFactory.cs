using Moravia.Homework.Infrastructure;

namespace Moravia.Homework.Domain.Interfaces;
internal interface IFileSaverFactory
{
    IFileSaver Create(LocationType locationType);
}

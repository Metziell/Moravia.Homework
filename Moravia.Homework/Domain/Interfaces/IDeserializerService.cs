using Moravia.Homework.Domain;
using Moravia.Homework.Infrastructure;

namespace Moravia.Homework.Domain.Interfaces;
public interface IDeserializerService
{
    T? Deserialize<T>(string path, LocationType locationType, FileFormat fileFormat);
}
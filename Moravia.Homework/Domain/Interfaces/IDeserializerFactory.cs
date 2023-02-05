using Moravia.Homework.Domain.Types;

namespace Moravia.Homework.Domain.Interfaces;
public interface IDeserializerFactory
{
    IDeserializer Create(FileFormat fileFormat);
}
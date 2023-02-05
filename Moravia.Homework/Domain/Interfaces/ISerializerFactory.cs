namespace Moravia.Homework.Domain.Interfaces;
public interface ISerializerFactory
{
    ISerializer Create(FileFormat fileFormat);
}
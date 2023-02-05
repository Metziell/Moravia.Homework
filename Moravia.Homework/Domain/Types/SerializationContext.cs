namespace Moravia.Homework.Domain.Types;
public record SerializationContext(
    string FileName,
    LocationType Location,
    FileFormat Format);
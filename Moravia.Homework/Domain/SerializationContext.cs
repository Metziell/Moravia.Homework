namespace Moravia.Homework.Domain;
public record SerializationContext(
    string FileName,
    LocationType Location,
    FileFormat Format);
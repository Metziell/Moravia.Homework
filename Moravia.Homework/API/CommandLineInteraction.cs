using Moravia.Homework.Domain.Types;

namespace Moravia.Homework.API;
public class CommandLineInteraction : IUserInteraction
{
    public SerializationContext GetSourceSerializationContext()
    {
        Console.WriteLine("Provide source file name:");
        var filename = GetFileName();
        var location = GetLocationType();
        var format = GetFileFormat();

        return new(filename, location, format);
    }

    public SerializationContext GetTargetSerializationContext()
    {
        Console.WriteLine("Provide target file name:");
        var filename = GetFileName();
        var location = GetLocationType();
        var format = GetFileFormat();

        return new(filename, location, format);
    }

    private LocationType GetLocationType()
    {
        Console.WriteLine("Provide location type (local):");
        var input = Console.ReadLine();

        return input?.ToLower() switch
        {
            "local" => LocationType.Local,
            _ => throw new ValidationException($"Invalid location type: {input}")
        };
    }

    private FileFormat GetFileFormat()
    {
        Console.WriteLine("Provide file format (XML, JSON):");
        var input = Console.ReadLine();

        return input?.ToLower() switch
        {
            "xml" => FileFormat.Xml,
            "json" => FileFormat.Json,
            _ => throw new ValidationException($"Invalid file format: {input}")
        };
    }

    private string GetFileName()
    {
        var input = Console.ReadLine();

        if (Uri.TryCreate(input, UriKind.RelativeOrAbsolute, out _))
        {
            return input;
        }

        throw new ValidationException($"Invalid file name: {input}");
    }

    public void PrintError(string message, bool moreInfoInLogs = true)
    {
        Console.WriteLine($"Format conversion failed: {message}");
        
        if (moreInfoInLogs)
        {
            Console.WriteLine("See logs for more information.");
        }
    }

    public void PrintResult(string message) => Console.WriteLine(message);
}

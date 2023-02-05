using Moravia.Homework.Domain;
using Moravia.Homework.Infrastructure;

namespace Moravia.Homework;
internal static class UserInteraction
{    
    public static LocationType GetLocationType()
    {
        Console.WriteLine("Provide location type (local, cloud, HTTP):");
        var input = Console.ReadLine();

        return input?.ToLower() switch
        {
            "local" => LocationType.Local,
            "cloud" => LocationType.Cloud,
            "http" => LocationType.Http,
            _ => throw new ValidationException($"Invalid location type: {input}")
        };     
    } 

    public static FileFormat GetFileFormat()
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

    public static string GetSourceFileName()
    {
        Console.WriteLine("Location of source file:");
        var input = Console.ReadLine();
        
        if (File.Exists(input))
        {
            return input;
        }
            
        throw new ValidationException($"Invalid source path: {input}");
    }

    public static string GetTargetFileName()
    {
        Console.WriteLine("Location of target file:");
        var input = Console.ReadLine();
        
        if (Uri.TryCreate(input, UriKind.RelativeOrAbsolute, out _)
            && !string.IsNullOrWhiteSpace(Path.GetFileNameWithoutExtension(input))
            && !string.IsNullOrWhiteSpace(Path.GetExtension(input))
            && Directory.Exists(Path.GetDirectoryName(input)))
        {
            return input;
        }

        throw new ValidationException($"Invalid target path: {input}");
    }

    public static void PrintError(string message) => Console.WriteLine($"Format conversion failed: {message}");
}

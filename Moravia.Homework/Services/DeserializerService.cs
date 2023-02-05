using Microsoft.Extensions.Logging;

using Moravia.Homework.Domain;
using Moravia.Homework.Domain.Interfaces;
using Moravia.Homework.Infrastructure;

namespace Moravia.Homework.Services;
public class DeserializerService : IDeserializerService
{
    private readonly IFileLoaderFactory fileLoaderFactory;
    private readonly IDeserializerFactory deserializerFactory;
    private readonly ILogger<DeserializerService> logger;

    public DeserializerService(IFileLoaderFactory fileLoaderFactory, IDeserializerFactory deserializerFactory, ILogger<DeserializerService> logger)
    {
        this.fileLoaderFactory = fileLoaderFactory;
        this.deserializerFactory = deserializerFactory;
        this.logger = logger;
    }

    public T? Deserialize<T>(string path, LocationType locationType, FileFormat fileFormat)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            logger.LogError("Source path is empty");
            return default;
        }

        var fileLoader = fileLoaderFactory.Create(locationType);
        var data = fileLoader.LoadFileAsString(path);

        if (string.IsNullOrWhiteSpace(data))
        {
            logger.LogError("Source file is empty");
            return default;
        }

        var formatDeserializer = deserializerFactory.Create(fileFormat);
        return formatDeserializer.Deserialize<T>(data);
    }
}

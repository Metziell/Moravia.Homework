using Microsoft.Extensions.Logging;
using Moravia.Homework.Domain.Interfaces;
using Moravia.Homework.Domain.Types;

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

    public T? Deserialize<T>(SerializationContext context)
    {
        if (string.IsNullOrWhiteSpace(context.FileName))
        {
            logger.LogError("Source path is empty");
            return default;
        }

        var fileLoader = fileLoaderFactory.Create(context.Location);
        var dataString = fileLoader.LoadFileAsString(context.FileName);

        if (string.IsNullOrWhiteSpace(dataString))
        {
            logger.LogError("Source file is empty");
            return default;
        }

        var formatDeserializer = deserializerFactory.Create(context.Format);
        return formatDeserializer.Deserialize<T>(dataString);
    }
}

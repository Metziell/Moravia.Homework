using Microsoft.Extensions.Logging;

using Moravia.Homework.Domain;
using Moravia.Homework.Domain.Interfaces;

namespace Moravia.Homework.Services;
public class SerializerService : ISerializerService
{
    private readonly ILogger<SerializerService> logger;
    private readonly ISerializerFactory serializerFactory;
    private readonly IFileSaverFactory fileSaverFactory;

    public SerializerService(ILogger<SerializerService> logger, ISerializerFactory serializerFactory, IFileSaverFactory fileSaverFactory)
    {
        this.logger = logger;
        this.serializerFactory = serializerFactory;
        this.fileSaverFactory = fileSaverFactory;
    }

    public void Serialize<T>(T data, string path, LocationType locationType, FileFormat fileFormat)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            logger.LogError("Target path is empty");
            return;
        }

        var serializer = serializerFactory.Create(fileFormat);
        var dataString = serializer.Serialize(data);
        if (string.IsNullOrWhiteSpace(dataString))
        {
            logger.LogError("Serialized data is empty");
            return;
        }

        var fileSaver = fileSaverFactory.Create(locationType);
        fileSaver.SaveFileFromString(path, dataString);
    }
}

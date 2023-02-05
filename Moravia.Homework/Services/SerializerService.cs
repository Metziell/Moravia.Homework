using Microsoft.Extensions.Logging;
using Moravia.Homework.Domain.Interfaces;
using Moravia.Homework.Domain.Types;

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

    public bool Serialize<T>(T data, SerializationContext context)
    {
        ArgumentNullException.ThrowIfNull(context, nameof(context));

        if (string.IsNullOrWhiteSpace(context.FileName))
        {
            logger.LogError("Target path is empty");
            return false;
        }

        var serializer = serializerFactory.Create(context.Format);
        var dataString = serializer.Serialize(data);
        if (string.IsNullOrWhiteSpace(dataString))
        {
            logger.LogError("Serialized data is empty");
            return false;
        }

        var fileSaver = fileSaverFactory.Create(context.Location);
        fileSaver.SaveFileFromString(context.FileName, dataString);

        return true;
    }
}

using Microsoft.Extensions.Logging;
using Moravia.Homework.Domain.Interfaces;
using Moravia.Homework.Domain;

namespace Moravia.Homework;
internal class Executor
{
    private readonly ILogger<Executor> logger;
    private readonly IDeserializerService deserializerService;
    private readonly ISerializerService serializerService;
    private readonly IUserInteraction userInteraction;

    public Executor(ILogger<Executor> logger, IDeserializerService deserializerService, ISerializerService serializerService)
    {
        this.logger = logger;
        this.deserializerService = deserializerService;
        this.serializerService = serializerService;
    }

    public void Execute()
    {
        try
        {
            logger.LogInformation("test");
            var source = UserInteraction.GetSourceFileName();
            var sourceLocation = UserInteraction.GetLocationType();
            var sourceFormat = UserInteraction.GetFileFormat();

            var document = deserializerService.Deserialize<Document>(source, sourceLocation, sourceFormat);
            if (document == null)
            {
                UserInteraction.PrintError("Couldn't parse source file.");
                return;
            }

            var target = UserInteraction.GetTargetFileName();
            var targetLocation = UserInteraction.GetLocationType();
            var targetFormat = UserInteraction.GetFileFormat();

            serializerService.Serialize(document, target, targetLocation, targetFormat);
        }
        catch (Exception e)
        {
            UserInteraction.PrintError(e.Message);
            logger.LogError(e, "Format conversion failed");
        }
    }
}

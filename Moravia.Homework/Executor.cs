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
            var sourceContext = UserInteraction.GetSourceSerializationContext();

            var document = deserializerService.Deserialize<Document>(sourceContext);
            if (document == null)
            {
                UserInteraction.PrintError("Couldn't parse source file.");
                return;
            }

            var targetContext = UserInteraction.GetTargetSerializationContext();

            serializerService.Serialize(document, targetContext);
        }
        catch (Exception e)
        {
            UserInteraction.PrintError(e.Message);
            logger.LogError(e, "Format conversion failed");
        }
    }
}

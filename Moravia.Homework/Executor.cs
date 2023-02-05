using Microsoft.Extensions.Logging;
using Moravia.Homework.Domain.Interfaces;
using Moravia.Homework.Domain;
using Moravia.Homework.API;

namespace Moravia.Homework;
internal class Executor
{
    private readonly ILogger<Executor> logger;
    private readonly IDeserializerService deserializerService;
    private readonly ISerializerService serializerService;
    private readonly IUserInteraction userInteraction;

    public Executor(ILogger<Executor> logger, IDeserializerService deserializerService, ISerializerService serializerService, IUserInteraction userInteraction)
    {
        this.logger = logger;
        this.deserializerService = deserializerService;
        this.serializerService = serializerService;
        this.userInteraction = userInteraction;
    }

    public void Execute()
    {
        try
        {
            var sourceContext = userInteraction.GetSourceSerializationContext();

            var document = deserializerService.Deserialize<Document>(sourceContext);
            if (document == null)
            {
                userInteraction.PrintError("Couldn't parse source file.");
                return;
            }

            var targetContext = userInteraction.GetTargetSerializationContext();

            serializerService.Serialize(document, targetContext);
        }
        catch (Exception e)
        {
            userInteraction.PrintError(e.Message);
            logger.LogError(e, "Format conversion failed");
        }
    }
}

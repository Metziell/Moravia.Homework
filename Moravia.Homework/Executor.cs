using Microsoft.Extensions.Logging;
using Moravia.Homework.Domain.Interfaces;
using Moravia.Homework.API;
using Moravia.Homework.Domain.Types;

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
            SerializationContext sourceContext;
            try 
            { 
                sourceContext = userInteraction.GetSourceSerializationContext();
            }
            catch (ValidationException ex)
            {
                userInteraction.PrintError($"Invalid source data: {ex.Message}");
                return;
            }

            var document = deserializerService.Deserialize<Document>(sourceContext);
            if (document == null)
            {
                userInteraction.PrintError("Couldn't parse source file.");
                return;
            }

            SerializationContext targetContext;
            try
            {
                targetContext = userInteraction.GetTargetSerializationContext();
            }
            catch (ValidationException ex)
            {
                userInteraction.PrintError($"Invalid target data: {ex.Message}");
                return;
            }

            var success = serializerService.Serialize(document, targetContext);
            if (!success) 
            {
                userInteraction.PrintError("Couldn't create target file.");
                return;
            }

            userInteraction.PrintResult("Format conversion successful.");
        }
        catch (Exception e)
        {
            userInteraction.PrintError("Unexpected error.");
            logger.LogError(e, "Format conversion failed");
        }
    }
}

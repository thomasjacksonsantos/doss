using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using MediatR;
using System.Text.Json;
using Doss.Core.Commands.Files;

namespace Doss.Functions;

public class UploadAudioServiceBusTrigger
{
    private readonly IMediator mediator;

    public UploadAudioServiceBusTrigger(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [Function(nameof(UploadAudioServiceBusTrigger))]
    public async Task RunAsync([ServiceBusTrigger("sbq-upload-audio", Connection = "ServiceBusConnection")] string message, FunctionContext context)
    {
        var logger = context.GetLogger(nameof(UploadAudioServiceBusTrigger));

        logger.LogInformation($"{nameof(UploadAudioServiceBusTrigger)} - Start Processing: {message}");

        var request = JsonSerializer.Deserialize<UploadAudioCommand>(message)!;

        var result = await mediator.Send(request);

        logger.LogInformation($"{nameof(UploadAudioServiceBusTrigger)} - result {JsonSerializer.Serialize(result)} End Processing");
    }
}
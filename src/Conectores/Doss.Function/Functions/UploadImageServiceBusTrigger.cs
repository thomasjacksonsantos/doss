using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using MediatR;
using System.Text.Json;
using Doss.Core.Commands.Files;

namespace Doss.Functions;

public class UploadImageServiceBusTrigger
{
    private readonly IMediator mediator;

    public UploadImageServiceBusTrigger(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [Function(nameof(UploadImageServiceBusTrigger))]
    public async Task RunAsync([ServiceBusTrigger("sbq-upload-image", Connection = "ServiceBusConnection")] string message, FunctionContext context)
    {
        var logger = context.GetLogger(nameof(UploadImageServiceBusTrigger));

        logger.LogInformation($"{nameof(UploadImageServiceBusTrigger)} - Start Processing: {message}");

        var request = JsonSerializer.Deserialize<UploadImageCommand>(message)!;

        var result = await mediator.Send(request);

        logger.LogInformation($"{nameof(UploadImageServiceBusTrigger)} - result {JsonSerializer.Serialize(result)} End Processing");
    }
}
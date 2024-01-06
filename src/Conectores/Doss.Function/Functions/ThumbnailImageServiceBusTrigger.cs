using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using MediatR;

namespace Guruja.AzureFunctions.Functions.Students;

public class ThumbnailImageServiceBusTrigger
{
    private readonly IMediator mediator;

    public ThumbnailImageServiceBusTrigger(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [Function(nameof(ThumbnailImageServiceBusTrigger))]
    public async Task RunAsync([ServiceBusTrigger("sbq-notify-program-closed", Connection = "ServiceBusConnection")] string message, FunctionContext context)
    {
        var logger = context.GetLogger(nameof(ThumbnailImageServiceBusTrigger));

        logger.LogInformation($"{nameof(ThumbnailImageServiceBusTrigger)} - Start Processing: {message}");

        // var request = JsonSerializer.Deserialize<NotifyProgramClosedRequest>(message)!;

        // var result = await mediator.Send<EventResponse<NotifyProgramClosedRequest.Response>>(request);

        // logger.LogInformation($"{nameof(ThumbnailImageServiceBusTrigger)} - result {result} End Processing");
    }
}
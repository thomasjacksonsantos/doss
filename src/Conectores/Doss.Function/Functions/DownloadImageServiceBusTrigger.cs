using System.Net;
using Doss.Core.Queries.Files;
using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Doss.Function
{
    public class DownloadImageServiceBusTrigger
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public DownloadImageServiceBusTrigger(IMediator mediator, ILoggerFactory loggerFactory)
        {
            _mediator = mediator;
            _logger = loggerFactory.CreateLogger<DownloadImageServiceBusTrigger>();
        }

        [Function("DownloadImageServiceBusTrigger")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
        {
            try
            {

                _logger.LogInformation("C# HTTP trigger function processed a request.");
                var filename = req.Query["filename"]!;

                var result = await _mediator.Send(new DownloadFilesQuery(filename));

                var response = req.CreateResponse(HttpStatusCode.OK);
                response.WriteBytes(result.Data!.Files);
                response.Headers.Add("Content-Type", "image/jpeg; charset=utf-8");

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(JsonConvert.SerializeObject(ex));
                throw;
            }
        }
    }
}

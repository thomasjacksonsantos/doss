using System.Net;
using Doss.Core.Queries.Files;
using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using NAudio.Wave;
using Newtonsoft.Json;

namespace Doss.Function
{
    public class DownloadAudioServiceBusTrigger
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public DownloadAudioServiceBusTrigger(IMediator mediator, ILoggerFactory loggerFactory)
        {
            _mediator = mediator;
            _logger = loggerFactory.CreateLogger<DownloadAudioServiceBusTrigger>();
        }

        [Function("DownloadAudioServiceBusTrigger")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
        {
            try
            {

                _logger.LogInformation("C# HTTP trigger function processed a request.");
                var filename = req.Query["filename"]!;

                var result = await _mediator.Send(new DownloadFilesQuery(filename));

                var response = req.CreateResponse(HttpStatusCode.OK);
                response.WriteBytes(ObterDadosDoAudio(result.Data!.Files));
                // response.Headers.Add("Content-Disposition", "attachment; filename=audio.m4a");
                response.Headers.Add("Content-Type", "audio/m4a");

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(JsonConvert.SerializeObject(ex));
                throw;
            }
        }

        private byte[] ObterDadosDoAudio(byte[] files)
        {
            // Implementar a lógica para obter ou gerar dados do áudio
            // Por exemplo, você pode usar a biblioteca NAudio para gerar um áudio simples.
            // Aqui está um exemplo básico para ilustrar:

            using (var ms = new MemoryStream(files))
            {
                using (var writer = new WaveFileWriter(ms, new WaveFormat()))
                {
                    // Adicione dados de áudio aqui
                    // Exemplo: writer.WriteSamples(seuAudioData, 0, seuAudioData.Length);
                }
                return ms.ToArray();
            }
        }
    }
}

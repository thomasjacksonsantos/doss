using Doss.Core.Interfaces.Repositories;
using Doss.Core.Domain.Addresses;
using Doss.Core.Domain.Settings;
using Doss.Infra.Seedwork;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Doss.Infra.Repositories;

public class ZipCodeRepository : BaseHttpRepository, IZipCodeRepository
{
    private readonly AppSettings appSettings;
    public ZipCodeRepository(IHttpClientFactory factory, IOptions<AppSettings> appSettings)
        : base(factory, appSettings.Value.Cep.ServiceName)
            => this.appSettings = appSettings.Value;

    public async Task<ZipCode> SearchByZipCode(string zipCode)
    {
        AddToken();
            var response = await Client.GetAsync($"api/v3/cep?cep={zipCode.RemoveSpecialCharacter()}");
            return Deserialize<ZipCode>(await response.Content.ReadAsStringAsync()) ?? null!;
    }

        T? Deserialize<T>(string content)
            => JsonConvert.DeserializeObject<T>(content);

        void AddToken()
            => Client.DefaultRequestHeaders.Add("Authorization", $"Token token={GetToken()}");

        string GetToken()
            => appSettings.Cep.Token;
}
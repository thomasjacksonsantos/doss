using System.Threading;
using System.Threading.Tasks;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using MediatR;

namespace Doss.Core.Queries.ZipCode.Handlers;

public class ZipCodeQueryHandler : IRequestHandler<ZipCodeQuery, Result<ZipCodeQuery.Response>>
{
    private readonly IZipCodeRepository zipCodeRepository;

    public ZipCodeQueryHandler(IZipCodeRepository zipCodeRepository)
        => this.zipCodeRepository = zipCodeRepository;

    public async Task<Result<ZipCodeQuery.Response>> Handle(ZipCodeQuery query, CancellationToken cancellationToken)
    {
        var address = await zipCodeRepository.SearchByZipCode(query.Code);

        if (address.IsNull())
            return Results.Error<ZipCodeQuery.Response>("Code not found.");

        return Results.Ok(new ZipCodeQuery.Response(new ZipCodeQuery.State(address.Estado.Sigla),
                                                 new ZipCodeQuery.City(address.Cidade.Ibge, address.Cidade.Nome, address.Cidade.DDD),
                                                 address.Cep,
                                                 address.Bairro,
                                                 address.Logradouro,
                                                 address.Complemento,
                                                 address.Altitude,
                                                 address.Latitude,
                                                 address.Longitude));
    }
}
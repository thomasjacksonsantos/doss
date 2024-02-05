using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using MediatR;

namespace Doss.Core.Queries.Contacts.Handlers;

public class ResidentialContactsQueryHandler : IRequestHandler<ResidentialContactsQuery, Result<ResidentialContactsQuery.Response>>
{
    private readonly IResidentialRepository residentialRepository;

    public ResidentialContactsQueryHandler(IResidentialRepository residentialRepository)
        => this.residentialRepository = residentialRepository;

    public async Task<Result<ResidentialContactsQuery.Response>> Handle(ResidentialContactsQuery query, CancellationToken cancellationToken)
    {
        return Results.Ok(new ResidentialContactsQuery.Response(new List<ResidentialContactsQuery.Contact>{
            new ResidentialContactsQuery.Contact(Guid.NewGuid(), "Thomas Jackson", "5519994282237", "https://func-doss.azurewebsites.net/api/DownloadImageServiceBusTrigger?filename=/vehicle/image/a52cb71a-27f5-4e9d-8ace-9b3407b969c1"),
            new ResidentialContactsQuery.Contact(Guid.NewGuid(), "Eduardo dos Santos", "5519994282237", "https://func-doss.azurewebsites.net/api/DownloadImageServiceBusTrigger?filename=/vehicle/image/a52cb71a-27f5-4e9d-8ace-9b3407b969c1"),
            new ResidentialContactsQuery.Contact(Guid.NewGuid(), "Abrar Ahmad", "5519994282237", "https://func-doss.azurewebsites.net/api/DownloadImageServiceBusTrigger?filename=/vehicle/image/a52cb71a-27f5-4e9d-8ace-9b3407b969c1"),
            new ResidentialContactsQuery.Contact(Guid.NewGuid(), "Maria Silva", "5519994282237", "https://func-doss.azurewebsites.net/api/DownloadImageServiceBusTrigger?filename=/vehicle/image/a52cb71a-27f5-4e9d-8ace-9b3407b969c1"),
            new ResidentialContactsQuery.Contact(Guid.NewGuid(), "Saul", "5519994282237", "https://func-doss.azurewebsites.net/api/DownloadImageServiceBusTrigger?filename=/vehicle/image/a52cb71a-27f5-4e9d-8ace-9b3407b969c1"),
            new ResidentialContactsQuery.Contact(Guid.NewGuid(), "David", "5519994282237", "https://func-doss.azurewebsites.net/api/DownloadImageServiceBusTrigger?filename=/vehicle/image/a52cb71a-27f5-4e9d-8ace-9b3407b969c1"),
            new ResidentialContactsQuery.Contact(Guid.NewGuid(), "Carlos Moura", "5519994282237", "https://func-doss.azurewebsites.net/api/DownloadImageServiceBusTrigger?filename=/vehicle/image/a52cb71a-27f5-4e9d-8ace-9b3407b969c1"),
            new ResidentialContactsQuery.Contact(Guid.NewGuid(), "Daniel Dias", "5519994282237", "https://func-doss.azurewebsites.net/api/DownloadImageServiceBusTrigger?filename=/vehicle/image/a52cb71a-27f5-4e9d-8ace-9b3407b969c1"),
            new ResidentialContactsQuery.Contact(Guid.NewGuid(), "Antonio", "5519994282237", "https://func-doss.azurewebsites.net/api/DownloadImageServiceBusTrigger?filename=/vehicle/image/a52cb71a-27f5-4e9d-8ace-9b3407b969c1"),
            new ResidentialContactsQuery.Contact(Guid.NewGuid(), "Roberto", "5519994282237", "https://func-doss.azurewebsites.net/api/DownloadImageServiceBusTrigger?filename=/vehicle/image/a52cb71a-27f5-4e9d-8ace-9b3407b969c1"),
            new ResidentialContactsQuery.Contact(Guid.NewGuid(), "Fatima", "5519994282237", "https://func-doss.azurewebsites.net/api/DownloadImageServiceBusTrigger?filename=/vehicle/image/a52cb71a-27f5-4e9d-8ace-9b3407b969c1"),
            new ResidentialContactsQuery.Contact(Guid.NewGuid(), "Silvia", "5519994282237", "https://func-doss.azurewebsites.net/api/DownloadImageServiceBusTrigger?filename=/vehicle/image/a52cb71a-27f5-4e9d-8ace-9b3407b969c1"),
            new ResidentialContactsQuery.Contact(Guid.NewGuid(), "Douglas", "5519994282237", "https://func-doss.azurewebsites.net/api/DownloadImageServiceBusTrigger?filename=/vehicle/image/a52cb71a-27f5-4e9d-8ace-9b3407b969c1"),
            new ResidentialContactsQuery.Contact(Guid.NewGuid(), "Maicom", "5519994282237", "https://func-doss.azurewebsites.net/api/DownloadImageServiceBusTrigger?filename=/vehicle/image/a52cb71a-27f5-4e9d-8ace-9b3407b969c1"),
            new ResidentialContactsQuery.Contact(Guid.NewGuid(), "Marta", "5519994282237", "https://func-doss.azurewebsites.net/api/DownloadImageServiceBusTrigger?filename=/vehicle/image/a52cb71a-27f5-4e9d-8ace-9b3407b969c1"),
            new ResidentialContactsQuery.Contact(Guid.NewGuid(), "Madalena", "5519994282237", "https://func-doss.azurewebsites.net/api/DownloadImageServiceBusTrigger?filename=/vehicle/image/a52cb71a-27f5-4e9d-8ace-9b3407b969c1"),
            new ResidentialContactsQuery.Contact(Guid.NewGuid(), "Silvano", "5519994282237", "https://func-doss.azurewebsites.net/api/DownloadImageServiceBusTrigger?filename=/vehicle/image/a52cb71a-27f5-4e9d-8ace-9b3407b969c1"),
            new ResidentialContactsQuery.Contact(Guid.NewGuid(), "Robert", "5519994282237", "https://func-doss.azurewebsites.net/api/DownloadImageServiceBusTrigger?filename=/vehicle/image/a52cb71a-27f5-4e9d-8ace-9b3407b969c1"),
            new ResidentialContactsQuery.Contact(Guid.NewGuid(), "Elias", "5519994282237", "https://func-doss.azurewebsites.net/api/DownloadImageServiceBusTrigger?filename=/vehicle/image/a52cb71a-27f5-4e9d-8ace-9b3407b969c1"),
            new ResidentialContactsQuery.Contact(Guid.NewGuid(), "Thais", "5519994282237", "https://func-doss.azurewebsites.net/api/DownloadImageServiceBusTrigger?filename=/vehicle/image/a52cb71a-27f5-4e9d-8ace-9b3407b969c1"),
            new ResidentialContactsQuery.Contact(Guid.NewGuid(), "Beatriz", "5519994282237", "https://func-doss.azurewebsites.net/api/DownloadImageServiceBusTrigger?filename=/vehicle/image/a52cb71a-27f5-4e9d-8ace-9b3407b969c1"),
            new ResidentialContactsQuery.Contact(Guid.NewGuid(), "Sandra", "5519994282237", "https://func-doss.azurewebsites.net/api/DownloadImageServiceBusTrigger?filename=/vehicle/image/a52cb71a-27f5-4e9d-8ace-9b3407b969c1"),
        }));
    }
    //  => Results.Ok(new ResidentialContactsQuery.Response(await residentialRepository.ReturnContacts(query.User!.Id, query.Page, query.Total)));
}
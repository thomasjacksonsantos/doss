using System.Text.Json.Serialization;
using Doss.Core.Domain.Enums;
using Doss.Core.Seedwork;

namespace Doss.Core.Queries.Residentials;

public class ResidentialListByServiceProviderIdQuery : Query<ResidentialListByServiceProviderIdQuery.Response>
{
    public int Page { get; set; }
    public int Total { get; set; }
    public UserStatus? Status { get; set; }

    public class Response
    {
        public IEnumerable<Residential> Residentials { get; set; }

        public Response(IEnumerable<Residential> residentials)
            => Residentials = residentials;
    }

    public class Residential
    {        
        public Guid Id { get; set; }
        public string Name { get; private set; }
        public UserStatus Status { get; private set; }
        public string Photo { get; private set; }
        public string Plan { get; private set; }

        public Residential(Guid id, string name, UserStatus status, string photo, string plan)
            => (Id, Name, Status, Photo, Plan) = (id, name, status, photo, plan);

    }
}
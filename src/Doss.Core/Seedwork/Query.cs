using System.Text.Json.Serialization;
using MediatR;

namespace Doss.Core.Seedwork;

public abstract class Query : IRequest<Result>
{
    [JsonIgnore]
    public UserQuery? User { get; set; }
}

public abstract class Query<TResponse> : IRequest<Result<TResponse>>
{
    [JsonIgnore]
    public UserQuery User { get; set; } = null!;
}

public class UserQuery
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Lastname { get; set; }
    public IEnumerable<string> Emails { get; set; }

    public UserQuery(Guid id, string name, string lastname, IEnumerable<string> emails)
        => (Id, Name, Lastname, Emails) = (id, name, lastname, emails);
}
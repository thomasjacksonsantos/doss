using System.Text.Json.Serialization;
using MediatR;

namespace Doss.Core.Seedwork;
public abstract class Command : IRequest<Result>
{
    [JsonIgnore]
    public UserCommand? User { get; set; }
}

public abstract class Command<TResponse> : IRequest<Result<TResponse>>
{
    [JsonIgnore]
    public UserCommand? User { get; set; }
}

public class UserCommand
{
    [JsonIgnore]
    public Guid Id { get; set; }
    [JsonIgnore]
    public string Name { get; set; }
    [JsonIgnore]
    public string Lastname { get; set; }
    [JsonIgnore]
    public IEnumerable<string> Emails { get; set; }

    public UserCommand(Guid id, string name, string lastname, IEnumerable<string> emails)
        => (Id, Name, Lastname, Emails) = (id, name, lastname, emails);
}

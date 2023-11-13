using Doss.Core.Domain.OnBoard;
using Doss.Core.Seedwork;

namespace Doss.Core.Queries.ServiceProvidersOnBoard;

public class ReturnServiceProviderOnBoardByIdQuery : Query<OnBoardServiceProvider>
{
    public Guid Id { get; set; }    
}
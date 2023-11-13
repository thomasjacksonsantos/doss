using Doss.Core.Domain.OnBoard;
using Doss.Core.Seedwork;

namespace Doss.Core.Queries.ResidentialsOnBoard;

public class ReturnResidentialOnBoardByIdQuery : Query<OnBoardResidential>
{
    public Guid Id { get; set; }    
}
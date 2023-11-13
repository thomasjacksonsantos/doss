using Doss.Core.Domain.Enums;
using Doss.Core.Seedwork;

namespace Doss.Core.Queries.Banks;

public class BankAllQuery : Query<BankAllQuery.Response>
{
    public class Response
    {
        public IEnumerable<Bank> Banks { get; set; } = new List<Bank>();
        public Response(IEnumerable<Bank> banks)
            => Banks = banks;
        public class Bank
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public BankStatus BankStatus { get; set; }
            public Bank(Guid id, string name, BankStatus bankStatus)
                => (Id, Name, BankStatus) = (id, name, bankStatus);
        }
    }
}
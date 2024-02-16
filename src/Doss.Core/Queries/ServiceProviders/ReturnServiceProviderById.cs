using Doss.Core.Domain.Enums;
using Doss.Core.Seedwork;

namespace Doss.Core.Queries.ServiceProviders;

public class ReturnServiceProviderById : Query<ReturnServiceProviderById.Response>
{
    public class Response
    {
        public ServiceProviderCommand ServiceProvider { get; set; }
        public AddressCommand Address { get; set; }
        public CoverageCommand Coverage { get; set; }
        public FormPaymentCommand FormPayment { get; set; }

        public Response(ServiceProviderCommand serviceProvider, AddressCommand address, CoverageCommand coverage, FormPaymentCommand formPayment)
            => (ServiceProvider, Address, Coverage, FormPayment) = (serviceProvider, address, coverage, formPayment);

        public class ServiceProviderCommand
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public TypeDocument TypeDocument { get; set; }
            public string Document { get; set; }
            public string Phone { get; set; }
            public string Photo { get; set; }
            public ServiceProviderCommand(Guid id, string name, TypeDocument typeDocument, string document, string phone, string photo)
                => (Id, Name, TypeDocument, Document, Phone, Photo) = (id, name, typeDocument, document, phone, photo);
        }

        public class AddressCommand
        {
            public string ZipCode { get; set; }
            public string Country { get; set; }
            public string State { get; set; }
            public string City { get; set; }
            public string Neighborhood { get; set; }
            public string Street { get; set; }
            public string Complement { get; set; }
            public string Number { get; set; }

            public AddressCommand(string zipCode, string country, string state, string city, string neighborhood, string street, string complement, string number)
                => (ZipCode, Country, State, City, Neighborhood, Street, Complement, Number) = (zipCode, country, state, city, neighborhood, street, complement, number);
        }

        public class CoverageCommand
        {
            public int CoverageArea { get; set; }
            public CoverageCommand(int coverageArea)
                => (CoverageArea) = (coverageArea);
        }

        public class FormPaymentCommand
        {
            public Guid BankId { get; set; }
            public string Agency { get; set; } = string.Empty;
            public string Account { get; set; } = string.Empty;
            public IEnumerable<PlanCommand> Plans { get; set; } = new List<PlanCommand>();

            public FormPaymentCommand(Guid bankId, string agency, string account, IEnumerable<PlanCommand> plans)
                => (BankId, Agency, Account, Plans) = (bankId, agency, account, plans);
        }

        public class PlanCommand
        {
            public Guid Id { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }

            public PlanCommand(Guid id, string description, decimal price)
                => (Id, Description, Price) = (id, description, price);
        }
    }
}
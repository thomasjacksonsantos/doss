
using Doss.Core.Domain.Addresses;

namespace Doss.Core.Interfaces.Repositories;

public interface IZipCodeRepository 
{
    Task<ZipCode> SearchByZipCode(string zipCode);
}
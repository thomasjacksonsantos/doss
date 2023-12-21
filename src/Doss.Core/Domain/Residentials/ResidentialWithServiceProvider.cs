using Doss.Core.Domain.Addresses;
using Doss.Core.Domain.Plans;
using Doss.Core.Domain.ServiceProviders;
using Doss.Core.Domain.Vehicles;

namespace Doss.Core.Domain.Residentials;

public class ResidentialWithServiceProvider
{
    public Guid Id { get; set; }
    public Guid ResidentialId { get; set; }
    public Residential Residential { get; set; }
    public Guid ServiceProviderPlanId { get; set; }
    public ServiceProviderPlan ServiceProviderPlan { get; set; } = null!;
    public IEnumerable<ResidentialVehicle>? ResidentialVehicles { get; private set; }
    public Vehicle VehicleDefault
        => ResidentialVehicles!
            .Select(c => c.Vehicle)
            .FirstOrDefault(c => c.DefaultVehicle)!;

    public Vehicle ReturnVehicleById(Guid vehicleId)
        => ResidentialVehicles!
            .Select(c => c.Vehicle)
            .SingleOrDefault(c => c.Id == vehicleId)!;
    public void ResetDefaultVehicles()
        => ResidentialVehicles!.ForEach(c => c.Vehicle.DefaultVehicle = false);

    public Guid PlanId { get; set; }
    public Plan Plan { get; set; }
    public Address Address { get; set; }

    public ResidentialWithServiceProvider()
    {

    }

    public ResidentialWithServiceProvider(Guid serviceProviderPlanId, Guid planId, Address address)
        => (ServiceProviderPlanId, PlanId, Address) = (serviceProviderPlanId, planId, address);

    public void AddVehicle(ResidentialVehicle residentialVehicle)
    {
        if (ResidentialVehicles is not { }) ResidentialVehicles = new List<ResidentialVehicle>();
        ResidentialVehicles.Append(residentialVehicle);
    }
}
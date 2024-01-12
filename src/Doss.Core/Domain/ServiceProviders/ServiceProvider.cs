using Doss.Core.Domain.Enums;
using Doss.Core.Domain.Plans;
using Doss.Core.Domain.Vehicles;

namespace Doss.Core.Domain.ServiceProviders;

public class ServiceProvider
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Document { get; private set; }
    public TypeDocument TypeDocument { get; private set; }
    public string Phone { get; private set; }
    public string Photo { get; private set; }
    public string PhotoUrl { get; set; }
    public bool CompletedRegistration { get; private set; }
    public UserStatus UserStatus { get; private set; }
    public IEnumerable<ServiceProviderVehicle>? ServiceProviderVehicles { get; private set; }
    public Vehicle ReturnVehicleById(Guid vehicleId)
        => ServiceProviderVehicles!.Select(c => c.Vehicle).Single(c => c.Id == vehicleId);
    public void ResetDefaultVehicles()
        => ServiceProviderVehicles!.ForEach(c => c.Vehicle.ChangeDefaultVehicle(false));

    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }
    public IEnumerable<ServiceProviderPlan> ServiceProviderPlans { get; private set; } = new List<ServiceProviderPlan>();

    public ServiceProvider(Guid id, string name, TypeDocument typeDocument, string document, string phone, string photo, bool completedRegistration)
    => (Id, Name, TypeDocument, Document, Phone, Photo, PhotoUrl, CompletedRegistration, UserStatus, Created)
        = (id, name, typeDocument, document.OnlyNumbers(), phone.OnlyNumbers(), photo, string.Empty, completedRegistration, UserStatus.Active, DateTime.Now);

    public void AddVehicle(ServiceProviderVehicle serviceProviderVehicle)
    {
        if (ServiceProviderVehicles is not { }) ServiceProviderVehicles = new List<ServiceProviderVehicle>();

        ((List<ServiceProviderVehicle>)ServiceProviderVehicles).Add(serviceProviderVehicle);
    }

    public void ChangePhotoUrl(string url)
        => PhotoUrl = url;

    public void ChangeName(string name)
        => Name = name;

    public void ChangeDocument(string document)
        => Document = document;

    public void ChangeTypeDocument(TypeDocument typeDocument)
        => TypeDocument = typeDocument;

    public void ChangePhoto(string photo)
        => Photo = photo;

    public void ChangePhone(string phone)
        => Phone = phone;

    public void CompleteRegistration(bool complete)
        => CompletedRegistration = complete;

    public void ChangeUserStatus(UserStatus userStatus)
        => UserStatus = userStatus;

    public Plan ReturnPlanById(Guid planId)
        => ServiceProviderPlans!.SelectMany(c => c.Plans)
                .SingleOrDefault(c => c.Id == planId)!;

    public void AddServiceProviderPlan(ServiceProviderPlan serviceProviderPlan)
        => ((List<ServiceProviderPlan>)ServiceProviderPlans).Add(serviceProviderPlan);
}
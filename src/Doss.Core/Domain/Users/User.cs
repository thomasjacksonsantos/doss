using Doss.Core.Domain.Enums;
using Doss.Core.Domain.Vehicles;

namespace Doss.Core.Domain.Users;

public class User
{
    public Guid Id { get; private set; }
    public Guid UserId { get; set; }
    public string Name { get; private set; }
    public string Document { get; private set; }
    public string Phone { get; private set; }
    public string Photo { get; private set; }
    public bool CompletedRegistration { get; private set; }
    public UserStatus UserStatus { get; private set; }
    public IEnumerable<Vehicle>? Vehicles { get; private set; }
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }

    public User(Guid userid, string name, string document, string phone, string photo, bool completedRegistration)
        => (Id, UserId, Name, Document, Phone, Photo, CompletedRegistration, UserStatus, Created)
            = (Guid.NewGuid(), userid, name, document, phone, photo, completedRegistration, UserStatus.Active, DateTime.Now);

    public void AddVehicle(Vehicle vehicle)
    {
        if (Vehicles is not { }) Vehicles = new List<Vehicle>();

        ((List<Vehicle>)Vehicles).Add(vehicle);
    }

    public void ChangeName(string name)
        => Name = name;

    public void ChangeDocument(string document)
        => Document = document;

    public void ChangePhoto(string photo)
        => Photo = photo;

    public void ChangePhone(string phone)
        => Phone = phone;

    public void CompleteRegistration(bool complete)
        => CompletedRegistration = complete;

    public void ChangeUserStatus(UserStatus userStatus)
        => UserStatus = userStatus;
}
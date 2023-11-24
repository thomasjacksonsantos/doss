namespace Doss.Core.Domain.OnBoard;

public class OnBoardUser
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Document { get; set; }
    public string Phone { get; set; }
    public string Photo { get; set; }

    public OnBoardUser(string name, string document, string phone, string photo)
        => (Name, Document, Phone, Photo) = (name, document, phone, photo);

    public void ChangeName(string name)
        => Name = name;

    public void ChangeDocument(string document)
        => Document = document;

    public void ChangePhone(string phone)
        => Phone = phone;

    public void ChangePhoto(string photo)
        => Photo = photo;
}
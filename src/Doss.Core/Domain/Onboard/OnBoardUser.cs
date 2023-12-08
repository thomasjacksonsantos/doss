using Doss.Core.Domain.Enums;

namespace Doss.Core.Domain.OnBoard;

public class OnBoardUser
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public TypeDocument TypeDocument { get; set; }
    public string Document { get; set; }
    public string Phone { get; set; }
    public string Photo { get; set; }

    public OnBoardUser(string name, TypeDocument typeDocument, string document, string phone, string photo)
        => (Name, TypeDocument, Document, Phone, Photo) = (name, typeDocument, document.OnlyNumbers(), phone.OnlyNumbers(), photo);

    public void ChangeName(string name)
        => Name = name;

    public void ChangeDocument(string document)
        => Document = document.OnlyNumbers();

    public void ChangeTypeDocument(TypeDocument typeDocument)
        => TypeDocument= typeDocument;

    public void ChangePhone(string phone)
        => Phone = phone.OnlyNumbers();

    public void ChangePhoto(string photo)
        => Photo = photo;
}
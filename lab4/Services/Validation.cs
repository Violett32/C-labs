using VetaLab4.Model;

namespace VetaLab4.Services;

public class Validation : IValidation
{
    public void ValidateContact(Contact contact)
    {
        if (contact.Name=="" || contact.Surname=="" || contact.Phone == "" ||
            contact.Email=="")
            throw new Exception("Empty fields are not allowed");
    }
}

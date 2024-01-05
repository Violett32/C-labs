using VetaLab4.Model;

namespace VetaLab4.Services;

public class StoreContact : IStoreContact
{
    private readonly IValidation _validator;
    public StoreContact(IValidation validator)
    {
        _validator = validator;
    }
    
    public Contact SetContact(string name, string surname, string phone, string email)
    {
        var contact = new Contact{Name = name, Surname = surname, Email = email, Phone = phone};

        _validator.ValidateContact(contact);
        return contact;

    }
}

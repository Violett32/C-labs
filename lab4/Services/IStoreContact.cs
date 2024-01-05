using VetaLab4.Model;

namespace VetaLab4.Services;

public interface IStoreContact
{
    Contact SetContact(string name, string surname, string phone, string email);
}

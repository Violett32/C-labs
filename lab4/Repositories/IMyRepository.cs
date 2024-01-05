using VetaLab4.Model;

namespace VetaLab4.Repositories;

public interface IMyRepository
{
    Task Add(Contact contact);
    Task<List<Contact>> Search(string keywords, int mode);
}

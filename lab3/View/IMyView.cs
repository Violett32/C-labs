using VetaLab3.Model;

namespace VetaLab3.View;

public interface IMyView
{
    int Menu();
    Contact NewContact();
    void ViewAllContacts(List<Contact> contacts);
    string SearchRequest();
    int SearchMode();
    int SaveMode();
}

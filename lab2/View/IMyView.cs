using VetaLab2.Model;

namespace VetaLab2.View;

public interface IMyView
{
    int Menu();
    Contact NewContact();
    void ViewAllContacts(List<Contact> contacts);
    string SearchRequest();
    int SearchMode();
}

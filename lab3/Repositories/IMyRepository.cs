using VetaLab3.Model;

namespace VetaLab3.Repositories;

public interface IMyRepository
{
    void DBSave(List<Contact> taskks);
    List<Contact> DBLoad();
    void JSONSave(List<Contact> taskks);
    List<Contact> JSONLoad();
}

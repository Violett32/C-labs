using Newtonsoft.Json;
using VetaLab3.Context;
using VetaLab3.Model;

namespace VetaLab3.Repositories;

public class MyRepository : IMyRepository
{
    private readonly string _jsonFilePath =
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "contacts.json");

    private readonly MyContext _context = new ();

    public MyRepository()
    {
        _context.Database.EnsureCreated();
    }
    public void DBSave(List<Contact> contacts)
    {
        _context.Contacts?.RemoveRange(_context.Contacts);
        _context.SaveChanges();

        // Добавление новых задач и сохранение изменений
        _context.Contacts?.AddRange(contacts);
        _context.SaveChanges();
    }

    public List<Contact> DBLoad()
    {
        return _context.Contacts!.ToList();
    }

    public void JSONSave(List<Contact> contacts)
    {
        var jsonData = JsonConvert.SerializeObject(contacts, Formatting.Indented);
        File.WriteAllText(_jsonFilePath, jsonData);
    }

    public List<Contact> JSONLoad()
    {
        var temp = new List<Contact>();
        File.Create(_jsonFilePath).Close();

        var jsonData = File.ReadAllText(_jsonFilePath);
        var data = JsonConvert.DeserializeObject<List<Contact>>(jsonData) ??
                   new List<Contact>();
        foreach (var contact in data)
        {
            temp.Add(new Contact
            {
                Name = contact.Name,
                Surname = contact.Surname,
                Phone = contact.Phone,
                Email = contact.Email
            });
        }

        return temp;
    }
}

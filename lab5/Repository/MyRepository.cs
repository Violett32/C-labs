using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using VetaLab5.Database;
using VetaLab5.Models;

namespace VetaLab5.Repository;

public class MyRepository:IMyRepository
{
    private readonly MyContext _context;
    
    public MyRepository(MyContext context)
    {
        _context = context;
        _context.Database.EnsureCreated();
    }
    public void SaveToDb(ObservableCollection<Contact> contacts)
    {
        _context.Contacts?.RemoveRange(_context.Contacts);
        _context.SaveChanges();

        // Добавление новых задач и сохранение изменений
        _context.Contacts?.AddRange(contacts);
        _context.SaveChanges();
    }

    public List<Contact> LoadFromDb()
    {
        return _context.Contacts!.ToList();
    }
}

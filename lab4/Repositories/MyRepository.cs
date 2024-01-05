using Microsoft.EntityFrameworkCore;
using VetaLab4.Context;
using VetaLab4.Model;

namespace VetaLab4.Repositories;

public class MyRepository : IMyRepository
{
    private readonly MyContext _context;

    public MyRepository(MyContext context)
    {
        _context = context;
    }
    
    public Task Add(Contact contact)
    {
        if (!_context.Contacts!.Any(c => c.Name == contact.Name && c.Name == contact.Surname && c.Phone == 
                                         contact.Phone && c.Email == contact.Email))
        {
            _context.Contacts?.Add(contact);
            return _context.SaveChangesAsync();
        }

        throw new Exception("Контакт уже существует.");
    }
    
    public Task<List<Contact>> Search(string keyword, int mode) // Реализация поиска по ключевым словам
    {
        return mode switch
        {
            1 => _context.Contacts!.Where(с => с.Name.ToLower() == keyword.ToLower()).ToListAsync(),
            2 => _context.Contacts!.Where(с => с.Surname.ToLower() == keyword.ToLower()).ToListAsync(),
            3 => _context.Contacts!.Where(с => с.Name.ToLower() == keyword.ToLower() || с.Surname.ToLower()
                == keyword.ToLower()).ToListAsync(),
            4 => _context.Contacts!.Where(с => с.Phone.ToLower() == keyword.ToLower()).ToListAsync(),
            5 => _context.Contacts!.Where(с => с.Email.ToLower() == keyword.ToLower()).ToListAsync(),
            _ => throw new Exception("Неизвестный режим / книга не найдена.")
        };
    }
}

using Microsoft.EntityFrameworkCore;
using VetaLab4.Model;

namespace VetaLab4.Context;

public class MyContext:DbContext
{
    public DbSet<Contact>? Contacts { get; set; }
    
    public MyContext(DbContextOptions<MyContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}

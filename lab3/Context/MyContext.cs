using Microsoft.EntityFrameworkCore;
using VetaLab3.Model;

namespace VetaLab3.Context;

public class MyContext:DbContext
{
    public DbSet<Contact>? Contacts { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=ContactBook.db");
    }
}

using VetaLab5.Models;
using Microsoft.EntityFrameworkCore;

namespace VetaLab5.Database;

public class MyContext : DbContext
{
    public DbSet<Contact>? Contacts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Contacts.db");
    }
}

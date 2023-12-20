using System.ComponentModel.DataAnnotations;

namespace VetaLab4.Model;

public class Contact
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
}

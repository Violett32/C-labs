using VetaLab2.Controller;
using VetaLab2.Model;
using VetaLab2.View;

namespace VetaLab2.Test;

public class UnitTest1
{
    [Fact]
    public void SearchByNameAndSurnameTest()
    {
        var contacts = new List<Contact>
        {
            new()
            {
                Name = "Илон",
                Surname = "Маск",
                Phone = "+79528125252",
                Email = "qwerty@gmail.com"
            },
            new()
            {
                Name = "Джефф",
                Surname = "Безос",
                Phone = "+81112233445",
                Email = "bezos@gmail.com"
            }
        };

        var myView = new MyView();
        var myContoller = new MyController(contacts, myView);
        var actual = myContoller.Search("дже", 3);
        Assert.Equal(actual[0], contacts[1]); 
    }
    
    [Theory]
    [InlineData ("Илон", "Маск", "+79528125252", "qwerty@gmail.com")]
    public void AddContactTest(string name, string surname, string phone, string email)
    {
        var contact = new Contact
        {
            Name = name,
            Surname = surname,
            Phone = phone,
            Email = email
        };

        var contacts = new List<Contact>();
        var myView = new MyView();
        var myContoller = new MyController(contacts, myView);
        myContoller.AddContact(contact);
        
        Assert.Equal(contacts[0], contact);
    }
}

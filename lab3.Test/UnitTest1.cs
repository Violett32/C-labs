using Moq;
using VetaLab3.Controller;
using VetaLab3.Model;
using VetaLab3.Repositories;
using VetaLab3.View;

namespace VetaLab3.Test;

public class UnitTest1
{
    [Theory]
    [InlineData("Ева", "Тажибаева", "+7(952)8125252", "bruh@gmail.com", 1, "Ева")]
    public void SearchTest(string name, string surname, string phone, string email, int mode, string keyword)
    {
        var contacts = new List<Contact>
        {
            new()
            {
                Name = name,
                Surname = surname,
                Phone = phone,
                Email = email
            }
        };
        var myView = new MyView();
        var mock = new Mock<IMyRepository>();
        mock.Setup(c => c.DBLoad()).Returns(new List<Contact>());
        mock.Setup(c => c.JSONLoad()).Returns(new List<Contact>());
        var myController = new MyController(contacts, myView, mock.Object);
        
        Assert.Equal(contacts[0], myController.Search(keyword, 1)[0]);
    }
    
    [Theory]
    [InlineData("Ева", "Тажибаева", "+7(952)8125252", "bruh@gmail.com")]
    public void AddWordTest(string name, string surname, string phone, string email)
    {
        var contacts = new List<Contact>();
        var myView = new MyView();
        var mock = new Mock<IMyRepository>();
        mock.Setup(c => c.DBLoad()).Returns(new List<Contact>());
        mock.Setup(c => c.JSONLoad()).Returns(new List<Contact>());
        var myController = new MyController(contacts, myView, mock.Object);
        var expected = new Contact
        {
            Name = name,
            Surname = surname,
            Phone = phone,
            Email = email

        };
        myController.AddContact(expected);
        
        Assert.Equal(expected, contacts[0]);
    }
}

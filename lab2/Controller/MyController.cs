using System.Text.RegularExpressions;
using VetaLab2.Model;
using VetaLab2.View;

namespace VetaLab2.Controller;

public class MyController
{
    private readonly List<Contact> _contacts;
    private readonly IMyView _myView;

    public MyController(List<Contact> contacts, IMyView myView)
    {
        _contacts = contacts;
        _myView = myView;
    }

    public void AddContact(Contact contact) 
    {
        _contacts.Add(contact);
    }

    public List<Contact> Search(string keyword, int mode)
    {
        var flag = false;
        var tmp = new List<Contact>();
        var regex = new Regex($@"{keyword.ToLower()}(\w*)");
        foreach (var contact in _contacts)
        {
            switch (mode)
            {
                case 1:
                    if (regex.Matches(contact.Name.ToLower()).Count > 0)
                    {
                        flag = true;
                        tmp.Add(contact);
                    }
                    break;
                case 2:
                    if (regex.Matches(contact.Surname.ToLower()).Count > 0)
                    {
                        flag = true;
                        tmp.Add(contact);
                    }
                    break;
                case 3:
                    if (regex.Matches(contact.Name.ToLower()).Count > 0 ||
                        regex.Matches(contact.Surname.ToLower()).Count > 0)
                    {
                        flag = true;
                        tmp.Add(contact);
                    }
                    break;
                case 4:
                    if (regex.Matches(contact.Phone.ToLower()).Count > 0)
                    {
                        flag = true;
                        tmp.Add(contact);
                    }
                    break;
                case 5:
                    if (regex.Matches(contact.Email.ToLower()).Count > 0)
                    {
                        flag = true;
                        tmp.Add(contact);
                    }
                    break;
            }
        }

        if (flag == false)
            Console.WriteLine("No such contacts");
        return tmp;
    }
    

    public void Run()
    {
        var running = true;
        while (running)
        {
            var menu = _myView.Menu();
            switch (menu)
            {
                case 1:
                    _myView.ViewAllContacts(_contacts);
                    break;
                case 2:
                    var mode = _myView.SearchMode();
                    _myView.ViewAllContacts(Search(_myView.SearchRequest(), mode));
                    break;
                case 3:
                    AddContact(_myView.NewContact());
                    break;
                case 4:
                    running = !running;
                    break;
            }
        }
    }
}

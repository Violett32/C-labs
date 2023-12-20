using System.Text.RegularExpressions;
using VetaLab3.Model;
using VetaLab3.Repositories;
using VetaLab3.View;

namespace VetaLab3.Controller;

public class MyController
{
    private List<Contact> _contacts;
    private readonly IMyView _myView;
    private readonly IMyRepository _myRepository;

    public MyController(List<Contact> contacts, IMyView myView, IMyRepository myRepository)
    {
        _contacts = contacts;
        _myView = myView;
        _myRepository = myRepository;
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
        var savemode = _myView.SaveMode();
        switch (savemode)
        {
            case 1:
                _contacts = _myRepository.DBLoad();
                break;
            case 2:
                _contacts = _myRepository.JSONLoad();
                break;
        }
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
        
        switch (savemode)
        {
            case 1:
                _myRepository.DBSave(_contacts);
                break;
            case 2:
                _myRepository.JSONSave(_contacts);
                break;
        }
    }
}

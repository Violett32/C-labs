using System.Collections.ObjectModel;
using System.Threading.Tasks;
using DynamicData;
using VetaLab5.Repository;
using VetaLab5.Database;
using VetaLab5.Models;
using ReactiveUI;

namespace VetaLab5.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly MyContext _context;
    private readonly IMyRepository _repository;
    private string _inputWord;
    private bool _isInputValid;
    
    public MainWindowViewModel()
    {
        _context = new MyContext();
        _repository = new MyRepository(_context);
        var t = _repository.LoadFromDb();
        ContactList.AddRange(t);
        ContactList = new ObservableCollection<Contact>(_repository.LoadFromDb());
    }

    private string _name;
    public string Name
    {
        get => _name;
        set => this.RaiseAndSetIfChanged(ref _name, value);
    }
    
    private string _surname;
    public string Surname
    {
        get => _surname;
        set => this.RaiseAndSetIfChanged(ref _surname, value);
    }
    
    private string _phone;
    public string Phone
    {
        get => _phone;
        set => this.RaiseAndSetIfChanged(ref _phone, value);
    }
    
    private string _email;
    public string Email
    {
        get => _email;
        set => this.RaiseAndSetIfChanged(ref _email, value);
    }
    
    
    private Contact _selectedItem;
    public Contact SelectedItem
    {
        get { return _selectedItem; }
        set
        {
            this.RaiseAndSetIfChanged(ref _selectedItem, value);
            if (value != null)
            {
                Name = SelectedItem.Name;
                Surname = SelectedItem.Surname;
                Email = SelectedItem.Email;
                Phone = SelectedItem.Phone;
            }
        }
    }

    
    public ObservableCollection<Contact> ContactList { get; set; } = [];
    
    

    public async Task AddContact()
    {
        await Task.Delay(1000);

        Name = "";
        Surname = "";
        Phone = "";
        Email = "";
        SelectedItem = null;
    }
    
    
    public async void SaveChanges()
    {
        await Task.Delay(1000);
        if (SelectedItem == null)
        {
            var newContact = new Contact
            {
                Name = Name,
                Surname =Surname,
                Phone = Phone,
                Email = Email
            };
            ContactList.Add(newContact);
        }
        else
        {
            foreach (var contact in ContactList)
            {
                if (contact.Phone == SelectedItem.Phone)
                {
                    contact.Name = Name;
                    contact.Surname = Surname;
                    contact.Phone = Phone;
                    contact.Email = Email;
                    
                }
            }
        }
        _repository.SaveToDb(ContactList);

    }
    
    
}

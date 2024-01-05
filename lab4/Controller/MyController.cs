using VetaLab4.Model;
using VetaLab4.Services;
using Microsoft.AspNetCore.Mvc;
using VetaLab4.Repositories;

namespace VetaLab4.Controller;

[ApiController]
public class MyController : ControllerBase
{
    private readonly IMyRepository _myRepository;

    public MyController(IMyRepository myRepository)
    {
        _myRepository = myRepository;
    }

    [HttpPost]
    [Route("/add-contact")]
    public Task Add([FromBody] string fake, string name, string surname, string phone, string email)
    {
        var validator = new Validation();
        var storeContact = new StoreContact(validator);
        var contact = storeContact.SetContact(name, surname, phone, email);

        return _myRepository.Add(contact);
    }

    [HttpGet]
    [Route("/search-contact")]
    public Task<List<Contact>> SearchContact(string keyword, int mode)
    {
        return _myRepository.Search(keyword, mode);
    }
}

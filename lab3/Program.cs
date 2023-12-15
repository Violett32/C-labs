using VetaLab3.Controller;
using VetaLab3.Model;
using VetaLab3.Repositories;
using VetaLab3.View;

namespace VetaLab3;

public static class Program
{
    public static void Main(string[] args)
    {
        var contacts = new List<Contact>();
        var myView = new MyView();
        var myRepository = new MyRepository();
        var myController = new MyController(contacts, myView, myRepository);
        myController.Run();
    }
}

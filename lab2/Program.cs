using VetaLab2.Controller;
using VetaLab2.Model;
using VetaLab2.View;

namespace VetaLab2;

public static class Program
{
    public static void Main(string[] args)
    {
        var contacts = new List<Contact>();
        var myView = new MyView();
        var myContoller = new MyController(contacts, myView);
        myContoller.Run();
    }
}

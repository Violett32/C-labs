using VetaLab3.Model;

namespace VetaLab3.View;

public class MyView : IMyView
{
    public int Menu() // Взаимодействие с пользователем для выбора пунктов меню
    {
        Console.WriteLine(
            "Menu:\n1. View all contacts.\n2. Search.\n3. New contact.\n4. Exit.");
        Console.Write("> ");
        var isValid = int.TryParse(Console.ReadLine(), out var n);
        if (!isValid || n < 1 || n > 4)
            throw new Exception("Введено неверное значение");
        return n;
    }

    public Contact NewContact()
    {
        var contact = new Contact();

        Console.WriteLine("New contact");
        Console.Write("Name: ");
        var input = Console.ReadLine() ?? "";
        if (input == "")
            throw new Exception("An empty string is not allowed.");
        contact.Name = input;

        Console.Write("Surname: ");
        input = Console.ReadLine() ?? "";
        if (input == "")
            throw new Exception("An empty string is not allowed.");
        contact.Surname = input;

        Console.Write("Phone: ");
        input = Console.ReadLine() ?? "";
        if (input == "")
            throw new Exception("An empty string is not allowed.");
        contact.Phone = input;

        Console.Write("E-mail: ");
        input = Console.ReadLine() ?? "";
        if (input == "")
            throw new Exception("An empty string is not allowed.");
        contact.Email = input;

        return contact;
    }

    public void ViewAllContacts(List<Contact> contacts)
    {
        var count = contacts.Count;
        if (count > 0)
        {
            Console.WriteLine($"Results ({count}):");
            for (var i = 0; i < count; i++)
            {
                Console.WriteLine("#" + i);
                Console.WriteLine("Name: " + contacts[i].Name);
                Console.WriteLine("Surname: " + contacts[i].Surname);
                Console.WriteLine("Phone: " + contacts[i].Phone);
                Console.WriteLine("E-mail: " + contacts[i].Email);
            }
        }
        else
        {
            Console.WriteLine("No such tasks.");
        }
    }

    public string SearchRequest()
    {
        Console.Write("Request: ");
        var input = Console.ReadLine() ?? "";
        if (input == "")
            throw new Exception("An empty string is not allowed.");
        return input;
    }
    
    public int SearchMode() // Взаимодействие с пользователем для выбора пунктов меню
    {
        Console.WriteLine(
            "Search by:\n1. Name.\n2. Surname.\n3. Name and surname.\n4. Phone.\n5. E-mail.");
        Console.Write("> ");
        var isValid = int.TryParse(Console.ReadLine(), out var n);
        if (!isValid || n < 1 || n > 5)
            throw new Exception("Invalid value");
        return n;
    }

    public int SaveMode()
    {
        Console.WriteLine(
            "Choose saving mode:\n1. DB.\n2. JSON.");
        Console.Write("> ");
        var isValid = int.TryParse(Console.ReadLine(), out var n);
        if (!isValid || n < 1 || n > 2)
            throw new Exception("Invalid value");
        return n;
    }
}

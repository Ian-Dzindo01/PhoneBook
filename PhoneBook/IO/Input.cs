using System;

namespace PhoneBook;

class InputHelper
{   
    static public void GetUserInput()
    {
        Console.WriteLine("------------------------------------");
        Console.WriteLine("1: Create a New Contact");
        Console.WriteLine("2: View a Contact");
        Console.WriteLine("3: Update Contact Info");
        Console.WriteLine("4: Delete a Contact");

        string? choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Controller.Create();
                break;
            case "2":
                Controller.Show();
                break;
            case "3":
                Console.WriteLine("Id of contact you would like to update: ");
                int id1 = int.Parse(Console.ReadLine());
                Controller.Update(id1);
                break;
            case "4":
                Console.WriteLine("Id of contact you would like to delete: ");
                int id2 = int.Parse(Console.ReadLine());
                Controller.Delete(id2);
                break;
            default:
                Console.WriteLine("\nInvalid Command. Please type a number from 0 to 4.\n");
                break;
        }
    }
}
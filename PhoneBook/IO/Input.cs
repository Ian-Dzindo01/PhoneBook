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

        Controller.Init();
        string? choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Controller.Create();
                break;
            case "2":
                Console.WriteLine("Id of contact you would like to update: ");
                int id = int.Parse(Console.ReadLine());
                Controller.Update(id);
                break;
            case "3":
                Games.GamePrep();
                break;
            case "4":
                Games.ShowSessionTables();
                break;
            case "5":
                Card.ShowCards();
                break;
            case "6":
                Stack.ReadInFromCsv(ConfigurationManager.AppSettings["stackCsv"]);
                Card.ReadInFromCsv(ConfigurationManager.AppSettings["cardCsv"]);
                break;
            default:
                Console.WriteLine("\nInvalid Command. Please type a number from 0 to 4.\n");
                break;
        }

    }
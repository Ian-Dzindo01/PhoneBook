using System;
using System.Linq;

namespace PhoneBook
{
    public class Controller
    {   
        private static ContactContext db = new ContactContext();

        public static void Init()
        {
            // Note: This sample requires the database to be created before running.
            Console.WriteLine($"Database path: {db.DbPath}.");
        }

        // ADD VALIDITY CHECKING HERE.
        public static void Create()
        {   
            if (db == null)
            {
                Console.WriteLine("Database context is not initialized.");
                return;
            }
            string name, email, number;

            Console.WriteLine("Please input contact data in this order - Name, Email, Number");
            name = Console.ReadLine();
            email = Console.ReadLine();
            number = Console.ReadLine();

            Console.WriteLine("Successfully inserted a new contact.");
            db.Contacts.Add(new Contact{ Name = name, Email=email, Number=number});
            db.SaveChanges();

        }
        // FINISH THIS.
        public static Contact Read()
        {
            Console.WriteLine("Querying for a contact");
            var contact = db.Contacts.OrderBy(b => b.Id).First();
            return contact;
        }

        // Update. SUPPORT FOR UPDATE TO ALL PROPERTIES.
        public static void Update(int id)
        {   
            // Fetch contact from id here
            var contact = db.Contacts.Find(id);

            if (contact == null)
            {
                Console.WriteLine($"Contact with ID {id} not found.");
                Controller.Update(id);
            }

            Console.WriteLine("New number for this contact: ");
            string number = Console.ReadLine();

            contact.Number = number;
            db.SaveChanges();
            Console.WriteLine("Contact successfully updated.");
            InputHelper.GetUserInput();
        }

        public static void Delete(int id)
        {   
            var contact = db.Contacts.Find(id);

            if (contact == null)
            {
                Console.WriteLine($"Contact with ID {id} not found.");
                Controller.Delete(id);
            }
            db.Remove(contact);
            db.SaveChanges();
            Console.WriteLine("Contact successfully deleted. \n");
            InputHelper.GetUserInput();
        }
    }
}
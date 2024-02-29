using System;
using System.Linq;

namespace PhoneBook
{
    public class Controller
    {   
        private static ContactContext db;

        public static void Init()
        {
            var db = new ContactContext();
            // Note: This sample requires the database to be created before running.
            Console.WriteLine($"Database path: {db.DbPath}.");
        }

        // Create. ADD VALIDITY CHECKING HERE.
        public static void Create()
        {   
            string name, email, number;

            Console.WriteLine("Please input contact data in this order - Name, Email, Number");
            name = Console.ReadLine();
            email = Console.ReadLine();
            number = Console.ReadLine();

            Console.WriteLine("Inserting a new contact");
            db.Add(new Contact { Name = name, Email=email, Number=number});
            db.SaveChanges();
        }
        // Read
        public static Contact Read()
        {
            Console.WriteLine("Querying for a contact");
            var contact = db.Contacts.OrderBy(b => b.Id).First();
            return contact;
        }

        // Update. SUPPORT FOR UPDATE TO ALL PROPERTIES.
        public static void Update(int id)
        {   
            Console.WriteLine("New number for this contact: ");
            string number = Console.ReadLine();

            Console.WriteLine("Updating the contact number");
            contact.Number = number;
            db.SaveChanges();
        }

        // Delete
        public static void Delete(Contact contact)
        {
            Console.WriteLine("Delete a contact");
            db.Remove(contact);
            db.SaveChanges();
            Console.WriteLine("Contact successfully deleted. \n");
        }
    }
}
namespace PhoneBook
{
    public class Controller
    {   
        private static ContactContext db = new ContactContext();
        
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

            if(name.Length > 35)
            {
                Console.WriteLine("Name exceeds 35 character limit.\n Please try again.");
                Controller.Create();

            }

            email = Console.ReadLine();

            if (!Controller.IsValidEmail(email))
            {
                Console.WriteLine("Email format incorrect. Please try again.");
                Controller.Create();
            }

            number = Console.ReadLine();

            if(number.Length != 9 || number.All(char.IsDigit))
            {
                Console.WriteLine("Incorrect number format. Please try again.");
                Controller.Create();
            }

            Console.WriteLine("Successfully inserted a new contact.");
            db.Contacts.Add(new Contact{ Name = name, Email=email, Number=number});
            db.SaveChanges();

        }
        public static void Show()
        {   
            Console.WriteLine("Id of contact you wish to see: ");            
            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine("Querying for a contact...");

            var contact = db.Contacts.OrderBy(b => b.Id).First();
            Console.WriteLine($"Name: {contact.Name} Email: {contact.Email} Number: {contact.Number}");
            InputHelper.GetUserInput();
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
        static bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith(".")) {
                return false;
            }

            try {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }

            catch {
                return false;
            }
        }
    }
}
using System;
using System.Linq;

using var db = new ContactContext();

// Note: This sample requires the database to be created before running.
Console.WriteLine($"Database path: {db.DbPath}.");

// Create
Console.WriteLine("Inserting a new contact");
db.Add(new Contact { Name = "Ian", Email="ian.dzindo01@gmail.com", Number="061227556"});
db.SaveChanges();

// Read
Console.WriteLine("Querying for a contact");
var contact = db.Contacts.OrderBy(b => b.Id).First();

// Update
Console.WriteLine("Updating a contact");
contact.Number = "061147154";
db.SaveChanges();

// Delete
Console.WriteLine("Delete a contact");
db.Remove(contact);
db.SaveChanges();

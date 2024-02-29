using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;




public class Contact
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Number { get; set; }
}

public class ContactContext : DbContext
{
    public DbSet<Contact> Contacts { get; set; }
    public string DbPath { get; }
    
    public ContactContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "contacts.db");
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseSqlite($"Data Source={DbPath}");
}
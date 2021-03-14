using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ContactBook.Models;

namespace ContactBook.ViewModels
{
    // Capabilities:
    //
    // Add a new contact
    // Get all of the contacts in the database
    // Get a single contact by id
    // Update a contact 
    // Delete a contact from the database

    public interface IContactStore
    {
        Task AddContact(Contact contact);
        Task<Contact> GetContact(int id);
        Task<IEnumerable<Contact>> GetContacts();
        Task UpdateContact(Contact contact);
        Task DeleteContact(Contact contact);
    }
}

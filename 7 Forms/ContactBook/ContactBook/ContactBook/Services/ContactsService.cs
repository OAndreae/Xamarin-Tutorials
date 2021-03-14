using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContactBook.Models;

namespace ContactBook.Services
{
    public class ContactsService
    {
        private readonly List<Contact> _contacts;

        public ContactsService()
        {
            _contacts = new List<Contact>
            {
                new Contact
                {
                    Id=1,
                    FirstName="Oliver",
                    Surname="Andreae",
                    Email="oliverandreae@outlook.com",
                    PhoneNumber="07721 180105",
                    IsBlocked=true
                },

                new Contact
                {
                    Id=2,
                    FirstName="Lynne",
                    Surname="Andreae",
                    Email="lynneandreae@hotmail.co.uk",
                    PhoneNumber="07785 184204",
                    IsBlocked=false
                }
            };
        }

        public void AddContact(Contact contact)
        { 
            //if (_contacts.Exists(c => c.Id == contact.Id))
            //    throw new ArgumentException(string.Format("Contact already exists with id {0}", contact.Id));

            _contacts.Add(contact);
        }

        public IEnumerable<Contact> GetContacts(string filter = null)
        {
            if (filter != null)
                return _contacts.Where(c => c.FirstName.Contains(filter) || c.Surname.Contains(filter));

            return _contacts;
        }

        public void UpdateContact(Contact contact)
        {
            if (!_contacts.Exists(c => c.Id == contact.Id))
                throw new ArgumentException(string.Format("Contact doesn't with id {0} doesn't exist", contact.Id));

            var index = _contacts.FindIndex(c => c.Id == contact.Id);
            _contacts[index].FirstName = contact.FirstName;
            _contacts[index].Surname = contact.Surname;
            _contacts[index].PhoneNumber = contact.PhoneNumber;
            _contacts[index].Email = contact.Email;
            _contacts[index].IsBlocked = contact.IsBlocked;
        }

        public void DeleteContact(Contact contact)
        {
            _contacts.Remove(contact);
        }
    }

}

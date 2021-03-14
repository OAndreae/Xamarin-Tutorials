using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using ContactBook.Models;
using Xamarin.Forms;

namespace ContactBook.ViewModels
{
    public class ContactsDetailViewModel : ViewModelBase
    {
        private readonly IPageService _pageService;
        private readonly IContactStore _contactStore;

        public Contact Contact { get; set; }
        public string Title { get; private set; }

        public ICommand SaveContactCommand { get; private set; }

        public ContactsDetailViewModel(ContactViewModel contact, IPageService pageService, IContactStore contactStore)
        {
            if (contact == null)
                throw new ArgumentNullException(nameof(contact));

            Contact = new Contact
            {
                Id = contact.Id,
                FirstName = contact.FirstName,
                Surname = contact.Surname,
                PhoneNumber = contact.PhoneNumber,
                Email = contact.Email,
                IsBlocked = contact.IsBlocked
            };

            Title = Contact.Id == 0 ? "New contact" : "Update contact";

            SaveContactCommand = new Command(SaveContact);

            _pageService = pageService;
            _contactStore = contactStore;
        }

        public async void SaveContact()
        {
            if (string.IsNullOrWhiteSpace(Contact.FirstName) &&
                string.IsNullOrWhiteSpace(Contact.Surname))
            {
                await _pageService.DisplayAlert("Invalid contact", "Please enter a name for your contact", "OK");
                return;
            }

            // Id==0 indicates a new contact
            if (Contact.Id == 0)
            {
                await _contactStore.AddContact(Contact);
                MessagingCenter.Send(this, Events.ContactAdded, Contact);
            }
            else
            {
                await _contactStore.UpdateContact(Contact);
                MessagingCenter.Send(this, Events.ContactUpdated, Contact);
            }

            // Database and contacts page are updated
            // so navigate back to the contacts page
            await _pageService.PopAsync();
        }
    }
}

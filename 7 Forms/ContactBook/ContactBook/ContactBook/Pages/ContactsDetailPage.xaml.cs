using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactBook.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactBook
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactsDetailPage : ContentPage
    {
        private readonly int _contactId;

        public EventHandler<Contact> ContactAdded;

        public EventHandler<Contact> ContactUpdated;

        public ContactsDetailPage(Contact contact)
        {
            InitializeComponent();
            if (contact == null)
                throw new ArgumentNullException(nameof(contact));

            BindingContext = new Contact
            {
                Id = contact.Id,
                FirstName = contact.FirstName,
                Surname = contact.Surname,
                PhoneNumber = contact.PhoneNumber,
                Email = contact.Email,
                IsBlocked = contact.IsBlocked
            };

            if (contact.Id != 0)
                Title = "Update contact";
        }

        protected virtual void OnContactUpdated(Contact contact)
        {
            ContactUpdated?.Invoke(this, contact);
        }

        protected virtual void OnContactAdded(Contact contact)
        {
            ContactAdded?.Invoke(this, contact);
        }

        private void Save_Clicked(object sender, EventArgs e)
        {
            // validate input
            // assume that input is correct
            if(string.IsNullOrWhiteSpace(firstNameInput.Text) && string.IsNullOrWhiteSpace(surnameInput.Text))
            {
                DisplayAlert("Invalid contact", "Please enter the name of your contact", "OK");
                return;
            }

            var newContact = BindingContext as Contact;

            if (newContact.Id == 0)
                OnContactAdded(newContact);
            else
                OnContactUpdated(newContact);

            Navigation.PopAsync();
        }
    }
}
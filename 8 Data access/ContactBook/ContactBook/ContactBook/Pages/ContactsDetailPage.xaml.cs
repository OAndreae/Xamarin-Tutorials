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
        public EventHandler<Contact> ContactAdded;
        public EventHandler<Contact> ContactUpdated;

        private SQLite.SQLiteAsyncConnection _connection;

        public ContactsDetailPage(Contact contact)
        {
            InitializeComponent();

            if (contact == null)
                throw new ArgumentNullException(nameof(contact));

            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();

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

        private async void Save_Clicked(object sender, EventArgs e)
        {
            // validate input
            // assume that the input is in the correct format
            if(string.IsNullOrWhiteSpace(firstNameInput.Text) && string.IsNullOrWhiteSpace(surnameInput.Text))
            {
                await DisplayAlert("Invalid contact", "Please enter the name of your contact", "OK");
                return;
            }

            var contact = BindingContext as Contact;

            if (contact.Id == 0)
            {
                await _connection.InsertAsync(contact);
                ContactAdded?.Invoke(this, contact);
            }
            else
            {
                await _connection.UpdateAsync(contact);
                ContactUpdated?.Invoke(this, contact);
            }

            await Navigation.PopAsync();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactBook.Models;
using ContactBook.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactBook
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactsPage : ContentPage
    {
        private ContactsService _contactsService;
        private ObservableCollection<Contact> _contacts;

        public ContactsPage()
        {
            InitializeComponent();
            _contactsService = new ContactsService();

            _contacts = new ObservableCollection<Contact>(_contactsService.GetContacts());
            listView.ItemsSource = _contacts;
        }

        private async void OnContactSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var selectedContact = e.SelectedItem as Contact;

            var page = new ContactsDetailPage(selectedContact);

            page.ContactUpdated += (source, contact) =>
            {
                _contactsService.UpdateContact(contact);
            };
            
            await Navigation.PushAsync(page);
            listView.SelectedItem = null;
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            var contact = (sender as MenuItem).CommandParameter as Contact;
            if(await DisplayAlert("Delete contact", string.Format("Are you sure you want to delete {0} {1} from your contacts?", contact.FirstName, contact.Surname), "Yes", "No"))
            {
                _contactsService.DeleteContact(contact);
                _contacts.Remove(contact);
            }
        }

        private async void OnAddClicked(object sender, EventArgs e)
        {
            var page = new ContactsDetailPage(new Contact());
            page.ContactAdded += (source, contact) =>
            {
                // update data storage
                _contactsService.AddContact(contact);

                // update local view
                _contacts.Add(contact);
            };

            await Navigation.PushAsync(page);
        }
    }
}
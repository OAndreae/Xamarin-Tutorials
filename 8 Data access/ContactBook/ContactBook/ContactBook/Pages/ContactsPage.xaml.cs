using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactBook.Models;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactBook
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactsPage : ContentPage
    {
        //private ContactsService _contactsService;
        private SQLiteAsyncConnection _connection;
        private ObservableCollection<Contact> _contacts;

        private bool _isDataLoaded = false;

        public ContactsPage()
        {
            InitializeComponent();
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        protected override async void OnAppearing()
        {
            if (_isDataLoaded)
                return;

            await LoadDataAsync();
            _isDataLoaded = true;

            base.OnAppearing();
        }

        private async Task LoadDataAsync()
        {
            await _connection.CreateTableAsync<Contact>();
            var contacts = await _connection.Table<Contact>().ToListAsync();

            _contacts = new ObservableCollection<Contact>(contacts);
            listView.ItemsSource = _contacts;
        }

        private async void OnContactSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var selectedContact = e.SelectedItem as Contact;
            var page = new ContactsDetailPage(selectedContact);
            page.ContactUpdated += async (source, c) =>
            {
                selectedContact.FirstName = c.FirstName;
                selectedContact.Surname = c.Surname;
                selectedContact.PhoneNumber = c.PhoneNumber;
                selectedContact.Email = c.Email;
                selectedContact.IsBlocked = c.IsBlocked;
                await _connection.UpdateAsync(selectedContact);
            };
            
            await Navigation.PushAsync(page);
            listView.SelectedItem = null;
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            var contact = (sender as MenuItem).CommandParameter as Contact;
            if(await DisplayAlert("Delete contact", string.Format("Are you sure you want to delete {0} {1} from your contacts?", contact.FirstName, contact.Surname), "Yes", "No"))
            {
                _contacts.Remove(contact);
            }
        }

        private async void OnAddClicked(object sender, EventArgs e)
        {
            var page = new ContactsDetailPage(new Contact());
            page.ContactAdded += (source, contact) =>
            {
                _contacts.Add(contact);
            };

            await Navigation.PushAsync(page);
        }
    }
}
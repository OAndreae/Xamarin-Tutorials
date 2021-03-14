using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinTutorials.Models;

namespace XamarinTutorials
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewPage : ContentPage
    {
        private ObservableCollection<Contact> _contacts;

        public ListViewPage()
        {
            InitializeComponent();

            var contacts = new ObservableCollection<Contact>
            {
                    new Contact{FirstName="Oliver", LastName="Andreae", ImageUrl=@"https://loremflickr.com/100/100/smile", Status="Hello!"},
                    new Contact{FirstName="Elliot", LastName="Andreae", ImageUrl=@"https://loremflickr.com/100/100/smile", Status="Hello!"},

                    new Contact{FirstName="Lucy", LastName="Binks", ImageUrl=@"https://loremflickr.com/100/100/smile", Status="Hello!"},
                    new Contact{FirstName="Sophie", LastName="Binks", ImageUrl=@"https://loremflickr.com/100/100/smile", Status="Hello!"}
            };

            _contacts = contacts;
            listView.ItemsSource = contacts;
        }

        private void Call_Clicked(object sender, EventArgs e)
        {
            var contact = (sender as MenuItem).CommandParameter as Contact;
            DisplayAlert("Call", contact.FullName, "OK");
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            var contact = (sender as MenuItem).CommandParameter as Contact;
            _contacts.Remove(contact);
        }
    }
}
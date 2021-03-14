using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Navigation.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Navigation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SimpleContactsMasterPage : ContentPage
    {
        private List<Contact> _contacts;

        public SimpleContactsMasterPage()
        {
            InitializeComponent();

            _contacts = new List<Contact>
            {
                new Contact {Name="Oliver", Number="07725 458658"},
                new Contact {Name="Elliot", Number="07723 597458"},
                new Contact{Name="Charlotte", Number="07758 455784"}
            };

            listView.ItemsSource = _contacts;
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var contact = e.SelectedItem as Contact;
            await Navigation.PushAsync(new SimpleContactsDetailPage(contact));

            listView.SelectedItem = null;
        }
    }
}
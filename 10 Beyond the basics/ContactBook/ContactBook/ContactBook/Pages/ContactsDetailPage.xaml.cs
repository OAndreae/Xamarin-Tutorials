using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactBook.Models;
using ContactBook.Persistence;
using ContactBook.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactBook
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactsDetailPage : ContentPage
    {

        public ContactsDetailViewModel ViewModel
        {
            get { return BindingContext as ContactsDetailViewModel; }
            set { BindingContext = value; }
        }

        public ContactsDetailPage(ContactViewModel contact = null)
        {
            // Add a new contact
            if (contact == null)
                contact = new ContactViewModel();

            InitializeComponent();

            ViewModel = new ContactsDetailViewModel(contact, new PageService(), new SQLiteContactStore());
        }

        private void Save_Clicked(object sender, EventArgs e)
        {
            ViewModel.SaveContact();
        }
    }
}
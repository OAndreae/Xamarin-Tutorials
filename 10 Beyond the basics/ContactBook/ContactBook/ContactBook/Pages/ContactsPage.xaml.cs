using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactBook.Models;
using ContactBook.Persistence;
using ContactBook.ViewModels;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactBook
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactsPage : ContentPage
    {
        public ContactsViewModel ViewModel
        {
            get { return BindingContext as ContactsViewModel; }
            set { BindingContext = value; }
        }


        public ContactsPage()
        {
            InitializeComponent();
            ViewModel = new ContactsViewModel(new PageService(), new SQLiteContactStore());
        }

        protected override void OnAppearing()
        {
            ViewModel.LoadContacts();

            base.OnAppearing();
        }

        private void OnContactSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel.ViewContactCommand.Execute(e.SelectedItem as ContactViewModel);
        }
    }
}
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
    public partial class ContactsDetailPage : ContentPage
    {
        public ContactsDetailPage(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException("contact");

            InitializeComponent();

            BindingContext = contact;
        }
    }
}
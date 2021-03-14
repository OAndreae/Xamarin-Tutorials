using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Navigation.Models;

namespace Navigation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SimpleContactsDetailPage : ContentPage
    {
        public SimpleContactsDetailPage(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException("contact");

            InitializeComponent();
            BindingContext = contact;
        }
    }
}
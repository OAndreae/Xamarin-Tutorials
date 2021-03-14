using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Navigation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToolbarExample : ContentPage
    {
        public ToolbarExample()
        {
            InitializeComponent();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Add new item", "New item added", "OK");
        }

        private async void ViewActionSheet_Clicked(object sender, EventArgs e)
        {
            await DisplayActionSheet("Share", "Cancel", "Delete", "WhatsApp", "Instagram", "Facebook");
        }
    }
}
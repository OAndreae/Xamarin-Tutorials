using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Navigation.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Navigation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserProfilePage : ContentPage
    {
        private readonly UserService _userService;

        public UserProfilePage(int userId)
        {
            _userService = new UserService();
            InitializeComponent();
            BindingContext = _userService.GetUser(userId);
            //postsView.ItemsSource = _userService.GetUser(userId).Posts;
        }

        private void OnMoreClicked(object sender, EventArgs e)
        {
            DisplayActionSheet(null, null, null, "Report...", "Block", "Hide Your Story", "Copy Profile URL", "Send Profile as Message");
        }

        private void OnBackButtonClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}
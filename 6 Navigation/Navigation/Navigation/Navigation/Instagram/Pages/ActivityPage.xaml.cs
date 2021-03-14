using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Navigation.Models;
using Navigation.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Navigation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActivityPage : ContentPage
    {
        private readonly ActivityService _activityService;

        public ActivityPage()
        {
            _activityService = new ActivityService();
            InitializeComponent();
            listView.ItemsSource = _activityService.GetActivities();
        }

        private async void OnActivitySelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var activity = (e.SelectedItem as Activity);
            listView.SelectedItem = null;
            await Navigation.PushAsync(new UserProfilePage(activity.UserId));

        }
    }
}
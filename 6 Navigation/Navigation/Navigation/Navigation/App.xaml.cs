using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Navigation
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var appColour = Color.WhiteSmoke;

            MainPage = new NavigationPage(new TabbedShell())
            {
                Visual = VisualMarker.Material,
                BarTextColor = Color.Black,
                BarBackgroundColor = appColour,
                BackgroundColor = appColour
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

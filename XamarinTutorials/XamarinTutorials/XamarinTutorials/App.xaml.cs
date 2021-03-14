using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinTutorials
{
    public partial class App : Application
    {
        private readonly string TitleKey = "Title";
        private readonly string NotificationsEnabledKey = "NotificationsEnabled";

        public string Title
        {
            get
            {
                if (Application.Current.Properties.ContainsKey(TitleKey))
                    return Application.Current.Properties[TitleKey].ToString();

                return "";
            }

            set
            {
                Application.Current.Properties[TitleKey] = value;
            }
        }

        public bool NotificationsEnabled
        {
            get
            {
                if (Application.Current.Properties.ContainsKey(NotificationsEnabledKey))
                    return (bool) Current.Properties[NotificationsEnabledKey];
                return true;
            }

            set
            {
                Application.Current.Properties[NotificationsEnabledKey] = value;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new OnlinePostsPage());
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

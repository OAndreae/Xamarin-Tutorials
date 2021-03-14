using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ContactBook.ViewModels
{
    public class PageService : IPageService
    {
        public Task<bool> DisplayAlert(string title, string message, string accept, string cancel = null)
        {
            return MainPage.DisplayAlert(title, message, accept, cancel);
        }

        public Task PopAsync()
        {
            return MainPage.Navigation.PopAsync();
        }

        public Task PushAsync(Page page)
        {
            return MainPage.Navigation.PushAsync(page);
        }

        public Task DisplayAlert(string title, string message, string cancel)
        {
            return MainPage.DisplayAlert(title, message, cancel);
        }

        private Page MainPage { get { return Application.Current.MainPage; } }
    }
}

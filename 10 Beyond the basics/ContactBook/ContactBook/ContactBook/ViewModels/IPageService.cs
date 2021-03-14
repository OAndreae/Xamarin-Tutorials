using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ContactBook.ViewModels
{
    // Capabilites:
    // Navigate to a new page
    // Navigate back to the previous page
    // Display an alert

    public interface IPageService
    {
        Task PushAsync(Page page);
        Task PopAsync();
        Task<bool> DisplayAlert(string title, string message, string accept, string cancel = null);
        Task DisplayAlert(string title, string message, string cancel);
    }
}

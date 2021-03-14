using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinTutorials.Models;

namespace XamarinTutorials
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InboxPage : ContentPage
    {
        private ObservableCollection<Email> _emails;

        public InboxPage()
        {
            InitializeComponent();

            _emails = new ObservableCollection<Email>
            {
                new Email
                {
                    SenderName="Hudson, Susan",
                    Subject="Volunteer Induction Day",
                    Message=@"Hi Oliver,

I am inviting you to attend the next Dudmaston Hall Volunteer Induction Day on Wednesday, 11th September 2019.

The programme runs from 11am to 3.30pm and comprises a presentation followed by a tour/introduction to the various departments and will include lunch.

You are advised to wear warm clothing and sensible footwear.

It is important that you attend an Induction Day so I would be most grateful if you would let me know whether or not you are able to attend.

Best wishes
Sue Hudson"
                },

                new Email
                {
                    SenderName="Aide Pottinger",
                    Subject="Officiating",
                    Message=@"
Hi Oliver, 
Hope the exams have gone well for you, and that you are able to relax and enjoy life a bit more. 
Have you had any thoughts about doing any meetings this year. We still have plenty of season left if you fancy gaining your L1 this year. 
If you need any help, or pointing in the right direction, don't hesitate to contact me here or on 07866811346
Best wishes
Adie
--
Sent from Outlook Email App for Android
"
                },

                new Email
                {
                    SenderName="Amazon.co.uk",
                    Subject="Your order has been dispatched"
                },
            };

            listView.ItemsSource = _emails;        
        }

        private void UpdateEmails()
        {
            _emails = new ObservableCollection<Email>
            {
                new Email {SenderName = "Lynne Andreae", Subject = "Oxford day" },
                new Email {SenderName="Amazon.co.uk", Subject="Your Amazon.co.uk order of \"Piano Mix 1: Great...\" has been dispatched"},
                new Email {SenderName="Microsoft Developer", Subject="Your payment from October 2019 has been paid to your bank account"}
            };

            listView.ItemsSource = _emails;
        }

        private IEnumerable<Email> FilterEmails(IEnumerable<Email> emails, string searchText)
        {
            if (string.IsNullOrEmpty(searchText))
                return emails;

            return emails.Where(c => c.SenderName.ToUpper().Contains(searchText.ToUpper()) || c.Subject.ToUpper().Contains(searchText.ToUpper()));
        }

        private void ListView_Refreshing(object sender, EventArgs e)
        {
            UpdateEmails();

            listView.EndRefresh();
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            listView.ItemsSource = FilterEmails(_emails, e.NewTextValue);
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            var email = (sender as MenuItem).CommandParameter as Email;
            _emails.Remove(email);
        }
    }
}
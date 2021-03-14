using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinTutorials
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuotesPage : ContentPage
    {
        private List<string> _quotes;

        public QuotesPage()
        {
            InitializeComponent();
            _quotes = new List<string>
            {
                "Intelligence is the ability to adapt to change.",
                "We are all now connected by the Internet, like neurons in a giant brain.",
                "However difficult life may seem, there is always something you can do and succeed at."
            };

            quoteLabel.Text = _quotes[0];
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var index = _quotes.FindIndex((string arg) =>
            {
                return arg == quoteLabel.Text;
            });

            // wrap round or move onto next quote
            if (index == _quotes.Count - 1)
                index = 0;
            else
                index++;

            quoteLabel.Text = _quotes[index];
        }
    }
}
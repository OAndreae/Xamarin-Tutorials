using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamlEssentials
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Padding = GetThickness();

        }

        private Thickness GetThickness()
        {
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    return new Thickness(0, 20, 0, 0);
                default:
                    return new Thickness(0, 0, 0, 0);
            }
        }
    }
}

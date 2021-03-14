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
    public partial class EmbeddedImagePage : ContentPage
    {
        public EmbeddedImagePage()
        {
            InitializeComponent();

            //image.Source = ImageSource.FromResource("XamarinTutorials.Images.background.jpg");
        }
    }
}
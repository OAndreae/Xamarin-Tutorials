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
    public partial class PhotoGalleryPage : ContentPage
    {
        private List<string> _images;
        private int _imageIndex;

        public PhotoGalleryPage()
        {
            InitializeComponent();
            _images = new List<string>
            {
                @"https://www.bing.com/th?id=OIP.1YM53mG10H_U25iPjop83QHaEo&pid=Api&rs=1&p=0",
                @"https://www.bing.com/th?id=OIP.mYWopSug3k_E8lUA5GCwAAHaEo&pid=Api&rs=1&p=0",
                @"https://www.bing.com/th?id=OIP.DwTdZwLSYEiXy5EscPrhWQHaEK&pid=Api&rs=1&p=0",
                @"https://www.wallpapersin4k.org/wp-content/uploads/2017/04/Green-Nature-Wallpaper-HD-13.jpg",
                @"https://jooinn.com/images/nature-328.jpg",
                @"https://wallpapershome.com/images/wallpapers/mountain-3840x2160-lake-trees-4k-16728.jpeg",
                @"https://www.bing.com/th?id=OIP.sZdgMA-FLkCwsc4KWzSAfwHaEK&pid=Api&rs=1&p=0",
                @"https://wallpapershome.com/images/wallpapers/isle-of-skye-7680x4320-scotland-europe-nature-travel-8k-14973.jpg",
                @"https://www.bing.com/th?id=OIP.IwZ5_cJLJ1AO8up5cRlopQHaEo&pid=Api&rs=1&p=0",
                @"http://www.hdwallpaper.nu/wp-content/uploads/2015/04/Nature___Seasons___Spring_Beautiful_spring_forest_065881_.jpg",
                @"https://wallup.net/wp-content/uploads/2017/03/16/198298-lake-Dolomites_mountains-forest-mountains-reflection-Alps-summer-trees-cabin-nature-landscape-sky.jpg",
                @"http://stnicks.org.uk/wp-content/uploads/2014/03/DaisyComfreyView_amended.jpg",
                @"https://wallup.net/wp-content/uploads/2016/01/47222-anime-landscape-nature.jpg"
            };

            _imageIndex = 0;
            UpdateImageSource();
        }


        private void RightButton_Clicked(object sender, EventArgs e)
        {
            if (_imageIndex == _images.Count - 1)
            {
                _imageIndex = 0;
            }
            else
                _imageIndex++;

            UpdateImageSource();
        }

        private void LeftButton_Clicked(object sender, EventArgs e)
        {
            if (_imageIndex == 0)
            {
                _imageIndex = _images.Count - 1;
            }
            else
                _imageIndex--;

            UpdateImageSource();
        }

        private void UpdateImageSource()
        {
            var source = new UriImageSource
            {
                Uri = new Uri(_images[_imageIndex]),
                CachingEnabled = false
            };

            image.Source = source;
            imageLabel.Text = "Image " + (_imageIndex + 1).ToString();
        }
    }
}
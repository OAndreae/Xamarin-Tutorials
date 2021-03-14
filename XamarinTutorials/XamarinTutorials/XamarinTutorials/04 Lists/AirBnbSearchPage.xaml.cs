using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinTutorials.Models;
using XamarinTutorials.Services;

namespace XamarinTutorials
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AirBnbSearchPage : ContentPage
    {
        private SearchService _searchService;
        private List<SearchGroup> _searchGroups;

        public AirBnbSearchPage()
        {
            InitializeComponent();

            _searchService = new SearchService();
            PopulateListView();
        }

        private void PopulateListView(string filter = null)
        {
            _searchGroups = new List<SearchGroup>()
            {
                new SearchGroup("Recent searches", _searchService.GetRecentSearches(filter))
            };

            listView.ItemsSource = _searchGroups;
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            PopulateListView(e.NewTextValue);
        }
    }
}
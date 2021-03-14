using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Lists.Models;
using Lists.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lists
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AirBnbSearchPage : ContentPage
    {
        private SearchService _searchService;
        private ObservableCollection<SearchGroup> _searchGroups;

        public AirBnbSearchPage()
        {
            _searchService = new SearchService();

            InitializeComponent();

            PopulateListView(_searchService.GetRecentSearches());
        }

        private void PopulateListView(IEnumerable<Search> searches)
        {
            _searchGroups = new ObservableCollection<SearchGroup>()
            {
                new SearchGroup("Recent searches", searches)
            };

            listView.ItemsSource = _searchGroups;
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            PopulateListView(_searchService.GetRecentSearches(e.NewTextValue));
        }

        private void ListView_Refreshing(object sender, EventArgs e)
        {
            PopulateListView(_searchService.GetRecentSearches(searchBar.Text));
            listView.IsRefreshing = false;
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            var search = (sender as MenuItem).CommandParameter as Search;

            // remove locally to automatically update list view
            foreach (var group in _searchGroups)
                group.Remove(search);

            _searchService.DeleteSearch(search.Id);
        }
    }
}
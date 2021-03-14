using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using XamarinTutorials.Models;

namespace XamarinTutorials.Services
{
    public class SearchService
    {
        private List<Search> _searches;

        public SearchService()
        {
            var checkIn = DateTime.Parse("1/9/2019", new CultureInfo("en-GB"));

            _searches = new List<Search>
            {
                new Search{Id=0, Location="West Hollywood, CA, United States", CheckIn=DateTime.Parse("1/9/2019", new CultureInfo("en-GB")), CheckOut=DateTime.Parse("1/11/2019", new CultureInfo("en-GB"))},
                new Search{Id=1, Location="Bridgnorth, Shropshire, United Kingdom", CheckIn=DateTime.Parse("2/10/2019", new CultureInfo("en-GB")), CheckOut=DateTime.Parse("5/12/2019", new CultureInfo("en-GB"))},
                new Search{Id=2, Location="West Hollywood, CA, United States", CheckIn=DateTime.Parse("25/11/2019", new CultureInfo("en-GB")), CheckOut=DateTime.Parse("30/11/2019", new CultureInfo("en-GB"))}
            };
        }

        public IEnumerable<Search> GetRecentSearches(string filter = null)
        {
            if (string.IsNullOrWhiteSpace(filter))
                return _searches;
            return _searches.Where(e => e.Location.ToUpper().Contains(filter.ToUpper()));
        }

        public void DeleteSearch(int searchId)
        {
            _searches.RemoveAll(e => e.Id == searchId);
        }
    }
}

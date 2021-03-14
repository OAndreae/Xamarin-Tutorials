using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Lists.Models;

namespace Lists.Services
{
    public class SearchService
    {
        private List<Search> _searches;

        public SearchService()
        {
            _searches = new List<Search>
            {
                new Search
                {
                    Id = 0,
                    Location = "West Hollywood, CA, United States",
                    CheckIn = new DateTime(2019,9,1),
                    CheckOut =  new DateTime(2019,11,1)
                },
                new Search
                {
                    Id = 1,
                    Location = "Bridgnorth, United Kingdom",
                    CheckIn = new DateTime(2019,10,2),
                    CheckOut = new DateTime(2019,12,5)
                },
                new Search
                {
                    Id = 2,
                    Location = "Oxford, United Kingdom",
                    CheckIn = new DateTime(2019, 7, 28),
                    CheckOut = new DateTime(2019,8,14)
                }
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
            // note: Single throws an exception if there is more than one item with
            // the same Id
            _searches.Remove(_searches.Single(s => s.Id == searchId));
        }
    }
}

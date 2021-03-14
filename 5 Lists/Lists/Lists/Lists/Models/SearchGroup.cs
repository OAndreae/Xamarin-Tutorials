using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Lists.Models
{
    public class SearchGroup : ObservableCollection<Search>
    {
        public string Title { get; set; }

        public SearchGroup(string title, IEnumerable<Search> searches = null)
            : base(searches)
        {
            Title = title;
        }
    }

    public interface IObservableCollection<T>
    {
    }
}

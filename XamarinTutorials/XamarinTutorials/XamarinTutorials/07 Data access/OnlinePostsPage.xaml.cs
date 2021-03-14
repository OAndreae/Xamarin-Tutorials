using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinTutorials.Models;

namespace XamarinTutorials
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OnlinePostsPage : ContentPage
    {
        private readonly string Url = @"https://jsonplaceholder.typicode.com/posts";
        private HttpClient _client = new HttpClient();

        private ObservableCollection<Post> _posts;
        
        public OnlinePostsPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            var content = await _client.GetStringAsync(Url);
            var posts = JsonConvert.DeserializeObject<List<Post>>(content);

            _posts = new ObservableCollection<Post>(posts);
            postsListView.ItemsSource = _posts;

            base.OnAppearing();
        }

        private async void OnAdd(object sender, EventArgs e)
        {
            var post = new Post
            {
                Id = _posts.Count + 1,
                Title = DateTime.Now.Ticks.ToString()
            };

            _posts.Insert(0, post);

            var content = JsonConvert.SerializeObject(post);
            await _client.PostAsync(string.Format(Url + "/{0}", post.Id), new StringContent(content));
        }

        private async void OnUpdate(object sender, EventArgs e)
        {
            if (_posts.Count <= 0)
                return;
            var post = _posts[0];
            post.Title += " UPDATED";

            var content = JsonConvert.SerializeObject(post);
            await _client.PutAsync(string.Format(Url + "/{0}", post.Id), new StringContent(content));
        }

        private void OnDelete(object sender, EventArgs e)
        {
            if (_posts.Count <= 0)
                return;

            var post = _posts[0];

            _posts.Remove(post);
            _client.DeleteAsync(Url + "/" + post.Id);
        }

    }
}
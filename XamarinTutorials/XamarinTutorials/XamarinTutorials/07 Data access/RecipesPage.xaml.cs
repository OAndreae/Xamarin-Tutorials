using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinTutorials.Models;

namespace XamarinTutorials
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipesPage : ContentPage
    {
        private readonly SQLiteAsyncConnection _connection;
        private ObservableCollection<Recipe> _recipes;

        public RecipesPage()
        {
            InitializeComponent();
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        protected override async void OnAppearing()
        {
            await _connection.CreateTableAsync<Recipe>();

            var recipes = await _connection.Table<Recipe>().ToListAsync();

            _recipes = new ObservableCollection<Recipe>(recipes);
            recipesListView.ItemsSource = _recipes;

            base.OnAppearing();
        }

        private async void OnAdd(object sender, EventArgs e)
        {
            var recipe = new Recipe { Name = "Recipe: " + DateTime.Now.TimeOfDay.ToString() };
            await _connection.InsertAsync(recipe);
            _recipes.Add(recipe);
        }

        private async void OnUpdate(object sender, EventArgs e)
        {
            if (_recipes.Count <= 0)
                return;

            var recipe = _recipes.Last();
            recipe.Name += " UPDATAED";
            await _connection.UpdateAsync(recipe);
        }

        private void OnDelete(object sender, EventArgs e)
        {
            if (_recipes.Count <= 0)
                return;

            var recipe = _recipes.Last();
            _connection.DeleteAsync(recipe);
            _recipes.Remove(recipe);
        }
    }
}
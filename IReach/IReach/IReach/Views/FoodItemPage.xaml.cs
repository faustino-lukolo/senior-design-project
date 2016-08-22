using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IReach.Models;
using IReach.Services;
using Xamarin.Forms;

namespace IReach.Views
{
    public partial class FoodItemPage : ContentPage
    {
        public FoodItemPage ( )
        {
            InitializeComponent ( );
        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
            var foodItem = (FoodItem) BindingContext;
            App.Database.SaveItem(foodItem);

            await this.Navigation.PopAsync();
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var foodItem = (FoodItem) BindingContext;
            App.Database.DeleteItem(foodItem.ID);
            await this.Navigation.PopAsync();
        }

        private void OnSpeakClicked(object sender, EventArgs e)
        {
            var foodItem = (FoodItem) BindingContext;
            DependencyService.Get<ITextToSpeech>().Speak(foodItem.Name);
        }
    }
}

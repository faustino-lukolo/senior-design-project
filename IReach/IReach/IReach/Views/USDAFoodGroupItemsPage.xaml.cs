using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IReach.Models;
using Xamarin.Forms;

namespace IReach.Views
{
    public partial class USDAFoodGroupItemsPage : ContentPage
    {
        public USDAFoodGroupItemsPage (int id )
        {
            InitializeComponent ( );
            GroupID = id;
            Debug.WriteLine("Display Foods in Group ID = {0}", GroupID);
        }
         
        public int GroupID { get; set; }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            foodGroupListView.ItemsSource = App.NutritionDb.GetFoodsWithGroupID(GroupID);
        }

        private void USDAFoodItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selected = (food) e.SelectedItem;
            Debug.WriteLine("Selected Food: {0} ID = {1}", selected.short_desc, selected.id); 
            var usdaFood = App.NutritionDb.GetFoodWithID(selected.id);

            Debug.WriteLine("Retrieved Food short desc: {0}", usdaFood.short_desc);

            var usdaFoodPage = new USDAFoodItemPage();
            usdaFoodPage.BindingContext = usdaFood;

            Navigation.PushAsync(usdaFoodPage);
        }
    }
}

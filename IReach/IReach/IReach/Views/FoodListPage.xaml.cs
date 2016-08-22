using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IReach.Models;
using IReach.Services;
using Xamarin.Forms;

namespace IReach.Views
{
    public partial class FoodListPage : ContentPage
    {
        private ToolbarItem tbi;
        public FoodListPage ( )
        {
            InitializeComponent ( );

            tbi = new ToolbarItem ( "+", null, ( ) =>
            {
                var foodItem = new FoodItem ( );
                var foodPage = new FoodItemPage ( );
                foodPage.BindingContext = foodItem;
                Navigation.PushAsync ( foodPage );
            }, 0, 0 );

            if (Device.OS == TargetPlatform.Android)
            {
                tbi = new ToolbarItem("+", "plus", () =>
                {
                    var foodItem = new FoodItem();
                    var foodPage = new FoodItemPage();
                    foodPage.BindingContext = foodItem;
                    Navigation.PushAsync(foodPage);
                },0,0); 
            }

            ToolbarItems.Add(tbi);
        }

        void listItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var foodItem = (FoodItem) e.SelectedItem;
            var foodPage = new FoodItemPage();
            foodPage.BindingContext = foodItem;

          
            ( (App) App.Current).ResumeAtFoodID = foodItem.ID;
            Debug.WriteLine("Setting ResumeAtFoodId = " + foodItem.ID); 
            
            Navigation.PushAsync(foodPage);

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ((App) App.Current).ResumeAtFoodID = -1;
            listView.ItemsSource = App.Database.GetFoodItems();
        }
    }
}

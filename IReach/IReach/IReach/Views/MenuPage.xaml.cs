using System;		  
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace IReach.Views
{
	public partial class MenuPage : ContentPage
	{
		RootPage root;
		List<HomeMenuItem> menuItems;
		public MenuPage (RootPage root)
		{
			this.root = root;
			InitializeComponent ( );
			if ( !App.IsWindows10 )
			{
				BackgroundColor = Color.FromHex ( "#03A9F4" );
				ListViewMenu.BackgroundColor = Color.FromHex ( "#F5F5F5" );
			}

			BindingContext = new BaseViewModel
			{
				Title = "IReach.Forms",
				Subtitle = "IReach.Forms",
				Icon = "slideout.png"  
			};

			ListViewMenu.ItemsSource = menuItems = new List<HomeMenuItem>
			{
                new HomeMenuItem {Title = "Home", MenuType = MenuType.Home, Icon ="home.png" },
                new HomeMenuItem {Title = "Diet", MenuType = MenuType.Diet, Icon = "diet.png" },
                new HomeMenuItem {Title = "Search USDA", MenuType = MenuType.Usda, Icon = "Search.png"},
                new HomeMenuItem {Title = "About", MenuType = MenuType.About, Icon ="about.png" } 
            };
			ListViewMenu.SelectedItem = menuItems[ 0 ];

			ListViewMenu.ItemSelected += async ( sender, e ) =>
			{
				if ( ListViewMenu.SelectedItem == null )
					return;

				await this.root.NavigateAsync ( ( ( HomeMenuItem )e.SelectedItem ).MenuType ); 

			};
		}
	}
}

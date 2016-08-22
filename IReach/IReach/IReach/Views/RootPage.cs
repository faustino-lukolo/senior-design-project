using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using IReach.Controls;
using Xamarin.Forms;

namespace IReach.Views
{
	public class RootPage : MasterDetailPage
	{
		public static bool IsUWPDesktop { get; set; }
		Dictionary<MenuType, NavigationPage> Pages;
		public RootPage ( )
		{
			Pages = new Dictionary<MenuType, NavigationPage> ( );
			Master = new MenuPage (this);

			BindingContext = new BaseViewModel
			{
				Title = "IReach",
				Icon = "slideout.png"
			};

			NavigateAsync ( MenuType.Home );
			InvalidateMeasure ( );
		}

		public async Task NavigateAsync ( MenuType id )
		{
			Page newPage;
			if ( !Pages.ContainsKey ( id ) )
			{
				switch ( id )
				{
					case MenuType.Home:
						Pages.Add ( id, new IReachNavigationPage ( new HomePage ( ) ) );
						break;  
                    case MenuType.Diet:
                        Pages.Add(id, new IReachNavigationPage(new FoodListPage()));
				        break;
                    case MenuType.Usda:
                        Pages.Add(id, new IReachNavigationPage(new USDASearchPage( ) ) );
                        break;
                    case MenuType.About:
                        Pages.Add ( id, new IReachNavigationPage ( new AboutPage ( ) ) );
                        break;
                }  
			}

            newPage = Pages[ id ];
            if ( newPage == null )
            {
                return;
            }

            if ( Detail != null && Device.OS == TargetPlatform.WinPhone )
                await Detail.Navigation.PopToRootAsync ( );

            Detail = newPage;

            if ( IsUWPDesktop )
                return;

            if ( Device.Idiom != TargetIdiom.Tablet )
                IsPresented = false;

        }
	}
}

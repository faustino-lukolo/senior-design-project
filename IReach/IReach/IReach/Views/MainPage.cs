using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace IReach.Views
{
	public class MainPage : MasterDetailPage
	{

		public static bool IsUWPDesktop { get; set; }
		Dictionary<MenuType, NavigationPage> Pages { get; set; }
		public MainPage ( )
		{
			Pages = new Dictionary<MenuType, NavigationPage> ( );
			Master = new MenuPage ( this );
			BindingContext = new BaseViewModel
			{
				Title = "Hanselman",
				Icon = "slideout.png"
			};
			//setup home page
			NavigateAsync ( MenuType.About );

			InvalidateMeasure ( );
		}



		public async Task NavigateAsync ( MenuType id )
		{
			Page newPage;
			if ( !Pages.ContainsKey ( id ) )
			{

				switch ( id )
				{
					case MenuType.About:
						Pages.Add ( id, new HanselmanNavigationPage ( new AboutPage ( ) ) );
						break;
					case MenuType.Blog:
						Pages.Add ( id, new HanselmanNavigationPage ( new BlogPage ( ) ) );
						break;
					case MenuType.DeveloperLife:
						Pages.Add ( id, new HanselmanNavigationPage ( new PodcastPage ( id ) ) );
						break;
					case MenuType.Hanselminutes:
						Pages.Add ( id, new HanselmanNavigationPage ( new PodcastPage ( id ) ) );
						break;
					case MenuType.Ratchet:
						Pages.Add ( id, new HanselmanNavigationPage ( new PodcastPage ( id ) ) );
						break;
					case MenuType.Twitter:
						Pages.Add ( id, new HanselmanNavigationPage ( new TwitterPage ( ) ) );
						break;
				}
			}

			newPage = Pages[ id ];
			if ( newPage == null )
				return;

			//pop to root for Windows Phone
			if ( Detail != null && Device.OS == TargetPlatform.WinPhone )
			{
				await Detail.Navigation.PopToRootAsync ( );
			}

			Detail = newPage;

			if ( IsUWPDesktop )
				return;

			if ( Device.Idiom != TargetIdiom.Tablet )
				IsPresented = false;
		}
	}
}

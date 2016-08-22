using Xamarin.Forms;

namespace IReach.Controls
{
	public class IReachNavigationPage  : NavigationPage
	{
		public IReachNavigationPage ( Page root ) : base(root)
        {
			Init ( );
		}

		public IReachNavigationPage ( )
		{
			Init ( );
		}

		void Init ( )
		{

			BarBackgroundColor = Color.FromHex ( "#03A9F4" );
			BarTextColor = Color.White;
		}

	}
}

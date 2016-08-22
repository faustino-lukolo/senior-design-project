using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IReach.Services;
using Xamarin.Forms;

namespace IReach.Views
{
    public partial class SplashPage : ContentPage
    {
        private readonly IAuthenticationService _authenticationService;

        public SplashPage ( )
        {
            InitializeComponent ( ); 

            
        }


        public string Username { get; set; }
        public string Password { get; set; }


        async void LogMeIn(object sender, EventArgs args)
        {
            App.GoToRoot();
        }
    }
}

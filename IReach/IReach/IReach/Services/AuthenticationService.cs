using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IReach.Services;
using Xamarin.Forms;

[assembly:Dependency(typeof(AuthenticationService))]
namespace IReach.Services
{
    public class AuthenticationService : IAuthenticationService
    {
       
        public bool IsAuthenticated
        {
            get
            {
                if (_AuthenticationBypassed)
                    return true;
                else
                {
                    return false;
                }

            } 
        }

        bool _AuthenticationBypassed;
        public void BypassAuthentication()
        {
            _AuthenticationBypassed = true;
        }

        // Change this to Async Function
        public bool AuthenticateAsync ( )
        {
            return true;
        }

    }
}

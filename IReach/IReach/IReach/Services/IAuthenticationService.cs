using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReach.Services
{
    public interface IAuthenticationService
    {
        bool AuthenticateAsync();
        bool IsAuthenticated { get; }
    }
}

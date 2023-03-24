using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seiri.Domain.Models;

namespace Seiri.Domain.Interfaces
{
    public interface IAuthenticationService
    {
		Task<AuthenticationResponse> SignIn(string username, string password);

    }
}

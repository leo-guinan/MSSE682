using SharedLibraries.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskWebApplication.AuthenticationService;

namespace TaskWebApplication.Service
{
    public class UserServiceAuthenticationWCFImpl : IAuthenticationService
    {
        public Boolean authenticateUser(User user)
        {
            AuthenticationService.AuthenticationServiceClient proxy = new AuthenticationServiceClient();
            return proxy.AuthenticateUser(user);
        }

    }
}
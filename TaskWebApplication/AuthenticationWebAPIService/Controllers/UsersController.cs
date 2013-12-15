using SharedLibraries.Domain;
using SharedLibraries.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AuthenticationWebAPIService.Controllers
{
    public class UsersController : ApiController
    {
        IUserService userService = new UserServiceADOImpl("taskManagement");

        public Boolean PostAuthenticateUser(User user)
        {
            return userService.authenticateUser(user);
        }

        public Boolean GetAuthenticateUser(String username, String password)
        {
            User user = new User(username, password);
            return userService.authenticateUser(user);
        }
    }
}

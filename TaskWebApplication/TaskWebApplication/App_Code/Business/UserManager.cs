using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharedLibraries.Domain;
using TaskWebApplication.Factory.Service;
using SharedLibraries.Service;
using TaskWebApplication.Service;


namespace TaskApp.Business
{
    public class UserManager : IUserManager
    {
        private IUserService userService;
        private IServiceFactory serviceFactory;
        private IAuthenticationService authenticationService;

        [Inject]
        public UserManager(IServiceFactory serviceFactory)
        {
            this.serviceFactory = serviceFactory;
            userService = (IUserService)serviceFactory.getService("userService");
            authenticationService = (IAuthenticationService)serviceFactory.getService("authenticationService");

        }

        public User addUser(String username, String password)
        {
            return userService.addUser(new User(username, password));
        }

        public Boolean login(String username, String password)
        {
            return authenticationService.authenticateUser(new User(username, password));
        }
    }
}
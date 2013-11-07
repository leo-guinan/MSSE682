using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskApp.Domain;
using TaskApp.Factory.Service;
using TaskApp.Service;


namespace TaskApp.Business
{
    public class UserManager : IUserManager
    {
        private IUserService userService;
        private IServiceFactory serviceFactory;

        [Inject]
        public UserManager(IServiceFactory serviceFactory)
        {
            this.serviceFactory = serviceFactory;
            userService = (IUserService)serviceFactory.getService("userService");

        }

        public Boolean addUser(String username, String password)
        {
            return userService.addUser(new User(username, password));
        }

        public Boolean login(String username, String password)
        {
            return userService.authenticateUser(new User(username, password));
        }
    }
}
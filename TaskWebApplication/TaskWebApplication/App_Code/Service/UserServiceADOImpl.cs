using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskApp.Domain;

namespace TaskWebApplication.Service
{
    public class UserServiceADOImpl : ServiceADOImpl, IUserService
    {
        public Boolean addUser(User user)
        {
            throw new NotImplementedException("Not implemented yet.");
        }
        public Boolean modifyUser(User user)
        {
            throw new NotImplementedException("Not implemented yet.");
        }
        public User getUserById(String id)
        {
            throw new NotImplementedException("Not implemented yet.");
        }
        public IList<User> getAllUsers()
        {
            throw new NotImplementedException("Not implemented yet.");
        }
        public Boolean removeUser(User user)
        {
            throw new NotImplementedException("Not implemented yet.");
        }
        public Boolean authenticateUser(User user)
        {
            throw new NotImplementedException("Not implemented yet.");
        }
    }
}
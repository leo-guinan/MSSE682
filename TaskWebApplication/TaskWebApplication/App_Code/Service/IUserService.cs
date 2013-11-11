using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskApp.Domain;

namespace TaskWebApplication.Service
{
    public interface IUserService : IService
    {
        Boolean addUser(User user);
        Boolean modifyUser(User user);
        User getUserById(String id);
        IList<User> getAllUsers();
        Boolean removeUser(User user);
        Boolean authenticateUser(User user);
    }
}
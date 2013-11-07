using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskApp.Domain;
using TaskApp.Repository;

namespace TaskApp.Service
{
    public class UserService : IUserService
    {
        IRepository<User> repository;
        
        public UserService(IRepository<User> repository)
        {
            this.repository = repository;
        }


        public Boolean addUser(User user)
        {
            return null != repository.addEntity(user);
        }

        public Boolean modifyUser(User user)
        {
            return null != repository.updateEntity(user);
        }

        public User getUserById(String id)
        {
            return repository.getEntity(id);

        }

        public IList<User> getAllUsers()
        {
            IList<User> allUsers = new List<User>();

            foreach (User item in repository.getAllEntities())
            {
                allUsers.Add(item);
            }

            return allUsers;

        }

        public Boolean removeUser(User user)
        {
            return repository.delete(user);
        }

        public Boolean authenticateUser(User user)
        {
            User targetUser = repository.getEntity(user.username);
            if (targetUser != null)
            {
                return user.password == targetUser.password;
            }
            return false;
        }
    }
}
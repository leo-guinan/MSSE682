using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskWebApplication.Domain;

namespace TaskApp.Business
{
    /// <summary>
    /// This is a business manager. It controls the business logic for all user related functionality. Adding, modification, removing, logging in, etc.
    /// </summary>
    public interface IUserManager
    {
        /// <summary>
        /// This method adds a user to the system.
        /// </summary>
        /// <param name="username">The username of the user to create.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns>if the user was created successfully.</returns>
        User addUser(String username, String password);

        /// <summary>
        /// This method logs a user into the system.
        /// </summary>
        /// <param name="username">The username of the user to create.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns>if the user log in was successful.</returns>
        Boolean login(String username, String password);
    }
}

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Security;
using SharedLibraries.Domain;
using SharedLibraries.Service;
using TaskWebpApplication.Factory.Service;

namespace TaskWebApplication.Membership
{
    public class CustomRoleProvider : RoleProvider
    {
        private string applicationName;
        private ServiceFactory serviceFactory = ServiceFactory.Instance;
        private IUserService userService;

        public override string ApplicationName
        {
            get
            {
                return applicationName;
            }
            set
            {
                applicationName = value;
            }
        }

        /// <summary>
        /// Initialize.
        /// </summary>
        /// <param name="usernames"></param>
        /// <param name="roleNames"></param>
        public override void Initialize(string name, NameValueCollection config)
        {
            userService = (IUserService)serviceFactory.getService("userService");
            if (config == null)
            {
                throw new ArgumentNullException("config");
            }
            if (name == null || name.Length == 0)
            {
                name = "CustomRoleProvider";
            }
            if (String.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "Custom Role Provider");
            }
            //Initialize the abstract base class.
            base.Initialize(name, config);
            applicationName = GetConfigValue(config["applicationName"], System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath);
        }

        /// <summary>
        /// Add users to roles.
        /// </summary>
        /// <param name="usernames"></param>
        /// <param name="roleNames"></param>
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            foreach (String username in usernames)
            {
                User user = userService.getUserByUsername(username);
                foreach (String roleName in roleNames)
                {
                    Role role = userService.getRoleByRoleName(roleName);
                    userService.addRoleToUser(user, role);
                }
            }
        }

        /// <summary>
        /// Create new role.
        /// </summary>
        /// <param name="roleName"></param>
        public override void CreateRole(string roleName)
        {
            Role role = new Role(roleName);
            userService.addRole(role);
        }

        /// <summary>
        /// Delete role.
        /// </summary>
        /// <param name="roleName"></param>
        /// <param name="throwOnPopulatedRole"></param>
        /// <returns>true if role is successfully deleted</returns>
        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            return userService.removeRole(roleName);
        }

        /// <summary>
        /// Find users in role.
        /// </summary>
        /// <param name="roleName"></param>
        /// <param name="usernameToMatch"></param>
        /// <returns></returns>
        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            List<string> users = new List<string>();
            var usersInRole = userService.getUsersInRole(roleName);
            if (usersInRole != null)
            {
                foreach (var userInRole in usersInRole)
                {
                    users.Add(userInRole.username);
                }
            }
            return users.ToArray();
        }

        /// <summary>
        /// Get all roles.
        /// </summary>
        /// <returns></returns>
        public override string[] GetAllRoles()
        {
            List<string> roles = new List<string>();
            var dbRoles = userService.getAllRoles();
            foreach (var role in dbRoles)
            {
                roles.Add(role.roleName);
            }
            return roles.ToArray();
        }

        /// <summary>
        /// Get all roles for a specific user.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public override string[] GetRolesForUser(string username)
        {
            List<string> roles = new List<string>();
            var dbRoles = userService.getUserByUsername(username).roles;
            foreach (var role in dbRoles)
            {
                roles.Add(role.roleName);
            }
            return roles.ToArray();
        }

        /// <summary>
        /// Get all users that belong to a role.
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public override string[] GetUsersInRole(string roleName)
        {
            List<string> users = new List<string>();
            var usersInRole = userService.getUsersInRole(roleName);
            if (usersInRole != null)
            {
                foreach (var userInRole in usersInRole)
                {
                    users.Add(userInRole.username);
                }
            }
            return users.ToArray();
        }

        /// <summary>
        /// Checks if user belongs to a given role.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public override bool IsUserInRole(string username, string roleName)
        {
            List<User> users = userService.getUsersInRole(roleName);
            foreach (User user in users)
            {
                if (username.Equals(user.username))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usernames"></param>
        /// <param name="roleNames"></param>
        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            foreach (String username in usernames)
            {
                User user = userService.getUserByUsername(username);
                foreach (String roleName in roleNames)
                {
                    Role role = userService.getRoleByRoleName(roleName);
                    userService.removeRoleFromUser(user, role);
                }
            }

        }

        /// <summary>
        /// Check if role exists.
        /// </summary>
        /// <param name="configValue"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public override bool RoleExists(string roleName)
        {
            bool isValid = false;
            // check if role exits
            if (GetAllRoles().Contains(roleName))
            {
                isValid = true;
            }
            return isValid;
        }

        /// <summary>
        /// Get config value.
        /// </summary>
        /// <param name="configValue"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        private string GetConfigValue(string configValue, string defaultValue)
        {
            if (String.IsNullOrEmpty(configValue))
            {
                return defaultValue;
            }
            return configValue;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TaskWebApplication.Domain;

namespace TaskWebApplication.Service
{
    public class UserServiceADOImpl : ServiceADOImpl, IUserService
    {
        private readonly String USER_TABLE_NAME = "Users";
        private readonly String ROLE_TABLE_NAME = "Roles";
        private readonly String USERS_IN_ROLES_TABLE_NAME = "UsersInRoles";
        private readonly String USER_KEY = "userId";



        public User addUser(User user)
        {
            int id = create(USER_TABLE_NAME, buildUserDictionary(user));
            if (id > 0)
            {
                user.userId = id;
                if (user.roles != null)
                {
                    foreach (Role role in user.roles)
                    {
                        if (create(USERS_IN_ROLES_TABLE_NAME, buildRoleDictionary(role, user)) < 0)
                        {
                            return null;
                        }
                    }
                }
                return user;

            }
            return null;
        }

        public Boolean modifyUser(User user)
        {
            int userResult = update(USER_TABLE_NAME, buildUserDictionary(user), USER_KEY, user.userId.ToString());
            delete(USERS_IN_ROLES_TABLE_NAME, USER_KEY, user.userId.ToString());
            foreach (Role role in user.roles)
            {
                if (create(USERS_IN_ROLES_TABLE_NAME, buildRoleDictionary(role, user)) < 0)
                {
                    return false;
                }
            }
            if (userResult > 0)
            {
                return true;
            }
            return false;
        }

        public User getUserById(String id)
        {
            throw new NotImplementedException("Not implemented yet.");
        }

        public User getUserByUsername(String username)
        {
            DataTable users = read(USER_TABLE_NAME, "username", username);
            User user = null;
            if (users.Rows != null && users.Rows.Count > 0)
            {
                user = new User();
                DataRow row = users.Rows[0];
                user.userId = int.Parse(row["userId"].ToString());
                user.username = row["username"].ToString();
                user.password = row["password"].ToString();
                user.roles = getAllRolesForUser(user);
            }
            return user;
        }

        public User getUserByEmail(String email)
        {
            DataTable users = read(USER_TABLE_NAME, "email", email);
            User user = null;
            if (users.Rows != null && users.Rows.Count > 0)
            {
                user = new User();
                DataRow row = users.Rows[0];
                user.userId = int.Parse(row["userId"].ToString());
                user.username = row["username"].ToString();
                user.password = row["password"].ToString();
                user.roles = getAllRolesForUser(user);
            }
            return user;
        }

        public List<User> getAllUsers()
        {
            DataTable users = readAll(USER_TABLE_NAME);
            List<User> allUsers = new List<User>();
            foreach (DataRow row in users.Rows)
            {
                User user = new User();
                user.userId = int.Parse(row["userId"].ToString());
                user.username = row["username"].ToString();
                user.password = row["password"].ToString();
                user.roles = getAllRolesForUser(user);
                allUsers.Add(user);
            }
            return allUsers;
        }

        public Boolean removeUser(User user)
        {
            delete(USERS_IN_ROLES_TABLE_NAME, USER_KEY, user.userId.ToString());
            return delete(USER_TABLE_NAME, USER_KEY, user.userId.ToString()) > 0;
        }

        public Boolean removeRole(Role role)
        {
            return delete(ROLE_TABLE_NAME, "roleId", role.roleId.ToString()) > 0;
        }

        public Boolean removeRole(String roleName)
        {
            return delete(ROLE_TABLE_NAME, "roleName", roleName) > 0;
        }

        public Boolean authenticateUser(User user)
        {
            List<User> users = getAllUsers();
            foreach (User userToCheck in users)
            {
                if (userToCheck.username.Equals(user.username) && userToCheck.password.Equals(user.password))
                {
                    return true;
                }
            }
            return false;
        }

        public Role addRole(Role role)
        {
            int id = create(ROLE_TABLE_NAME, buildRoleDictionary(role));
            if (id >= 0)
            {
                role.roleId = id;
                return role;
            }
            return null;
        }

        public List<Role> getAllRoles()
        {
            List<Role> roles = new List<Role>();
            DataTable table = readAll(ROLE_TABLE_NAME);
            foreach (DataRow row in table.Rows)
            {
                int roleId = int.Parse(row["roleId"].ToString());
                String roleName = row["roleName"].ToString();
                roles.Add(new Role(roleName, roleId));
            }
            return roles;
        }

        public List<User> getUsersInRole(String roleName)
        {
            List<User> usersHavingRole = new List<User>();
            Role role = getRoleByRoleName(roleName);
            List<int> targetUserIds = new List<int>();
            DataTable usersInRoles = read(USERS_IN_ROLES_TABLE_NAME, "roleId", role.roleId.ToString());
            foreach (DataRow row in usersInRoles.Rows)
            {
                targetUserIds.Add(int.Parse(row["userId"].ToString()));
            }
            List<User> allUsers = getAllUsers();
            foreach (User user in allUsers)
            {
                if (targetUserIds.Contains(user.userId))
                {
                    usersHavingRole.Add(user);
                }
            }
            return usersHavingRole;
        }

        public Role getRoleByRoleName(String roleName)
        {
            Role role = null;
            DataTable roleTable = read(ROLE_TABLE_NAME, "roleName", roleName);
            foreach (DataRow row in roleTable.Rows)
            {
                role = new Role(row["roleName"].ToString(), int.Parse(row["roleId"].ToString()));
            }
            return role;
        }

        public Role getRoleByRoleId(String roleId)
        {
            Role role = null;
            DataTable roleTable = read(ROLE_TABLE_NAME, "roleName", roleId);
            foreach (DataRow row in roleTable.Rows)
            {
                role = new Role(row["roleName"].ToString(), int.Parse(row["roleId"].ToString()));
            }
            return role;
        }

        public User addRoleToUser(User user, Role role)
        {
            create(USERS_IN_ROLES_TABLE_NAME, buildRoleDictionary(role, user));
            if (user.roles == null)
            {
                user.roles = new List<Role>();
            }
            user.roles.Add(role);
            return user;
        }

        public Boolean removeRoleFromUser(User user, Role role)
        {
            delete(USERS_IN_ROLES_TABLE_NAME, USER_KEY, user.userId.ToString());
            if (user.roles != null)
            {
                user.roles.Remove(role);
                foreach (Role currentRole in user.roles)
                {
                    addRoleToUser(user, currentRole);
                }
            }
            return true;
        }


        private List<Role> getAllRolesForUser(User user)
        {
            List<Role> roles = new List<Role>();
            DataTable table = read(USERS_IN_ROLES_TABLE_NAME, USER_KEY, user.userId.ToString());
            foreach (DataRow row in table.Rows)
            {
                roles.Add(getRoleByRoleId(row["roleId"].ToString()));
            }
            return roles;
        }
        private Dictionary<String, Object> buildUserDictionary(User user)
        {
            Dictionary<String, Object> columnsToValues = new Dictionary<String, Object>();
            columnsToValues.Add("username", user.username);
            columnsToValues.Add("password", user.password);
            columnsToValues.Add("email", user.email);
            return columnsToValues;
        }

        private Dictionary<String, Object> buildRoleDictionary(Role role, User user)
        {
            Dictionary<String, Object> columnsToValues = new Dictionary<String, Object>();
            columnsToValues.Add("roleId", role.roleId);
            columnsToValues.Add("userId", user.userId);
            return columnsToValues;
        }

        private Dictionary<String, Object> buildRoleDictionary(Role role)
        {
            Dictionary<String, Object> columnsToValues = new Dictionary<String, Object>();
            columnsToValues.Add("roleName", role.roleName);
            return columnsToValues;
        }


    }
}
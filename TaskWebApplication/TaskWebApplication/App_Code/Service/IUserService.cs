using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskWebApplication.Domain;

namespace TaskWebApplication.Service
{
    public interface IUserService : IService
    {
        User addUser(User user);
        Boolean modifyUser(User user);
        User getUserById(String id);
        User getUserByUsername(String id);
        User getUserByEmail(String email);
        Role getRoleByRoleId(String roleId);
        Role getRoleByRoleName(String roleName);
        List<User> getAllUsers();
        Boolean removeUser(User user);
        Boolean removeRole(Role role);
        Boolean removeRole(String roleName);
        Boolean removeRoleFromUser(User user, Role role);
        Boolean authenticateUser(User user);
        List<User> getUsersInRole(String rolename);
        List<Role> getAllRoles();
        Role addRole(Role role);
        User addRoleToUser(User user, Role role);
    }
}
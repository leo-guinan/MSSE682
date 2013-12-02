using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharedLibraries.Domain
{
    [Serializable]
    public class User
    {

        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public List<Role> roles { get; set; }
        public int userId { get; set; }
        public bool validateUser()
        {
            return this.username != null && this.password != null;
        }

        public User(String username, String password)
        {
            this.username = username;
            this.password = password;
        }

        public User() { }

        public override string ToString()
        {
            String userString = "User: " + username + "; password: " + password + "; email: " + email + "; Roles: ";
            if (roles != null)
            {
                userString += String.Join(",", roles);

            }
            return userString;

        }


    }
}
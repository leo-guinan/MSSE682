using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskWebApplication.Domain
{

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
        
       

    }
}
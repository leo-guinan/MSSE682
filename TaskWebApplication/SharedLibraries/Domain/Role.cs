using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharedLibraries.Domain
{
    [Serializable]
    public class Role
    {
        public String roleName { get; set; }
        public int roleId { get; set; }
        public Role(String roleName)
        {
            this.roleName = roleName;
        }

        public Role(String roleName, int roleId)
        {
            this.roleName = roleName;
            this.roleId = roleId;
        }

        public override string ToString()
        {
            return roleName;
        }

    }
}
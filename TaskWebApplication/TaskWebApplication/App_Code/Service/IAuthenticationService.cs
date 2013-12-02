using SharedLibraries.Domain;
using SharedLibraries.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskWebApplication.Service
{
    interface IAuthenticationService : IService
    {
        Boolean authenticateUser(User user);
    }
}

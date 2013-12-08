using SharedLibraries.Domain;
using SharedLibraries.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AuthenticationServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class AuthenticationService : IAuthenticationService
    {
        private IUserService userService = new UserServiceADOImpl("taskManagement");

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public string Hello(String name)
        {
            return "Hello " + name;
        }

        public Boolean AuthenticateUser(User user)
        {
            return userService.authenticateUser(user);
        }
    }
}

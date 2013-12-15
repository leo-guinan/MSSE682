using SharedLibraries.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskWebApplication.Factory.Service;
using TaskWebApplication.Service;


namespace TaskWebpApplication.Factory.Service
{
    public class ServiceFactory : IServiceFactory
    {
        private readonly String CONNECTION_STRING = "taskManagement";
        protected static readonly ServiceFactory instance = new ServiceFactory();

        public ServiceFactory()
        {
           
        }

        public static ServiceFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private IAuthenticationService getAuthenticationService()
        {
            return new UserServiceAuthenticationWebApiImpl();
        }

        private ITaskService getTaskService()
        {
            return new TaskServiceADOImpl(CONNECTION_STRING);
        }
        private IUserService getUserService()
        {
            return new UserServiceADOImpl(CONNECTION_STRING);
        }

        public IService getService(String serviceName)
        {
            if ("taskService" == serviceName)
            {
                return getTaskService();
            }
            else if ("userService" == serviceName)
            {
                return getUserService();
            }
            else if ("authenticationService" == serviceName)
            {
                return getAuthenticationService();
            }
            throw new NotSupportedException("Requested service not supported");

        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskApp.Domain;
using TaskWebApplication.Factory.Service;
using TaskWebApplication.Service;


namespace TaskWebpApplication.Factory.Service
{
    public class ServiceFactory : IServiceFactory
    {
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

        private ITaskService getTaskService()
        {
            return null;
        }
        private IUserService getUserService()
        {
            return null;
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
            throw new NotSupportedException("Requested service not supported");

        }

    }
}
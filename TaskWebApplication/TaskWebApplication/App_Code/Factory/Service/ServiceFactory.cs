using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TaskApp.Domain;
using TaskApp.Repository;
using TaskApp.Service;


namespace TaskApp.Factory.Service
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

        private static DbContext context = new taskDomainDBEntities();
        private static IRepository<Task> taskRepository = new Repository<Task>(context);
        private static IRepository<Estimate> estimateRepository = new Repository<Estimate>(context);

        private static IRepository<User> userRepository = new Repository<User>(context);
        private ITaskService getTaskService()
        {
            return new TaskService(taskRepository, estimateRepository);
        }
        private IUserService getUserService()
        {
            return new UserService(userRepository);
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
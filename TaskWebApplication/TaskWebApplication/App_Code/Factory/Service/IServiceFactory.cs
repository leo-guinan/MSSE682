using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibraries.Service;

namespace TaskWebApplication.Factory.Service
{
    public interface IServiceFactory
    {
        IService getService(String serviceName);
    }
}

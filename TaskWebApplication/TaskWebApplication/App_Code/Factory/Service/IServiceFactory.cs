using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Service;

namespace TaskApp.Factory.Service
{
    public interface IServiceFactory
    {
        IService getService(String serviceName);
    }
}

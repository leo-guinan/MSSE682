using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ServiceModel;

namespace ConsoleApplication1
{
    class AuthenticationWCFServer
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Out.WriteLine("Starting Host");
                ServiceHost host = new ServiceHost(typeof(AuthenticationServiceLibrary.AuthenticationService));
                host.Open();
                Console.Out.WriteLine("Service started; enter Return to exit application");
                Console.ReadLine();
                host.Close();
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
    }
}

using SharedLibraries.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;

namespace TaskWebApplication.Service
{
    public class UserServiceAuthenticationServerImpl : IAuthenticationService
    {
        public Boolean authenticateUser(User user)
        {
            bool result = false;
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8900);
                socket.Connect(ipEndPoint);
                NetworkStream stream = new NetworkStream(socket);
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.AssemblyFormat = FormatterAssemblyStyle.Simple;
                formatter.Serialize(stream, user);
                BinaryReader reader = new BinaryReader(stream);
                result = reader.ReadBoolean();
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }


            return result;
        }
    }
}
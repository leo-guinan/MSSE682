using AuthenticationServer.TCPConnection;
using SharedLibraries.Domain;
using SharedLibraries.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AuthenticationServer
{
    class Server
    {
        static IUserService userService = new UserServiceADOImpl("taskManagement");

        static void Main(string[] args)
        {
            Listen();
        }

        /// <summary>
        /// This is the main exection for the authentication server. Creates a server that listens for incoming authentication requests.
        /// </summary>
        public static void Listen()
        {
            TcpListener listener = null;
            try
            {
                Int32 port = 8900;
                IPAddress ipAddr = IPAddress.Parse("127.0.0.1");

                listener = new TcpListener(ipAddr, port);
                // Start listening for incoming client requests
                listener.Start();
                int threadCounter = 0;
                while (true)
                {
                    Console.Write("Waiting for a connection... ");
                    TcpClient tcpClient = listener.AcceptTcpClient();
                    TCPSocketAuthenticator authenticator = new TCPSocketAuthenticator(tcpClient, Server.userService, threadCounter);
                    Thread thread = new Thread(new ThreadStart(authenticator.authenticateUser));
                    thread.Start();
                    threadCounter++;
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown exception: {0}", e);
            }
            finally
            {
                // Stop listening for new clients
                listener.Stop();
            }
        }
    }
}





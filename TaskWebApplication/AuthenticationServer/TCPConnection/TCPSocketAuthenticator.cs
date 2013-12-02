using SharedLibraries.Domain;
using SharedLibraries.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationServer.TCPConnection
{
    /// <summary>
    /// This class is used to control the authentication of users in a thread-safe manner.
    /// </summary>
    class TCPSocketAuthenticator
    {
        private TcpClient tcpClient;

        private IUserService userService;

        private int threadId;

        /// <summary>
        /// This is a constructor that sets up the class to use a thread.
        /// </summary>
        /// <param name="tcpClient">The TCP Client to use</param>
        /// <param name="userService">The user service that authenticates the user</param>
        /// <param name="threadId">the currently running thread number. (Added for logging)</param>
        public TCPSocketAuthenticator(TcpClient tcpClient, IUserService userService, int threadId)
        {
            this.tcpClient = tcpClient;
            this.userService = userService;
            this.threadId = threadId;

        }

        /// <summary>
        /// This method reads an input stream from a TCP socket connection, deserializes a User object, and authenticates it against the configured user service.
        /// </summary>
        public void authenticateUser()
        {
            // get a stream to read/write 
            Console.WriteLine("Beginning thread " + threadId);
            NetworkStream stream = tcpClient.GetStream();
            // read the data sent by the client.
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.AssemblyFormat = FormatterAssemblyStyle.Simple;
            Object o = formatter.Deserialize(stream);
            User user = o as User;
            Console.WriteLine("credentials: " + user);
            Boolean authenticated = userService.authenticateUser(user);

            // process the credentials and return a true / false

            BinaryWriter writer = new BinaryWriter(stream);
            writer.Write(authenticated);

            // close the socket when you’re done using it
            tcpClient.Close();
            Console.WriteLine("Ending thread " + threadId);

        }
    }
}

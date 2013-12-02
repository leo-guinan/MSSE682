using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{

    public class TestThreadClass
    {

        // This method that will be called when the thread is started
        public void Calculate()
        {
            int i = 0;
            while (true)
            {
                Console.WriteLine("i*2=" + i*2);
                Thread.Sleep(2000);
                i = i + 2;
            }
        }
    };

    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            while (true)
            {
                TestThreadClass test = new TestThreadClass();

                // Create the thread object, passing in the Alpha.Beta method
                // via a ThreadStart delegate. This does not start the thread.
                Thread oThread = new Thread(new ThreadStart(test.Calculate));
                // Start the thread
                oThread.Start();

                // Spin for a while waiting for the started thread to become
                // alive:
                while (!oThread.IsAlive) ;

                // Put the Main thread to sleep for 1 millisecond to allow oThread
                // to do some work:
                Thread.Sleep(5000);

                // Request that oThread be stopped
                oThread.Abort();

                // Wait until oThread finishes. Join also has overloads
                // that take a millisecond interval or a TimeSpan object.
                oThread.Join();

                Console.WriteLine();
                Console.WriteLine("TTC.Calculate has finished");

                try
                {
                    Console.WriteLine("Try to restart the TTC.Calculate thread");
                    oThread.Start();
                }
                catch (ThreadStateException)
                {
                    Console.Write("ThreadStateException trying to restart TTC.Calculate. ");
                    Console.WriteLine("Expected since aborted threads cannot be restarted.");
                }
            }
             
        }

    }
}

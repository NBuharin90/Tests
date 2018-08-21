using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreading_Signals
{
    class Program
    {
        static void Main(string[] args)
        {
            var signal = new ManualResetEvent(false);
            new Thread(() =>
            {
                Console.WriteLine("Waiting for signal ... ");
                signal.WaitOne();
                signal.Dispose();
                Console.WriteLine("Got signal!");
            }).Start();
            Thread.Sleep(2000);
            signal.Set();
            Console.ReadKey();
        }
    }
}

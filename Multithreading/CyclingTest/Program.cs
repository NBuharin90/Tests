using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CyclingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            object sync = new object();

            for(int i=0;i<100;i++)
                new Thread(() =>
                {
                    while (true)
                    {
                        lock (sync)
                        {
                            Thread.Sleep(10);
                        }
                    }
                }).Start();
        }
    }
}

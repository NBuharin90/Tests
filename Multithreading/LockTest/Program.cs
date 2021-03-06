﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LockTest
{
    class Program
    {
        static void Main(string[] args)
        {
            object sync = new object();
            var thread = new Thread(() =>
            {
                try
                {
                    Work();
                }
                finally
                {
                    lock (sync)
                    {
                        Monitor.PulseAll(sync);
                    }
                }
            });
            thread.Start();
            lock (sync)
            {
                Monitor.Wait(sync);
            }
            Console.WriteLine("test");
        }
        private static void Work()
        {
            Thread.Sleep(1000);
        }
    }
}

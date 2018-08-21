using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrentCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            var concurrCollection = new ConcurrentDictionary<int, Timer>();

            var tryAddRes1 = concurrCollection.TryAdd(1, null);
            if (tryAddRes1)
                concurrCollection[1] = new Timer(
                    state =>
                    {
                        Console.WriteLine("First Timer is work!");
                    }, null, 5000, Timeout.Infinite);
            Console.WriteLine("First TryAdd return "+ tryAddRes1);

            var tryAddRes2 = concurrCollection.TryAdd(1, null);
            if (tryAddRes2)
                concurrCollection[1] = new Timer(
                    state =>
                    {
                        Console.WriteLine("Second Timer is work!");
                    }, null, 5000, Timeout.Infinite);
            Console.WriteLine("Second TryAdd return " + tryAddRes2);

            Console.ReadKey();
        }
    }
}

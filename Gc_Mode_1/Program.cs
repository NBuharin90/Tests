using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Gc_Mode_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("GCSettings:");
            Console.WriteLine($"IsServerGC:{GCSettings.IsServerGC}");
            Console.WriteLine($"LargeObjectHeapCompactionMode:{GCSettings.LargeObjectHeapCompactionMode}");
            Console.WriteLine($"LatencyMode:{GCSettings.LatencyMode}");
            Console.ReadKey();
        }
    }
}

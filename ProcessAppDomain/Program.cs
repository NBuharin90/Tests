using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProcessAppDomain
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Process:");
            var process = Process.GetProcessesByName("ProcessAppDomain")[0];
            Console.WriteLine($"Id: {process.Id};  ProcessName: { process.ProcessName}; VirtualMemorySize64: {(process.VirtualMemorySize64/1024)/1024}MB ");

            Console.WriteLine("Process modules:");
            foreach (ProcessModule module in process.Modules)
                Console.WriteLine($"Name: {module.ModuleName}; MemorySize: {module.ModuleMemorySize}");

            Console.WriteLine("Process threads:");
            foreach (ProcessThread thread in process.Threads)
                Console.WriteLine($"ThreadId: {thread.Id}; StartTime: {thread.StartTime}");

            Console.WriteLine($"Main thread Id: {AppDomain.GetCurrentThreadId()}");

            Console.WriteLine("AppDomain assemlies:");
            foreach (var ass in AppDomain.CurrentDomain.GetAssemblies())
                Console.WriteLine($"Assembly: {ass.FullName}");

           

            Console.ReadKey();
        }
    }
}

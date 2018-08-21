using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Task.Run(() => { throw new Exception(); });
                Thread.Sleep(1000);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadKey();
        }
    }
}

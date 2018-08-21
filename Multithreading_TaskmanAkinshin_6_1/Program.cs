using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreading_TaskmanAkinshin_6_1
{
    //Что выведет данный код?

    class Program
    {
        [ThreadStatic]
        static int Foo = 42;

        static void Main(string[] args)
        {
            Console.WriteLine(Foo);
            var thr = new Thread(()=>Console.WriteLine(Foo));
            thr.Start();
            thr.Join();
            Console.ReadKey();
        }
    }
}

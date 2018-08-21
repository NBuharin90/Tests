using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Closures_1
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    Action p = Console.WriteLine; // P объявлен как delegate void P();
        //    foreach (var i in new[] { 1, 2, 3, 4 })
        //    {
        //        p += () => Console.Write(i);
        //    }
        //    p();

        //    //Console.ReadKey();
        //}

        //static Action _closure;

        //static void Main(string[] args)
        //{
        //    SetUpClosure();
        //    _closure();     // 1 + 1 = 2
        //    Console.ReadKey();
        //}

        //private static void SetUpClosure()
        //{
        //    int nonLocal = 1;
        //    _closure = () =>
        //    {
        //        Console.WriteLine($"{nonLocal} + 1 = {nonLocal + 1}");
        //    };
        //}

        static void Main(string[] args)
        {
            int nonLocal = 1;
            Action closure = delegate
            {
                Console.WriteLine("{0} + 1 = {1}", nonLocal, nonLocal + 1);
            };
            nonLocal = 10;
            closure();

            Console.ReadKey();
        }
    }
}

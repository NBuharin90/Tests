using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariableSwap
{
    class Program
    {
        static void Main()
        {
            int a = 1, b = 2;
            Swap(a, b);
            Console.WriteLine("a=" + a + ", b=" + b);
            Console.ReadKey();
        }

        private static void Swap(int a, int b)
        {
            int c = a;
            a = b;
            b = c;
        }

    }
}

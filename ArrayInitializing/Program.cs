using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayInitializing
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] someArray1 = {1, 2, 3, 4};
            int[] someArray2 = new int[4];
            //int someArray3[] = new int[4];
            int[] someArray4 = new int[4] {1, 2, 3, 4};
            //int[4] someArray5;
            int[] someArray6 = new int[] {1, 2, 3, 4};
        }
    }
}

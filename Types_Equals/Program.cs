using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Types_Equals
{
    //  Чему будет равно сравнение переменных в каждом варианте

    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public struct Point1
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            object i = 1;
            object j = 1;
            //Point i = new Point { X = 1, Y = 1 };
            //Point j = new Point { X = 1, Y = 1 };
            //Point1 i = new Point1 { X = 1, Y = 1 };
            //Point1 j = new Point1 { X = 1, Y = 1 };

            var res = i == j; Console.WriteLine(res);
            var res1 = i.Equals(j); Console.WriteLine(res1);
            var res2 = object.Equals(i, j); Console.WriteLine(res2);
            var res3 = object.ReferenceEquals(i, j); Console.WriteLine(res3);

            Console.ReadKey();
        }
    }
}

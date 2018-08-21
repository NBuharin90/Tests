using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections_Dictionary_1
{
    //	Что выведет на консоль данный код?

    class Program
    {
        public class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
        }

        static void Main(string[] args)
        {
            var obj1 = new Point();
            var obj2 = new Point();
            var dict = new Dictionary<Point, int>{{obj1,1}};
            if (!dict.TryGetValue(obj2, out var res))
                Console.WriteLine("Object not found");
            Console.WriteLine($"Found {res}");
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectMethods
{
    public class ObjectChildClass : Object
    {
    }

    class Program
    {
        static void Main(string[] args)
        {
            var obj = new ObjectChildClass();
            Console.WriteLine(obj.Equals(null));
            Console.WriteLine(obj.GetHashCode());
            Console.WriteLine(obj.GetType());
            Console.WriteLine(obj.ToString());
            Console.ReadKey();
        }
    }
}

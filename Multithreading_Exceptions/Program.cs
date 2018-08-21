using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreading_Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                new Thread(() =>
                {
                    // Генерирует исключение NullReferenceException
                    //throw null;
                }).Start();
            }
            catch (Exception ех)
            {
                // Сюда мы никогда не попадем!
                Console.WriteLine("Exception!"); // Исключение!
            }
            Console.ReadKey();
        }
    }
}

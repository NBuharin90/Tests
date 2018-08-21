using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorLock
{
    internal class Program
    {
        private static Object syncObject = new Object();

        private static void Write()
        {
            lock (syncObject)
            {
                Console.WriteLine("test");
            }
        }

        static void Main(string[] args)
        {
            lock (syncObject)
            {
                Write();
            }
            Console.ReadKey();
        }
    }
    /*
     * Варианты ответов:
        1.	Выбросит исключение
        2.	Напечатает слово "test"
        3.	Произойдет взаимоблокировка (deadlock)
        4.	Напечатает слово "test" бесконечное число раз
     */

}

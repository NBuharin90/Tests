using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exceptions_InThreadHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            //Неперехватываемое исключение?
            //try
            //{
            //    var thr = new Thread(() =>
            //    {
            //        throw new Exception("In thread Exception");
            //    });
            //    thr.Start();
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //    throw;
            //}

            //Исключение не перехватываеся
            try
            {
                var tsk = Task.Run(() =>
                {
                    throw new Exception("In task Exception");
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

            Console.WriteLine("After thread and task start");
            Console.ReadKey();
        }
    }
}

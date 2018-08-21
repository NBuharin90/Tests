using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Interview_Maxima_Task7
{
    //Дан код, который должен последовательно выполнить три операции в разных потоках
    //  1)Присвоить переменной значение 10
    //  2)Вывести её значение на консолль
    //  3)Присвоить переменной значение 20

    //Как можно улучшить данный код?

    class Program
    {
        /// <summary>
        /// Задание
        /// </summary>
        static void Main(string[] args)
        {
            bool flag = false;
            int value = 0;

            var thr1 = new Thread(() =>
            {
                value = 10;
                flag = true;
            });

            var thr2 = new Thread(() =>
            {
                do
                {
                } while (!flag);

                Console.WriteLine(value);
            });

            thr1.Start();
            thr2.Start();

            thr1.Join();
            value = 20;
            thr2.Join();

            Console.ReadKey();
        }

        ///// <summary>
        ///// Решение 1
        ///// </summary>
        //static void Main(string[] args)
        //{
        //    //Заменяем булеву переменную на сигнал
        //    var signal = new ManualResetEvent(false);
        //    int value = 0;

        //    var thr1 = new Thread(() =>
        //    {
        //        value = 10;
        //        signal.Set();
        //    });

        //    var thr2 = new Thread(() =>
        //    {
        //        signal.WaitOne();
        //        signal.Dispose();

        //        Console.WriteLine(value);
        //    });

        //    thr1.Start();
        //    thr2.Start();

        //    thr1.Join();
        //    //Поставить ожидание завершения второго потока перед присвоением
        //    thr2.Join();
        //    value = 20;

        //    Console.ReadKey();
        //}

        ///// <summary>
        ///// Решение 2 через ContinueWith
        ///// </summary>
        //static void Main(string[] args)
        //{
        //    int value = 0;
        //    var tsk2 = Task.Run(() => { value = 10; }).ContinueWith(tsk1 => { Console.WriteLine(value); });
        //    tsk2.Wait();
        //    value = 20;
        //    Console.ReadKey();
        //}
    }
}

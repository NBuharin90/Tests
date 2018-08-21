using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreading_Closures
{
    class MultithreadingClosuresTest
    {
        /// <summary>
        /// Пример 562-1.
        /// </summary>
        private static void Go()
        {
            //Объявить и сипользовать локальную переменную cycles
            for (int cycles = 0; cycles < 5; cycles++) Console.Write('?');
        }

        private bool _done;
        /// <summary>
        /// Пример 562-2.
        /// Обратите внимание, что это метод экземпляра
        /// </summary>
        private void Go1()
        {
            //При смене порядка операторов вывода и присвоения вероятность двойного вывода сильно возрастает
            if (!_done) { _done = true; Console.WriteLine("Done"); }
        }

        // Статические поля разделяются между всеми потоками в том же самом домене приложения
        private static bool _done1;
        /// <summary>
        /// Пример 563-2.
        /// Обратите внимание, что это метод экземпляра
        /// </summary>
        private static void Go2()
        {
            //При смене порядка операторов вывода и присвоения вероятность двойного вывода сильно возрастает
            if (!_done1) { _done1 = true; Console.WriteLine("Done"); }
        }

        static void Main(string[] args)
        {
            //Локальные переменные захваченные лямбда-выражением или анонимным делегатом, преобразуюся компилятором в поля, 
            //поэтому они могут быть разделяемыми между потоками

            Console.WriteLine("Пример 562-1. C# 6.0. Справочник. Полное описание языка. Д. и Б. Албахари");
            new Thread(Go).Start();
            Go();
            Console.ReadKey();
            Console.WriteLine();
            
            //
            Console.WriteLine("Пример 562-2. C# 6.0. Справочник. Полное описание языка. Д. и Б. Албахари");
            var tt = new MultithreadingClosuresTest(); //Создать общий экземпляр
            new Thread(tt.Go1).Start();
            tt.Go1();
            Console.ReadKey();

            //
            Console.WriteLine("Пример 563-1. C# 6.0. Справочник. Полное описание языка. Д. и Б. Албахари");
            bool done = false;
            ThreadStart action = () =>
            {
                if (!done) { Console.WriteLine("Done"); done = true; }
            };
            new Thread(action).Start();
            action();
            Console.ReadKey();

            //
            Console.WriteLine("Пример 563-2. C# 6.0. Справочник. Полное описание языка. Д. и Б. Албахари");
            new Thread(Go2).Start();
            Go2();
            Console.ReadKey();

            //
            Console.WriteLine("Пример 565 C# 6.0. Справочник. Полное описание языка. Д. и Б. Албахари");
            //Результат вывода
            for (var i = 0; i < 10; i++)
                new Thread(() => Console.Write(i)).Start();

            Console.ReadKey();
            Console.WriteLine();

            //
            Console.WriteLine("Пример 566-1 C# 6.0. Справочник. Полное описание языка. Д. и Б. Албахари");
            for (var i = 0; i < 10; i++)
            {
                var temp = i;
                new Thread(() => Console.Write(temp)).Start();
            }
            Console.ReadKey();
            Console.WriteLine();

            //
            Console.WriteLine("Пример 566-2 C# 6.0. Справочник. Полное описание языка. Д. и Б. Албахари");
            string text = "t1";
            var t1 = new Thread(()=>Console.WriteLine(text));
            text = "t2";
            var t2 = new Thread(() => Console.WriteLine(text));
            t1.Start();
            t2.Start();
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PeriodicOperations
{
    class Program
    {
        private static Timer s_timer;

        // Методу можно передавать любые параметры на ваше усмотрение
        private static async void Status()
        {
            while (true)
            {
                Console.WriteLine("In Status at {0}, ThreadFromPool:{1}", DateTime.Now, Thread.CurrentThread.IsThreadPoolThread);
                // Здесь размещается код проверки состояния...
                // В конце цикла создается 2-секундная задержка без блокировки потока
                await Task.Delay(2000); // await ожидает возвращения управления потоком
            }
        }

        static void MainAwait(string[] args)
        {
            //Вариант с await
            CancellationTokenSource cts = new CancellationTokenSource();
            Console.WriteLine("Checking status every 2 seconds");
            Status();
            Console.ReadLine(); // Предотвращение завершения процесса
        }

        static void MainTimer(string[] args)
        {
            Console.WriteLine("Checking status every 2 seconds");
            // Создание таймера, который никогда не срабатывает. Это гарантирует,
            // что ссылка на него будет храниться в s_timer,
            // До активизации Status потоком из пула
            s_timer = new Timer(state =>
            {
                // Сигнатура этого метода должна соответствовать
                // сигнатуре делегата TimerCallback

                // Этот метод выполняется потоком из пула
                Console.WriteLine("In Status at {0}, ThreadFromPool:{1}", DateTime.Now, Thread.CurrentThread.IsThreadPoolThread);
                Thread.Sleep(1000); // Имитация другой работы (1 секунда)
                                    // Заставляем таймер снова вызвать метод через 2 секунды
                s_timer.Change(2000, Timeout.Infinite);
                // Когда метод возвращает управление, поток
                // возвращается в пул и ожидает следующего задания
            },
            null, Timeout.Infinite, Timeout.Infinite);
            // Теперь, когда s_timer присвоено значение, можно разрешить таймеру
            // срабатывать; мы знаем, что вызов Change в Status не выдаст
            // исключение NullReferenceException
            s_timer.Change(0, Timeout.Infinite);
            Console.ReadLine(); // Предотвращение завершения процесса
        }
    }
}

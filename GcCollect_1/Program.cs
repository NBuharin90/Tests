using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GcCollect_1
{
    /// <summary>
    /// Пример показывает работу сборщика мусора с локальными корнями
    /// Взято из книги "Оптимизация приложений на платформе .net"
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer(OnTimer, null, 0, 1000);
            Console.ReadKey();
            //Без вызова этого метода в Release таймер отработает только 1 раз
            GC.KeepAlive(timer);
        }

        static void OnTimer(object state)
        {
            Console.WriteLine(DateTime.Now.Ticks);
            GC.Collect();
        }
    }
}

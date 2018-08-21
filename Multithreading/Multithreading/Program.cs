using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreading
{
    class Program
    {
        static void Main(string[] args)
        {
            //var res = DirectoryBytes(@"C:\Work", "*", SearchOption.TopDirectoryOnly);
            //Console.WriteLine(res);

            var thr = new Thread(() => { Thread.Sleep(10000);});
            thr.Start();
            Thread.Sleep(1000);
            Console.WriteLine(thr.ThreadState);

            var tsk = Task.Run(() =>
            {
                Thread.Sleep(10000);
            });
            Thread.Sleep(1000);
            Console.WriteLine(tsk.Status);
            Console.WriteLine(tsk.AsyncState);
            Console.ReadKey();
        }

        private static Int64 DirectoryBytes(String path, String searchPattern, SearchOption searchOption)
        {
            var files = Directory.EnumerateFiles(path, searchPattern, searchOption);
            Int64 masterTotal = 0;
            ParallelLoopResult result = Parallel.ForEach<String, Int64>(
                files,
                () =>
                {
                    // localInit: вызывается в момент запуска задания
                    // Инициализация: задача обработала 0 байтов
                    return 0; // Присваивает taskLocalTotal начальное значение 0
                },
                (file, loopState, index, taskLocalTotal) =>
                {
                    // body: Вызывается
                    // один раз для каждого элемента
                    // Получает размер файла и добавляет его к общему размеру
                    Int64 fileLength = 0;
                    FileStream fs = null;
                    try
                    {
                        fs = File.OpenRead(file);
                        fileLength = fs.Length;
                    }
                    catch (IOException)
                    {
                        /* Игнорируем файлы, к которым нет доступа */
                    }
                    finally
                    {
                        if (fs != null) fs.Dispose();
                    }
                    return taskLocalTotal + fileLength;
                },
                taskLocalTotal =>
                {
                    // localFinally: Вызывается один раз в конце задания
                    // Атомарное прибавление размера из задания к общему размеру
                    Interlocked.Add(ref masterTotal, taskLocalTotal);
                });
            return masterTotal;
        }
    }
}

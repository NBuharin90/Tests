using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskStatusTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test started");

            var tkn = new CancellationTokenSource();
            var tsk = Task.Run(() =>
            {
                Console.WriteLine("In task: started");
                try
                {
                    Task.Delay(3000, tkn.Token).Wait(tkn.Token);
                }
                catch (Exception e)
                {
                    Console.WriteLine("In task: error "+e.Message);
                }
                Console.WriteLine("In task: after Delay");
                Thread.Sleep(3000);
                if (DateTime.Today.Year==2017)
                    throw new Exception("error");
                Console.WriteLine("In task: finished");
            }, tkn.Token);

            var tknMain = new CancellationTokenSource();
            Task.Run(() =>
            {
                while(!tknMain.IsCancellationRequested)
                {
                    Console.WriteLine("Task status:"+tsk.Status);
                    Thread.Sleep(1000);
                }
            }, tknMain.Token);
            
            Thread.Sleep(4000);
            tkn.Cancel();
            //tsk.Wait(tknMain.Token);

            Console.WriteLine("After tsk.Wait()");
            Console.WriteLine("Task status:" + tsk.Status);

            //tknMain.Cancel();
            Console.WriteLine("Test finished");
            Console.ReadKey();
        }
    }
}

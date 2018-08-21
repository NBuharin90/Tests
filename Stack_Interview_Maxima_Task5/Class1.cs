using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_Interview_Maxima_Task5
{
    //Как можно улучшить данную реализацию стека?

    public class MyStack
    {
        private class MyStackEl
        {
            public object Data { get; set; }
            public MyStackEl Next { get; set; }
        }

        private MyStackEl _head;

        public void Push(object obj)
        {
            //расточительно обертывать каждый элемент в еще один объект, поэтому данная реализация работает медленнее чем стандартная
            var newEl = new MyStackEl
            {
                Data = obj,
                Next = _head
            };
            _head = newEl;
        }

        public object Pop()
        {
            if (_head==null)
                throw new InvalidOperationException("Стек пуст");
            var oldEl = _head;
            _head = _head.Next;
            return oldEl.Data;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //var stack = new Stack(); //~1sec for 10.000.000 elements
            var stack = new MyStack(); //~2sec for 10.000.000 elements

            long iters = 10000000;

            for (long i = 0; i < iters; i++)
                stack.Push(i);

            for (long i = 0; i < iters; i++)
                stack.Pop();

            Console.ReadKey();
        }
    }
}

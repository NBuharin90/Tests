using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections_ListVsLinkedList
{
    //public class TestData
    //{
    //    public TestData(string data)
    //    {
    //        SomeData = data;
    //    }

    //    public string SomeData { get; set; }
    //}

    class Program
    {
        static void Main(string[] args)
        {
            int elementsCount = 10000000;
            var indexOfMiddle = elementsCount / 2;
            int operationsCount = 100;
            int longOperationsCount = 1000;

            //Коллекции
            var lst = new List<int>();
            var linkLst = new LinkedList<int>();
            
            //Инициализация коллекций
            for (int i = 0; i < elementsCount; i++)
            {
                lst.Add(i);
                linkLst.AddLast(i);
            }

            //** Добавление в начало списка
            for (var i = 0; i < longOperationsCount; i++)       //551ms
                lst.Insert(0, i);
            for (var i = 0; i < operationsCount; i++)           //1349ms
                linkLst.AddFirst(i);

            //** Добавление в конец списка
            for (var i = 0; i < operationsCount; i++)           //70ms
                lst.Add(i);
            for (var i = 0; i < operationsCount; i++)           //1632ms
                linkLst.AddLast(i);

            int obj = 0;
            //** Операция чтения из середины списка
            for (var i = 0; i < operationsCount; i++)           //55ms
                obj = lst[indexOfMiddle + i];

            for (var i = 0; i < longOperationsCount; i++)      //3301ms
                obj = linkLst.ElementAt(indexOfMiddle + i);

            //** Добавление в середину списка
            //for (var i = 0; i < operationsCount; i++)                             //ms
            lst.Insert(indexOfMiddle,-1);                    //5ms
            //for (var i = 0; i < operationsCount; i++)                             //ms
            //{
                var obj1 = linkLst.Find(indexOfMiddle);           //18ms
                if (obj1!=null)
                    linkLst.AddAfter(obj1, -1);                   //1ms
            //}

            Console.ReadKey();
        }
    }
}

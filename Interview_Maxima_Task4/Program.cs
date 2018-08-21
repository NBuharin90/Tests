using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    //Реализуйте расширение для IEnumerable<int> вычисляющее частичную сумму для последовательности.Например: Вх: 1,3,7,6 -> Вых:1, 4, 11, 17.
    //Что будет если последовательность будет бесконечно большой?

    static class MyIEnumerableExtensions
    {
        public static IEnumerable<TResult> GetPartialSum<TSource, TResult>(this IEnumerable<TSource> source)
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}

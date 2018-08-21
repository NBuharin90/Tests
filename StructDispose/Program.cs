using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructDispose
{
    public struct S : IDisposable
    {
        private bool _dispose;
        public void Dispose()
        {
            _dispose = true;
        }
        public bool GetDispose()
        {
            return _dispose;
        }
    }

    public class C : IDisposable
    {
        private bool _dispose;
        public void Dispose()
        {
            _dispose = true;
        }
        public bool GetDispose()
        {
            return _dispose;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var s = new S();
            using (s)
            {
                Console.WriteLine(s.GetDispose());
            }
            Console.WriteLine(s.GetDispose());

            var c = new C();
            using (c)
            {
                Console.WriteLine(c.GetDispose());
            }
            Console.WriteLine(c.GetDispose());

            Console.ReadKey();
        }
    }
}

using System;


namespace Inheritance
{
    public class A
    {
        public virtual void Foo()
        {
            Console.WriteLine("Foo() from class A");
        }
    }

    public class B : A
    {
        public override void Foo()
        {
            Console.WriteLine("Foo() from class B");
        }
    }

    public class C : B
    {
        public new void Foo()
        {
            Console.WriteLine("Foo() from class C");
        }
    }

    public class D : A
    {
        public new void Foo()
        {
            Console.WriteLine("Foo() from class D");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            A obj1 = new A();
            obj1.Foo();

            A obj2 = new B();
            obj2.Foo();

            A obj3 = new C();
            obj3.Foo();

            A obj4 = new D();
            obj4.Foo();

            //B obj5 = new A();
            //obj5.Foo();

            B obj6 = new B();
            obj6.Foo();

            B obj7 = new C();
            obj7.Foo();

            C obj8 = new C();
            obj8.Foo();

            D obj9 = new D();
            obj9.Foo();

            Console.ReadKey();
        }
    }
}

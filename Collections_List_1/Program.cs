using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections_List_1
{
    public class Person : IEquatable<Person>
    {
        public string Name { get; set; }

        public Person(string name)
        {
            Name = name;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (!(obj is Person tobj))
                return false;

            return tobj.Name.Equals(Name);
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }

        public bool Equals(Person other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Name, other.Name);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var pers1 = new Person("Nikolay");
            var pers2 = new Person("Nikolay");
            Console.WriteLine(ReferenceEquals(pers1,pers2));
            var lst = new List<Person>{pers1};
            Console.WriteLine(lst.Contains(pers2));
            Console.ReadKey();
        }
    }
}

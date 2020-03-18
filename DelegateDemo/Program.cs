using System;

namespace DelegateDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var dd = new DelegateDefinition("My instance");
            var theOtherClassInstance = new ClassWithTheStaticAndInstanceMethod();
            (FirstDelegate d1, FirstDelegate d2) = dd.DelegateInstanceCreationDemo(theOtherClassInstance);
            Console.WriteLine(d1(10));
            Console.WriteLine(d2(5));
        }
    }
}

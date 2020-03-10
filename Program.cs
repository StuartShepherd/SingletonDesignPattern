using System;
using System.Threading;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Singleton design pattern example");
            Console.WriteLine("Singleton is a creational design pattern that lets you ensure that a class has only one instance, while providing a global access point to this instance.");
            Console.WriteLine();

            Console.WriteLine("If you see the same value, then singleton was reused");
            Console.WriteLine("If you see different values, then 2 singletons were created");
            Console.WriteLine("Result:");

            Thread process1 = new Thread(() =>
            {
                TestSingleton("foo");
            });
            Thread process2 = new Thread(() =>
            {
                TestSingleton("bar");
            });

            process1.Start();
            process2.Start();

            process1.Join();
            process2.Join();
        }

        public static void TestSingleton(string value)
        {
            Singleton.Singleton singleton = Singleton.Singleton.GetInstance(value);
            Console.WriteLine(singleton.Value);
        }
    }
}

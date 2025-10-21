using System;
using System.Linq.Expressions;
using Bai01;
using Bai02;
using Bai03;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bai 1:");
            B1 b1 = new B1();
            b1.Run();
            Console.WriteLine("----------------------");
            Console.WriteLine("Bai 2:");
            B2 b2 = new B2();
            b2.Run();
            Console.WriteLine("----------------------");
            Console.WriteLine("Bai 3: ");
            B3 b3 = new B3();
            b3.Run();

        }
    }
}
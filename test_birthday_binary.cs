using System;


namespace Practice 
{
    class Program
    {
        static void Main(string[] args)
        {
            uint a = Convert.ToUInt32(Console.ReadLine()); // day
            uint b = Convert.ToUInt32(Console.ReadLine()); // month
            
            // a&b, a|b, a^b, ~a, ~b,  a<<1, b>>2.

            uint res1 = a&b;
            uint res2 = a|b;
            uint res3 = a^b;

            uint res4 = ~a;
            uint res5 = ~b;

            uint res6 = a<<1;
            uint res7 = b>>2;

            Console.WriteLine($"a&b {res1}");
            Console.WriteLine($"a|b {res2}");
            Console.WriteLine($"a^b {res3}");

            Console.WriteLine($"~a {res4}");
            Console.WriteLine($"~b {res5}");

            Console.WriteLine($"a<<1 {res6}");
            Console.WriteLine($"b>>2 {res7}");
        }
    }
}
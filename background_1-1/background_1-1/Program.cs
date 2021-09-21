using System;

namespace background_1_1
{
    class Program
    {

        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());  // test:        1
            int b = int.Parse(Console.ReadLine());  // test:        2
            int c = int.Parse(Console.ReadLine());  // test:        3

            double result;                          // result: 11.574

            result = (double)(a + c) / (b + a) +
                Math.Pow(
                    (Math.Sin(b) + a),
                    (1.0 / 3.0)) +
                Math.Pow(c, 2);
            
            Console.WriteLine($"{result:f3}");
            Console.ReadKey();
        }
        
    }
}

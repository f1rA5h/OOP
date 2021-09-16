using System;

namespace background_1_1
{
    class Program
    {
        static double CalcFunc10(int a, int b, int c)
        {

            return (double)(a + c) / (b + a) +
                Math.Pow(
                    (2 * Math.Sin(b) + a),
                    (1.0 / 3.0)) +
                Math.Pow(c, 2);
        }

        static void Main(string[] args)
        {
            Console.WriteLine(CalcFunc10(1, 2, 3));
            Console.ReadKey();
        }
        
    }
}

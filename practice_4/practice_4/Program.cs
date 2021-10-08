using System;

namespace practice_4
{
    class Program
    {
        static double max(double a, double b, double c = int.MinValue)
        {
            double temp = a;
            if (b > temp) temp = b;
            if (c > temp) temp = c;

            return temp;
        }

        static double min(double a, double b, double c = int.MaxValue)
        {
            double temp = a;
            if (b < temp) temp = b;
            if (c < temp) temp = c;

            return temp;
        }

        static void Main(string[] args)
        {

            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());
            double res = min(Math.Sqrt(max(a, Math.Abs(b + 1), a + 5)), min(a, b - max(a, -b, a * b)))
                - max((Math.Sqrt(a + 1)) / (2 + Math.Pow(a, 2)), b + 5, a);

            Console.WriteLine($"{res:f3}");
        }
    }
}

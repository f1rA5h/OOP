using System;

namespace practice7
{
    static class Program
    {
        static void Increase(ref int first, int second)
        {
            int tmp = second;
            while (tmp > 10)
            {
                first *= 10;
                tmp /= 10;
            }
        }
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());;

            Increase(ref first, second);

            Console.WriteLine($"{first}");
        }
    }
}
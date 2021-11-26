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

        static void MinusDevider(ref int param)
        {
            int devider = 1;
            for(int i = 1; i <= param / 2; i++)
            {
                if (param % i == 0)
                {
                    devider = i;
                }
            }
            param -= devider;
        }

        static void Main(string[] args)
        {
            Console.Write("input first param:\t");
            int first = int.Parse(Console.ReadLine());

            Console.Write("input first param:\t");
            int second = int.Parse(Console.ReadLine());;

            Increase(ref first, second);

            Console.WriteLine($"result:\t{first}");

            Console.Write("input divident:\t");
            int param = int.Parse(Console.ReadLine());

            MinusDevider(ref param);
            Console.WriteLine($"result:\t{param}");
        }
    }
}
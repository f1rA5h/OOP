using System;

namespace practice7
{
    static class Program
    {
        static int F(int n)
        {
            if(n <= 0) return n;
            else if(n > 0 && n % 5 == 0) return n + F(n / 5 - 1);
            else if(n > 0 && n % 5 != 0) return n + F(n + 6);
            return 0;
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int result = F(n);
            while(result < 1000)
            {
                n++;
                result = F(n);
            }
            Console.WriteLine(n);
        }
    }
}
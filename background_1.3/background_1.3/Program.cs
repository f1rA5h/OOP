using System;

namespace background_1._3
{
    class Program
    {
    static double maxSum(int n)
        {
            double a1, a2;
            double tmp;


            a1 = Convert.ToDouble(Console.ReadLine()); 
            a2 = Convert.ToDouble(Console.ReadLine()); 

            tmp = a1 + a2; 
            for (int i = 2; i < n; i++) 
            {
                a1 = a2; 
                a2 = Convert.ToDouble(Console.ReadLine()); 
                if (a1 + a2 > tmp)
                {
                    tmp = a1 + a2;
                }
            }
            return tmp;
        }



        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            double maxSumResult = maxSum(n);
            Console.WriteLine($"{maxSumResult:f3}");
        }
    }
}

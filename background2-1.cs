using System;

namespace Background 
{
    class Program
    {
        static int Task1(uint x)
        {
            uint tmp = x;
            uint mask = 1;

            int counter = 0;
            for(int i = 31; i >= 0; i--)
            {
                tmp >>= i;
                if((tmp & mask) == 0)
                {
                    counter++;
                }
                tmp = x;
            }
            
            return counter;
        }

        static void Task2(int x)
        {
            int tmp = x;
            int mask = 1;

            bool first1 = false;

            int tmpRes;
            for(int i = 31; i >= 0; i--)
            {
            
                tmp >>= i;
                tmpRes = tmp & mask;
                if (tmpRes == 1)
                {
                    first1 = true;
                }
                if (first1)
                {
                    Console.Write(tmp & mask);
                }
                tmp = x;
            }
            Console.WriteLine();
        }

        static void Task3(uint x, uint n)
        {   

            uint tmp = x;
            uint mask = 0x80000000; // первый бит -- 1 (8 = 1000)
            uint mask2 = 1;

            uint tmpRes;

            for(int i = 0; i < n; i++)
            {
                tmpRes = tmp & mask2;

                tmp >>= 1;

                if (tmpRes == 1)
                {
                    tmp |= mask;
                }

                // tmp = x;
            }

            uint tmp2 = tmp;

            for(int i = 31; i >= 0; i--)
            {
                tmp2 >>= i;
                Console.Write(tmp2 & mask2);
                tmp2 = tmp;
            }
        }
        static void Main(string[] args)
        {
            uint x1 = Convert.ToUInt32(Console.ReadLine());
            uint n = Convert.ToUInt32(Console.ReadLine());
            int x2 = Convert.ToInt32(Console.ReadLine());


            Console.Write("Кол-во нулей в двоичной: ");
            int res1 = Task1(x1);
            Console.WriteLine(res1);
            
            Console.Write("Число в двоичной без ведущих нулей: ");
            Task2(x2);

            Console.Write("Результат цикличного сдвига: ");
            Task3(x1, n);

            Console.ReadKey();
        }
    }
}
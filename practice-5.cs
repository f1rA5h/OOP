using System;

namespace Practice 
{
    class Program
    {
        static void Experiment(int a, int b)
        {
            int c = a % b;
            Console.WriteLine(c);
        }

        static uint sum(uint number)
        {
            uint result = 0;

            int tmp = 0;
            uint tmpNum = number;
            while(tmpNum > 0) 
            {
                tmp++;
                tmpNum /= 10;
            }

            uint digit;
            for(int i = 0; i <= tmp; i++)
            {
                digit = number % 10;
                number /= 10;
                if(digit % 3 != 0)
                {
                    result += digit;
                }
            }
            
            return result;
        }

        static uint sacondEnd(uint number)
        {
            uint result = number;

            int tmp = 0;
            uint tmpNum = number;
            while(tmpNum > 0) 
            {
                tmp++;
                tmpNum /= 10;
            }

            if (number >= 10)
            {
                for (int i = 0; i < tmp - 2; i++)
                {
                    result /= 10;
                }


                return result % 10;
            }
            else
            {
                return 10;
            }
        }

        static uint NoThree(uint number)
        {
            uint result = 0;

            int tmp = 0;
            uint tmpNum = number;

            while(tmpNum > 0) 
            {
                tmp++;
                tmpNum /= 10;
            }

            int digit;
            for(int i = 1; i < tmp; i++)
            {
                
            }
        }

        static void Main(string[] args)
        {
            uint number = uint.Parse(Console.ReadLine());
            uint result = sum(number);

            if(result != 0)
            {
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("NO");
            }

            result = sacondEnd(number);
            if (result < 10) 
            {
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
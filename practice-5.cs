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

            uint digit;
            int j = 0;
            for(int i = 0; i <= tmp; i++)
            {
                digit = number % 10;
                if(digit != 3)
                {
                    result += digit * Convert.ToUInt32(Math.Pow(10, j++));
                }
                number /= 10;
            }
            return result;
        }

        static uint DigitSwith(uint number)
        {
            int tmp = 0;
            uint tmpNum = number;

            while(tmpNum > 0) 
            {
                tmp++;
                tmpNum /= 10;
            }

            uint lastDigit = number % 10;

            uint firstDigit = number;
            uint j = 1;
            while(firstDigit >= 10)
            {
                j *= 10;
                firstDigit /= 10;
            }

            number -= j * firstDigit;
            number /= 10;
            
            return lastDigit * j + number * 10 + firstDigit;
        }

        static void Deviders(uint a, uint b)
        {
            for(int i = 2; i <= (int)Math.Sqrt(a); i++)
            {
               if(a % i == 0) {
                    if(b % i != 0 && i % b != 0)
                    {
                        Console.WriteLine(i);
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            uint number = uint.Parse(Console.ReadLine());
            uint result1 = sum(number);

            if(result1 != 0)
            {
                Console.WriteLine(result1);
            }
            else
            {
                Console.WriteLine("NO");
            }

            uint result2 = sacondEnd(number);
            if (result2 < 10) 
            {
                Console.WriteLine(result1);
            }
            else
            {
                Console.WriteLine("NO");
            }

            uint result3 = NoThree(number);
            Console.WriteLine(result3);

            uint result4 = DigitSwith(number);
            Console.WriteLine(result4);

            uint a = Convert.ToUInt32(Console.ReadLine());
            uint b = Convert.ToUInt32(Console.ReadLine());
            Deviders(a, b);
        }
    }
}
using System;

namespace Task
{
    class Program
    {
        static void Task1(out int count, out int min)
        {
            min = 7;
            count = 0;
            for(int i = 1107; i <= 9504; i++)
            {
                if(i % 9 == 0 && i % 7 != 0 && i % 15 != 0 && i % 17 != 0 && i % 19 != 0)
                {
                    count++;
                    if(i < min || min == 7)
                    {
                        min = i;
                    }
                }
            }
        }

        static void Task2(out int count, out int min)
        {
            min = 7;
            count = 0;
            for(int i = 1529; i <= 9482; i++)
            {
                if((i - 1) % 4 == 0 && (i - 3) % 5 == 0)
                {
                    count += i;
                    if(i < min || min == 7)
                    {
                        min = i;
                    }
                }
            }
        }

        static void Task3(out int count, out int max)
        {
            max = 7;
            count = 0;
            for(int i = 2461; i <= 9719; i++)
            {
                if((i / 10) % 10 >= 3 && (i / 10) % 10 <= 7 && (i / 100) % 10 != 1 && (i / 100) % 10 != 9)
                {
                    count++;
                    if(i > max || max == 7)
                    {
                        max = i;
                    }
                }
            }
        }

        static void Task4(out int count, out int min)
        {
            min = 7;
            count = 0;
            int j = 0;
            int tmp = 1;
            for(int i = 2079; i <= 43167; i++)
            {
                j = i;
                while(j != 0)
                {
                    if(j % 10 == 2)
                    {
                        tmp *= 2;
                    } else
                    if(j % 10 == 0)
                    {
                        tmp *= 3;
                    } else
                    if(j % 10 == 5)
                    {
                        tmp *= 5;
                    }
                    j /= 10;
                }

                if(i % 7 == 0 && tmp % 30 == 0)
                {
                    count++;
                    if(i < min || min == 7)
                    {
                        min = i;
                    }
                }
                tmp = 1;
            }
        }

        static void Task5(out int count, out int min)
        {
            min = 7;
            count = 0;
            int countTmp = 0;
            for(int i = 56123; i <= 97354; i++)
            {
                for(int j = 1; j <= Math.Sqrt(i); j++)
                {
                    if(i % j == 0) countTmp+=2;
                }
                if(countTmp >= 35)
                {
                    count++;
                    if(i < min || min == 7)
                    {
                        min = i;
                    }
                }
            }
        }

        static void Main()
        {
            int count, min, sum;
            Task1(out count, out min);
            Console.WriteLine("{0}, {1}", count, min);

            Task2(out sum, out min);
            Console.WriteLine("{0}, {1}", min, sum);

            Task3(out count, out min);
            Console.WriteLine("{0}, {1}", count, min);

            Task4(out count, out min);
            Console.WriteLine("{0}, {1}", count, min);

            Task5(out count, out min);
            Console.WriteLine("{0}, {1}", count, min);
        }
    }
}
using System;

namespace task_after_lesson
{
    class Program
    {
        // 1
        static double task1(double a, double b, double c, double d)
        {
            double z = (f(a, b) + f(c, d)) / f(2.8, Math.Sin(0.6));
            return z;
        }

        static double f(double x, double y)
        {
            return Math.Pow(x, 2) + Math.Pow(y, 2);
        }

        // 2
        static string isOdd(int a)
        {
            if (a % 2 == 0)
                return "NS";
            else
                return "S";

        }

        // 3
        static string checkMark(int a)
        {
            if (a >= 5)
                return "Задание выполнено отлично!";
            else
                return "Еще поработай!";
        }

        static void Main(string[] args)
        {
            Console.WriteLine($"{task1(5, 5, 5, 5):f3}");

            int checkIsOdd = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(isOdd(checkIsOdd));

            int markToCheck = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(checkMark(markToCheck));
        }
    }
}

using System;

namespace practice_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            double f; // индекс производительности

            const double r = 64.100; // разряд ОС
            const float p1 = 0.78932597F; // доступная память
            const float pr = 100000000000f; // оп/с
            const double f1 = 3.20000; // разпядность проц

            const int s1 = 4; // жесткий диск
            const int p = 16; // память
            const string s = "AMD"; 
            const decimal dec = 18500.5m; // производительность 
            

            Console.Write("Введите Ваше имя: ");
            name = Console.ReadLine();
            Console.Write("Введите дробное число: ");
            
            f = double.Parse(Console.ReadLine());

            Console.WriteLine("");
            Console.WriteLine("Привет, {0}!", name);
            Console.WriteLine("*********************************");
            Console.WriteLine("*\tЯ твой компьютер!\t*");
            Console.WriteLine("*********************************");
            Console.WriteLine("У меня следующие характеристики: ");
            Console.WriteLine("");
            Console.WriteLine($"Процессор\t\t{s} c разрядностью {f1:F2}GHz");
            Console.WriteLine($"Моя память\t\t{p}Gb (доступно {p1:P0}) ");
            Console.WriteLine($"Жесткий диск\t\t{s1 * 1024:E2} Gb");
            Console.WriteLine($"Тип системы\t\t{r:F0}-разрядная ОС");
            Console.WriteLine("");
            Console.WriteLine($"Моя производительность\t{pr:G3} оп/сек");
            Console.WriteLine($"Индекс произв-ти\t{f:F0}");
            Console.WriteLine($"Моя производительность\t{dec:C2}");
            Console.ReadKey();
        }
    }
}
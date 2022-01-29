using System;

namespace normal_practice
{
    internal class Program
    {
        private enum Month
        {
            декабрь = 11, январь = 0, февраль, март, апрель, май, июль, июнь, август, сентябрь, ноябрь, октябрь,
        };
        private enum Seasons { Зима = 0, Весна, Лето, Осень }; 
        private static readonly int[] Days = {0, 31, 62, 90, 121, 150, 182, 212, 243, 274, 304, 335 };
        
        public static void Main()
        {
            ShowValues();
            Console.Write("Введите номер месяца:\t");
            int month = int.Parse(Console.ReadLine());
            Console.Write("Введите день:\t");
            int currentDay = int.Parse(Console.ReadLine());
            Console.Write("Сколько дней нужно отсчитать:\t");
            int day = int.Parse(Console.ReadLine());
            
            int season = GetDays(month, currentDay, day);
            Console.WriteLine($"{(Seasons) season}!");
        }

        private static void ShowValues()
        {
            for (int i = (int) Month.январь; i <= (int) Month.декабрь; i++)
                Console.WriteLine($"Месяц: \"{(Month) i}\", соответсвует числу {i + 1}");
        }
        
        private static int GetDays(int currentMonth, int currentDay, int days)
        {
            double resultDay = (Days[currentMonth - 1] + currentDay + days + 31) % 365;
            return resultDay switch
            {
                <= 90 => Seasons.Зима,
                <= 182 => Seasons.Весна,
                <= 274 => Seasons.Лето,
                _ => Seasons.Осень
            };
        }
    }
}
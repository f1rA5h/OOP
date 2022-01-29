using System;
using System.Diagnostics;

class Program
{
    private enum Month
    {
        январь = 1, февраль,
        март, апрель, май,
        июль, июнь, август,
        сентябрь, ноябрь, октябрь,
        декабрь
    };

    private enum Seasons { Зима = 1, Весна, Лето, Осень };
    
    private const int monthAmount = 12;
    private const int firstMonthIndex = 1;
    private const int daysInYear = 365;
    
    private static void Main() 
    {
        ShowValues();
        
        Console.WriteLine(ReturnSeason(
            InputDays(
            GetDaysBeforeDate(
                InputNumber("Введите номер месяца: "), 
                InputNumber("Введите номер дня: ")),
            InputNumber("Сколько дней нужно отсчитать?")
            ))
        );
    }

    private static Seasons? ReturnSeason(int? month) => month switch
    {
        <= 2 => Seasons.Зима,
        <= 5 => Seasons.Весна,
        <= 8 => Seasons.Лето,
        <= 11 => Seasons.Осень,
        12 => Seasons.Зима,
        _ => null
    };
    
    private static int InputNumber(string message)
    {
        Console.WriteLine(message);
        return int.Parse(Console.ReadLine());
    }
    
    private static int? InputDays(int? external, int days)
        => GetMonth((days <= daysInYear) ? days + external : days % daysInYear + external);

    private static void ShowValues(int monthRealIndex = firstMonthIndex)
    {
        Console.WriteLine($"Месяц: \"{Month.январь + monthRealIndex - 1}\", соответсвует числу {monthRealIndex++}");
        if (monthRealIndex <= monthAmount) ShowValues(monthRealIndex);
    }

    private static int? GetDays(int? monthsNumber) => monthsNumber switch 
    {
        <= 8 when monthsNumber == 2 => 28,
        <= 8 => 30 + monthsNumber % 2,
        <= 12 => 31 - monthsNumber % 2,
        _ => null
    };
    
    private static int? GetDaysBeforeDate(int? month, int? day)
        => GetDaysBeforeMonth(month) + day;
    
    private static int? GetDaysBeforeMonth(int? month, int? day = 0)
    {
        if (month == 1) return GetDays(month) + day;
        else return day + GetDays(month) + GetDaysBeforeMonth(month - 1, day);
    }

    private static int? GetMonth(int? days, Month month = Month.январь)
    {
        if (days == null) return null;
        if (days - GetDays((int) month + 1) <= 0) return 1;
        return 1 + GetMonth(days - GetDays((int) month + 1), month);
    }
}
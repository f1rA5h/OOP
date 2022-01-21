using System;
using System.Diagnostics;

class Program
{
    private enum Month
    {
        январь = 1,
        февраль,
        март,
        апрель,
        май,
        июль,
        июнь,
        август,
        сентябрь,
        ноябрь,
        октябрь,
        декабрь
    };

    private enum Seasons
    {
        зима = 1,
        весна,
        лето,
        осень
    };
    
    private const int monthAmount = 12;
    private const int firstMonthIndex = 1;
    private const int daysInYear = 365;
    
    static void Main() 
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

    static Seasons? ReturnSeason(int? month) => month switch
    {
        <= 2 => Seasons.зима,
        <= 5 => Seasons.весна,
        <= 8 => Seasons.лето,
        <= 11 => Seasons.осень,
        12 => Seasons.зима,
        _ => null
    };

    static int? GetDaysBeforeDate(int? month, int? day)
    {
        return GetDaysBeforeMonth(month) + day;
    }
    static int InputNumber(string message)
    {
        Console.WriteLine(message);
        return int.Parse(Console.ReadLine());
    }
    
    static int? InputDays(int? external, int days)
    {
        return GetMonth((days <= daysInYear) ? days + external : days % daysInYear + external);
    }
    
    static void ShowValues(int monthRealIndex = firstMonthIndex)
    {
        Console.WriteLine($"Месяц: \"{Month.январь + monthRealIndex - 1}\", соответсвует числу {monthRealIndex++}");
        if (monthRealIndex <= monthAmount) ShowValues(monthRealIndex);
    }

    static int? GetDays(int? monthsNumber) => monthsNumber switch 
    {
        <= 8 when monthsNumber == 2 => 28,
        <= 8 => 30 + monthsNumber % 2,
        <= 12 => 31 - monthsNumber % 2,
        _ => null
    };

    static int? GetDaysBeforeMonth(int? month, int? day = 0)
    {
        if (month == 1) return GetDays(month) + day;
        else return day + GetDays(month) + GetDaysBeforeMonth(month - 1, day);
    }

    static int? GetMonth(int? days, Month month = Month.январь)
    {
        if (days == null) Console.WriteLine("ошибка");
        // int? res = days - GetDays((int)++month);

        if (days - GetDays((int) month + 1) <= 0) return 1;

        return 1 + GetMonth(days - GetDays((int) month + 1), month);
    }
}
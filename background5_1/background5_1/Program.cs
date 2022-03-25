using System;

namespace background5_1
{
    class MatrixWeather
    {
        private static Random rnd = new Random();
        
        private static int valueToFill = -1000; 
        public enum Monthes
        {
            January = 0, February, 
            March, April, May,
            June, July, August,
            September, October, November,
            December
        }

        public enum DaysOfWeek
        {
            Mo = 0, Tu, We, Th, Fr, St, Su
        }
        
        
        private static readonly int[] daysInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        private static readonly int[,] temperatureDiaposone =
        {
            { -25, 5 }, { -20, 10 },
            { -15, 20 }, { -5, 25 }, { 5, 30 }, 
            { 15, 35 }, { 15, 35}, { 15, 40 },
            { 10, 30 }, { 0, 20 }, { -15, 15 },
            { -20, 10 }
        };

        private MatrixWeather()
        {
            month = (Monthes)rnd.Next(0, 12);
            day = rnd.Next(0, 7);

            FillTemp();
        }

        private MatrixWeather(int day, int month)
        {
            this.month = (Monthes)month;
            this.day = day;
            
            FillTemp();

        }

        private Monthes month;      // месяц
        private int day;            // день недели, на который пришлось первое число данного месяца
        private int[,] temperature; // 0 – номер недели, 1 – день недели
                                    // [6,7]
        public Monthes Month        // или же сделать string чтобы закрыть Monthes (а зачем?)
        {
            get { return month; } 
            set {
                try
                {
                    month = value;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                } } 
        }
        public int Day
        {
            get { return day; }
            set
            {
                try
                {
                    if (value >= 0 && value < 7)
                    {
                        ChangeFirstDay(value);
                        day = value;
                    }
                    else throw new Exception("Такого дня недели не может существовать");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            } 
        }

       
        public string DayOfWeek
        {
            get { return ((DaysOfWeek) day).ToString(); }
        }
        public int[,] Temperature
        {
            get { return temperature; }
            // set {}
        }
        // получить количество дней в дневнике
        public int DaysInDiary
        {
            get { return daysInMonth[(int)month]; }
        }
        // вычислить количество дней, когда погода была равна 0 градусов
        public int ZeroTemperatureCount
        {
            get
            {
                int count = 0;
                foreach (var i in Temperature) 
                    if (i == 0) count++;
                return count;
            }
        }
        // возвращает -1000 ииспользуется для заполнения ячеек массива, для которых нет информации о температуре
        public int[,] NoData
        {
            get
            {
                int i = temperature.GetLength(0);
                int j = temperature.GetLength(1);
                int[,] arr = new int[i, j];
                // МЕТОД ARRAY.FILL ЕСТЬ ТОЛЬКО В .NET А В .NET FRAMEWORK ЕГО ПРОСТО ПО ПРИКОЛУ НЕ ЗАВЕЗЛИ
                FillIntTwoArray(arr, valueToFill);
                return arr;
            }
        }
        private void FillIntTwoArray(int[,] arr, int value)
        {
            int x = arr.GetLength(0);
            int y = arr.GetLength(1);
            
            for(int i = 0; i < x; i++)
            for (int j = 0; j < y; j++)
                arr[i, j] = value;
        }
        private void FillTemp()
        {
            temperature = new int[6, 7];
            FillIntTwoArray(temperature, valueToFill);
            int x = temperature.GetLength(0);
            int y = temperature.GetLength(1);
            int leftValues = daysInMonth[(int) month];
            
            for (int i = 0; i < y; i++)
            {
                if(i < day) temperature[0, i] = valueToFill;
                else {
                    temperature[0, i] = 
                    rnd.Next(temperatureDiaposone[(int)month, 0], temperatureDiaposone[(int)month, 1]);
                    leftValues--;
                }
            }
            
            for(int i = 1; i < x; i++)
            for (int j = 0; j < y; j++)
            {
                leftValues--;
                if (leftValues <= 0) temperature[i, j] = valueToFill;
                else temperature[i, j] = 
                    rnd.Next(temperatureDiaposone[(int)month, 0], temperatureDiaposone[(int)month, 1]);
            }
        }
        public void Output()
        {
            int d = 0;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            for (int i = 0; i < 7; i++)
                Console.Write($"{(DaysOfWeek)i}\t");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < temperature.Length; i++)
            {
                int j = i / 7;
                int ir = i % 7;
                if (temperature[j, ir] != valueToFill)
                {                
                    d++;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(d);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write($" {temperature[j, ir]}");
                }
                Console.Write("\t");

                if (ir == 6) Console.WriteLine();

            }
        }
        private void ChangeFirstDay(int newDay)
        {
            int[,] tmpTemperature = new int[6, 7];

            FillIntTwoArray(tmpTemperature, valueToFill);
            int diff = newDay - day;
            for (int i = 0; i < temperature.Length; i++)
            {
                int ni = i - diff;
                if (ni >= 0 && ni < temperature.Length)
                {
                    int j = ni / 7;
                    int ir = ni % 7;

                    int j2 = i / 7;
                    int ir2 = i % 7;

                    tmpTemperature[j2, ir2] = temperature[j, ir];
                }

            }
            
            temperature = tmpTemperature;
        }
        public int ZeroDays
        {
            get
            {
                int counter = 0;
                for (int i = 0; i < temperature.GetLength(0); i++)
                for (int j = 0; j < temperature.GetLength(1); j++)
                {
                    if (temperature[i, j] == 0) counter++;
                }

                return counter;
            }
        }
        public int JustJump
        {
            get
            { 
                int value;
                int newValue = temperature[0, day];
                int diff = 0;

                for (int i = 0; i < temperature.GetLength(0); i++)
                for (int j = 1; j < temperature.GetLength(1); j++)
                {
                    if (temperature[i, j] != valueToFill)
                    {
                        value = newValue;
                        newValue = temperature[i, j];

                        if (Math.Abs(value - newValue) > diff) diff = Math.Abs(value - newValue);
                    }
                }
                return diff;
            }
        }
       
        public int Jump(out int dayN, out int tempN)
        {
            int value;
            int newValue = temperature[0, day];
            dayN = 0;
            tempN = 0; 
            int diff = 0;
                
                for (int i = 0; i < temperature.GetLength(0); i++)
                for (int j = 1; j < temperature.GetLength(1); j++)
                {
                    if (temperature[i, j] != valueToFill)
                    {
                        value = newValue;
                        newValue = temperature[i, j];

                        if (Math.Abs(value - newValue) > diff)
                        {
                            diff = Math.Abs(value - newValue);
                            dayN = (i - 1) * 7 + j + (7 - day);
                            tempN = value;
                        }
                    }
                }

                return diff;
            
        }

        public static MatrixWeather Create()
        {
            MatrixWeather weather1;
            while (true)
            {
                try
                {
                    Console.WriteLine("1) Создать случайный месяц\n2) Создать месяц с заданными днями");
                    int option = int.Parse(Console.ReadLine());
                    if (option == 1)
                    { 
                        weather1 = new MatrixWeather();
                        
                        return weather1;
                    }
                    else if (option == 2)
                    {
                        int day = int.Parse(Console.ReadLine());
                        int month = int.Parse(Console.ReadLine());

                        weather1 = new MatrixWeather(day, month);
                        
                        return weather1;
                    }
                    break;
                }
                
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка:" + e);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
            }

            return new MatrixWeather();
        }
    }
    
    internal class Program
    {
        public static void Main()
        {
            MatrixWeather weather1;

            int option;
            
            weather1 = MatrixWeather.Create();
            
            weather1.Output();
            while (true)
            {
                Console.WriteLine(@"
1) Вывести день недели первого дня месяца
2) Изменить день недели первого месяца
3) Вывести месяц
4) Вывести массив с температурой по дням
5) Вывести количество дней в месяце
6) Вывести количество дней с нулевой температурой
7) Вывести максимальный скачок температуры
8) Вывести максимальный скачок с первым днем и температурой");
                
                try
                {
                    option = int.Parse(Console.ReadLine());
                    switch (option)
                    {
                        case 1: Console.WriteLine("День недели: " + weather1.DayOfWeek); break;
                        case 2: 
                            Console.WriteLine("Введите новый день недели (0 - пн, 6 - вс");
                            weather1.Day = int.Parse(Console.ReadLine()); 
                            break;
                        case 3: Console.WriteLine("Месяц: " + weather1.Month); break;
                        case 4: weather1.Output(); break;

                        case 5: Console.WriteLine("Дней в месяце: " + weather1.DaysInDiary); break;
                        case 6: Console.WriteLine("Дней с 0 температурой: " + weather1.ZeroDays); break;
                        case 7: Console.WriteLine("Скачок: " + weather1.JustJump); break;
                        case 8: 
                            int day, temp;
                            Console.Write("Скачок: " + weather1.Jump(out day,out temp));
                            Console.WriteLine($" День: {day} Температура: {temp}");
                            break;

                        default: break;
                    }

                    Console.ReadKey();
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка:" + e);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
            }
        }
    }
}
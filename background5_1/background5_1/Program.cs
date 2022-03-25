using System;

namespace background5_1
{
    class MatrixWeather
    {
        private static Random rnd = new Random();
        
        private static int valueToFill = -1000; 
        public enum Monthes
        {
            January, February, 
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

        public MatrixWeather()
        {
            month = (Monthes)rnd.Next(1, 13);
            day = rnd.Next(1, 8);

            FillTemp();
        }

        public MatrixWeather(int day, int month)
        {
            Month = (Monthes)month;
            Day = day;
            
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
                    if (value > 0 && value <= 7)
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
            int i = arr.GetLength(0) - 1;
            int j = arr.GetLength(1) - 1;

            for (; i >= 0; i--)
                for (; j >= 0; j--)
                    arr[i, j] = value;
        }
        private void FillTemp()
        {
            temperature = new int[6, 7];
            int x = temperature.GetLength(0);
            int y = temperature.GetLength(1);
            int leftValues = daysInMonth[(int) month];
            
            for (int i = 0; i < x; i++)
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
            for (int i = 0; i < 7; i++)
                Console.Write($"{(DaysOfWeek)i}\t");
            Console.WriteLine();
            
            for (int i = 0; i < temperature.Length; i++)
            {
                int j = i / 7;
                int ir = i % 7;
                if (temperature[j, ir] != valueToFill)
                {                
                    d++;
                    Console.Write($"{d} {temperature[j, ir]}");
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
                int value = temperature[2, 4];
                int newValue = temperature[2, 4];

                int diff = Math.Abs(value - newValue);
                
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
            int value = temperature[0, 0];
            int newValue = temperature[0, 0];
            dayN = 0;
            tempN = 0; 
            int diff = Math.Abs(value - newValue);
                
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
                            dayN = day + i * 7 + j;
                            tempN = value;
                        }
                    }
                }

                return diff;
            
        }
    }
    
    internal class Program
    {
        public static void Main()
        {
            MatrixWeather weather1 = new MatrixWeather(3, 4);
            weather1.Output();
            
            Console.WriteLine(weather1.DayOfWeek);
            Console.WriteLine(weather1.Month);
            Console.WriteLine(weather1.DaysInDiary);
            Console.WriteLine(weather1.ZeroDays);
            
            weather1.Day = 6;
            weather1.Output();
            
            Console.WriteLine(weather1.JustJump);
            
            int day, temp;
            Console.Write(weather1.Jump(out day,out temp));
            Console.WriteLine($" {day} {temp}");
            
        }
    }
}
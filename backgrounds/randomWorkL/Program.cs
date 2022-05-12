using System;

namespace randomWorkL
{
    class FreakedNumber
    {
        private int mainPart;
        private int topPart;
        private int bottomPart;

        public double Double
        {
            get { return mainPart + (double) topPart / bottomPart; }
        }
        public string String
        {
            get
            {
                this.MakeNormal();
                if (mainPart == 0) return $"{topPart}/{bottomPart}";
                return $"{mainPart} {topPart}/{bottomPart}";
            }
        }
        
        public FreakedNumber()
        {
            mainPart = 1;
            topPart = 1;
            bottomPart = 2;
        }

        public FreakedNumber(int mainPart, int topPart, int bottomPart)
        {
            this.mainPart = Math.Abs(mainPart);
            this.topPart = Math.Abs(topPart);
            this.bottomPart = Math.Abs(bottomPart);
            
            Devide(ref this.topPart, ref this.bottomPart);
        }
        
        static private void Devide(ref int a, ref int b)
        {
            int val = 1;
            
            for (int i = a; i > 1; i--)
                if (a % i == 0 && b % i == 0)
                {
                    val = i;
                    break;
                }


            a /= val;
            b /= val;
        }

        public void MakeNormal()
        {
            Devide(ref topPart, ref bottomPart);
            mainPart += topPart / bottomPart;
            topPart -= bottomPart * (topPart / bottomPart);
        }
        public void MakeMokeFreaked()
        {
            Devide(ref topPart, ref bottomPart);
            topPart += mainPart * bottomPart;
            mainPart = 0;
        }

        public static FreakedNumber operator +(FreakedNumber a, FreakedNumber b)
        {
            
            FreakedNumber c = new FreakedNumber(a.mainPart + b.mainPart, 
                a.topPart * b.bottomPart + b.topPart * a.bottomPart, 
                a.bottomPart * b.bottomPart);
            c.MakeNormal();
            return c;
        }
        public static FreakedNumber operator -(FreakedNumber a, FreakedNumber b)
        {
            FreakedNumber c = new FreakedNumber(a.mainPart - b.mainPart, 
                a.topPart * b.bottomPart - b.topPart * a.bottomPart, 
                a.bottomPart * b.bottomPart);
            c.MakeNormal();
            return c;
        }
        public static FreakedNumber operator *(FreakedNumber a, FreakedNumber b)
        {
            a.MakeMokeFreaked();
            b.MakeMokeFreaked();
            FreakedNumber c = new FreakedNumber(0,
                a.topPart * b.topPart, 
                a.bottomPart * b.bottomPart);
            a.MakeNormal();
            b.MakeNormal();
            c.MakeNormal();
            return c;
        }
        public static FreakedNumber operator /(FreakedNumber a, FreakedNumber b)
        {
            a.MakeMokeFreaked();
            b.MakeMokeFreaked();
            FreakedNumber c = new FreakedNumber(0,
                a.topPart * b.bottomPart, 
                a.bottomPart * b.topPart);
            a.MakeNormal();
            b.MakeNormal();
            c.MakeNormal();
            return c;
        }
        public static bool operator >=(FreakedNumber a, FreakedNumber b)
        {
            a.MakeMokeFreaked();
            b.MakeMokeFreaked();
            return a.topPart * b.bottomPart >= b.topPart * a.bottomPart;
        }

        public static bool operator <=(FreakedNumber a, FreakedNumber b)
        {
            a.MakeMokeFreaked();
            b.MakeMokeFreaked();
            return a.topPart * b.bottomPart <= b.topPart * a.bottomPart;
        }

        public static bool operator ==(FreakedNumber a, FreakedNumber b)
        {
            a.MakeMokeFreaked();
            b.MakeMokeFreaked();
            return a.topPart * b.bottomPart == b.topPart * a.bottomPart;
        }
        
        public static bool operator !=(FreakedNumber a, FreakedNumber b)
        {
            a.MakeMokeFreaked();
            b.MakeMokeFreaked();
            return a.topPart * b.bottomPart != b.topPart * a.bottomPart;
        }

        public static bool operator <(FreakedNumber a, FreakedNumber b)
        {
            a.MakeMokeFreaked();
            b.MakeMokeFreaked();
            return a.topPart * b.bottomPart < b.topPart * a.bottomPart;
        }

        public static bool operator >(FreakedNumber a, FreakedNumber b)
        {
            a.MakeMokeFreaked();
            b.MakeMokeFreaked();
            return a.topPart * b.bottomPart > b.topPart * a.bottomPart;
        }
        
        public static bool operator true(FreakedNumber a)
        {
            a.MakeNormal();
            return a.mainPart == 1;
        }

        public static bool operator false(FreakedNumber a)
        {
            a.MakeNormal();
            return a.mainPart != 1;
        }
    }
    
    class Program
    {
        public static void Main()
        {
            FreakedNumber number1 = new FreakedNumber(3, 3, 6);
            FreakedNumber number2 = new FreakedNumber(2, 8, 32);

            Console.WriteLine($"{number1.String} + {number2.String} = {(number1 + number2).String}");
            Console.WriteLine($"{number1.String} - {number2.String} = {(number1 - number2).String}");
            
            Console.WriteLine($"{number1.String} * {number2.String} = {(number1 * number2).String}");
            Console.WriteLine($"{number1.String} / {number2.String} = {(number1 / number2).String}");
            
            Console.WriteLine(number1.String + (number1 >= number2 ? " >= " : " <= ") + number2.String);
            
            Console.WriteLine(number1.String + " = " + number1.Double);
            Console.WriteLine(number2.String + " = " + number2.Double);

        }
    }
}


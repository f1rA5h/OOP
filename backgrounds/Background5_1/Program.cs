using System;

namespace Background5_1
{
    class Ellipse
    {
        private double a;
        private double A {
            set {
                if (value > 0) a = value;
                else throw new Exception("радиус не может быть отрицательным");
            }
            get { return a; }
        }

        private double b;
        private double B {
            set {
                if (value > 0) b = value;
                else throw new Exception("радиус не может быть отрицательным");
            }
            get { return b; }
        }

        public Ellipse()
        {
            a = 5;
            b = 2;
        }

        public Ellipse(double a, double b)
        {
            A = a;
            B = b;
        }
        public double c { get { return Math.Abs(a * a - b * b); } }
        public double Expocentre { get { return c / a; } }
        public double S { get { return Math.PI * a * b; } }
        public double P { get { return 4 * (Math.PI * a * b + (a - b) * (a - b)) / (a + b); } }
        public double R(double degree)
        {
            return a * b / Math.Sqrt(a * a * Math.Cos(ToRadian(degree)) * Math.Cos(ToRadian(degree)) + 
                                     b * b * Math.Cos(ToRadian(degree)) * Math.Cos(ToRadian(degree)));
        }
        private static double ToRadian(double degree) { return degree * Math.PI / 180; }

        public static Ellipse CreateEllipseConsole()
        {
            Console.WriteLine("1 для создания вручную\n" +
                              "2 для создания по умолчанию");
            int option = 3;
            int.TryParse(Console.ReadLine(), out option);

            switch (option)
            {
                case 1:
                    Console.WriteLine("Введите радиусы");
                    try
                    {
                        double a = double.Parse(Console.ReadLine());
                        double b = double.Parse(Console.ReadLine());
                        return new Ellipse(a, b);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Ошибка:" + e.Message + "\n Попробуйте заново");
                        return CreateEllipseConsole();
                    }
                case 2:
                    return new Ellipse();
                default:
                    Console.WriteLine("Некорректный ввод, попробуйте заново");
                    return CreateEllipseConsole();
            }
        }
    }
    
    internal class Program
    {
        public static void Main()
        {
            Ellipse ellipse1 = Ellipse.CreateEllipseConsole();
            Console.WriteLine(ellipse1.c);
            Console.WriteLine(ellipse1.Expocentre);
            Console.WriteLine(ellipse1.P);
            Console.WriteLine(ellipse1.S);
        }
    }
}
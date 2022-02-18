using System;

namespace Background5_1
{
    class Ellipse
    {
        private double a;
        private double b;

        public Ellipse()
        {
            a = 5;
            b = 2;
        }

        public Ellipse(double a, double b)
        {
            this.a = a;
            this.b = b;
        }
        double c
        {
            get { return Math.Abs(a * a - b * b); }
        }
        public double Expocentre()
        {
            return c / a;
        }
        public double S
        {
            get { return Math.PI * a * b; }
        }
        public double P
        {
            get { return 4 * (Math.PI * a * b + (a - b) * (a - b)) / (a + b); }
        }
        public double R(double degree)
        {
            return a * b / 
                   (Math.Sqrt(a * a * Math.Cos(ToRadian(degree)) * Math.Cos(ToRadian(degree)) + 
                              b * b * Math.Cos(ToRadian(degree)) * Math.Cos(ToRadian(degree))));
        }
        private static double ToRadian(double degree)
        {
            return degree * Math.PI / 180;
        }
    }
    
    internal class Program
    {
        public static void Main()
        {
            Console.WriteLine("1 для создания вручную\n" +
                              "2 для создания по умолчанию");
            int option = int.Parse(Console.ReadLine());
        }
    }
}
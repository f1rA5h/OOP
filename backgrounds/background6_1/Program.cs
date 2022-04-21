using System;

namespace background6_1
{
    abstract class Figure
    { 
        public double X { get; set; }
        public double Y { get; set; }
        
        public Figure()
        {
            X = 0;
            Y = 0;
        }
        
        public Figure(double x, double y)
        {
            X = x;
            Y = y;
        }

        public void Show()
        {
            Console.WriteLine($"x: {X}, y: {Y}");
        }
    }

    class Triangle : Figure
    {
        // deg * pi / 180 = rad
        // rad * 180 / pi = deg
        private double angle; // stored in radians
        private double a;
        private double b;
        
        public double Angle
        {
            get { return angle * 180 / Math.PI; }
            set
            {
                if (value > 0 && value < 180) angle = value * Math.PI / 180;
                else throw new Exception("низя так");
            }
        }

        public double A
        {
            get { return a; }
            set
            {
                if (value > 0) a = value;
                else throw new Exception("низя так");
            }
        }
        
        public double B
        {
            get { return b; }
            set
            {
                if (value > 0) b = value;
                else throw new Exception("низя так");
            }
        }

        public Triangle()
        {
            angle = 60;
            a = 1;
            b = 1;
        }

        public Triangle(double x, double y, double angle, double a, double b) : base(x, y)
        {
            Angle = angle;
            A = a;
            B = b;
        }
    }

    class Rectangle : Figure
    {
        private double height;
        private double width;
        
        public double Height
        {
            get { return height; }
            set
            {
                if (value > 0) height = value;
                else throw new Exception("низя так");
            }
        }
        
        public double Width
        {
            get { return width; }
            set
            {
                if (value > 0) width = value;
                else throw new Exception("низя так");
            }
        }

        public Rectangle()
        {
            height = 1;
            width = 2;
        }

        public Rectangle(int x, int y, int height, int width) : base(x, y)
        {
            Height = height;
            Width = width;
        }
    }
    
    class Program
    {
        public static void Main()
        {

        }
    }
}
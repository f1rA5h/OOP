using System;


namespace background6_1
{
    abstract class Figure
    {
        public const double normalError = 0.01;
        public double x;
        public double X
        {
            get { return x; }
            set { x = value; }
        }
        public double y;
        public double Y
        {
            get { return y; }
            set { y = value; }
        }
        public Figure()
        {
            x = 0;
            y = 0;
        }
        public Figure(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public virtual void Show()
        {
            Console.Write($"x: {X}, y: {Y}");
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
                else throw new Exception("угол такой нельзя");
            }
        }

        public double A
        {
            get { return a; }
            set
            {
                if (value > 0) a = value;
                else throw new Exception("сторона такой быть не может");
            }
        }
        public double B
        {
            get { return b; }
            set
            {
                if (value > 0) b = value;
                else throw new Exception("вторая не может");
            }
        }
        public double Area
        {
            get { return 0.5 * a * b * Math.Sin(angle); }
        }
        public double C
        {
            get { return Math.Sqrt(a * a + b * b - 2 * Math.Cos(angle) * a * b); }
        }
        public bool IsIsosceles
        {
            get { return Math.Abs(A - B) < normalError || Math.Abs(A - C) < normalError || Math.Abs(C - B) < normalError; }
        }
        public Triangle(): base()
        {
            angle = 60;
            a = 1;
            b = 1;
        }
        public Triangle(double x, double y, double angle, double a, double b) : base(x, y)
        {
            this.angle = angle;
            this.a = a;
            this.b = b;
        }
        public override void Show()
        {
            Console.WriteLine("Triangle");
            base.Show();
            Console.WriteLine($", a: {a}, b: {b}, angle: {angle}");
            Console.Write($"Area = {Area}, ");
            if(IsIsosceles) Console.WriteLine("isosceles");
            else Console.WriteLine("non isosceles");
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
                else throw new Exception("высота не может");
            }
        }
        public double Width
        {
            get { return width; }
            set
            {
                if (value > 0) width = value;
                else throw new Exception("ширина не может");
            }
        }

        public bool IsSquare
        {
            get { return Math.Abs(width - height) < normalError; }
        }

        public double Area
        {
            get { return width * height; }
        }
        public Rectangle()
        {
            height = 1;
            width = 2;
        }
        public Rectangle(double x, double y, double height, double width) : base(x, y)
        {
            Height = height;
            Width = width;
        }
        public override void Show()
        {
            Console.WriteLine("Rectangle");
            base.Show();
            Console.WriteLine($", width = {width}, height = {height}");
            Console.Write($"Area = {Area}, ");
            if(IsSquare) Console.WriteLine("isosceles");
            else Console.WriteLine("non isosceles");
        }
    }
    
    class Program
    {
        public static void Main()
        {
            Random random = new Random();
            double rnd;
            Figure[] figures = new Figure[10];
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    switch (random.Next(2))
                    {
                        case 0:
                            rnd = (double) random.Next(1, 11) * random.Next(1, 11) / random.Next(1, 11);
                            figures [i] = new Rectangle(rnd, 10 + rnd, 60 - 5 * rnd , 20 + rnd);
                            break;
                        case 1:
                            rnd = (double) random.Next(1, 11) * random.Next(1, 11) / random.Next(1, 11);                            
                            figures[i] = new Triangle(rnd, 10 + rnd, (double)rnd / 10 * 180, 20 + rnd, 20 + rnd);
                            break;
                        default:
                            throw new Exception("что черт возьми тут произошло");
                    }
                }

                foreach (var item in figures)
                {
                    item.Show();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
using System;
using System.Runtime.InteropServices;
using System.Xml;

namespace background6_2
{
    class Paralelogram
    {
        static public Random random = new Random();
        
        protected const double error = 0.01;
        protected double alpha; // stored in radians
        protected double height;
        protected double width;

        public double Width
        {
            get { return width; }
            set
            {
                if (value > 0) width = value;
                else throw new Exception("сморозил");
            }
        }
        public virtual double Height
        {
            get { return height; }
            set
            {
                if (value > 0) width = value;
                else throw new Exception("сморозил");
            }
        }
        
        public double Alpha
        {
            get { return InDegrees(alpha); }
            set
            {
                if (value > 0 && value < 180) alpha = InRadians(value);
                else throw new Exception("сморозил");
            }
        }
        public double Area { get { return width * Height; } }
        public virtual double Side { get { return Height / Math.Sin(alpha); } }
        public double Perimeter { get { return 2 * (width + Side); } }
        public double Diagonal
        {
            get
            {
                double d1 = Math.Sqrt(Side * Side + width * width + 2 * Side * width * Math.Cos(alpha));
                double d2 = Math.Sqrt(Side * Side + width * width + 2 * Side * width * Math.Cos(Math.PI - alpha));
                return d1 < d2 ? d1 : d2;
            }
        }
        public Paralelogram()
        {
            alpha = InRadians(30);
            height = 10;
            width = 15;
        }
        public Paralelogram(double alpha, double height, double width)
        {
            this.alpha = InRadians(alpha);
            this.height = height;
            this.width = width;
        }
        public virtual void Show()
        {
            Console.WriteLine("Паралелограм");
            ShowInfo();
        }
        protected void ShowInfo()
        {
            Console.WriteLine($"Угол: {InDegrees(alpha)}\nПервая сторона: {width}\nВторая сторона: {Side}");
            Console.WriteLine($"Диагональ: {Diagonal}, S: {Area}, P: {Perimeter}");
        }
        protected double InRadians(double value)
        {
            return value * Math.PI / 180;
        }
        protected double InDegrees(double value)
        {
            return value * 180 / Math.PI;
        }
    }

    class Diamond : Paralelogram
    {
        public override double Side { get { return width; } }
        public override double Height { get { return CountHeight(alpha, width); } }
        public Diamond() : base(30, CountHeight(30, 15), 15) { }
        public Diamond(double alpha, double width) : base(alpha, CountHeight(alpha, width), width) { }
        static private double CountHeight(double alpha, double width)
        {
            return width * Math.Sin(alpha);
        }
        public override void Show()
        {
            Console.WriteLine("Ромб");
            ShowInfo();
        }
    }

    class Rectangle : Paralelogram
    {
        public override double Side { get { return height; } }
        public bool IsSquare
        {
            get { return Math.Abs(width - height) < error; }
        }
        public Rectangle() : base(90, 15, 20) { }
        public Rectangle(double height, double width) : base(90, height, width){ }
        public override void Show()
        {
            Console.WriteLine(IsSquare ? "Квадрат" : "Прямоугольник");
            ShowInfo();
        }
    }
    
    class Program
    {
        public static void Main()
        {
            double rnd;
            int option = -1;
            Paralelogram[] paralelogram = new Paralelogram[15];
            try
            {
                for (int i = 0; i < paralelogram.Length; i++)
                {
                    switch (Paralelogram.random.Next(3))
                    {
                        case 0:
                            rnd = (double) Paralelogram.random.Next(1, 11) * 
                                Paralelogram.random.Next(1, 11) / 
                                Paralelogram.random.Next(1, 11);
                            paralelogram[i] = new Paralelogram((double)rnd * 18, 20 + rnd, 20 + rnd);
                            paralelogram[i].Show();
                            try
                            {
                                while (option != 0)
                                {
                                    Console.WriteLine("0 -- выйти\n1 -- изменить высоту\n" +
                                                      "2 -- изменить угол\n3 -- изменить сторону");
                                    
                                    option = Int32.Parse(Console.ReadLine());
                                    switch (option)
                                    {
                                        case 0:
                                            break;
                                        case 1:
                                            paralelogram[i].Height = Double.Parse(Console.ReadLine());
                                            paralelogram[i].Show();
                                            break;
                                        case 2:
                                            paralelogram[i].Alpha = Double.Parse(Console.ReadLine());
                                            paralelogram[i].Show();
                                            break;
                                        case 3:
                                            paralelogram[i].Width = Double.Parse(Console.ReadLine());
                                            paralelogram[i].Show();
                                            break;
                                        default:
                                            throw new Exception("такой опции нет.");
                                    }
                                }

                                option = -1;
                            }
                            catch { Console.WriteLine("Ошибка ввода, попробуйте еще раз"); }
                            break;
                        case 1:
                            rnd = (double) Paralelogram.random.Next(1, 11) * 
                                Paralelogram.random.Next(1, 11) / 
                                Paralelogram.random.Next(1, 11);
                            paralelogram[i] = new Rectangle(3.33, 3);
                            paralelogram[i].Show();
                            try
                            {
                                while (option != 0)
                                {
                                    Console.WriteLine("0 -- выйти\n1 -- изменить высоту\n" +
                                                      "2 -- изменить сторону");
                                    
                                    option = Int32.Parse(Console.ReadLine());
                                    switch (option)
                                    {
                                        case 0:
                                            break;
                                        case 1:
                                            paralelogram[i].Height = Double.Parse(Console.ReadLine());
                                            paralelogram[i].Show();
                                            break;
                                        case 2:
                                            paralelogram[i].Width = Double.Parse(Console.ReadLine());
                                            paralelogram[i].Show();
                                            break;
                                        default:
                                            throw new Exception("такой опции нет.");
                                    }
                                }

                                option = -1;
                            }
                            catch { Console.WriteLine("Ошибка ввода, попробуйте еще раз"); }
                            break;
                        case 2:
                            rnd = (double) Paralelogram.random.Next(1, 11) * 
                                Paralelogram.random.Next(1, 11) / 
                                Paralelogram.random.Next(1, 11);
                            paralelogram[i] = new Diamond((double) rnd * 18, 10 + rnd);
                            paralelogram[i].Show();
                            try
                            {
                                while (option != 0)
                                {
                                    Console.WriteLine("0 -- выйти\n1 -- изменить сторону\n" +
                                                      "2 -- изменить угол");
                                    
                                    option = Int32.Parse(Console.ReadLine());
                                    switch (option)
                                    {
                                        case 0:
                                            break;
                                        case 1:
                                            paralelogram[i].Height = Double.Parse(Console.ReadLine());
                                            paralelogram[i].Show();
                                            break;
                                        case 2:
                                            paralelogram[i].Alpha = Double.Parse(Console.ReadLine());
                                            paralelogram[i].Show();
                                            break;
                                        default:
                                            throw new Exception("такой опции нет.");
                                    }
                                }

                                option = -1;
                            }
                            catch { Console.WriteLine("Ошибка ввода, попробуйте еще раз"); }
                            break;
                        default:
                            throw new Exception("что черт возьми тут произошло");
                    }
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
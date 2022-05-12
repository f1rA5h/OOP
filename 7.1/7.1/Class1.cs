using System;
using System.Runtime.InteropServices;
using System.Xml;

namespace _7._1
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
                if (value > 0) height = value;
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

        protected double InRadians(double value)
        {
            return value * Math.PI / 180;
        }
        protected double InDegrees(double value)
        {
            return value * 180 / Math.PI;
        }

        public bool IsSquare
        {
            get { return Math.Abs(width - height) < error && Math.Abs(alpha - InRadians(90)) < error; }
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
    }

    class Rectangle : Paralelogram
    {
        public override double Side { get { return height; } }
        
        public Rectangle() : base(90, 15, 20) { }
        public Rectangle(double height, double width) : base(90, height, width) { }

    }
}
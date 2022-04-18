using System;

namespace practice13
{
    class DemoPoint
    {
        protected double x;
        protected double y;

        public DemoPoint()
        {
            x = 0;
            y = 0;
        }

        public DemoPoint(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public void Show()
        {
            Console.Write($"х = {x}, y = {y}");
        }
    }

    class DemoLine : DemoPoint
    {
        protected double x1;
        protected double y1;

        public DemoLine() : base()
        {
            x1 = 0;
            y1 = 0;
        }

        public DemoLine(double x0, double y0, double x1, double y1) : base(x0, y0)
        {
            this.x1 = x1;
            this.y1 = y1;
        }
        
        // override
        new public void Show()
        {
            base.Show();
            Console.Write($"; х1 = {x1}, y1 = {y1}");
        }

        public void Draw()
        {
            
        }
    }
    
    class Program
    {
        public static void Main()
        {
            DemoPoint point = new DemoPoint(12, 43);
            DemoLine line = new DemoLine(23, 43, 2, 32);
            
            point.Show();
            Console.WriteLine();
            line.Show();
        }
    }
}
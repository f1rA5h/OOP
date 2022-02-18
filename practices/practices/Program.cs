using System;
using System.Diagnostics;

namespace practices
{
    class Point3D
    {
        private double x;
        private double y;
        private double z;
        
        public double X
        {
            get { return X; }
            set { if (value >= 0) x = value; }
        }
        public double Y
        {
            get { return X; }
            set { if (value >= 0) x = value; }
        }
        public double Z
        {
            get { return X; }
            set { if (value >= 0) x = value; }
        }

        public Point3D()
        {
            x = 0;
            y = 0;
            z = 0;
        }
        public Point3D(double x, double y,double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public void Move(int axis, double distance)
        {
            switch (axis)
            {
                case 1: x += distance; break;
                case 2: y += distance; break;
                case 3: z += distance; break;
            }
        }
        public double RadiusVector{
            get { return Math.Sqrt(x * x + y * y + z * z); }
        }
        public void Addiction(Point3D secondPoint)
        {
            x += secondPoint.x;
            y += secondPoint.y;
            z += secondPoint.z;
        }
        public void Output()
        {
            Console.WriteLine($"x: {x}; y: {y}; z: {z}");
        }
        public static void InputAxis(out int option, out double distance)
        {
            Console.WriteLine("Для смещения по оси X введите 1\n" +
                              "Для смещения по оси Y введите 2\n" +
                              "Для смещения по оси Z введите 3\n");

            option = int.Parse(Console.ReadLine());
            Console.Write("На какое значение изменить? ");
            distance = double.Parse(Console.ReadLine());
        }
        public static Point3D InputDot()
        {
            Console.WriteLine("Для ввода вручную введите 1\n" +
                              "Для точки в начале координат введите 2");
            int selectedOption = int.Parse(Console.ReadLine());

            if (selectedOption == 2)
            {
                Console.WriteLine("Точка создана");
                return new Point3D();
            }

            Console.Write("Введите координату X: ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("Введите координату Y: ");
            double y = double.Parse(Console.ReadLine());
            Console.Write("Введите координату Z: ");
            double z = double.Parse(Console.ReadLine());
            
            Console.WriteLine("Точка создана");
            return new Point3D(x, y, z);
        }
    }

    internal class Program
    {
        public static void Main()
        {
            Point3D point1 = Point3D.InputDot();
            Point3D point2 = Point3D.InputDot();
            
            Point3D.InputAxis(out int option, out double distance);
            point1.Move(option, distance);
            
            Point3D.InputAxis(out option, out distance);
            point2.Move(option, distance);
            
            point1.Output();
            point2.Output();
            
            Console.WriteLine($"Радиус верктор равен {point1.RadiusVector}");
            point1.Output(); 
            
            point1.Addiction(point2);
            
            Console.Write("Новые координаты: "); 
            point1.Output();
            point2.Output();

        }
    }
}
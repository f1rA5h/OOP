using System;
using System.Diagnostics;

namespace practices
{
    class Point3D
    {
        public float x;
        public float y;
        public float z;

        public Point3D()
        {
            x = 0;
            y = 0;
            z = 0;
        }
        
        public Point3D(float x, float y,float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public void Move(int axis, float distance)
        {
            switch (axis)
            {
                case 1: x += distance; break;
                case 2: y += distance; break;
                case 3: z += distance; break;
            }
        }

        public void Output()
        {
            Console.WriteLine($"x: {x}; y: {y}; z: {z}");
        }
        
        public static void InputAxis(out int option, out float distance)
        {
            Console.WriteLine("Для смещения по оси X введите 1\n" +
                              "Для смещения по оси Y введите 2\n" +
                              "Для смещения по оси Z введите 3\n");

            option = int.Parse(Console.ReadLine());
            Console.Write("На какое значение изменить? ");
            distance = float.Parse(Console.ReadLine());
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
            float x = float.Parse(Console.ReadLine());
            Console.Write("Введите координату Y: ");
            float y = float.Parse(Console.ReadLine());
            Console.Write("Введите координату Z: ");
            float z = float.Parse(Console.ReadLine());
            
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
            
            Point3D.InputAxis(out int option, out float distance);
            point1.Move(option, distance);
            
            Point3D.InputAxis(out option, out distance);
            point2.Move(option, distance);
            
            point1.Output();
            point2.Output();
        }
    }
}
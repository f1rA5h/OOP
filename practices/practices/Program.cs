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

        void Move(int axis, float distance)
        {
            switch (axis)
            {
                case 1: x += distance; break;
                case 2: y += distance; break;
                case 3: z += distance; break;
            }
        }

        void Output()
        {
            p OutputPoints(x, y, z);
        }

        private void InputAxis()
        {
            Console.WriteLine("Если хотите сделать смещение по оси X введите 1\n" +
                              "Если хотите сделать смещение по оси Y введите 2\n" +
                              "Если хотите сделать смещение по оси Z введите 3\n");

            int option = int.Parse(Console.ReadLine());
            Console.Write("Введите значение на которое требуется изменить: ");
            float distance = float.Parse(Console.ReadLine());
            
            Move(option, distance);
        }
    }

    internal class Program
    {
        private static void OutputPoints(float x, float y, float z)
        {
            Console.WriteLine($"x: {x}; y: {y}; z: {z}");
        }
        private static Point3D InputDot()
        {
            Console.WriteLine("Если хотите ввести координаты вручную введите 1\n" +
                              "Если хотите создвть точку в начале воординат введите 2");
            int selectedOption = int.Parse(Console.ReadLine());
            Point3D i = new Point3D();
            if (selectedOption == 2)
                return new Point3D();
            Console.Write("Введите координату X: ");
            float x = float.Parse(Console.ReadLine());
            Console.Write("Введите координату Y: ");
            float y = float.Parse(Console.ReadLine());
            Console.Write("Введите координату Z: ");
            float z = float.Parse(Console.ReadLine());
            return new Point3D(x, y, z);
        }
        
        public static void Main()
        {
            Point3D point1 = InputDot();
            Point3D point2 = InputDot();

            
        }
    }
}
 using System;
 
 namespace Help{
 class Program
    {
        static void vuvod(int[,] a)//a -Функция вывода массива на экран так, чтобы увидеть строки и столбцы
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write("{0} ", a[i, j]);
                }
                Console.WriteLine();
            }
        }
        static void vuvods(string[,] a)//a -Функция вывода массива на экран так, чтобы увидеть строки и столбцы
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write(" {0}", a[i, j]);
                }
                Console.WriteLine();
            }
        }
        static void vvod(int[,] m, string[] s)//b -функцию заполняет массив по особой схеме
        {
            int i = 0;
            int j = 0;
            m[i, j] = int.Parse(s[0]);
            for (int k = 1; k < 12; k++)
            {
                if (i == 1 && j == 2)
                {
                    ;
                }
                else if (i == 0 && j != 3)
                {
                    j++;
                }

                else if (i == 1 && j != 3)
                {
                    j++;
                }
                else if (j == 0)
                {
                    i--;
                }
                else if (i == 2)
                {
                    j--;
                }
                else if (j == 3)
                {
                    i++;
                }

                m[i, j] = int.Parse(s[k]);
            }
        }
        static void change(int[,]m)//c - поменять местами элементы главной и побочной диагонали
        {
            int k;
            int a = m.GetLength(0);
            for (int i = 0; i < a; i++)
            {
                k = m[i, i];
                m[i, i] = m[i, a - 1 - i];
                m[i, a - 1 - i] = k;
            }
        }
        static void snow(string[,] m)
        {
            int x;
            int y;
            for (int i = 0; i < m.Length; i++)
            {
                x = i / m.GetLength(0);
                y = i % m.GetLength(0);
                if ( x == y || x == m.GetLength(0) - 1 - y || x == m.GetLength(0) / 2 || y == m.GetLength(0) / 2)
                {
                    m[x,y] = "*";
                }
                else{
                    m[x,y] = " ";
                }
            }
        }
        static void chess(string[,] m)
        {
            int x;
            int y;
            for (int i = 0; i < m.Length; i++)
            {
                x = i / m.GetLength(0);
                y = i % m.GetLength(0);
                if ( (x + y)% 2 == 0)
                {
                    m[x,y] = "*";
                }
                else{
                    m[x,y] = " ";
                }
            }
        }
        static void Main(string[] args)
        {
            string[] arrs = Console.ReadLine().Split(new char[] {' '});
            int[,] mass = new int[3, 4];
            vvod(mass, arrs);
            vuvod(mass);
            int[,] mass2 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            change(mass2);
            vuvod(mass2);
            int t = int.Parse(Console.ReadLine());
            string[,] mass4 = new string[t, t];
            chess(mass4);
            vuvods(mass4);
            int n = int.Parse(Console.ReadLine());
            string[,] mass3 = new string[n, n];
            snow(mass3);
            vuvods(mass3);
            Console.ReadKey();
            
        }
    }
}
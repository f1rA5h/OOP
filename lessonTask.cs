using System;

namespace task
{
    class Program
    {
        static void MakeArray(int[][] array)
        {
            for(int i = 0; i < array.Length; i++)
            {
                array[i] = new int[(i + 1) * 2];
                for(int j = 0; j < array[i].Length; j++)
                {
                    array[i][j] = i + j;
                }
            }
        }
        
        static void OutputArray(int[][] array)
        {
            foreach (int[] tmpArr in array)
            {
                foreach (int x in tmpArr)
                    Console.Write($"{x} ");
                Console.WriteLine();
            }
        }
        
        static void Main()
        {
            Console.WriteLine("Введите кол-во массивов в массиве");
            int[][] array = new int[int.Parse(Console.ReadLine())][];

            MakeArray(array);
            OutputArray(array);
        }
    }
}
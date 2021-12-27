using System;

namespace practice7
{
    static class Program
    {
    static void GetSecondMax(ref int[] array)
    {
        int j;
        int[] array2 = new int[array.Length];

        for (int i = 0; i < array.Length; i++)
        {
            j = (array.Length - 1) - i;
            array2[i] = array[j];
        }
        array = array2;
    }

       static void InputArray(int len, ref int[] array)
    {
        for(int i = 0; i < len; i++)
        {
            array[i] = Convert.ToInt32(Console.ReadLine());
        }
    }

    static void OutputArray(int[] array)
    {
        foreach(int i in array)
        {
            Console.Write("{0} ", i);
        }
        Console.WriteLine();
    }
        static void Main()
        {
            int len = Convert.ToInt32(Console.ReadLine());
        int[] array = new int[len];

        InputArray(len, ref array);

        GetSecondMax(ref array);

        OutputArray(array);
        }
    }
}
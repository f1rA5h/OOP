using System;


namespace Practice_6
{
  static class Program
  {
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

    static void ReplaceMin(ref int[] array)
    {
        int minimum = 0;
        int sum = 0;
        for(int i = 0; i < array.Length; i++)
        {
            if(array[i] < 0)
            {
                sum += array[i];
                if(i > minimum)
                {
                    minimum = i;
                }
            }
        }
        array[minimum] = sum;
    }

    static void ReplaceMax(ref int[] array)
    {
        int maximum = 0;
        int sum = 0;
        for(int i = 0; i < array.Length; i++)
        {
            if(array[i] < 0)
            {
                sum += array[i];
                if(i < maximum)
                {
                    maximum = i;
                }
            }
        }
        array[minimum] = sum;
    }

    static int Difference(int[] array, int k)
    {
        int count = 0;
        for(int i = 0; i < array.Length - 1; i++)
        {
            if(Math.Abs(array[i] - array[i + 1]) == k)
            {
                count++;
            }
        }
        return count;
    }
    static void Main()
    {
        int len = Convert.ToInt32(Console.ReadLine());
        int[] array = new int[len];

        InputArray(len, ref array);
        OutputArray(array);

        ReplaceMin(ref array);
        OutputArray(array);
        
        ReplaceMax(ref array);
        OutputArray(array);

        int k = Convert.ToInt32(Console.ReadLine());
        int res = Difference(array, k);
        Console.WriteLine(res);
    }
  }
}

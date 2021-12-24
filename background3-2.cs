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

    static void ReplaceMin(int[] array)
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
        if(sum == 0) Console.WriteLine("нет");
        else array[minimum] = sum;
    }

    static void ReplaceMax(int[] array)
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
        if (sum == 0) Console.WriteLine("нет");
        else array[maximum] = sum;
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

    static int MinDelCount(int[] array)
    {
        int count = 0;
        for(int i = 1; i <= array.Length - 2; i++)
        {
            if(i != -1)
            {
                if(!(array[i] > array[i + 1] && array[i] > array[i - 1]))
                {
                    if(!(array[i] < array[i + 1] && array[i] < array[i - 1]))
                    {
                        count++;
                    }
                }
            }
        }
        return count;
    }
    
    static void Main()
    {
        int len = Convert.ToInt32(Console.ReadLine());
        int[] array = new int[len];

        InputArray(len, ref array);
        // OutputArray(array);

        // ReplaceMin(array);
        // OutputArray(array);

        // ReplaceMax(array);
        // OutputArray(array);

        // int k = Convert.ToInt32(Console.ReadLine());
        // int res = Difference(array, k);
        // Console.WriteLine(res);
        int res = MinDelCount(array);
        Console.WriteLine(res);
    }
  }
}

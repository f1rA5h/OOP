using System;


namespace Practice_6
{
    static class Program 
    {
        static void OutputArray(int[,] array)
        {
            for(int i = 0; i < array.GetLength(0); i++)
            {
                for(int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write($"{array[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        static void InputArray(int[,] array)
        {                           //      0     
            byte side = 0;           //    3   1
                                    //      2
            
            int rightBorder = array.GetLength(0) - 1;
            int leftBorder = 0;

            int bottomBorder = array.GetLength(1) - 1;
            int topBorder = 0;

            int xCoord = 0;
            int yCoord = 0;

            int i = 2;
            int j = 1;
            array[0, 0] = 1;
            while(i <= array.Length + 1)
            {
                if(side == 0)
                {
                    while(xCoord < rightBorder)
                    {
                        j++;
                        xCoord += 1;
                        array[xCoord, yCoord] = j;
                    }
                    Console.WriteLine("3");
                    side = 1;
                    topBorder += 1;
                } else
                if(side == 1)
                {
                    while(yCoord < bottomBorder)
                    {                                        
                        j++;
                        yCoord += 1;
                        array[xCoord, yCoord] = j;
                    }
                    side = 2;
                    rightBorder -= 1;
                } else
                if(side == 2)
                {
                    while(xCoord > leftBorder)
                    {                                     
                        j++;
                        xCoord -= 1;
                        array[xCoord, yCoord] = j;
                    }
                    side = 3;
                    bottomBorder -= 1;
                } else
                if(side == 3)
                {
                    while(yCoord > topBorder)
                    {                                       
                        j++;
                        yCoord -= 1;
                        array[xCoord, yCoord] = j;
                    }
                    side = 0;
                    leftBorder += 1;
                }
                
                i++;
            }
        }   

        static void SwitchD(int[,] array)
        {
            int n = array.GetLength(0);
            int[] d1 = new int[n];
            int[] d2 = new int[n];

            for(int i = 0; i < n; i++)
            {
                d1[i] = array[i, i];
            }
            for(int i = 0; i < n; i++)
            {
                d2[i] = array[i, (n - 1) - i];
            }

            for(int i = 0; i < n; i++)
            {
                array[i, i] = d2[i];
            }
            for(int i = 0; i < n; i++)
            {
                array[i, (n - 1) - i] = d1[i];
            }
        }

        static void Main()
        {
            int len0 = Convert.ToInt32(Console.ReadLine());
            int len1 = Convert.ToInt32(Console.ReadLine());
            int[,] array = new int[len0, len1];

            InputArray(array);
            OutputArray(array);

            SwitchD(array);
            OutputArray(array);
        }
    }
}

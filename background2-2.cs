using System;

namespace background2_2
{
    static class Program
    {
        static void PutNum(ulong num, ref ulong memory)
        {
            bool isPlaceFound = false;
            ulong mask = 0xF;
            for(int i = 0; i < 16; i++)
            {
                if ((memory & mask) == 0)
                {
                    isPlaceFound = true;
                    memory |= (num << (i * 4));
                    ShowCell(i, memory);
                    break;
                }
                else
                {
                    mask <<= 4;
                }
            }
            if(!isPlaceFound)
            {
                Console.WriteLine("Не нашлось места для числа");
            }
        }

        static void ReadNum(int index, ulong memory)
        {
            ulong mask = 0xF;
            ShowCell(index, memory);
            memory >>= index * 4;
            memory &= mask;
            
            Console.WriteLine(memory);
        }

        static void ClearCell(int index, ref ulong memory)
        {
            ulong mask = 0xF;
            memory &= ~(mask << (index * 4));
            ShowCell(index, memory);
        }
        static void ShowCell(int index, ulong memory){
            ulong mask = 0x8000000000000000;

            for (int i = 64; i > 0; i--)
            {
                if((i - 1)/ 4 == index)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                if((mask & memory) == 0) Console.Write(0);
                else Console.Write(1);
                if ((i - 1) % 4 == 0 && i != 0) 
                {
                    Console.Write(" ");
                }

                mask >>= 1;
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void ChooseAction(ref bool cont, ref ulong memory)
        {
            Console.WriteLine("Введите (1), чтобы занести число\nВведите (2), чтобы прочесть ячейку\nВведите (3), чтобы очистить ячейку\nВведите (4), чтобы остановить");
            
            // тут мог бы быть прекрасный try-catch
            int option = int.Parse(Console.ReadLine());
            ulong number;
            int index;

            switch (option)
            {
                case 1:
                    Console.Write("Введите число:\t");
                    number = ulong.Parse(Console.ReadLine());
                    if(isNumberValid(number))
                    {
                        PutNum(number, ref memory);
                    }
                    break;
                case 2:
                    Console.WriteLine("Введите индекс:\t");
                    index = int.Parse(Console.ReadLine());
                    if(isIndexValid(index))
                    {
                        ReadNum(index, memory);
                    }
                    break;
                case 3:
                    Console.WriteLine("Введите индекс:\t");
                    index = int.Parse(Console.ReadLine());
                    if(isIndexValid(index))
                    {
                        ClearCell(index, ref memory);
                    }
                    break;
                case 4:
                    cont = false;
                    break;
                default:
                    Console.WriteLine("Введите число из списка");
                    break;
            }
        }
        
        static bool isIndexValid(int index)
        {
            if(index <= 16)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Индекс недействителен");
                return false;
            }
        }
        static bool isNumberValid(ulong index)
        {
            if(index <= 15)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Число слишком большое");
                return false;
            }
        }

        static void Main(string[] args)
        {
            ulong memory = 0;

            bool cont = true;
            while (cont)
            {
                ChooseAction(ref cont, ref memory);
            }
        }
    }
}
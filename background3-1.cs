using System;

namespace practice7
{
    static class Program
    {
        static void Plus(string s1, string s2)
        {
            int difference = s1.Length - s2.Length;

            if(difference >= 0) 
            {
                for (int i = 0; i < difference - 1; i++)
                {
                    Console.Write(s1[i]);
                }
                
                if(Char.GetNumericValue(s1[difference]) + Char.GetNumericValue(s2[0]) >= 10){
                    Console.Write(Char.GetNumericValue(s1[difference - 1]) + 1);}
                else {Console.Write(s1[difference - 1]);}
                
                int addiction = 1;
                while(addiction + difference != s1.Length)
                {
                    if(Char.GetNumericValue(s1[difference + addiction]) + Char.GetNumericValue(s2[addiction]) >= 10){
                    Console.Write(Char.GetNumericValue(s1[difference + addiction - 1]) + Char.GetNumericValue(s2[addiction]) + 1);}
                    else {Console.Write(s1[difference + addiction - 1]);}
                    addiction++;
                }

                Console.Write(Char.GetNumericValue(s1[s1.Length - 1]) + Char.GetNumericValue(s2[s2.Length - 1]));
            }

            // while(s2.Length > 0 && s1.Length > 0)
            // {

            // }
            
        }

        static void Minus(string s1, string s2){}
        static void Main()
        {
            string s1 = Console.ReadLine();   
            string s2 = Console.ReadLine();
            string operation = Console.ReadLine();


            if(operation == "+")
            
                Plus(s1, s2);
            else if (operation == "-")
            
                 Minus(s1, s2);
            
            else Console.WriteLine("ошибка");
        }
    }
}
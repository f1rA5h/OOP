using System;

namespace practice7
{
    static class Program
    {
        static string BeforeC(string s)
        {
            int cIndex = s.IndexOf(":");
            if(cIndex != -1)
            {
                return s.Substring(0, cIndex);
            }
            return "Нет двоеточия";
        }

        static string More(string s, string symb1, string symb2)
        {
            int index1 = s.IndexOf(symb1);
            int index2 = s.IndexOf(symb2);
            while (!(index1 == -1 || index2 == -1))
            {
                s = s.Remove(index1, 1);
                
                index2 = s.IndexOf(symb2);

                s= s.Remove(index2, 1);

                index1 = s.IndexOf(symb1);
                index2 = s.IndexOf(symb2);

            }

            if (index1 != -1) return symb1;
            if (index2 != -1) return symb2;

            return "Одинаково";
        }
        static void Main()
        {
            string s = Console.ReadLine();

            string symb1 = Console.ReadLine();
            string symb2 = Console.ReadLine();

            string res1 = BeforeC(s);
            string res2 = More(s, symb1, symb2);

            Console.WriteLine(res1);
            Console.WriteLine(res2);
        }
    }
}
using System;

namespace practice7
{
    static class Program
    {
        static string Plus(string s1, string s2)
        {
            int difference = s1.Length - s2.Length;
            int c = 0;
            int saved = 0;
            string result = "";
            int sum;
            int current1, current2;

            while(c != s1.Length && c != s2.Length)
            {
                c++;
                current1 = Convert.ToInt32(Char.GetNumericValue(s1[s1.Length - c]));
                current2 = Convert.ToInt32(Char.GetNumericValue(s2[s2.Length - c]));

                sum = current1 + current2 + saved;
                if(sum >= 10)
                    saved = 1;
                else
                    saved = 0;
                result = sum % 10 + result;

            }

            if(difference > 0)
            {
                while(c != s1.Length)
                {
                    c++;
                    current1 = Convert.ToInt32(Char.GetNumericValue(s1[s1.Length - c]));
                    sum = current1 + saved;
                    if(sum >= 10)
                        saved = 1;
                    else
                        saved = 0;
                    result = sum % 10 + result;
                }
                if(saved == 1)
                {
                    result = "1" + result;
                }
            }
            else if(difference == 0)
            {
                if(saved == 1)
                {
                    result = "1" + result;
                }
            }
            else
            {   
                while(c != s2.Length)
                {
                    c++;
                    current2 = Convert.ToInt32(Char.GetNumericValue(s2[s2.Length - c]));
                    result = (current2 + saved) + result;
                }
            }

            return result;
        }

        static string Minus(string s1, string s2)
        {
            int difference = s1.Length - s2.Length;
            int c = 0;
            int saved = 0;
            string result = "";
            int sum;
            int current1, current2;
            bool resDig = false;
            bool same = false;
            int zeroMark = 0;

            if(s1.Length > s2.Length)
            {
                resDig = false;
            }
            else if(s1.Length < s2.Length)
            {
                resDig = true;
            }
            else
            {
                int i = 0;
                while(true)
                {
                    current1 = Convert.ToInt32(Char.GetNumericValue(s1[i]));
                    current2 = Convert.ToInt32(Char.GetNumericValue(s2[i]));
                    if(current1 > current2)
                    {
                        resDig = false;
                        break;
                    }
                    else if(current1 < current2)
                    {
                        resDig = true;
                        break;
                    }
                    if(i == s1.Length - 1)
                    {
                        same = true;
                        break;
                    }

                    i++;
                }
            }

            if(resDig)
            {
                string s3 = s2;
                s2 = s1;
                s1 = s3;
            }

            while(c != s1.Length && c != s2.Length)
            {
                c++;
                current1 = Convert.ToInt32(Char.GetNumericValue(s1[s1.Length - c]));
                current2 = Convert.ToInt32(Char.GetNumericValue(s2[s2.Length - c]));

                sum = current1 - current2 - saved;
                if(sum < 0)
                {

                    result = (10 + sum - saved) + result;
                    saved = 1;
                }
                else
                {
                    saved = 0;
                    result = (sum - saved) + result;
                }
            }

            if(difference > 0)
            {
                while(c != s1.Length)
                {
                    c++;
                    current1 = Convert.ToInt32(Char.GetNumericValue(s1[s1.Length - c]));
                    // result = (current2 - saved) + result;
                    sum = current1 - saved;
                    if(sum < 0)
                    {
                        if(current1 == 0)
                        {
                            zeroMark = 1;
                        }
                        else
                        {
                            zeroMark = 0;
                        }
                        result = (10 + sum - saved + zeroMark) + result;
                        saved = 1;
                    }
                    else
                    {
                        saved = 0;
                        result = (sum - saved) + result;
                    }
                }
            }
            else if(difference == 0)
            {
                result = "" + result;
            }
            else
            {   
                while(c != s2.Length)
                {
                    c++;
                    current2 = Convert.ToInt32(Char.GetNumericValue(s2[s2.Length - c]));
                    // result = (current2 - saved) + result;
                    sum = current2 - saved;
                    if(sum < 0)
                    {
                        result = (10 + sum - saved) + result;
                        saved = 1;
                    }
                    else
                    {
                        saved = 0;
                        result = (sum - saved) + result;
                    }
                }
            }
            if(same)
            {
                return "0";
            }
            else
            {
                if(resDig)
                {
                    return "-" + result;
                }
            }
            return result;
        }
        static void Main()
        {
            string s1 = Console.ReadLine();   
            string s2 = Console.ReadLine();
            string operation = Console.ReadLine();

            string res;

            if(operation == "+"){
            
                res = Plus(s1, s2);Console.WriteLine(res);}
            else if (operation == "-"){
            
                res = Minus(s1, s2);Console.WriteLine(res);
            }
            else Console.WriteLine("ошибка");
        }
    }
}
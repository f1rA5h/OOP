using System;

namespace test
{
    static class Program
    {
static int ToSystem(int x, int num)
{
    if(num % x == 0) return num;
    else return num / (num % x);
}
static void Main(string[] args)
{
    int x = int.Parse(Console.ReadLine());
    int num = int.Parse(Console.ReadLine());
    int res = ToSystem(x, num);
    Console.WriteLine(res);
}
    }
}

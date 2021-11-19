using System;


namespace Practice_6{
  static class Program{
    static int Task1()
    {
        int x = Convert.ToInt32(Console.ReadLine());
        int n = Convert.ToInt32(Console.ReadLine());

        x >>= n;

        int mask = 0x00000001;


        return x & mask;
    }

    static void Task2()
    {
      int x = Convert.ToInt32(Console.ReadLine());
      int tmp = x;
      int mask = 1;
      for(int i = 31; i >= 0; i--)
      {
        tmp >>= i;
        Console.Write(tmp & mask);
        tmp = x;
      }
    }

    static void Main(string[] args)
    {
      int res2 = Task1();
      Console.WriteLine(res2);

      Task2();
    }
  }
}

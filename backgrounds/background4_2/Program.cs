using System;
using System.IO;

namespace background4_2
{
    internal class Program
    {
        struct Lesson
        {
            public int classroom;
            public string teacher;
            public string group;
            public string subject;
            public int number;
        }
        private static string ToFixedSize(int length, string source)
        {
            return source.PadRight(length).Substring(0, length);
        }
        private static void Check(Lesson[,] timeTable)
        {
            bool isCucsess = false;

            for (int i = 0; i < timeTable.GetLength(0); i++)
            {
                for (int j = 0; j < timeTable.GetLength(1); j++)
                {
                    for (int j2 = 0; j2 < timeTable.GetLength(1) / 2; j2++)
                    {
                        if (timeTable[i, j].number != 0 && timeTable[i, j2].number != 0)
                        {
                            if (j2 != j)
                            {
                                if (timeTable[i, j].classroom == timeTable[i, j2].classroom)
                                {
                                    Console.WriteLine(
                                        $"Обнаружена ошибка в рассписании: {timeTable[i, j].classroom} " +
                                        $"занят двумя группами на {timeTable[i, j].number} уроке");
                                }

                                if (timeTable[i, j].teacher == timeTable[i, j2].teacher)
                                {
                                    Console.WriteLine(
                                        $"Обнаружена ошибка в рассписании: {timeTable[i, j].teacher}" +
                                        $" учит у двух груп на {timeTable[i, j].number} уроке");
                                }
                            }
                        }
                    }
                }
            }
        }
        private static void Output(Lesson[,] timeTable)
        {
            int len = 20;
            int maxi = timeTable.GetLength(0);
            int maxj = timeTable.GetLength(1);

            string[,] preOutput = new string[maxi + 1, 3 * maxj + 1];

            preOutput[0, 0] = "";
            for (int i = 1; i < maxi + 1; i++)
            {
                preOutput[i, 0] = (i + 1).ToString();
                for (int j = 1; j < maxj + 1; j++)
                {
                    if (timeTable[i - 1, j - 1].number != 0)
                    {
                        // preOutput[i - 1, 0] = "";
                        preOutput[i, 0] = timeTable[i - 1, j - 1].group;
                        // preOutput[i, 0] = "";
                        
                        preOutput[0, (j - 1) * 3 + 1] = "";
                        preOutput[0, (j - 1) * 3 + 2] = (j).ToString();
                        preOutput[0, (j - 1) * 3 + 3] = "";
                        
                        preOutput[i, (j - 1) * 3 + 1] = timeTable[i - 1, j - 1].classroom.ToString();
                        preOutput[i, (j - 1) * 3 + 2] = timeTable[i - 1, j - 1].subject;
                        preOutput[i, (j - 1) * 3 + 3] = timeTable[i - 1, j - 1].teacher;
                    }
                    else
                    {
                        preOutput[i, (j - 1) * 3 + 1] = "";
                        preOutput[i, (j - 1) * 3 + 2] = ""; 
                        preOutput[i, (j - 1) * 3 + 3] = "";
                    }
                }
            }

            for (int j = 0; j < maxj * 3 + 1; j++)
            {            
                for (int i = 0; i < maxi + 1; i++)
                {
                    Console.Write(ToFixedSize(len, preOutput[i, j]));
                }
                Console.WriteLine();
            }
        }
        private static int GetMaxIndex(StreamReader file)
        {
            int max = 0;
            int index;
            file.BaseStream.Position = 0;

            int groupsCount = int.Parse(file.ReadLine());
            
            for (int i = 0; i < groupsCount; i++)
            {
                string group = file.ReadLine();
                int lessonsCount = int.Parse(file.ReadLine());
                for (int j = 0; j < lessonsCount; j++)
                {
                    index = int.Parse(file.ReadLine());
                    file.ReadLine();
                    file.ReadLine();
                    file.ReadLine();

                    if (index > max)
                    {
                        max = index;
                    }
                }
            }
            
            file.BaseStream.Position = 0;
            return max;
        }
        private static Lesson[,] InputFromFile(string filePath)
        {
            Lesson[,] timeTable;
            StreamReader file = new StreamReader(filePath);
            
            int maxLesson = GetMaxIndex(file);
            
            int groupsCount = int.Parse(file.ReadLine());
            
            timeTable = new Lesson[groupsCount, maxLesson];
            string group;
            int lessonsCount;
            int index;
            
            for (int i = 0; i < groupsCount; i++)
            {
                group = file.ReadLine();
                lessonsCount = int.Parse(file.ReadLine());
                for (int j = 0; j < lessonsCount; j++)
                {
                    index = int.Parse(file.ReadLine()) - 1;
                    if (timeTable[i, index].number != 0)
                    {
                        Console.WriteLine("В рассписании была обнаружена ошибочная запись. Она была проигнорирована");
                    }
                    else
                    {
                        timeTable[i, index].number = index + 1;                   
                        timeTable[i, index].group = group;
                        timeTable[i, index].teacher = file.ReadLine();
                        timeTable[i, index].subject = file.ReadLine();
                        timeTable[i, index].classroom = int.Parse(file.ReadLine());
                    }
                }
            }
            file.Close();
            Check(timeTable);
            return timeTable;
        }
        
        public static void Main(string[] args)
        {
            const string path = "input.txt";
            
            Lesson[,] timeTable = InputFromFile(path);
            Output(timeTable);
        }
    }
}
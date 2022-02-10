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
            public Subjects subject;
            public int number;
        }
        enum Subjects { Алгебра, ООП, ТОИ, Геометрия, Русский, Химия, Физкультура }
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
                        preOutput[i, (j - 1) * 3 + 2] = timeTable[i - 1, j - 1].subject.ToString();
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
                        Enum.TryParse(file.ReadLine(), out Subjects result);
                        timeTable[i, index].subject = result;
                        timeTable[i, index].classroom = int.Parse(file.ReadLine());
                    }
                }
            }

            file.Close();
            Check(timeTable);
            return timeTable;
        }
        private static void OutputByGroup(Lesson[,] timeTable)
        {
            Console.Write("Введите группу, для которой требуется вывести рассписание: ");
            string group = Console.ReadLine();
            int groupIndex = -1;
            bool isFound = false;
            int len = 20;
            int maxj = timeTable.GetLength(1);
            string[] preOutput = new string[3 * maxj + 1];

            for (int i = 0; i < timeTable.GetLength(0); i++)
            {
                for (int k = 0; k < timeTable.GetLength((1)); k++)
                {
                    if (timeTable[i, k].group == group)
                    {
                        isFound = true;
                    
                        for (int j = 1; j < maxj + 1; j++)
                        {
                            if (timeTable[i, j - 1].number != 0)
                            {
                                // preOutput[i - 1, 0] = "";
                                preOutput[0] = timeTable[i, j - 1].group;
                                // preOutput[i, 0] = "";
                        
                                preOutput[(j - 1) * 3 + 1] = "";
                                preOutput[(j - 1) * 3 + 2] = (j).ToString();
                                preOutput[(j - 1) * 3 + 3] = "";
                        
                                preOutput[(j - 1) * 3 + 1] = timeTable[i , j - 1].classroom.ToString();
                                preOutput[(j - 1) * 3 + 2] = timeTable[i , j - 1].subject.ToString();
                                preOutput[(j - 1) * 3 + 3] = timeTable[i, j - 1].teacher;
                            }
                            else
                            {
                                preOutput[(j - 1) * 3 + 1] = "";
                                preOutput[(j - 1) * 3 + 2] = ""; 
                                preOutput[(j - 1) * 3 + 3] = "";
                            }
                        }
                        break;
                    }
                }
            }

            if (isFound)
            {
                for (int j = 0; j < preOutput.Length; j++)
                {
                    Console.WriteLine(preOutput[j]);
                }
            }
        }

        private static void FillSpaces(Lesson[,] timeTable, string filePath)
        {
            Console.Write("Введите группу, которую хотите проверить на пропуски в рассписании: ");
            string group = Console.ReadLine();
            StreamReader file = new StreamReader(filePath);

            int[] allClassrooms = Array.ConvertAll(file.ReadLine().Split(','), int.Parse);
            string[] allTeachers = file.ReadLine().Split(',');
            file.Close();
            
            int[] tmpClassrooms = new int[allClassrooms.Length];
            string[] tmpTeachers = new string[allTeachers.Length];
            
            int groupIndex = -1;
            int tmp;
            bool marker;
            
            for (int i = 0; i < timeTable.GetLength(0); i++)
            {
                for (int j = 0; j < timeTable.GetLength(1); j++)
                {
                    if (timeTable[i, j].group == group)
                    {
                        groupIndex = i;
                        break;
                    }
                }
            }

            for (int i = 0; i < timeTable.GetLength(1); i++)
            {
                for (int k = 0; k < tmpClassrooms.Length; k++)
                {
                    tmpClassrooms[k] = -1;
                }
                for (int k2 = 0; k2 < tmpTeachers.Length; k2++)
                {
                    tmpTeachers[k2] = "";
                }
                
                if (timeTable[groupIndex, i].number == 0)
                {
                    for (int j = 0; j < timeTable.GetLength(0); j++)
                    {
                        if (j != groupIndex)
                        {
                            if (timeTable[j, i].number != 0)
                            {
                                tmpClassrooms[j] = timeTable[j, i].classroom;
                                tmpTeachers[j] = timeTable[j, i].teacher;
                            }
                        }
                    }
                }

                marker = false;
                for (int m = 0; m < tmpTeachers.Length; m++)
                {
                    if (tmpTeachers[m] != "")
                    {
                        marker = true;
                        break;
                    }
                }

                if (marker)
                {
                    Console.WriteLine($"Пробел на {i + 1} уроке может быть заполнен следующими учителями:");
                    for (int q = 0; q < allTeachers.Length; q++)
                    {
                        tmp = 0;
                        for (int q2 = 0; q2 < allTeachers.Length; q2++)
                        {
                            if (allTeachers[q] == tmpTeachers[q2])
                            {
                                tmp = 1;
                            }
                        }

                        if (tmp == 0)
                        {
                            Console.Write($"{allTeachers[q]}, ");
                        }
                    }

                    Console.WriteLine();
                    
                    Console.WriteLine($"Урок на {i + 1} уроке может быть проведен в следующих кабинетах:");
                    for (int q = 0; q < allClassrooms.Length; q++)
                    {
                        tmp = 0;
                        for (int q2 = 0; q2 < allClassrooms.Length; q2++)
                        {
                            if (allClassrooms[q] == tmpClassrooms[q2])
                            {
                                tmp = 1;
                            }
                        }

                        if (tmp == 0)
                        {
                            Console.Write($"{allClassrooms[q]}, ");
                        }
                    }

                    Console.WriteLine("\n");
                }
            }
        }
        public static void Main(string[] args)
        {
            const string path = "input.txt";
            
            Lesson[,] timeTable = InputFromFile(path);
            Output(timeTable);
            FillSpaces(timeTable, "inputAll.txt");
            OutputByGroup(timeTable);
        }
    }
}
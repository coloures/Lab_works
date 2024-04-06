using static System.Net.Mime.MediaTypeNames;

namespace Diskretka_RGR
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string source = @"E:\Projects_VS\Ford_Bellman_alg\Diskretka_RGR\Дискретка РГР.txt";
            StreamReader sr = new StreamReader(source);
            int a = Convert.ToInt32(sr.ReadLine());
            double[,] table = new double[a,a];
            double[,] table_temp= new double[a,a]; // матрица возможных путей (однопалочных)
            for (int i = 0; i <= table.GetUpperBound(0); i++) 
            {
                for (int j = 0; j <= table.GetUpperBound(1); j++) 
                {
                    table[i, j] = double.PositiveInfinity;
                    table_temp[i,j] = double.PositiveInfinity;
                }
            }
            int ways = Convert.ToInt32(sr.ReadLine());
            //Console.WriteLine(ways);
            for(int i =0; i < ways; i++) 
            {
                string str = sr.ReadLine();
                //Console.WriteLine(str);
                table[Convert.ToInt32(str.Split(" ")[0])-1, Convert.ToInt32(str.Split(" ")[1])-1] = Convert.ToInt32(str.Split(" ")[2]);
                table_temp[Convert.ToInt32(str.Split(" ")[0]) - 1, Convert.ToInt32(str.Split(" ")[1]) - 1] = Convert.ToInt32(str.Split(" ")[2]);
                //table[Convert.ToInt32(str.Split(" ")[1]) - 1, Convert.ToInt32(str.Split(" ")[0]) - 1] = Convert.ToInt32(str.Split(" ")[2]);
                // Нижний для неориентированного графа!!!
            }
            for (int i = 0; i < a; i++) 
            {
                table[i, i] = 0;
            }
            sr.Close();
            for (int s = 0; s < a; s++) 
            {
                for (int i = 0; i <= table.GetUpperBound(0); i++)
                {
                    for (int j = 0; j <= table.GetUpperBound(1); j++)
                    {
                        table[i, j] = table[i, j] > table[i, s] + table[s, j] ? table[i, s] + table[s, j] : table[i, j];
                    }
                }
            }
            for (int i = 0; i <= table.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= table.GetUpperBound(1); j++)
                {
                    if (table[i, j] == double.PositiveInfinity) 
                    {
                        table[i, j] = -1;
                    }
                }
            }
            int ct;
            int cf;
            List<double> way = new List<double>();
            string[] menuItems = new string[] {"Вычисления", "Об авторе программы",
                "Описание постановки задачи", "Выход" };
            int row = Console.CursorTop+2;
            int col = Console.CursorLeft;
            int index = 0;
            bool cond = true;
            while (cond) 
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Меню");
                Console.ResetColor();
                Console.WriteLine();
                DrawMenu(menuItems, row, col,index);
                switch(Console.ReadKey(true).Key) 
                {
                    case ConsoleKey.DownArrow:
                        if (index < menuItems.Length - 1)
                            index++;
                        break;
                    case ConsoleKey.UpArrow:
                        if (index > 0)
                            index--;
                        break;
                    case ConsoleKey.Enter:
                        switch (index)
                        {
                            case 3:
                                Console.Clear();
                                int len = "Выбран выход из приложения".Length;
                                Console.SetCursorPosition((Console.WindowWidth / 2) - (len / 2), 0);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Выбран выход из приложения");
                                Console.ResetColor();
                                cond = false;
                                return;
                            default:
                                switch (index)
                                {
                                    case 2:
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        len = $"Выбран пункт {menuItems[index]}".Length;
                                        Console.SetCursorPosition((Console.WindowWidth / 2) - (len / 2), 0);
                                        Console.WriteLine($"Выбран пункт {menuItems[index]}");
                                        Console.ForegroundColor = ConsoleColor.Magenta;
                                        Console.SetCursorPosition((Console.WindowWidth / 2) - 3, 1);
                                        Console.WriteLine("ЗАДАЧА\r\n");
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\tПредположим, что вы хотите проехать из Новосибирска в Волгоград, " +
                                            "используя магистральные шоссейные дороги, соединяющие различные города.\r\n" +
                                            "В построенном " +
                                            "графе определить кратчайший путь между городами.\r\n");
                                        Console.ResetColor();
                                        Console.ReadKey();
                                        break;
                                    case 1: 
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        len = $"Выбран пункт {menuItems[index]}".Length;
                                        Console.SetCursorPosition((Console.WindowWidth / 2) - (len / 2), 0);
                                        Console.WriteLine($"Выбран пункт {menuItems[index]}");
                                        Console.ForegroundColor = ConsoleColor.Magenta;
                                        len = "АВТОР: Биндюк Глеб Игоревич, студент МО-231".Length;
                                        Console.SetCursorPosition((Console.WindowWidth / 2) - (len / 2), 0);
                                        Console.WriteLine("АВТОР: Биндюк Глеб Игоревич, студент МО-231");
                                        Console.ResetColor();
                                        Console.ReadKey(); 
                                        break;
                                    case 0:
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        len = $"Выбран пункт {menuItems[index]}".Length;
                                        Console.SetCursorPosition((Console.WindowWidth / 2) - (len / 2), 0);
                                        Console.WriteLine("\r");
                                        for (int i = 0; i <= table.GetUpperBound(0); i++)
                                        {
                                            if (i == 0)
                                            {
                                                Console.Write($"{"",10}");
                                                for (int m = 1; m <= a; m++)
                                                {
                                                    Console.Write($"{m,10}");
                                                }
                                                Console.WriteLine();
                                            }
                                            for (int j = 0; j <= table.GetUpperBound(1); j++)
                                            {
                                                if (j == 0)
                                                {
                                                    Console.Write($"{(i + 1),10}");
                                                }
                                                Console.Write($"{table[i, j],10}");
                                            }
                                            Console.WriteLine();
                                        }
                                        while (true)
                                        {
                                            try
                                            {
                                                Console.ForegroundColor = ConsoleColor.Magenta;
                                                Console.WriteLine("Введите город в который нужно попасть:");
                                                Console.ResetColor ();
                                                int city_to = Convert.ToInt32(Console.ReadLine());
                                                ct = city_to;
                                                Console.ForegroundColor = ConsoleColor.Magenta;
                                                Console.WriteLine("Введите город из какого идем:");
                                                Console.ResetColor();
                                                int city_from = Convert.ToInt32(Console.ReadLine());
                                                cf = city_from;
                                                double temp = table[city_from - 1, city_to - 1];
                                                if (temp == -1)
                                                {
                                                    throw new IndexOutOfRangeException();
                                                }
                                                way.Add(city_to);
                                                while (city_from != city_to)
                                                {
                                                    for (int i = 0; i <= table.GetUpperBound(1); i++)
                                                    {
                                                        if (table[city_from - 1, city_to - 1] - table_temp[i, city_to - 1] == table[city_from - 1, i])
                                                        {
                                                            city_to = i + 1;
                                                            way.Add(city_to);
                                                            break;
                                                        }
                                                    }
                                                }
                                                break;
                                            }
                                            catch (IndexOutOfRangeException)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Введите другие города, т.к. введенных вами городов (города) не существует или они являются недоступными!!!");
                                                Console.ResetColor();
                                            }
                                            catch (FormatException)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Таких городов нет!!!");
                                                Console.ResetColor();
                                            }
                                            catch (OverflowException) 
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Таких городов нет!!!");
                                                Console.ResetColor();
                                            }

                                        }
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        Console.WriteLine($"Путь из {cf} в {ct} города:");
                                        way.Reverse();
                                        foreach (double i in way)
                                        {
                                            Console.Write($"{i}\t");
                                        }
                                        Console.ResetColor();
                                        Console.WriteLine();
                                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                                        Console.WriteLine($"Вес пути: {table[cf - 1, ct - 1]}");
                                        Console.ResetColor();
                                        Console.ReadKey();
                                        break;
                                }
                                break;
                        }
                        break;
                }
            }
        }
        private static void DrawMenu(string[] items, int row, int col, int index)
        {
            Console.SetCursorPosition(col, row); // ставит курсор на позицию
            for (int i = 0; i < items.Length; i++)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.Yellow;
                if (i == index)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.WriteLine(items[i]);
                Console.ResetColor();
            }
            Console.WriteLine();
        }
    }
}

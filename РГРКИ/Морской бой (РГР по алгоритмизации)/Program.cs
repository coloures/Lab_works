using System.Runtime.CompilerServices;

namespace Sea_battle
{
    internal class Program
    {
        static void Main()
        {
            // Создание массива для вывода
            string[,] field = new string[10, 10];
            for (int i = 0; i < field.GetUpperBound(0)+1; i++) 
            {
                for (int j = 0; j < field.GetUpperBound(0) + 1; j++) 
                {
                    field[i, j] = "~";
                }
            }
            // Создание массива для взаимодействия
            int[,] in_field = new int[10, 10];
            var randomiser = new Random();
            // Расстановка 4 малых кораблей
            for (int i = 0; i < 4; i++) 
            {
                int x = randomiser.Next(10);
                int y = randomiser.Next(10);
                if (in_field[x, y] == 0)
                {
                    Around(x,y,x,y ,ref in_field);
                    in_field[x, y] = 1;
                }
                else 
                {
                    i--;
                }
            }
            // Расстановка 3 средних кораблей
            for (int i = 0; i < 3; i++) 
            {
                int cond = randomiser.Next(2);
                if (cond == 0) // горизонтальные корабли
                {
                    int x = randomiser.Next(10);
                    int y = randomiser.Next(10);
                    int x_end;
                    int y_end;
                    if (in_field[x, y] == 0)
                    {
                        // частный случай (x_1 == 0 => x_2 == 1)
                        if (x == 0)
                        {
                            x_end = 1;
                            y_end = y;
                            if (in_field[x_end, y_end] == 0)
                            {
                                Around(x, y, x_end, y_end, ref in_field);
                                in_field[x_end, y_end] = 1;
                                in_field[x, y] = 1;
                            }
                            else
                            {
                                i--;
                                continue;
                            }
                        }
                        // частный случай (x_1 == 9 => x_2 == 8)
                        else if (x == 9)
                        {
                            x_end = 8;
                            y_end = y;
                            if (in_field[x_end, y_end] == 0)
                            {
                                Around(x_end, y_end, x, y, ref in_field);
                                in_field[x_end, y_end] = 1;
                                in_field[x, y] = 1;
                            }
                            else
                            {
                                i--;
                                continue;
                            }
                        }
                        // другие случаи
                        else 
                        {
                            // "Да" -> корабль в левую сторону
                            if (randomiser.Next(2) == 0)
                            {
                                x_end = x - 1;
                                y_end = y;
                                if (in_field[x_end, y_end] == 0)
                                {
                                    Around(x_end, y_end, x, y, ref in_field);
                                    in_field[x_end, y_end] = 1;
                                    in_field[x, y] = 1;
                                }
                                else
                                {
                                    i--;
                                    continue;
                                }
                            }
                            // "Нет" -> корабль в правую сторону
                            else
                            {
                                x_end = x + 1;
                                y_end = y;
                                if (in_field[x_end, y_end] == 0)
                                {
                                    Around(x, y, x_end, y_end, ref in_field);
                                    in_field[x_end, y_end] = 1;
                                    in_field[x, y] = 1;
                                }
                                else
                                {
                                    i--;
                                    continue;
                                }
                            }
                        }
                    }
                    else 
                    {
                        i--;
                        continue;
                    }
                }
                if (cond == 1) // вертикальные корабли
                {
                    int x = randomiser.Next(10);
                    int y = randomiser.Next(10);
                    int x_end;
                    int y_end;
                    if (in_field[x, y] == 0)
                    {
                        // Частный случай (y_1 == 0 -> y_2 == 1)
                        if (y == 0)
                        {
                            x_end = x;
                            y_end = y + 1;
                            if (in_field[x_end, y_end] == 0)
                            {
                                Around(x, y, x_end, y_end, ref in_field);
                                in_field[x_end, y_end] = 1;
                                in_field[x, y] = 1;
                            }
                            else
                            {
                                i--;
                                continue;
                            }
                        }
                        // Частный случай (y_1 == 9 -> y_2 == 8)
                        else if (y == 9)
                        {
                            x_end = x;
                            y_end = y - 1;
                            if (in_field[x_end, y_end] == 0)
                            {
                                Around(x_end, y_end, x, y, ref in_field);
                                in_field[x_end, y_end] = 1;
                                in_field[x, y] = 1;
                            }
                            else
                            {
                                i--;
                                continue;
                            }
                        }
                        // Другие случаи
                        else 
                        {
                            // "Да" -> корабль вниз
                            if (randomiser.Next(2) == 0)
                            {
                                x_end = x;
                                y_end = y-1;
                                if (in_field[x_end, y_end] == 0)
                                {
                                    Around(x_end, y_end, x, y, ref in_field);
                                    in_field[x_end, y_end] = 1;
                                    in_field[x, y] = 1;
                                }
                                else
                                {
                                    i--;
                                    continue;
                                }
                            }
                            // "Нет" -> корабль вверх
                            else
                            {
                                x_end = x;
                                y_end = y+1;
                                if (in_field[x_end, y_end] == 0)
                                {
                                    Around(x, y, x_end, y_end, ref in_field);
                                    in_field[x_end, y_end] = 1;
                                    in_field[x, y] = 1;
                                }
                                else
                                {
                                    i--;
                                    continue;
                                }
                            }
                        }
                    }
                    else
                    {
                        i--;
                        continue;
                    }
                }
            }
            // Расстановка 2 больших кораблей
            for (int i = 0; i < 2; i++)
            {
                int cond = randomiser.Next(2);
                if (cond == 0) // горизонтальные корабли
                {
                    int x = randomiser.Next(10);
                    int y = randomiser.Next(10);
                    int x_end;
                    int y_end;
                    int x_mid;
                    int y_mid;
                    if (in_field[x, y] == 0)
                    {
                        // частный случай (x_1 == 0 => x_2 == 1, x_3 == 2)
                        if (x == 0)
                        {
                            x_mid = 1;
                            y_mid = y;
                            x_end = 2;
                            y_end = y;
                            if (in_field[x_end, y_end] == 0 && in_field[x_mid,y_mid] == 0)
                            {
                                Around(x, y, x_end, y_end, ref in_field);
                                in_field[x_end, y_end] = 1;
                                in_field[x_mid, y_mid] = 1;
                                in_field[x, y] = 1;
                            }
                            else
                            {
                                i--;
                                continue;
                            }
                        }
                        // частный случай (x_1 == 9 => x_2 == 8, x_3 == 7)
                        else if (x == 9)
                        {
                            x_end = 7;
                            y_end = y;
                            x_mid = 8;
                            y_mid = y;
                            if (in_field[x_end, y_end] == 0 && in_field[x_mid, y_mid] == 0)
                            {
                                Around(x_end, y_end, x, y, ref in_field);
                                in_field[x_end, y_end] = 1;
                                in_field[x_mid, y_mid] = 1;
                                in_field[x, y] = 1;
                            }
                            else
                            {
                                i--;
                                continue;
                            }
                        }
                        // другие случаи
                        else
                        {
                            // "Да" -> корабль в левую сторону
                            if (randomiser.Next(2) == 0)
                            {
                                x_end = x - 2;
                                y_end = y;
                                x_mid = x - 1; 
                                y_mid = y;
                                if (x_end > -1 && in_field[x_end, y_end] == 0 && in_field[x_mid, y_mid] == 0)
                                {
                                    Around(x_end, y_end, x, y, ref in_field);
                                    in_field[x_end, y_end] = 1;
                                    in_field[x_mid, y_mid] = 1;
                                    in_field[x, y] = 1;
                                }
                                else
                                {
                                    i--;
                                    continue;
                                }
                            }
                            // "Нет" -> корабль в правую сторону
                            else
                            {
                                x_end = x + 2;
                                y_end = y;
                                x_mid = x + 1; 
                                y_mid = y;
                                if (x_end < 10 && in_field[x_end, y_end] == 0 && in_field[x_mid, y_mid] == 0)
                                {
                                    Around(x, y, x_end, y_end, ref in_field);
                                    in_field[x_end, y_end] = 1;
                                    in_field[x_mid, y_mid] = 1;
                                    in_field[x, y] = 1;
                                }
                                else
                                {
                                    i--;
                                    continue;
                                }
                            }
                        }
                    }
                    else
                    {
                        i--;
                        continue;
                    }
                }
                if (cond == 1) // вертикальные корабли
                {
                    int x = randomiser.Next(10);
                    int y = randomiser.Next(10);
                    int x_end;
                    int y_end;
                    int x_mid;
                    int y_mid;
                    if (in_field[x, y] == 0)
                    {
                        // Частный случай (y_1 == 0 -> y_2 == 1, y_3 == 2)
                        if (y == 0)
                        {
                            x_end = x;
                            y_end = y + 2;
                            x_mid = x;
                            y_mid = y + 1;
                            if (in_field[x_end, y_end] == 0 && in_field[x_mid, y_mid] == 0)
                            {
                                Around(x, y, x_end, y_end, ref in_field);
                                in_field[x_end, y_end] = 1;
                                in_field[x_mid, y_mid] = 1;
                                in_field[x, y] = 1;
                            }
                            else
                            {
                                i--;
                                continue;
                            }
                        }
                        // Частный случай (y_1 == 9 -> y_2 == 8, y_3 == 7)
                        else if (y == 9)
                        {
                            x_end = x;
                            y_end = y - 2;
                            x_mid = x;
                            y_mid = y - 1;
                            if (in_field[x_end, y_end] == 0 && in_field[x_mid, y_mid] == 0)
                            {
                                Around(x_end, y_end, x, y, ref in_field);
                                in_field[x_end, y_end] = 1;
                                in_field[x_mid, y_mid] = 1;
                                in_field[x, y] = 1;
                            }
                            else
                            {
                                i--;
                                continue;
                            }
                        }
                        // Другие случаи
                        else
                        {
                            // "Да" -> корабль вниз
                            if (randomiser.Next(2) == 0)
                            {
                                x_end = x;
                                y_end = y - 2;
                                x_mid = x;
                                y_mid = y - 1;
                                if (y_end > -1 && in_field[x_end, y_end] == 0 && in_field[x_mid, y_mid] == 0)
                                {
                                    Around(x_end, y_end, x, y, ref in_field);
                                    in_field[x_end, y_end] = 1;
                                    in_field[x_mid, y_mid] = 1;
                                    in_field[x, y] = 1;
                                }
                                else
                                {
                                    i--;
                                    continue;
                                }
                            }
                            // "Нет" -> корабль вверх
                            else
                            {
                                x_end = x;
                                y_end = y + 2;
                                x_mid = x;
                                y_mid = y + 1;
                                if (y_end < 10 && in_field[x_end, y_end] == 0 && in_field[x_mid, y_mid] == 0)
                                {
                                    Around(x, y, x_end, y_end, ref in_field);
                                    in_field[x_end, y_end] = 1;
                                    in_field[x_mid, y_mid] = 1;
                                    in_field[x, y] = 1;
                                }
                                else
                                {
                                    i--;
                                    continue;
                                }
                            }
                        }
                    }
                    else
                    {
                        i--;
                        continue;
                    }
                }
            }
            // Расстановка 1 огромного корабля
            for (int i = 0; i < 1; i++)
            {
                int cond = randomiser.Next(2);
                if (cond == 0) // горизонтальные корабли
                {
                    int x = randomiser.Next(10);
                    int y = randomiser.Next(10);
                    int x_end;
                    int y_end;
                    int x_mid_1;
                    int y_mid_1;
                    int x_mid_2;
                    int y_mid_2;
                    if (in_field[x, y] == 0)
                    {
                        // частный случай (x_1 == 0 => x_2 == 1, x_3 == 2, x_4 == 3)
                        if (x == 0)
                        {
                            x_mid_1 = 1;
                            y_mid_1 = y;
                            x_mid_2 = 2;
                            y_mid_2 = y;
                            x_end = 3;
                            y_end = y;
                            if (in_field[x_end, y_end] == 0 && in_field[x_mid_1, y_mid_1] == 0 && in_field[x_mid_2, y_mid_2] == 0)
                            {
                                Around(x, y, x_end, y_end, ref in_field);
                                in_field[x_end, y_end] = 1;
                                in_field[x_mid_1, y_mid_1] = 1;
                                in_field[x_mid_2, y_mid_2] = 1;
                                in_field[x, y] = 1;
                            }
                            else
                            {
                                i--;
                                continue;
                            }
                        }
                        // частный случай (x_1 == 9 => x_2 == 8, x_3 == 7, x_4 == 6)
                        else if (x == 9)
                        {
                            x_end = 6;
                            y_end = y;
                            x_mid_1 = 8;
                            y_mid_1 = y;
                            x_mid_2 = 7;
                            y_mid_2 = y;
                            if (in_field[x_end, y_end] == 0 && in_field[x_mid_1, y_mid_1] == 0 && in_field[x_mid_2, y_mid_2] == 0)
                            {
                                Around(x_end, y_end, x, y, ref in_field);
                                in_field[x_end, y_end] = 1;
                                in_field[x_mid_1, y_mid_1] = 1;
                                in_field[x_mid_2, y_mid_2] = 1;
                                in_field[x, y] = 1;
                            }
                            else
                            {
                                i--;
                                continue;
                            }
                        }
                        // другие случаи
                        else
                        {
                            // "Да" -> корабль в левую сторону
                            if (randomiser.Next(2) == 0)
                            {
                                x_end = x - 3;
                                y_end = y;
                                x_mid_1 = x - 1;
                                y_mid_1 = y;
                                x_mid_2 = x - 2;
                                y_mid_2 = y;
                                if (x_end > -1 && in_field[x_end, y_end] == 0 && in_field[x_mid_1, y_mid_1] == 0 && in_field[x_mid_2, y_mid_2] == 0)
                                {
                                    Around(x_end, y_end, x, y, ref in_field);
                                    in_field[x_end, y_end] = 1;
                                    in_field[x_mid_1, y_mid_1] = 1;
                                    in_field[x_mid_2, y_mid_2] = 1;
                                    in_field[x, y] = 1;
                                }
                                else
                                {
                                    i--;
                                    continue;
                                }
                            }
                            // "Нет" -> корабль в правую сторону
                            else
                            {
                                x_end = x + 3;
                                y_end = y;
                                x_mid_1 = x + 1;
                                y_mid_1 = y;
                                x_mid_2 = x + 2;
                                y_mid_2 = y;
                                if (x_end < 10 && in_field[x_end, y_end] == 0 && in_field[x_mid_1, y_mid_1] == 0 && in_field[x_mid_2, y_mid_2] == 0)
                                {
                                    Around(x, y, x_end, y_end, ref in_field);
                                    in_field[x_end, y_end] = 1;
                                    in_field[x_mid_1, y_mid_1] = 1;
                                    in_field[x_mid_2, y_mid_2] = 1;
                                    in_field[x, y] = 1;
                                }
                                else
                                {
                                    i--;
                                    continue;
                                }
                            }
                        }
                    }
                    else
                    {
                        i--;
                        continue;
                    }
                }
                if (cond == 1) // вертикальные корабли
                {
                    int x = randomiser.Next(10);
                    int y = randomiser.Next(10);
                    int x_end;
                    int y_end;
                    int x_mid_1;
                    int y_mid_1;
                    int x_mid_2;
                    int y_mid_2;
                    if (in_field[x, y] == 0)
                    {
                        // Частный случай (y_1 == 0 -> y_2 == 1, y_3 == 2, y_4 = 3)
                        if (y == 0)
                        {
                            x_end = x;
                            y_end = y + 3;
                            x_mid_1 = x;
                            y_mid_1 = y + 1;
                            x_mid_2 = x;
                            y_mid_2 = y + 2;
                            if (in_field[x_end, y_end] == 0 && in_field[x_mid_1, y_mid_1] == 0 && in_field[x_mid_2, y_mid_2] == 0)
                            {
                                Around(x, y, x_end, y_end, ref in_field);
                                in_field[x_end, y_end] = 1;
                                in_field[x_mid_1, y_mid_1] = 1;
                                in_field[x_mid_2, y_mid_2] = 1;
                                in_field[x, y] = 1;
                            }
                            else
                            {
                                i--;
                                continue;
                            }
                        }
                        // Частный случай (y_1 == 9 -> y_2 == 8, y_3 == 7, y_4 == 6)
                        else if (y == 9)
                        {
                            x_end = x;
                            y_end = y - 3;
                            x_mid_1 = x;
                            y_mid_1 = y - 1;
                            x_mid_2 = x;
                            y_mid_2 = y - 2;
                            if (in_field[x_end, y_end] == 0 && in_field[x_mid_1, y_mid_1] == 0 && in_field[x_mid_2, y_mid_2] == 0)
                            {
                                Around(x_end, y_end, x, y, ref in_field);
                                in_field[x_end, y_end] = 1;
                                in_field[x_mid_1, y_mid_1] = 1;
                                in_field[x_mid_2, y_mid_2] = 1;
                                in_field[x, y] = 1;
                            }
                            else
                            {
                                i--;
                                continue;
                            }
                        }
                        // Другие случаи
                        else
                        {
                            // "Да" -> корабль вниз
                            if (randomiser.Next(2) == 0)
                            {
                                x_end = x;
                                y_end = y - 3;
                                x_mid_1 = x;
                                y_mid_1 = y - 1;
                                x_mid_2 = x;
                                y_mid_2 = y - 2;
                                if (y_end > -1 && in_field[x_end, y_end] == 0 && in_field[x_mid_1, y_mid_1] == 0 && in_field[x_mid_2, y_mid_2] == 0)
                                {
                                    Around(x_end, y_end, x, y, ref in_field);
                                    in_field[x_end, y_end] = 1;
                                    in_field[x_mid_1, y_mid_1] = 1;
                                    in_field[x_mid_2, y_mid_2] = 1;
                                    in_field[x, y] = 1;
                                }
                                else
                                {
                                    i--;
                                    continue;
                                }
                            }
                            // "Нет" -> корабль вверх
                            else
                            {
                                x_end = x;
                                y_end = y + 3;
                                x_mid_1 = x;
                                y_mid_1 = y + 1;
                                x_mid_2 = x;
                                y_mid_2 = y + 2;
                                if (y_end < 10 && in_field[x_end, y_end] == 0 && in_field[x_mid_1, y_mid_1] == 0 && in_field[x_mid_2, y_mid_2] == 0)
                                {
                                    Around(x, y, x_end, y_end, ref in_field);
                                    in_field[x_end, y_end] = 1;
                                    in_field[x_mid_1, y_mid_1] = 1;
                                    in_field[x_mid_2, y_mid_2] = 1;
                                    in_field[x, y] = 1;
                                }
                                else
                                {
                                    i--;
                                    continue;
                                }
                            }
                        }
                    }
                    else
                    {
                        i--;
                        continue;
                    }
                }
            }

            // 0 - нет кораблей; 1 - корабль; 2 - окрестность корабля
            // Меню для проверки
            Console.WriteLine(" ============================== ");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{in_field[i, 0],3}{in_field[i, 1],3}" +
                    $"{in_field[i, 2],3}{in_field[i, 3],3}{in_field[i, 4],3}" +
                    $"{in_field[i, 5],3}{in_field[i, 6],3}{in_field[i, 7],3}" +
                    $"{in_field[i, 8],3}{in_field[i, 9],3}");
            }
            Console.WriteLine(" ============================== ");

            int points = 0;
            char[] Letters = { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ж', 'З', 'И', 'К' };
            while ( points < 20 ) 
            {
                // Основное меню игры
                Console.WriteLine($"{"",2}{'A',3}{'Б',3}{'В',3}{'Г',3}{'Д',3}{'Е',3}{'Ж',3}{'З',3}{'И',3}{'К',3} ");
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"{i+1,2}{field[i, 0],3}{field[i, 1],3}" +
                        $"{field[i, 2],3}{field[i, 3],3}{field[i, 4],3}" +
                        $"{field[i, 5],3}{field[i, 6],3}{field[i, 7],3}" +
                        $"{field[i, 8],3}{field[i, 9],3}");
                }
                Console.Write("На какую клетку вы хотите напасть? Ответ: ");
                string answer = Console.ReadLine();
                string[] coordinates = answer.Split(' ');
                if (in_field[int.Parse(coordinates[0]) - 1, Array.IndexOf(Letters, char.Parse(coordinates[1]))] == 1)
                {
                    Console.WriteLine(" Вы попали по врагу!!! Так держать!!! ");
                    points++;
                    field[int.Parse(coordinates[0]) - 1, Array.IndexOf(Letters, char.Parse(coordinates[1]))] = "X";
                }
                else 
                {
                    Console.WriteLine(" Вы промахнулись!!! ");
                    field[int.Parse(coordinates[0]) - 1, Array.IndexOf(Letters, char.Parse(coordinates[1]))] = "*";
                }
            }
        }
        static void Around(int x_1, int y_1, int x_2, int y_2, ref int[,] ints) 
        {
            int[] xses = new int[x_2 - x_1 + 3];
            int x = 0;
            for (int i = x_1 - 1; i < x_2 + 2; i++) 
            {
                xses[x++] = i;
            }
            int[] yses = new int[y_2 - y_1 + 3];
            int y = 0;
            for (int i = y_1 -1; i < y_2 + 2; i++)
            {
                yses[y++] = i; 
            }
            foreach (int xse in xses)
            {
                foreach (int yse in yses)
                {
                    if (xse > -1 && yse > -1 && xse < 10 && yse < 10) // Создание границ 
                    {
                        ints[xse, yse] = 2;
                    }
                }
            }
        }
    }
}
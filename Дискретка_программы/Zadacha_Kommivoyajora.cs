using System.Diagnostics.CodeAnalysis;

namespace grgerfwdvrw
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // берется матрица;
            // В ней находятся наименьшие эл-ты по строкам и столбцам (и вычитаются от соотв. строки/столбца)
            // Находится нуль, вокруг которого наибольшие эл-ты (выбирая способом наименьшего, не считая сам нуль) (их суммируют для конечной суммы кратчайших путей)
            // Строка и столбец, где находился самый "дорогой нуль" удаляются, а ребро i->j отправляется в список использованных ребер
            // Убирается ребро, которое может вызвать цикл: в случае 1 ребра - ребро j->i или если целая цепочка: i->j->k, тогда k->i
            int a = Convert.ToInt32(Console.ReadLine());
            double[,] table = new double[a + 1, a + 1];
            List<string> doubles = new List<string>();
            List<double> used_rows = new List<double>();
            List<double> used_cols = new List<double>();
            double sum = 0;
            for (int i = 0; i <= a; i++)
            {
                if (i == 0)
                {
                    for (int j = 1; j <= a; j++)
                    {
                        table[0, j] = j;
                    }
                }
                else
                {
                    table[i, 0] = i;
                    string row = Console.ReadLine();
                    int b = 1;
                    foreach (string str in row.Split(" "))
                    {
                        table[i, b++] = Convert.ToInt32(str);
                    }
                    table[i, i] = double.PositiveInfinity;
                }
            }
            for (int i = 0; i <= a; i++)
            {
                for (int j = 0; j <= a; j++)
                {
                    Console.Write($"{table[i, j],5}");
                }
                Console.WriteLine();
            }
            while (doubles.Count != a)
            {
                for (int i = 1; i <= a; i++) // вычитание строк
                {
                    if (!used_rows.Contains(i))
                    {
                        Console.WriteLine($"Проверка {i}-й строки");
                        double temp_row = int.MaxValue;
                        for (int j = 1; j <= a; j++)
                        {
                            if (!used_cols.Contains(j))
                            {
                                temp_row = table[i, j] < temp_row ? table[i, j] : temp_row;
                            }
                        }
                        sum += temp_row;
                        for (int j = 1; j <= a; j++)
                        {
                            if (!used_cols.Contains(j))
                            {
                                table[i, j] = table[i, j] - temp_row;
                            }
                        }
                    }
                }
                for (int j = 1; j <= a; j++) // вычитание столбцов
                {
                    if (!used_cols.Contains(j))
                    {
                        Console.WriteLine($"Проверка {j}-го столбца");
                        double temp_col = int.MaxValue;
                        for (int i = 1; i <= a; i++)
                        {
                            if (!used_rows.Contains(i))
                            {
                                temp_col = table[i, j] < temp_col ? table[i, j] : temp_col;
                            }
                        }
                        sum += temp_col;
                        for (int i = 1; i <= a; i++)
                        {
                            if (!used_rows.Contains(i))
                            {
                                table[i, j] = table[i, j] - temp_col;
                            }
                        }
                    }
                }
                double c = 0;
                int temp_i = 0, temp_j = 0;
                for (int i = 1; i <= a; i++) // наибольший коэфф. нуля
                {
                    for (int j = 1; j <= a; j++)
                    {
                        double d = 0;
                        if (table[i, j] == 0)
                        {
                            double t = double.PositiveInfinity; 
                            for (int k = 1; k <= a; k++) // наименьший элемент по строке i
                            {
                                if (k != j && !used_cols.Contains(k) && !used_rows.Contains(i))
                                {
                                    t = t > table[i, k] ? table[i, k] : t;
                                }
                            }
                            d += t;
                            t = double.PositiveInfinity;
                            for (int k = 1; k <= a; k++) // наименьший элемент по столбцу j
                            {
                                if (k != i && !used_cols.Contains(j) && !used_rows.Contains(k))
                                {
                                    t = t > table[k, j] ? table[k, j] : t;
                                }
                            }
                            d += t;
                        }
                        c = d > c ? d : c;
                        if (d == c) { temp_i = i; temp_j = j; }
                    }
                }
                doubles.Add($"{temp_i} {temp_j}");
                for (int i = 1; i <= a; i++)
                {
                    table[temp_i, i] = double.PositiveInfinity;
                    table[i, temp_j] = double.PositiveInfinity;
                }
                used_rows.Add(temp_i); // использованные строки
                used_cols.Add(temp_j); // использованные столбцы
                Console.WriteLine($"Убираем строку {temp_i} и столбец {temp_j}");
                Console.WriteLine($"Добавляем элемент {temp_i} {temp_j}");
                Console.WriteLine("Содержание списка с путями:");
                foreach (string st in doubles) { Console.WriteLine($"\t* {st}"); }
                string temp = Finding_Cycles(doubles);
                if (doubles.Count != a - 1) 
                {
                    Console.WriteLine($"Убираем из рассмотрения {temp}");
                    table[Convert.ToInt32(temp.Split(" ")[0]), Convert.ToInt32(temp.Split(" ")[1])] = double.PositiveInfinity;
                }
                for (int i = 0; i <= a; i++)
                {
                    for (int j = 0; j <= a; j++)
                    {
                        Console.Write($"{table[i, j],5}");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine($"Сумма: {sum}");
            }
            for (int i = 0; i <= a; i++)
            {
                for (int j = 0; j <= a; j++)
                {
                    Console.Write($"{table[i, j],5}");
                }
                Console.WriteLine();
            }
            foreach (string s in doubles) { Console.WriteLine(s); }
            Console.WriteLine($"Сумма: {sum}") ;


        }
        static string Finding_Cycles(List<string> list) 
        {
            for(int i =0; i < list.Count-1; i++) 
            {
                for (int j = 0; j < list.Count; j++) 
                {
                    if (list[i].Split(" ")[0] == list[j].Split(" ")[1])
                    {
                        string temp = list[j];
                        list.Remove(list[j]);
                        list.Insert(i, temp);
                    }
                    else if (list[i].Split(" ")[1] == list[j].Split(" ")[0]) 
                    {
                        string temp = list[j];
                        list.Remove(list[j]);
                        list.Insert(i+1, temp);
                    }
                
                }
            }
            bool cond = true;
            for (int i = 0; i < list.Count - 1; i++) 
            {
                if (list[i].Split(" ")[1] != list[i + 1].Split(" ")[0]) 
                {
                    cond = false;
                    break;
                }
            }
            if (cond) { return $"{list.Last().Split(" ")[1]} {list.First().Split(" ")[0]}"; }
            else { return $"{list.Last().Split(" ")[1]} {list.Last().Split(" ")[0]}"; }
        }
    }
}

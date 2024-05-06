using System.Diagnostics.CodeAnalysis;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string source = @"E:\Projects_VS\grgerfwdvrw\ConsoleApp1\input_s1_02.txt";
            StreamReader sr = new StreamReader(source);
            string info = sr.ReadLine();
            int sum = int.MaxValue;
            int[,] ways = new int[5, Convert.ToInt32(info.Split(" ")[0])];
            int quantity_of_ways = Convert.ToInt32(info.Split(" ")[0]);
            int quantity;
            if (Convert.ToInt32(info.Split(" ")[0]) < Convert.ToInt32(info.Split(" ")[1])) 
            {
                quantity = Convert.ToInt32(info.Split(" ")[0]);
            }
            else 
            {
                quantity = Convert.ToInt32(info.Split(" ")[1]);
            }
            for (int i = 0; i < quantity_of_ways; i++) 
            {
                info = sr.ReadLine();
                ways[0, i] = i+1; // номер дерева
                ways[1, i] = Convert.ToInt32(info.Split(" ")[0]); // прошлая ветвь
                ways[2, i] = Convert.ToInt32(info.Split(" ")[1]); // длина
                ways[3, i] = -1;
                ways[4, i] = 0;
            }
            for (int i = 0; i < quantity; i++) 
            {
                info = sr.ReadLine();
                ways[3, Convert.ToInt32(info.Split(" ")[0]) - 1] = 1;
                ways[4, Convert.ToInt32(info.Split(" ")[0]) - 1] = Convert.ToInt32(info.Split(" ")[1]);
            }
            Console.WriteLine($"{"numb",5}{"prev",5}{"len",5}{"apple",5}{"spel",5}");
            for (int i = 0; i < quantity_of_ways; i++) { Console.WriteLine($"{ways[0,i],5}{ways[1, i],5}{ways[2, i],5}{ways[3, i],5}{ways[4, i],5}"); }
            info = sr.ReadLine();
            sr.Close();
            int pos = Convert.ToInt32(info.Split(" ")[0]);
            int temp_pos = pos;
            int spelost = Convert.ToInt32(info.Split(" ")[1]);
            List<int> branches = new List<int>();
            for (int i = 0; i <= ways.GetUpperBound(1); i++) 
            {
                if (ways[3, i] == 1) 
                {
                    if (ways[4, i] >= spelost) 
                    {
                        branches.Add(ways[0, i]);
                    }
                }
            }
            //int[,] lens = new int[3, branches.Count];
            //int k = 0;
            //while(branches.Count > 0) 
            //{
            //    lens[1,k] = temp_pos;
            //    lens[2, k] = branches[branches.Count - 1];
            //    lens[0, k] = len_of_way(ways, branches[branches.Count - 1], temp_pos);
            //    k++;
            //    branches.RemoveAt(branches.Count - 1);
            //}
            //Console.WriteLine($"{"Length",10}{"Way_from",10},{"Way_to",10}");
            //for (int i  = 0; i <= lens.GetUpperBound(1); i++) 
            //{
            //    Console.WriteLine($"{lens[0, i],10}{lens[1, i],10},{lens[2, i],10}");
            //}
            // алгоритм Дейкстры
            List<int> used = new List<int>();
            List<int> current = new List<int>();
            foreach(int i  in branches) {Console.WriteLine(i); }
            //while (used.Count != branches.Count) 
            //{
            //    current.Clear();
            //    for (int i = 0; i < branches.Count; i++) 
            //    {
            //        if (!used.Contains(branches[i]))
            //        {
            //            current.Add(len_of_way(ways, branches[i], temp_pos));
            //            Console.WriteLine(len_of_way(ways, branches[i], temp_pos));
            //        }
            //    }
            //    current.Sort();
            //    sum += current.First();
            //    for(int i = 0; i < branches.Count; i++) 
            //    {
            //        if (current.First() == len_of_way(ways, branches[i], temp_pos) && !used.Contains(branches[i])) 
            //        {
            //            Console.WriteLine($"{temp_pos} -> {branches[i]}");
            //            temp_pos = branches[i];
            //            used.Add(temp_pos);
            //        }
            //    }
            //}
            List<string> res = getStringList(branches.Count, branches.ToArray());
            foreach (string r in res) 
            {
                int temp_len = 0;
                int worm = temp_pos;
                for(int i =0; i < r.Split(" ").Length; i++) 
                {
                    temp_len += len_of_way(ways, Convert.ToInt32(r.Split(" ")[i]), worm);
                    worm = Convert.ToInt32(r.Split(" ")[i]);
                }
                sum = temp_len < sum ? temp_len : sum;
            }
            if (sum == int.MaxValue) { Console.WriteLine(0); return; }
            Console.WriteLine(sum);




        }
        static int len_of_way(int[,] ways, int apple , int worm) 
        {
            List<int> ways_from_apple = new List<int>();
            List<int> ways_from_worm = new List<int>();
            int len = 0;
            ways_from_apple.Add(apple);
            while (apple != 0)
            {
                apple = ways[1, apple - 1];
                ways_from_apple.Add(apple);
            }
            ways_from_apple.Reverse(); //  путь от корня до яблока
            ways_from_worm.Add(worm);
            while (worm != 0)
            {
                worm = ways[1, worm - 1];
                ways_from_worm.Add(worm);
            }
            ways_from_worm.Reverse(); // путь от корня до червя
            if (ways_from_worm.Count > ways_from_apple.Count)
            {
                int prev = ways_from_worm[0];
                for (int i = 0; i < ways_from_worm.Count; i++)
                {
                    if (!ways_from_apple.Contains(ways_from_worm[i])) // перечесение
                    {
                        for (int j = i + 1; j < ways_from_worm.Count; j++)  // от пересечения до червя
                        {
                            if (ways_from_worm[j] != 0) 
                            {
                                len += ways[2, ways_from_worm[j] - 1];
                            }
                        }
                        if (ways_from_apple.IndexOf(ways_from_worm[i]) != -1)
                        {
                            if (ways_from_apple.Count > ways_from_apple.IndexOf(prev) + 1)
                            {
                                for (int j = ways_from_apple.IndexOf(prev) + 1; j < ways_from_apple.Count; j++) // от пересечения до яблока
                                {
                                    len += ways[2, ways_from_apple[j] - 1];
                                }
                            }
                        }
                        break;
                    }
                    else
                    {
                        prev = ways_from_worm[i];
                    }
                }
            }
            else // ways_from_worm.Count <= ways_from_apple.Count
            {
                int prev = ways_from_apple[0];
                for (int i = 0; i < ways_from_apple.Count; i++)
                {
                    if (!ways_from_worm.Contains(ways_from_apple[i])) // перечесение
                    {
                        for (int j = i; j < ways_from_apple.Count; j++)  // от пересечения до яблока
                        {
                            if (ways_from_apple[j] != 0)
                            {
                                len += ways[2, ways_from_apple[j] - 1];
                            }
                        }
                        if (ways_from_worm.IndexOf(prev) != -1)
                        {
                            if (ways_from_worm.Count > ways_from_worm.IndexOf(prev) + 1)
                            {
                                for (int j = ways_from_worm.IndexOf(prev) + 1; j < ways_from_worm.Count; j++) // от пересечения до червя
                                {
                                    len += ways[2, ways_from_worm[j] - 1];
                                }
                            }
                        }
                        break;
                    }
                    else
                    {
                        prev = ways_from_apple[i];
                    }
                }
            }
            return len;
        }
        static int finding_way(int[,] ways, int worm, int[] branches, int i) 
        {
            int len = int.MaxValue;
            if (i > 1)
            {
                int temp = 0;
                foreach (int j in branches)
                {
                    temp += len_of_way(ways, branches[j], worm);
                    worm = branches[j];
                    int[] br = new int[branches.Length - 1];
                    for (int k = 0, m = 0; m < branches.Length; k++, m++)
                    {
                        if (m == j)
                        {
                            m++;
                        }
                        br[k] = branches[m];
                    }
                    temp += finding_way(ways, worm, br, i - 1);
                    len = temp < len ? temp : len;
                }
            }
            else 
            {
                return len_of_way(ways, branches.First(), worm);
            }
            return len;
        }
        static List<string> getStringList(int N, int[] arr)
        {
            List<string> OutArr = new List<string>();
            for (int i = 0; i < arr.Length; i++)
            {
                int[] arr_temp = new int[arr.Length - 1];
                for (int j = 0, k = 0; k < arr.Length; j++, k++)
                {
                    if (k == i)
                    {
                        k++;
                    }
                    if (k >= arr.Length) { break; }
                    arr_temp[j] = arr[k];
                }
                getString(OutArr, arr[i].ToString(), N - 1, arr_temp);
            }
            return OutArr;
        }
        static void getString(List<string> OutArr, string strToAppend, int N, int[] arr)
        {
            if (N == 0)
            {
                OutArr.Add(strToAppend);
                return;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                int[] arr_temp = new int[arr.Length - 1];
                for (int j = 0, k = 0; k < arr.Length; j++, k++)
                {
                    if (k == i)
                    {
                        k++;
                    }
                    if (k >= arr.Length) { break; }
                    arr_temp[j] = arr[k];
                }
                getString(OutArr, strToAppend + " " + arr[i], N - 1, arr_temp);
            }
        }
    }
}

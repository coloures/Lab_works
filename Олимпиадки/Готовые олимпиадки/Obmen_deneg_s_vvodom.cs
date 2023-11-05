namespace Obmen_deneg_s_vvodom
{
    internal class Obmen_deneg_s_vvodom
    {
        static void Main(string[] args)
        {
            try
            {
                StreamReader sr = new StreamReader("E:\\Projects_VS\\ConsoleApp25\\Obmen_deneg_s_vvodom\\input6.txt");
                string convertation = sr.ReadLine();
                string unlucky_nums = sr.ReadLine();
                int[] unlucky_numbers = new int[Convert.ToInt32(unlucky_nums.Split(' ')[0])];
                for (int i = 1; i < unlucky_nums.Split(' ').Length; i++)
                {
                    unlucky_numbers[i - 1] = Convert.ToInt32(unlucky_nums.Split(' ')[i]);
                }
                string after_convertation = sr.ReadLine();
                string after_unlucky_nums = sr.ReadLine();
                int[] after_unlucky_numbers = new int[Convert.ToInt32(after_unlucky_nums.Split(' ')[0])];
                for (int i = 1; i < after_unlucky_nums.Split(' ').Length; i++)
                {
                    after_unlucky_numbers[i - 1] = Convert.ToInt32(after_unlucky_nums.Split(' ')[i]);
                }
                int[] number = new int[Convert.ToInt32(convertation.Split(' ')[0])];
                string quantity = sr.ReadLine();
                for (int i = 0; i < quantity.Split(' ').Length; i++)
                {
                    number[i] = Convert.ToInt32(quantity.Split(' ')[i]);
                }
                int num = 0;
                for (int i = 0; i < number.Length; i++)
                {
                    int minus = 0;
                    foreach (int j in unlucky_numbers)
                    {
                        if (number[i] > j)
                        {
                            minus++;
                        }

                    }
                    number[i] -= minus;
                }
                foreach (int i in number) { Console.Write(i + "  "); }
                Console.WriteLine();
                for (int i = 0; i < number.Length - 1; i++)
                {
                    number[i + 1] = number[i + 1] + number[i] * Convert.ToInt32(convertation.Split(' ')[i + 1]);
                    Console.WriteLine(number[i+1]);
                    number[i] = 0;
                }
                num = number[number.Length - 1];

                Console.WriteLine($"num = {num}");
                int[] after_number = new int[Convert.ToInt32(after_convertation.Split(' ')[0])];
                after_number[after_number.Length - 1] = num;
                for (int i = after_number.Length - 1; i > 0; i--)
                {
                    int qua = after_number[i] / Convert.ToInt32(after_convertation.Split(' ')[i]);
                    after_number[i] = after_number[i] - qua * Convert.ToInt32(after_convertation.Split(' ')[i]);
                    after_number[i - 1] = qua;
                }
                foreach(int aft in after_number) { Console.Write(aft + "  "); }
                Console.WriteLine();
                int[] used = new int[after_unlucky_numbers.Length];
                for (int i = after_number.Length - 1; i > -1; i--)
                {
                    int q = 0;
                    int k = 0;
                    while (true)
                    {
                        if (q == after_unlucky_numbers.Length) { break; }
                        foreach (int j in after_unlucky_numbers)
                        {
                            if (after_number[i] > j && !used.Contains(j))
                            {
                                //after_number[i]++;
                                used[k++] = j;
                                Console.WriteLine($"{after_number[i]++} больше, чем {j}");
                            }

                        }
                        q++;


                    }
                    Console.WriteLine(after_number[i]);
                    Array.Clear(used, 0, used.Length);
                }
                for (int i = after_number.Length - 1; i > 0; i--)
                {
                    int qua = after_number[i] / Convert.ToInt32(after_convertation.Split(' ')[i]);
                    after_number[i] = after_number[i] - qua * Convert.ToInt32(after_convertation.Split(' ')[i]);
                    after_number[i - 1] = after_number[i - 1] + qua;
                }
                foreach(int i in after_number) { Console.Write(i + "  "); }
                string answer = "";
                foreach (int i in after_number) { answer += $"{i} "; }
                try
                {
                    StreamWriter sw = new StreamWriter("E:\\Projects_VS\\ConsoleApp25\\Obmen_deneg_s_vvodom\\output6.txt");
                    sw.WriteLine(answer);
                    sw.Close();
                }
                finally{}
                sr.Close();
            }
            finally { }
        }
    }
}
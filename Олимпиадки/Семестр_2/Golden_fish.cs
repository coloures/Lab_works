namespace golden_fish_3 // работает на примерах 1 -> 11 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int y = 1; y < 14; y++) 
            {
                string source = $"E:\\Projects_VS\\Sets\\Golden_fish\\input_s1_{y.ToString("00")}.txt";
                StreamReader sr = new StreamReader(source);
                int quantity = Convert.ToInt32(sr.ReadLine());
                string[] words = new string[quantity];
                for (int i = 0; i < quantity; i++)
                {
                    words[i] = sr.ReadLine();
                }
                Dictionary<string, int> starts_dict = new Dictionary<string, int>();
                Dictionary<string, int> ends_dict = new Dictionary<string, int>();
                string[] starts_temp = new string[Convert.ToInt32(sr.ReadLine())];
                for (int i = 0; i < starts_temp.Length; i++)
                {
                    starts_temp[i] = sr.ReadLine();
                    starts_dict.Add(starts_temp[i].Split(" ")[0], Convert.ToInt32(starts_temp[i].Split(" ")[1]));
                }
                string[] ends_temp = new string[Convert.ToInt32(sr.ReadLine())];
                for (int i = 0; i < ends_temp.Length; i++)
                {
                    ends_temp[i] = sr.ReadLine();
                    ends_dict.Add(ends_temp[i].Split(" ")[0], Convert.ToInt32(ends_temp[i].Split(" ")[1]));
                }
                sr.Close();
                Dictionary<string, List<string>> start_words_dict = new Dictionary<string, List<string>>();
                Dictionary<string, List<string>> end_words_dict = new Dictionary<string, List<string>>();
                foreach (string key in starts_dict.Keys) { start_words_dict[key] = new List<string>(); }
                foreach (string key in ends_dict.Keys) { end_words_dict[key] = new List<string>(); }
                foreach (string word in words) // изначальная сортировка
                {
                    foreach (string key in starts_dict.Keys)
                    {
                        if (key == word.First().ToString())
                        {
                            start_words_dict[key].Add(word);
                        }
                    }
                    foreach (string key in ends_dict.Keys)
                    {
                        if (key == word.Last().ToString())
                        {
                            end_words_dict[key].Add(word);
                        }
                    }
                }
                foreach (string key in start_words_dict.Keys) // проверка на правильность выбора
                {
                    for (int i = 0; i < start_words_dict[key].Count; i++)
                    {
                        bool cond = false;
                        foreach (string second_key in end_words_dict.Keys)
                        {
                            if (end_words_dict[second_key].Contains(start_words_dict[key][i]))
                            {
                                cond = true;
                            }
                        }
                        if (!cond)
                        {
                            start_words_dict[key].Remove(start_words_dict[key][i]);
                        }
                    }
                }
                foreach (string key in end_words_dict.Keys) // проверка на правильность выбора
                {
                    for (int i = 0; i < end_words_dict[key].Count; i++)
                    {
                        bool cond = false;
                        foreach (string second_key in start_words_dict.Keys)
                        {
                            if (start_words_dict[second_key].Contains(end_words_dict[key][i]))
                            {
                                cond = true;
                            }
                        }
                        if (!cond)
                        {
                            end_words_dict[key].Remove(end_words_dict[key][i]);
                        }
                    }
                }
                int sum = 0;
                foreach (string key in starts_dict.Keys)
                {
                    int sum2 = 0; // сумма значений справа (значений конца)
                    foreach (string key2 in ends_dict.Keys)
                    {
                        sum2 += Math.Min(start_words_dict[key].Intersect(end_words_dict[key2]).Count(), ends_dict[key2]); // сравнение с возможным кол-вом справа (которое задано в задании)
                    }
                    sum += Math.Min(starts_dict[key], sum2); // сравнение суммы слов слева с возможным количеством справа
                }
                int m = 0;
                foreach (string key in ends_dict.Keys) 
                {
                    m += ends_dict[key]; // кол-во слов справа
                }
                sum = sum > m ? m: sum; // сравнение чисел справа и слева
                Console.WriteLine(sum);
            }
        }
    }
}

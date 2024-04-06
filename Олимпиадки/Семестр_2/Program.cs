using System.Linq;

namespace Golden_fish
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string source = @"E:\Projects_VS\Sets\Golden_fish\input_s1_01.txt";
            StreamReader sr = new StreamReader(source);
            int quantity = Convert.ToInt32(sr.ReadLine());
            string[] words = new string[quantity];
            for(int i = 0; i < quantity; i++) 
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
            foreach(string key in starts_dict.Keys) { start_words_dict[key] = new List<string>(); }
            foreach (string key in ends_dict.Keys) { end_words_dict[key] = new List<string>(); }
            foreach (string word in words) // изначальная сортировка
            {
                foreach(string key in  starts_dict.Keys) 
                {
                    if (key == word.First().ToString()) 
                    {
                        start_words_dict[key].Add(word);
                    }
                }
                foreach(string key in  ends_dict.Keys) 
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
            int a = 0;
            foreach (int i in starts_dict.Values) 
            {
                if (i == 0) { a++; }
            }
            int b = 0;
            foreach (int i in ends_dict.Values) 
            {
                if (i == 0) { b++; }
            }
            List<string> appropriate_words = new List<string>();
            while (a != starts_dict.Values.Count() && b != ends_dict.Values.Count()) 
            {
                foreach (string s in starts_dict.Keys) 
                {
                    Console.WriteLine($"letter {s} --- {starts_dict[s]} times");
                }
                foreach (string s in ends_dict.Keys)
                {
                    Console.WriteLine($"letter {s} --- {ends_dict[s]} times");
                }
                foreach (string letter in start_words_dict.Keys)
                {
                    if (start_words_dict[letter].Count() <= starts_dict[letter])
                    {
                        for (int i = 0; i < start_words_dict[letter].Count; i++) 
                        {
                            bool cond = true;
                            string wrd = start_words_dict[letter][i];
                            appropriate_words.Add(wrd);
                            starts_dict[wrd.First().ToString()]--;
                            ends_dict[wrd.Last().ToString()]--;
                             if (ends_dict[wrd.Last().ToString()] < 0 || ends_dict[wrd.Last().ToString()] > Sum(starts_dict.Values.ToArray()))
                            {
                                starts_dict[wrd.First().ToString()]++;
                                ends_dict[wrd.Last().ToString()]++;
                                appropriate_words.Remove(wrd);
                                cond = false;
                            }
                            if (cond)
                            {
                                start_words_dict[wrd.First().ToString()].Remove(wrd);
                                foreach (string k in end_words_dict[wrd.Last().ToString()])
                                {
                                    if (k == wrd)
                                    {
                                        end_words_dict[wrd.Last().ToString()].Remove(wrd);
                                        break;
                                    }
                                }
                            }
                        }
                        starts_dict[letter] = 0;
                    }
                    Console.WriteLine("Start");
                    foreach (string st in start_words_dict[letter]) 
                    {
                        Console.Write(st + "\t");
                    }
                    Console.WriteLine();
                    Console.WriteLine("Start");
                }
                foreach (string letter in end_words_dict.Keys)
                {
                    if (end_words_dict[letter].Count() <= ends_dict[letter])
                    {

                        for (int i = 0; i < end_words_dict[letter].Count; i++)
                        {
                            bool cond = true;
                            string wrd = end_words_dict[letter][i];
                            appropriate_words.Add(wrd);
                            ends_dict[wrd.Last().ToString()]--;
                            starts_dict[wrd.First().ToString()]--;
                            if (starts_dict[wrd.First().ToString()] < 0 || starts_dict[wrd.First().ToString()] > Sum(ends_dict.Values.ToArray()))
                            {
                                starts_dict[wrd.First().ToString()]++;
                                ends_dict[wrd.Last().ToString()]++;
                                appropriate_words.Remove(wrd);
                                cond = false;
                            }
                            else if (ends_dict[wrd.Last().ToString()] < 0 || ends_dict[wrd.Last().ToString()] > Sum(starts_dict.Values.ToArray()))
                            {
                                starts_dict[wrd.First().ToString()]++;
                                ends_dict[wrd.Last().ToString()]++;
                                appropriate_words.Remove(wrd);
                                cond = false;
                            }
                            if (cond)
                            {
                                end_words_dict[wrd.Last().ToString()].Remove(wrd);
                                foreach (string k in start_words_dict[wrd.First().ToString()])
                                {
                                    if (k == wrd)
                                    {
                                        start_words_dict[wrd.First().ToString()].Remove(wrd);
                                        break;
                                    }
                                }
                            }
                        }
                        ends_dict[letter] = 0;

                    }
                    Console.WriteLine("End");
                    foreach (string st in end_words_dict[letter])
                    {
                        Console.Write(st + "\t");
                    }
                    Console.WriteLine();
                    Console.WriteLine("End");
                }
                foreach (string letter in start_words_dict.Keys) 
                {
                    for(int i = 0; i < start_words_dict[letter].Count; i++) 
                    {
                        if (starts_dict[start_words_dict[letter][i].First().ToString()] > 0 && ends_dict[start_words_dict[letter][i].Last().ToString()] > 0) 
                        {
                            appropriate_words.Add(start_words_dict[letter][i]);

                        }
                    }
                }
                a = 0;
                b = 0;
                foreach (int i in starts_dict.Values)
                {
                    if (i == 0) { a++; }
                }
                foreach (int i in ends_dict.Values)
                {
                    if (i == 0) { b++; }
                }

            }
        }
        static int Sum(int[] array)
        {
            int sum = 0;
            foreach(int i in array) { sum += i;}
            return sum;
        }
    }
}
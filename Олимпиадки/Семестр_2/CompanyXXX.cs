using System.Collections.Immutable;

namespace Company
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 11; i < 11; i++)
            {
                int a = 0;
                List<Company> list = new List<Company>();
                string source = $"E:\\Projects_VS\\BASE_OMGTU\\Company\\input_s1_{i.ToString("00")}.txt";
                StreamReader sr = new StreamReader(source);
                string line;
                while ((line = sr.ReadLine()) != "END")
                {
                    list.Add(new Company(line, a));
                    a = (a + 1) % 2;
                }
                string name = sr.ReadLine();
                sr.Close();
                //Company.Show();
                List<string> answer = Company.Search_boss_by_name(name);
                answer.Sort();
                string path = $"E:\\Projects_VS\\BASE_OMGTU\\Company\\output_s1_{i.ToString("00")}.txt";
                StreamWriter sw = new StreamWriter(path);
                foreach (string str in answer)
                {
                    sw.WriteLine(str);
                }
                sw.Close();
                list.Clear();
                Company.Clearing();
            }
        }
    }
    internal class Company 
    {
        static Dictionary<string, string> codes_names = new Dictionary<string, string>(); // коды - имена
        static Dictionary<string, List<string>> boss_workers = new Dictionary<string, List<string>>(); // начальник - подчиненные
        static List<string> answer = new List<string>();
        static string boss;
        static public void Clearing() 
        {
            codes_names.Clear();
            boss_workers.Clear();
            answer.Clear();
            boss = string.Empty;
        }
        public Company(string name, int a) 
        {
            if (a == 0) // начальник
            {
                if (!codes_names.ContainsKey(name.Substring(0,4))) // начальника нет в базе
                {
                    if (name.Length > 5) // есть и имя и код
                    {
                        codes_names[name.Substring(0, 4)] = name.Substring(5);
                        boss_workers[name.Substring(0, 4)] = new List<string>();
                    }
                    else // есть код, но нет имени
                    {
                        codes_names[name.Substring(0, 4)] = "Unknown name";
                        boss_workers[name.Substring(0, 4)] = new List<string>();
                    }
                }
                else // начальник уже есть в базе
                {
                    if (name.Length > 5) // есть и имя, и код
                    {
                        codes_names[name.Substring(0, 4)] = name.Substring(5);
                        if (!boss_workers.ContainsKey(name.Substring(0, 4))) 
                        {
                            boss_workers[name.Substring(0, 4)] = new List<string>();
                        }
                    }
                    else
                    {
                        if (!boss_workers.ContainsKey(name.Substring(0, 4)))
                        {
                            boss_workers[name.Substring(0, 4)] = new List<string>();
                        }
                    }
                }
                boss = name.Substring(0, 4); // чтобы при следующем шаге не пришлось искать начальника
            }
            if (a == 1) // рабочий
            {
                if (!codes_names.ContainsKey(name.Substring(0, 4))) // рабочего нет в базе;
                {
                    if (name.Length > 5) // есть и имя и код
                    {
                        codes_names[name.Substring(0, 4)] = name.Substring(5);
                        boss_workers[boss].Add(name.Substring(0, 4));
                    }
                    else // есть код, но нет имени
                    {
                        codes_names[name.Substring(0, 4)] = "Unknown name";
                        boss_workers[boss].Add(name.Substring(0, 4));
                    }
                }
                else // рабочий уже есть в базе
                {
                    if (name.Length > 5) // есть и имя, и код 
                    {
                        codes_names[name.Substring(0, 4)] = name.Substring(5);
                        boss_workers[boss].Add(name.Substring(0, 4));
                    }
                    else // есть код, но нет имени
                    {
                        boss_workers[boss].Add(name.Substring(0, 4));
                    }
                }
            }
        }
        static public List<string> Search_boss_by_name(string name) // при вводе может быть  код или имя
        {
            foreach (string code in codes_names.Keys) 
            {
                if (code == name) // по коду
                {
                    if (boss_workers.ContainsKey(code)) // проверка на принадлежность человека к начальнику
                    {
                        foreach (string code_worker in boss_workers[code])
                        {
                            answer.Add($"{code_worker} {codes_names[code_worker]}");
                            if (boss_workers.ContainsKey(code_worker))
                            {
                                //Console.WriteLine($"{name} ------- > {code_worker}");
                                Search_boss_by_name(code_worker); // переполнение стека
                            }
                        }
                    }
                }
            }
            foreach (string code in codes_names.Keys) 
            {
                if (codes_names[code] == name) // по имени
                {
                    if (boss_workers.ContainsKey(code)) // проверка на принадлежность человека к начальнику
                    {
                        foreach (string code_worker in boss_workers[code])
                        {
                            answer.Add($"{code_worker} {codes_names[code_worker]}");
                            if (boss_workers.ContainsKey(code_worker))
                            {
                                //Console.WriteLine($"{name} ------- > {code_worker}");
                                Search_boss_by_name(code_worker); // переполнение стека
                            }
                        }
                    }
                }
            }
            return answer;
        }
        static public void Show() // показывает все связи и все имена
        {
            foreach (string code in codes_names.Keys) 
            {
                Console.WriteLine($"{code} - {codes_names[code]}");
            }
            foreach (string code in boss_workers.Keys) 
            {
                Console.WriteLine($"!!! {code} !!!");
                foreach (string name in boss_workers[code]) 
                {
                    Console.Write($"{name}\t");
                }
                Console.WriteLine();
            }
        }
    }
}
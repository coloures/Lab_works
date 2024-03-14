using System.Runtime.CompilerServices;

namespace guess_the_number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //4
            //+ 2
            //* 3
            //- 5
            //- x
            //7
            // Иначе это можно представить строчкой
            // (х + 2) * 3 - 5 - х  = 7
            // 3х + 6 - 5 - х = 7
            // 2х + 1 = 7 ...
            // Представим х = 1: f (x) = 2 x + 1 => f (1) = 3
            // Фактически задача сводится к нахождению производной (в примерах нет х^2 или более)
            // Тогда пройдём циклом по строкам, предполагая, что производная х изначально равна единице
            // Если получится, что производная х = 1 и строк всего 2, то выдаём число последней строки
            for(int a = 1; a <= 12; a++) 
            {
                string sourse = $"E:\\Projects_VS\\Sets\\guess_the_number\\input_s1_{a.ToString("00")}.txt";
                StreamReader sr = new StreamReader(sourse);
                string line = "";
                List<string> strings = new List<string>();
                while (line != null)
                {
                    line = sr.ReadLine();
                    if (line != null)
                    {
                        strings.Add(line);
                    }
                }
                sr.Close();
                int temp_1 = 1;
                int sum = 1;
                if (strings.Count > 2)
                {
                    int steps = Convert.ToInt32(strings[0]);
                    int coeff = 1;
                    foreach (string str in strings)
                    {
                        if (str.Split(" ").Length > 1)
                        {
                            if (str.Split(" ")[1] == "x")
                            {
                                if (str.Split(" ")[0] == "-")
                                {
                                    coeff--;
                                }
                                else
                                {
                                    coeff++;
                                }
                            }
                            if (str.Split(" ")[0] == "*")
                            {
                                coeff *= Convert.ToInt32(str.Split(" ")[1]);
                            }
                        }
                    }
                    for (int i = 1; i < steps + 1; i++)
                    {
                        string[] info = strings[i].Split(" ");
                        if (info[0] == "+")
                        {
                            if (info[1] == "x")
                            {
                                sum += Convert.ToInt32(temp_1);
                            }
                            else
                            {
                                sum += Convert.ToInt32(info[1]);
                            }
                        }
                        else if (info[0] == "-")
                        {
                            if (info[1] == "x")
                            {
                                sum -= Convert.ToInt32(temp_1);
                            }
                            else
                            {
                                sum -= Convert.ToInt32(info[1]);
                            }
                        }
                        else
                        {
                            if (info[1] == "x")
                            {
                                sum *= Convert.ToInt32(temp_1);
                            }
                            else
                            {
                                sum *= Convert.ToInt32(info[1]);
                            }
                        }
                    }
                    Console.WriteLine($"coeff = {coeff}");
                    string way = $"E:\\Projects_VS\\Sets\\guess_the_number\\output_s1_{a.ToString("00")}.txt";
                    StreamWriter sw = new StreamWriter(way);
                    Console.WriteLine($"sum = {sum}; real = {Convert.ToInt32(strings.Last())}");
                    sw.WriteLine(temp_1 + (Convert.ToInt32(strings.Last()) - sum) / coeff);
                    sw.Close();
                }
                else
                {
                    string way = $"E:\\Projects_VS\\Sets\\guess_the_number\\output_s1_{a.ToString("00")}.txt";
                    StreamWriter sw = new StreamWriter(way);
                    sw.WriteLine(strings[1]);
                    sw.Close();
                }
            }
            
        }
    }
}

using System.ComponentModel.Design;
using System.Data;
using System.Net.NetworkInformation;

namespace gears
{
    internal class Program // РАБОТАЕТ!!!
    {
        static void Main(string[] args)
        {
            string source = @"E:\Projects_VS\Ford_Bellman_alg\gears\input_s1_13.txt";
            StreamReader sr = new StreamReader(source);
            string info = sr.ReadLine();
            Dictionary<int, int> info_about_gears = new Dictionary<int, int>();
            int[,] links = new int[Convert.ToInt32(info.Split(" ")[1]), 2];
            for (int i = 0; i < Convert.ToInt32(info.Split(" ")[0]); i++)
            {
                string temp = sr.ReadLine();
                info_about_gears.Add(Convert.ToInt32(temp.Split(" ")[0]), Convert.ToInt32(temp.Split(" ")[1]));
            }
            for (int i = 0; i < Convert.ToInt32(info.Split(" ")[1]); i++)
            {
                string temp = sr.ReadLine();
                links[i, 0] = Convert.ToInt32(temp.Split(" ")[0]); // соединение 1
                links[i, 1] = Convert.ToInt32(temp.Split(" ")[1]); // соединение 2
            }
            info = sr.ReadLine();
            int start = Convert.ToInt32(info.Split(" ")[0]); // точка начала
            int current_rounds; // зубцы
            double rounds = 1; // количество оборотов
            List<int> used = new List<int>();
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);
            int end = Convert.ToInt32(info.Split(" ")[1]); // точка конца
            int direction = Convert.ToInt32(sr.ReadLine());
            List<double[]> www = new List<double[]>();
            www.Add(new double[3] { start, rounds, direction });
            sr.Close();
            bool collision = false;
            while (queue.Count > 0)
            {
                if (collision)
                {
                    break;
                }
                bool cond = true;
                while (used.Contains(start))
                {
                    //Console.WriteLine(start + "->>>");
                    try
                    {
                        start = queue.Dequeue();
                        //Console.WriteLine("--->" + start);
                    }
                    catch (System.InvalidOperationException)
                    {
                        cond = false;
                        queue.Clear();
                        break;
                    }
                }
                if (!cond)
                {
                    break;
                }
                current_rounds = info_about_gears[start];
                for (int j = 0; j < www.Count(); j++)
                {
                    //Console.WriteLine($"{www[j][0]} {www[j][1]} {www[j][2]}");
                    if (Convert.ToInt32(www[j][0]) == start)
                    {
                        rounds = www[j][1];
                        direction = -1 * Convert.ToInt32(www[j][2]);
                    }
                }
                for (int i = 0; i <= links.GetUpperBound(0); i++)
                {
                    List<int> temp_nums = new List<int>();
                    foreach (double[] x in www)
                    {
                        temp_nums.Add(Convert.ToInt32(x[0]));
                    }
                    if ((links[i, 0] == start) && !temp_nums.Contains(links[i, 1]))
                    {
                        double a = current_rounds / (info_about_gears[links[i, 1]] * 1.0);
                        //Console.WriteLine($"{a} == a; {rounds} == rounds; {a * rounds} == a*rounds {links[i, 1]} - end");
                        www.Add(new double[3] { links[i, 1], a * rounds, direction });
                        queue.Enqueue(links[i, 1]);
                    }
                    else if ((links[i, 0] == start) && temp_nums.Contains(links[i, 1])) 
                    {
                        int d1 = 0;
                        int d2 = 1;
                        for (int j = 0; j < www.Count; j++)
                        {
                            if (Convert.ToInt32(www[j][0]) == start)
                            {
                                d1 = Convert.ToInt32(www[j][2]);
                            }
                            if (Convert.ToInt32(www[j][0]) == links[i, 1])
                            {
                                d2 = Convert.ToInt32(www[j][2]);
                            }

                        }
                        if (d1 == d2)
                        {
                            collision = true;
                        }
                    }
                }
                for (int i = 0; i <= links.GetUpperBound(0); i++)
                {
                    List<int> temp_nums = new List<int>();
                    foreach (double[] x in www)
                    {
                        temp_nums.Add(Convert.ToInt32(x[0]));
                    }
                    if ((links[i, 1] == start) && !temp_nums.Contains(links[i, 0]))
                    {
                        double a = current_rounds / (info_about_gears[links[i, 0]] * 1.0);
                        //Console.WriteLine($"{a} == a; {rounds} == rounds; {a * rounds} == a*rounds {links[i, 0]} - end");
                        www.Add(new double[3] { links[i, 0], a * rounds, direction });
                        //Console.WriteLine($"{links[i, 0]} -- {(current_rounds / (info_about_gears[links[i, 0]] * 1.0)) * rounds} -- {direction}   ");
                        queue.Enqueue(links[i, 0]);
                    }
                    else if ((links[i, 1] == start) && temp_nums.Contains(links[i, 0]))
                    {
                        int d1 = 0;
                        int d2 = 1;
                        for (int j = 0; j < www.Count; j++)
                        {
                            if (Convert.ToInt32(www[j][0]) == start)
                            {
                                d1 = Convert.ToInt32(www[j][2]);
                            }
                            if (Convert.ToInt32(www[j][0]) == links[i, 0])
                            {
                                d2 = Convert.ToInt32(www[j][2]);
                            }

                        }
                        if (d1 == d2)
                        {
                            collision = true;
                        }
                    }
                }
                used.Add(start);
            }
            int containing = -1;
            foreach (double[] x in www)
            {
                if (x[0] == end)
                {
                    containing = 1;
                }
            }
            if (containing == 1  && !collision)
            {
                foreach (double[] x in www)
                {
                    if (x[0] == end)
                    {
                        Console.WriteLine(1);
                        Console.WriteLine(x[2]);
                        Console.WriteLine(x[1].ToString("0.000"));
                    }
                }
            }
            else 
            {
                Console.WriteLine(-1);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ConsoleApplication16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                StreamReader sr = new StreamReader("D:\\Projects\\ConsoleApplication16\\input_s1_19.txt");
                //Console.Write("Введите ширину, глубину и высоту: ");
                string pos = sr.ReadLine();
                int[] poses = new int[3];
                int i = 0;
                foreach (string str in pos.Split(' '))
                {
                    poses[i++] = int.Parse(str);
                }
                i = 0;
                //Console.Write("Введите координаты паука: ");
                string pos_1 = sr.ReadLine();
                int[] spider_poses = new int[3];
                foreach (string str in pos_1.Split(' '))
                {
                    spider_poses[i++] = int.Parse(str);
                }
                i = 0;
                //Console.Write("Введите координаты мухи: ");
                string pos_2 = sr.ReadLine();
                int[] fly_poses = new int[3];
                foreach (string str in pos_2.Split(' '))
                {
                    fly_poses[i++] = int.Parse(str);
                }
                i = 0;
                double distance = 0;
                // координаты возможных сторон по 1 координате (Как грани)
                // они сравниваются с координатой мухи (одной)
                // и выбирается верное решение для каждого из 36 случаев
                if (spider_poses[0] == poses[0])
                {
                    if (fly_poses[1] == 0)
                    {
                        distance = Math.Sqrt((spider_poses[1] + poses[0] - fly_poses[0]) *
                            (spider_poses[1] + poses[0] - fly_poses[0]) + Math.Abs(spider_poses[2] - fly_poses[2]) * Math.Abs(spider_poses[2] - fly_poses[2]));
                    }
                    else if (fly_poses[1] == poses[1])
                    {
                        distance = Math.Sqrt((poses[1] - spider_poses[1] + poses[0] - fly_poses[0]) *
                            (poses[1] - spider_poses[1] + poses[0] - fly_poses[0]) + Math.Abs(spider_poses[2] - fly_poses[2]) * Math.Abs(spider_poses[2] - fly_poses[2]));
                    }
                    else if (fly_poses[2] == 0)
                    {
                        distance = Math.Sqrt((spider_poses[2] + poses[0] - fly_poses[0]) *
                            (spider_poses[2] + poses[0] - fly_poses[0]) + Math.Abs(spider_poses[1] - fly_poses[1]) * Math.Abs(spider_poses[1] - fly_poses[1]));
                    }
                    else if (fly_poses[2] == poses[2])
                    {
                        distance = Math.Sqrt((poses[2] - spider_poses[2] + poses[0] - fly_poses[0]) *
                            (poses[2] - spider_poses[2] + poses[0] - fly_poses[0]) + Math.Abs(spider_poses[1] - fly_poses[1]) * Math.Abs(spider_poses[1] - fly_poses[1]));
                    }
                    else if (fly_poses[0] == spider_poses[0])
                    {
                        int a = Math.Abs(fly_poses[1] - spider_poses[1]);
                        int b = Math.Abs(fly_poses[2] - spider_poses[2]);
                        distance = Math.Sqrt(a * a + b * b);
                    }
                    else if (fly_poses[0] == 0)
                    {
                        int a = spider_poses[1] + fly_poses[1] > 2 * poses[1] - spider_poses[1] - fly_poses[1]
                            ? 2 * poses[1] - spider_poses[1] - fly_poses[1] : spider_poses[1] + fly_poses[1];
                        int b = spider_poses[2] + fly_poses[2] > 2 * poses[2] - spider_poses[2] - fly_poses[2]
                            ? 2 * poses[2] - spider_poses[2] - fly_poses[2] : spider_poses[2] + fly_poses[2];
                        if (a < b)
                        {
                            Console.WriteLine(a + poses[0]);
                            Console.WriteLine(Math.Abs(spider_poses[2] - fly_poses[2]));
                            distance = Math.Sqrt((a + poses[0]) * (a + poses[0]) +
                                Math.Abs(spider_poses[2] - fly_poses[2]) * Math.Abs(spider_poses[2] - fly_poses[2]));
                        }
                        else
                        {
                            Console.WriteLine(b + poses[0]);
                            Console.WriteLine(Math.Abs(spider_poses[1] - fly_poses[1]));
                            distance = Math.Sqrt((b + poses[0]) * (b + poses[0]) +
                                Math.Abs(spider_poses[1] - fly_poses[1]) * Math.Abs(spider_poses[1] - fly_poses[1]));
                        }
                    }
                }
                else if (spider_poses[0] == 0)
                {
                    if (fly_poses[1] == 0)
                    {
                        distance = Math.Sqrt((spider_poses[1] + fly_poses[0]) * (spider_poses[1] + fly_poses[0]) +
                            Math.Abs(fly_poses[2] - spider_poses[2]) * Math.Abs(fly_poses[2] - spider_poses[2]));
                    }
                    else if (fly_poses[1] == poses[1])
                    {
                        distance = Math.Sqrt((poses[1] - spider_poses[1] + fly_poses[0]) * (poses[1] - spider_poses[1] + fly_poses[0]) +
                            Math.Abs(fly_poses[2] - spider_poses[2]) * Math.Abs(fly_poses[2] - spider_poses[2]));
                    }
                    else if (fly_poses[2] == 0)
                    {
                        distance = Math.Sqrt((spider_poses[2] + fly_poses[0]) * (spider_poses[2] + fly_poses[0]) +
                            Math.Abs(fly_poses[1] - spider_poses[1]) * Math.Abs(fly_poses[1] - spider_poses[1]));
                    }
                    else if (fly_poses[2] == poses[2])
                    {
                        distance = Math.Sqrt((poses[2] - spider_poses[2] + fly_poses[0]) * (poses[2] - spider_poses[2] + fly_poses[0]) +
                            Math.Abs(fly_poses[1] - spider_poses[1]) * Math.Abs(fly_poses[1] - spider_poses[1]));
                    }
                    else if (fly_poses[0] == spider_poses[0])
                    {
                        int a = Math.Abs(fly_poses[1] - spider_poses[1]);
                        int b = Math.Abs(fly_poses[2] - spider_poses[2]);
                        distance = Math.Sqrt((a * a + b * b));
                    }
                    else if (fly_poses[0] == poses[0])
                    {
                        int a = spider_poses[1] + fly_poses[1] > 2 * poses[1] - spider_poses[1] - fly_poses[1]
                            ? 2 * poses[1] - spider_poses[1] - fly_poses[1] : spider_poses[1] + fly_poses[1];
                        int b = spider_poses[2] = fly_poses[2] > 2 * poses[2] - spider_poses[2] - fly_poses[2]
                            ? 2 * poses[2] - spider_poses[2] - fly_poses[2] : spider_poses[2] = fly_poses[2];
                        if (a < b)
                        {
                            Console.WriteLine(a + poses[0]);
                            Console.WriteLine(Math.Abs(spider_poses[2] - fly_poses[2]));
                            distance = Math.Sqrt((a + poses[0]) * (a + poses[0]) +
                                Math.Abs(spider_poses[2] - fly_poses[2]) * Math.Abs(spider_poses[2] - fly_poses[2]));
                        }
                        else
                        {
                            Console.WriteLine(b + poses[0]);
                            Console.WriteLine(Math.Abs(spider_poses[1] - fly_poses[1]));
                            distance = Math.Sqrt((b + poses[0]) * (b + poses[0]) +
                                Math.Abs(spider_poses[1] - fly_poses[1]) * Math.Abs(spider_poses[1] - fly_poses[1]));
                        }
                    }

                }
                else if (spider_poses[1] == poses[1])
                {
                    if (fly_poses[0] == 0)
                    {
                        distance = Math.Sqrt((spider_poses[0] + poses[1] - fly_poses[1]) * (spider_poses[0] + poses[1] - fly_poses[1]) +
                            Math.Abs(spider_poses[2] - fly_poses[2]) * Math.Abs(spider_poses[2] - fly_poses[2]));
                    }
                    else if (fly_poses[0] == poses[0])
                    {
                        distance = Math.Sqrt((poses[0] - spider_poses[0] + poses[1] - fly_poses[1]) * (poses[0] - spider_poses[0] + poses[1] - fly_poses[1]) +
                            Math.Abs(spider_poses[2] - fly_poses[2]) * Math.Abs(spider_poses[2] - fly_poses[2]));
                    }
                    else if (fly_poses[2] == 0)
                    {
                        distance = Math.Sqrt((spider_poses[2] + poses[1] - fly_poses[1]) * (spider_poses[2] + poses[1] - fly_poses[1]) +
                            Math.Abs(spider_poses[0] - fly_poses[0]) * Math.Abs(spider_poses[0] - fly_poses[0]));
                    }
                    else if (fly_poses[2] == poses[2])
                    {
                        distance = Math.Sqrt((poses[2] - spider_poses[2] + poses[1] - fly_poses[1]) * (poses[2] - spider_poses[2] + poses[1] - fly_poses[1]) +
                            Math.Abs(spider_poses[0] - fly_poses[0]) * Math.Abs(spider_poses[0] - fly_poses[0]));
                    }
                    else if (fly_poses[1] == spider_poses[1])
                    {
                        int a = Math.Abs(fly_poses[0] - spider_poses[0]);
                        int b = Math.Abs(fly_poses[2] - spider_poses[2]);
                        distance = Math.Sqrt(a * a + b * b);
                    }
                    else if (fly_poses[1] == 0)
                    {
                        int a = spider_poses[2] + fly_poses[2] > 2 * poses[2] - spider_poses[2] - fly_poses[2] ?
                            2 * poses[2] - spider_poses[2] - fly_poses[2] : spider_poses[2] + fly_poses[2];
                        int b = spider_poses[0] + fly_poses[0] > 2 * poses[0] - spider_poses[0] - fly_poses[0] ?
                            2 * poses[0] - spider_poses[0] - fly_poses[0] : spider_poses[0] + fly_poses[0];
                        if (a < b)
                        {
                            Console.WriteLine("heeey");
                            Console.WriteLine(a + poses[1]);
                            Console.WriteLine(Math.Abs(spider_poses[0] - fly_poses[0]));
                            distance = Math.Sqrt((a + poses[1]) * (a + poses[1]) +
                                Math.Abs(spider_poses[0] - fly_poses[0]) * Math.Abs(spider_poses[0] - fly_poses[0]));
                        }
                        else
                        {
                            Console.WriteLine("heeey");
                            Console.WriteLine(b + poses[1]);
                            Console.WriteLine(Math.Abs(spider_poses[2] - fly_poses[2]));
                            distance = Math.Sqrt((b + poses[1]) * (b + poses[1]) +
                                Math.Abs(spider_poses[2] - fly_poses[2]) * Math.Abs(spider_poses[2] - fly_poses[2]));
                        }
                    }
                }
                else if (spider_poses[1] == 0)
                {
                    if (fly_poses[0] == 0)
                    {
                        distance = Math.Sqrt((spider_poses[0] + fly_poses[1]) * (spider_poses[0] + fly_poses[1]) +
                            Math.Abs(spider_poses[2] - fly_poses[2]) * Math.Abs(spider_poses[2] - fly_poses[2]));
                    }
                    else if (fly_poses[0] == poses[0])
                    {
                        distance = Math.Sqrt((poses[0] - spider_poses[0] + fly_poses[1]) * (poses[0] - spider_poses[0] + fly_poses[1]) +
                            Math.Abs(spider_poses[2] - fly_poses[2]) * Math.Abs(spider_poses[2] - fly_poses[2]));
                    }
                    else if (fly_poses[2] == 0)
                    {
                        distance = Math.Sqrt((spider_poses[2] + fly_poses[1]) * (spider_poses[2] + fly_poses[1]) +
                            Math.Abs(spider_poses[0] - fly_poses[0]) * Math.Abs(spider_poses[0] - fly_poses[0]));
                    }
                    else if (fly_poses[2] == poses[2])
                    {
                        distance = Math.Sqrt((poses[2] - spider_poses[2] + fly_poses[1]) * (poses[2] - spider_poses[2] + fly_poses[1]) +
                            Math.Abs(spider_poses[0] - fly_poses[0]) * Math.Abs(spider_poses[0] - fly_poses[0]));
                    }
                    else if (fly_poses[1] == poses[1])
                    {
                        int a = spider_poses[0] + fly_poses[0] > 2 * poses[0] - spider_poses[0] - fly_poses[0] ?
                            2 * poses[0] - spider_poses[0] - fly_poses[0] : spider_poses[0] + fly_poses[0];
                        int b = spider_poses[2] + fly_poses[2] > 2 * poses[2] - spider_poses[2] - fly_poses[2] ?
                            2 * poses[2] - spider_poses[2] - fly_poses[2] : spider_poses[2] + fly_poses[2];
                        if (a < b)
                        {
                            Console.WriteLine(a + poses[1]);
                            Console.WriteLine(Math.Abs(spider_poses[2] - fly_poses[2]));
                            distance = Math.Sqrt((a + poses[1]) * (a + poses[1]) +
                                Math.Abs(spider_poses[2] - fly_poses[2]) * Math.Abs(spider_poses[2] - fly_poses[2]));
                        }
                        else
                        {
                            Console.WriteLine(b + poses[1]);
                            Console.WriteLine(Math.Abs(spider_poses[0] - fly_poses[0]));
                            distance = Math.Sqrt((b + poses[1]) * (b + poses[1]) +
                                Math.Abs(spider_poses[0] - fly_poses[0]) * Math.Abs(spider_poses[0] - fly_poses[0]));
                        }
                    }
                    else if (fly_poses[1] == spider_poses[1])
                    {
                        int a = Math.Abs(fly_poses[0] - spider_poses[0]);
                        int b = Math.Abs(fly_poses[2] - spider_poses[2]);
                        distance = Math.Sqrt(a * a + b * b);
                    }
                }
                else if (spider_poses[2] == poses[2])
                {
                    if (fly_poses[0] == 0)
                    {
                        distance = Math.Sqrt((spider_poses[0] + poses[2] - fly_poses[2]) * (spider_poses[0] + poses[2] - fly_poses[2]) +
                            Math.Abs(spider_poses[1] - fly_poses[1]) * Math.Abs(spider_poses[1] - fly_poses[1]));
                    }
                    else if (fly_poses[0] == poses[0])
                    {
                        distance = Math.Sqrt((poses[0] - spider_poses[0] + poses[2] - fly_poses[2]) * (poses[0] - spider_poses[0] + poses[2] - fly_poses[2]) +
                            Math.Abs(spider_poses[1] - fly_poses[1]) * Math.Abs(spider_poses[1] - fly_poses[1]));
                    }
                    else if (fly_poses[1] == 0)
                    {
                        distance = Math.Sqrt((spider_poses[1] + poses[2] - fly_poses[2]) * (spider_poses[1] + poses[2] - fly_poses[2]) +
                            Math.Abs(spider_poses[0] - fly_poses[0]) * Math.Abs(spider_poses[0] - fly_poses[0]));
                    }
                    else if (fly_poses[1] == poses[1])
                    {
                        distance = Math.Sqrt((poses[1] - spider_poses[1] + poses[2] - fly_poses[2]) * (poses[1] - spider_poses[1] + poses[2] - fly_poses[2]) +
                            Math.Abs(spider_poses[0] - fly_poses[0]) * Math.Abs(spider_poses[0] - fly_poses[0]));
                    }
                    else if (fly_poses[2] == spider_poses[2])
                    {
                        int a = Math.Abs(fly_poses[0] - spider_poses[0]);
                        int b = Math.Abs(fly_poses[1] - spider_poses[1]);
                        distance = Math.Sqrt(a * a + b * b);
                    }
                    else if (fly_poses[2] == 0)
                    {
                        int a = spider_poses[1] + fly_poses[1] > 2 * poses[1] - spider_poses[1] - fly_poses[1] ?
                            2 * poses[1] - spider_poses[1] - fly_poses[1] : spider_poses[1] + fly_poses[1];
                        int b = spider_poses[0] + fly_poses[0] > 2 * poses[0] - spider_poses[0] - fly_poses[0] ?
                            2 * poses[0] - spider_poses[0] - fly_poses[0] : spider_poses[0] + fly_poses[0];
                        if (a < b)
                        {
                            Console.WriteLine(a + poses[2]);
                            Console.WriteLine(Math.Abs(spider_poses[0] - fly_poses[0]));
                            distance = Math.Sqrt((a + poses[2]) * (a + poses[2]) +
                                Math.Abs(spider_poses[0] - fly_poses[0]) * Math.Abs(spider_poses[0] - fly_poses[0]));
                        }
                        else
                        {
                            Console.WriteLine(b + poses[2]);
                            Console.WriteLine(Math.Abs(spider_poses[1] - fly_poses[1]));
                            distance = Math.Sqrt((b + poses[2]) * (b + poses[2]) +
                                Math.Abs(spider_poses[1] - fly_poses[1]) * Math.Abs(spider_poses[1] - fly_poses[1]));
                        }
                    }

                }
                else if (spider_poses[2] == 0)
                {
                    if (fly_poses[0] == 0)
                    {
                        distance = Math.Sqrt((spider_poses[0] + fly_poses[2]) * (spider_poses[0] + fly_poses[2]) +
                            Math.Abs(spider_poses[1] - fly_poses[1]) * Math.Abs(spider_poses[1] - fly_poses[1]));
                    }
                    else if (fly_poses[0] == poses[0])
                    {
                        distance = Math.Sqrt((poses[0] - spider_poses[0] + fly_poses[2]) * (poses[0] - spider_poses[0] + fly_poses[2]) +
                            Math.Abs(spider_poses[1] - fly_poses[1]) * Math.Abs(spider_poses[1] - fly_poses[1]));
                    }
                    else if (fly_poses[1] == 0)
                    {
                        distance = Math.Sqrt((spider_poses[1] + fly_poses[2]) * (spider_poses[1] + fly_poses[2]) +
                            Math.Abs(spider_poses[0] - fly_poses[0]) * Math.Abs(spider_poses[0] - fly_poses[0]));
                    }
                    else if (fly_poses[1] == poses[1])
                    {
                        distance = Math.Sqrt((poses[1] - spider_poses[1] + fly_poses[2]) * (poses[1] - spider_poses[1] + fly_poses[2]) +
                            Math.Abs(spider_poses[0] - fly_poses[0]) * Math.Abs(spider_poses[0] - fly_poses[0]));
                    }
                    else if (fly_poses[2] == spider_poses[2])
                    {
                        int a = Math.Abs(spider_poses[0] - fly_poses[0]);
                        int b = Math.Abs(spider_poses[1] - fly_poses[1]);
                        distance = Math.Sqrt(a * a + b * b);
                    }
                    else if (fly_poses[2] == poses[2])
                    {
                        int a = spider_poses[1] + fly_poses[1] > 2 * poses[1] - spider_poses[1] - fly_poses[1] ?
                            2 * poses[1] - spider_poses[1] - fly_poses[1] : spider_poses[1] + fly_poses[1];
                        int b = spider_poses[0] + fly_poses[0] > 2 * poses[0] - spider_poses[0] - fly_poses[0] ?
                            2 * poses[0] - spider_poses[0] - fly_poses[0] : spider_poses[0] + fly_poses[0];
                        if (a < b)
                        {
                            Console.WriteLine(a + poses[2]);
                            Console.WriteLine(Math.Abs(spider_poses[0] - fly_poses[0]));
                            distance = Math.Sqrt((a + poses[2]) * (a + poses[2]) +
                                Math.Abs(spider_poses[0] - fly_poses[0]) * Math.Abs(spider_poses[0] - fly_poses[0]));
                        }
                        else
                        {
                            Console.WriteLine(b + poses[2]);
                            Console.WriteLine(Math.Abs(spider_poses[1] - fly_poses[1]));
                            distance = Math.Sqrt((b + poses[2]) * (b + poses[2]) +
                                Math.Abs(spider_poses[1] - fly_poses[1]) * Math.Abs(spider_poses[1] - fly_poses[1]));
                        }
                    }
                }
                //Console.WriteLine(distance);
                try
                {
                    StreamWriter sw = new StreamWriter("D:\\Projects\\ConsoleApplication16\\output_s1_19.txt");
                    sw.WriteLine(string.Format("{0:F3}",distance));
                    sw.Close();
                }
                finally 
                {
                }
                sr.Close();
            }
            finally 
            {
            }
        }
    }
}

using System.Diagnostics;

namespace Ford_Bellman_alg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int points = Convert.ToInt32(Console.ReadLine());
            double[,] matrix_of_weights = new double[points, points];
            for (int i = 0; i < points; i++) 
            {
                for (int j = 0; j < points; j++) 
                {
                    matrix_of_weights[i, j] = double.PositiveInfinity;
                }
            }
            int ways = Convert.ToInt32(Console.ReadLine());
            for(int i = 0;  i < ways; i++) 
            {
                string way = Console.ReadLine();
                matrix_of_weights[Convert.ToInt32(way.Split(" ")[0]) - 1, Convert.ToInt32(way.Split(" ")[1]) - 1] = Convert.ToInt32(way.Split(" ")[2]); 
            }
            double[] prev = new double[points];
            double[] next = new double[points];
            int point = Convert.ToInt32(Console.ReadLine());
            for(int i = 0; i < points; i++) 
            {
                if (i == point - 1)
                {
                    prev[i] = 0;
                }
                else 
                {
                    prev[i] = matrix_of_weights[point - 1, i];
                }
            }
            int cond = 0;
            for (int i = 0; i < points; i++) 
            {
                if (cond != 0) 
                {
                    break;
                }
                prev.CopyTo(next, 0);
                for (int j = 0; j < points; j++) 
                {
                    if (j != point - 1) 
                    {
                        for (int k = 0; k < points; k++) 
                        {
                            next[j] = next[j] > prev[k] + matrix_of_weights[k, j] ? prev[k] + matrix_of_weights[k, j] : next[j];
                        }
                    }
                }
                for (int j = 0; j < next.Length; j++) 
                {
                    if (next[j] != prev[j]) 
                    {
                        cond = 0;
                        break;
                    }
                    cond = 1;
                }
                next.CopyTo(prev, 0);
            }
            for (int i = 0; i < points; i++)
            {
                if (cond == 1) 
                {
                    break;
                }
                if(i != point - 1) 
                {
                    double temp = next[i];
                    int t = i;
                    List<int> list = new List<int>();
                    while (temp != 0) 
                    {
                        for (int j = 0; j < points; j++) 
                        {
                            if (temp - matrix_of_weights[j, t] == next[j]) 
                            {
                                list.Add(j);
                                temp -= matrix_of_weights[j, t];
                                t = j;
                            }
                        }
                    }
                    Console.WriteLine($"Way from point {point} to {i + 1}:");
                    foreach (int j in list) 
                    {
                        Console.Write($"{j+1}\t");
                    }
                    Console.WriteLine();
                    Console.WriteLine($"It's weight: {next[i]}");
                }
            }
            if (cond != 1)
            {
                Console.WriteLine("Whole smallest ways:");
                foreach (int i in next)
                {
                    Console.Write(i + "\t");
                }
            }
            else 
            {
                Console.WriteLine("There are negative loops!!!");
            }

        }
    }
}
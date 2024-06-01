using System.Reflection;

namespace Ford_Fulkerson_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int points = Convert.ToInt32(Console.ReadLine());
            int ribes = Convert.ToInt32(Console.ReadLine());
            int source = Convert.ToInt32(Console.ReadLine());
            int destination = Convert.ToInt32(Console.ReadLine());
            int[,] weights = new int[points, points];
            int[,] weights_temp = new int[points, points];
            for (int i = 0; i < ribes; i++)
            {
                string ribe = Console.ReadLine();
                weights[Convert.ToInt32(ribe.Split(" ")[0]) - 1, Convert.ToInt32(ribe.Split(" ")[1]) - 1] = Convert.ToInt32(ribe.Split(" ")[2]);
                //weights_temp[Convert.ToInt32(ribe.Split(" ")[0]) - 1, Convert.ToInt32(ribe.Split(" ")[1]) - 1] = Convert.ToInt32(ribe.Split(" ")[2]);
            }
            for (int i = 0; i < points; i++)
            {
                for (int j = 0; j < points; j++)
                {
                    Console.Write($"{weights[i, j]}\t");
                }
                Console.WriteLine();
            }
            int cond;
            int sum = 0;
            do
            {
                cond = Ford_Fulkerson_iter_to(ref weights, source, destination);
                sum += cond;
            }
            while (cond != 0);
            do
            {
                cond = Ford_Fulkerson_iter_back(ref weights, source, destination);
                sum += cond;
            }
            while (cond != 0);
            Console.WriteLine();
            for (int i = 0; i < points; i++)
            {
                for (int j = 0; j < points; j++)
                {
                    Console.Write($"{weights[i, j]}\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine(sum);

        }
        static int Ford_Fulkerson_iter_back(ref int[,] ints, int source, int destination) 
        {
            int[,] ints1 = new int[ints.GetLength(0), ints.GetLength(0)];
            for (int i = 0; i < ints1.GetLength(0); i++) { for (int j = 0; j < ints1.GetLength(1); j++) { 
                    if (ints[i, j] < 0) { ints1[i, j] = -ints[i, j]; } 
                    else { ints1[i, j] = ints[i, j]; } } } // новая матрица с абсолютными величинами.
            List<int> ints2 = width_alg_2(ints1, source, destination);
            int min = int.MaxValue;
            if (ints2 != null)
            {
                for (int i = 0; i < ints2.Count - 1;)
                {
                    for (int j = i + 1; j < ints2.Count; j++, i++)
                    {
                        min = min > ints[ints2[i] - 1, ints2[j] - 1] ? ints[ints2[i] - 1, ints2[j] - 1] : min;
                    }
                }
                for (int i = 0; i < ints2.Count - 1;)
                {
                    for (int j = i + 1; j < ints2.Count; j++, i++)
                    {
                        if (ints[ints2[i] - 1, ints2[j] - 1] > 0)
                        {
                            ints[ints2[i] - 1, ints2[j] - 1] -= min;
                            ints[ints2[j] - 1, ints2[i] - 1] -= min;
                        }
                        else 
                        {
                            ints[ints2[i] - 1, ints2[j] - 1] += min;
                            ints[ints2[j] - 1, ints2[i] - 1] += min;
                        }
                    }
                }
                return min;

            }
            else { return 0; }
        }
        static int Ford_Fulkerson_iter_to(ref int[,] ints, int source, int destination) 
        {
            int[,] ints1 = new int[ints.GetLength(0), ints.GetLength(0)];
            for (int i = 0; i < ints1.GetLength(0); i++) { for (int j = 0; j < ints1.GetLength(1); j++) { ints1[i, j] = ints[i, j]; } }
            List<int> ints2 = width_alg_2(ints1, source, destination);
            int min = int.MaxValue;
            if (ints2 != null)
            {
                for (int i = 0; i < ints2.Count - 1;) 
                {
                    for (int j = i + 1; j < ints2.Count; j++, i++) 
                    {
                        min = min > ints[ints2[i]-1,ints2[j]-1] ? ints[ints2[i]-1, ints2[j]-1] : min;
                    }
                }
                for (int i = 0; i < ints2.Count - 1;)
                {
                    for (int j = i + 1; j < ints2.Count; j++, i++)
                    {
                        ints[ints2[i] - 1, ints2[j] - 1] -= min;
                        ints[ints2[j] - 1, ints2[i]-1] -= min;
                    }
                }
                return min;

            }
            else { return 0; }

        }
        static List<int> width_alg_2(in int[,] weights, int source, int destination) // меняет массив
        {
            int source_original = source;
            int[,] weights_original = new int[weights.GetLength(0), weights.GetLength(1)];
            for (int i = 0; i < weights.GetLength(0); i++)
            {
                for (int j = 0; j < weights.GetLength(1); j++)
                {
                    if (weights[i, j] <= 0) { weights[i, j] = 101; }
                    else { weights[i, j] = -weights[i, j]; }
                    weights_original[i, j] = weights[i, j];
                }
            }
            List<int> ints = new List<int>() { source };
            int[,] met = new int[2, weights.GetLength(0)];
            for (int i = 0; i < met.GetLength(0); i++)
            {
                for (int j = 0; j < met.GetLength(1); j++) { met[i, j] = int.MinValue; }
            }
            met[0, source - 1] = int.MinValue;
            met[1, source - 1] = source;
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(source);
            while (queue.Count > 0)
            {
                source = queue.Dequeue();
                int[,] ls = new int[2, weights.GetLength(0)];
                for (int i = 0; i <= weights.GetUpperBound(0); i++)
                {
                    ls[0, i] = weights[source - 1, i];
                    ls[1, i] = i + 1;
                }
                for (int i = 0; i < ls.GetLength(1) - 1; i++)
                {
                    for (int j = i + 1; j < ls.GetLength(1); j++)
                    {
                        if (ls[0, i] > ls[0, j])
                        {
                            int m = ls[1, i];
                            ls[1, i] = ls[1, j];
                            ls[1, j] = m;
                            int t = ls[0, i];
                            ls[0, i] = ls[0, j];
                            ls[0, j] = t;
                        }
                    }
                }
                for (int i = 0; i <= ls.GetUpperBound(1); i++)
                {
                    if (ls[0, i] < 0)
                    {
                        if (met[0, ls[1, i] - 1] < Math.Max(met[0, source - 1], ls[0, i]) && met[1, ls[1, i] - 1] == int.MinValue)
                        {
                            met[0, ls[1, i] - 1] = Math.Max(met[0, source - 1], ls[0, i]);
                            met[1, ls[1, i] - 1] = source;
                            queue.Enqueue(ls[1, i]);
                        }
                    }
                }
                ints.Add(source);
            }
            List<int> way = new List<int>() { destination };
            bool cond_ = false;
            if (met[0, destination - 1] != int.MinValue)
            {
                while (destination != source_original)
                {
                    destination = met[1, destination - 1];
                    way.Add(destination);
                }
                cond_ = true;
            }
            if (!cond_)
            {
                return null;
            }
            way.Reverse();
            return way;

        }

    }
}
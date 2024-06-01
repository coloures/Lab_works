namespace Florens
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[,] weights = { { double.PositiveInfinity, 1, 1, 1, double.PositiveInfinity, double.PositiveInfinity , 1},
                {1, double.PositiveInfinity, 1, double.PositiveInfinity, 1 , double.PositiveInfinity, 1  },
                {1, 1, double.PositiveInfinity, 1, 1, 1, 1 },
                {1, double.PositiveInfinity, 1, double.PositiveInfinity, 1, 1, 1 },
                {double.PositiveInfinity, 1, 1, 1, double.PositiveInfinity, 1, double.PositiveInfinity },
                {double.PositiveInfinity,double.PositiveInfinity,1,1,1,double.PositiveInfinity, 1 },
                {double.PositiveInfinity, 1, 1, 1, double.PositiveInfinity, 1, double.PositiveInfinity } };
            //for(int i = 0; i < weights.GetLength(0); i++) 
            //{
            //    for (int j = 0; j < weights.GetLength(1); j++) 
            //    {
            //        Console.Write(weights[i,j]+"\t");    
            //    }
            //    Console.WriteLine();
            //}
            List<List<int>> ways = new List<List<int>>();
            List<List<int>> cycles = new List<List<int>>();
            Florens(ref ways, ref cycles, weights);
            Console.WriteLine($"Пути:");
            foreach(List<int> way in ways) 
            {
                //Console.WriteLine($"{way.Count} = count");
                foreach (int i in way) { Console.Write(i + "  "); }
                Console.WriteLine();
            }
            Console.WriteLine($"Циклы:");
            foreach (List<int> cycle in cycles) 
            {
                foreach (int i in cycle) { Console.Write(i + "  "); }
                Console.WriteLine() ;
            }

        }
        static void Florens(ref List<List<int>> ways, ref List<List<int>> cycles, double[,] weights, List<int> way = null) 
        {
            List<int> list = new List<int>();
            if (way == null)
            {
                list.Add(1);
                Florens(ref ways, ref cycles, weights, list);
            }
            else if (way.Count == weights.GetUpperBound(0)+1) 
            {
                List<int> temp = new List<int>();
                foreach (int i in way) { temp.Add(i);}
                if (weights[way.Last() - 1, way.First() - 1] != double.PositiveInfinity)
                {
                    temp.Add(way.First());
                    cycles.Add(temp);
                }
                else { ways.Add(temp); }
            }
            else
            {
                list = way;
                List<int> checking = new List<int>();
                for (int i = 0; i < weights.GetLength(1); i++)
                {
                    if (weights[list.Last() - 1, i] != double.PositiveInfinity && !list.Contains(i + 1))
                    {
                        checking.Add(i + 1);
                    }
                }
                foreach (int i in checking)
                {
                    list.Add(i);
                    Florens(ref ways, ref cycles, weights, list);
                    list.Remove(i);
                }

            }
        }
    }
}
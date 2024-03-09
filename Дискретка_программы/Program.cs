using System.Linq;

namespace Dijkstra_algorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> points = new List<string>();
            List<string> links = new List<string>();
            List<int> weights = new List<int>();
            List<int> checked_points = new List<int>();
            int N = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i < N + 1; i++)
            {
                points.Add(Convert.ToString(i));
            }
            int[,] points_with_weight = new int[2, points.Count];
            for (int i = 0; i < points.Count; i++)
            {
                points_with_weight[0, i] = Convert.ToInt32(points[i]);
                points_with_weight[1, i] = int.MaxValue;
            }
            int M = Convert.ToInt32(Console.ReadLine())*2;
            for (int i = 0; i < M; i++)
            {
                string[] link_str = Console.ReadLine().Split(' ');
                links.Add($"{link_str[0]},{link_str[1]}");
                weights.Add(Convert.ToInt32(link_str[2]));
            }
            string Way_needed = Console.ReadLine();
            points_with_weight[1, Convert.ToInt32(Way_needed.Split(" ")[0]+"") - 1] = 0;
            int current_point = Convert.ToInt32(Way_needed.Split(" ")[0] + "");
            while (checked_points.Count < points.Count) 
            {
                checked_points.Add(current_point);
                foreach (string link in links) 
                {
                    if (link.Split(",")[0] == Convert.ToString(current_point)) 
                    {
                        points_with_weight[1, Convert.ToInt32(link.Split(",")[1]+"") - 1] = weights[links.IndexOf(link)] +
                            points_with_weight[1, current_point - 1] < points_with_weight[1, Convert.ToInt32(link.Split(",")[1] + "") - 1] ? weights[links.IndexOf(link)] +
                            points_with_weight[1, current_point - 1] : points_with_weight[1, Convert.ToInt32(link.Split(",")[1] + "") - 1];
                    }

                }
                int smallest = int.MaxValue;
                if (current_point == Convert.ToInt32(Way_needed.Split(" ")[1] + "")) 
                {
                    break;
                }
                for (int i = 0; i < points_with_weight.GetUpperBound(1) + 1; i++)
                {
                    if (points_with_weight[1, i] < smallest && !checked_points.Contains(points_with_weight[0, i]))
                    {
                        current_point = points_with_weight[0, i];
                        smallest = points_with_weight[1, i];
                    }
                }
            }
            List<int> way = new List<int>();
            Console.WriteLine(points_with_weight[1,current_point - 1]);
            way.Add(current_point);
            while (current_point != Convert.ToInt32(Way_needed.Split(" ")[0] + "")) 
            {
                int temp = points_with_weight[1, current_point - 1];
                foreach (string link in links) 
                {
                    if (Convert.ToInt32(link.Split(",")[1]) == current_point && temp == weights[links.IndexOf(link)] + points_with_weight[1, Convert.ToInt32(link.Split(",")[0])-1]) 
                    {
                        current_point = Convert.ToInt32(link.Split(",")[0]);
                    }
                }
                way.Add(current_point);
            }
            way.Reverse();
            foreach (int point in way) { Console.Write(point + "\t"); }
        }
    }
}
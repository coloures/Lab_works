using System.Linq;
using System.Linq.Expressions;

namespace Kruskal_s_algorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] points = Console.ReadLine().Split(',');
            points[0] = points[0][1] + "";
            points[points.GetUpperBound(0)] = points[points.GetUpperBound(0)][0] + "";
            string[] links = Console.ReadLine().Split("}, {");
            links[0] = links[0].Substring(2);
            links[links.GetUpperBound(0)] = links[links.GetUpperBound(0)].Substring(0, 3);
            string[] weights = Console.ReadLine().Split(", ");
            List <Array> Ways_temp = new List<Array>();
            List<Array> Ways = new List<Array>();
            for ( int i = 0; i < weights.Length; i++ ) 
            {
                Ways_temp.Add(new int[3] { Convert.ToInt32(weights[i]),Convert.ToInt32("" + links[i][0]), Convert.ToInt32("" + links[i][2]) }); 
            } // массив: (вес ребра, первый узел, второй узел)
            List<int> temp = new List<int>();
            foreach (Array Way in Ways_temp) 
            {
                temp.Add(Convert.ToInt32(Way.GetValue(0)));
            }
            temp.Sort();
            int a = Ways_temp.Count;
            for (int i = 0; i < a; i++) 
            {
                foreach (Array Way in Ways_temp) 
                {
                    if (Convert.ToInt32(Way.GetValue(0)) == temp[i]) 
                    {
                        Ways.Add(Way);
                        Ways_temp.Remove(Way);
                        break;
                    }
                }
            }
            List<int> Used_points = new List<int>(); // использованные вершины
            Dictionary<int, List<int>> Stacks_of_ways = new Dictionary<int, List<int>>(); // "кучи вершин"
            List<Array> Used_ways = new List<Array>(); // использованные пути
            foreach(Array way in  Ways) // как в алгоритме : "перебор" рёбер
            {
                if (!Used_points.Contains(Convert.ToInt32(way.GetValue(1))) && !Used_points.Contains(Convert.ToInt32(way.GetValue(2))))
                {
                    Stacks_of_ways[Convert.ToInt32(way.GetValue(1))] = new List<int>() { Convert.ToInt32(way.GetValue(1)), Convert.ToInt32(way.GetValue(2)) };
                    Stacks_of_ways[Convert.ToInt32(way.GetValue(2))] = Stacks_of_ways[Convert.ToInt32(way.GetValue(1))];
                    Used_points.Add(Convert.ToInt32(way.GetValue(1)));
                    Used_points.Add(Convert.ToInt32(way.GetValue(2)));
                    Used_ways.Add(way);
                } // если обеих вершин нет в списке использованных
                else if (Used_points.Contains(Convert.ToInt32(way.GetValue(1))) && !Used_points.Contains(Convert.ToInt32(way.GetValue(2))))
                {
                    Stacks_of_ways[Convert.ToInt32(way.GetValue(1))].Add(Convert.ToInt32(way.GetValue(2)));
                    Stacks_of_ways[Convert.ToInt32(way.GetValue(2))] = Stacks_of_ways[Convert.ToInt32(way.GetValue(1))];
                    Used_points.Add(Convert.ToInt32(way.GetValue(2)));
                    Used_ways.Add(way);
                } // одна из вершин уже принадлежит списку
                else if (!Used_points.Contains(Convert.ToInt32(way.GetValue(1))) && Used_points.Contains(Convert.ToInt32(way.GetValue(2))))
                {
                    Stacks_of_ways[Convert.ToInt32(way.GetValue(2))].Add(Convert.ToInt32(way.GetValue(1)));
                    Stacks_of_ways[Convert.ToInt32(way.GetValue(1))] = Stacks_of_ways[Convert.ToInt32(way.GetValue(2))];
                    Used_points.Add(Convert.ToInt32(way.GetValue(1)));
                    Used_ways.Add(way);
                } // одна из вершин уже принадлежит списку
            }
            //foreach(int point in Used_points) { Console.WriteLine(point); }
            Used_points.Clear();
            foreach (Array way in Ways)
            {
                if (!Stacks_of_ways[Convert.ToInt32(way.GetValue(1))].Contains(Convert.ToInt32(way.GetValue(2))))
                {
                    Used_ways.Add(way);
                    foreach(int point in Stacks_of_ways[Convert.ToInt32(way.GetValue(1))]) 
                    {
                        Used_points.Add(point);
                    }
                    foreach (int point in Stacks_of_ways[Convert.ToInt32(way.GetValue(2))])
                    {
                        Used_points.Add(point);
                    }
                    foreach (int point in Stacks_of_ways[Convert.ToInt32(way.GetValue(2))])
                    {
                        Stacks_of_ways[Convert.ToInt32(way.GetValue(1))].Add(point);
                    }
                    Console.WriteLine(Used_points.Count);
                    List<int> points_ = new List<int>();
                    foreach (int point in Stacks_of_ways[Convert.ToInt32(way.GetValue(2))])
                    {
                        points_.Add(point);
                    }
                    foreach (int point in points_) 
                    {
                        Stacks_of_ways[point] = Stacks_of_ways[Convert.ToInt32(way.GetValue(1))];
                    }
                } // отчужденные друг от друга кучи
            }
            if (Used_points.Count() == points.Count())
            {
                foreach (var way in Used_ways)
                {
                    Console.WriteLine($"{way.GetValue(0)}  {way.GetValue(1)}  {way.GetValue(2)}");
                }
            }
            else 
            {
                Console.WriteLine("-1");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication13
{
    class Program // Алгоритм Прима
    {
        static void Main(string[] args)
        {
            List<string> points = new List<string>() {"1", "2", "3", "4", "5", "6", "7", "8", "9" };
            List<string> used_points = new List<string>();
            List<string> used_ways = new List<string>();
            int sum = 0;
            List<string> links = new List<string>() { "1,2", "1,5", "1,4", "2,3", "2,4", "2,5", "3,5", "3,6", "4,5", "4,7", "4,8", "5,6", "5,8", "5,9", "7,8", "8,9" };
            List<int> weights = new List<int>() { 15, 14, 23, 19, 16, 15, 14, 26, 25, 23, 20, 24, 27, 18, 14, 18 };
            used_points.Add(points[0]);
            while(true)
            {
                if (used_points.Count == points.Count)
                { break; }
                if (links.Contains(string.Format("{0},{1}", find_way(links, weights, used_points).GetValue(0), find_way(links, weights, used_points).GetValue(1))))
                {
                    sum += weights[links.IndexOf(string.Format("{0},{1}", find_way(links, weights, used_points).GetValue(0), find_way(links, weights, used_points).GetValue(1)))];
                    used_ways.Add(string.Format("{0},{1}", find_way(links, weights, used_points).GetValue(0), find_way(links, weights, used_points).GetValue(1)));
                    used_points.Add(find_way(links, weights, used_points).GetValue(1).ToString());
                }
                else if (links.Contains(string.Format("{0},{1}", find_way(links, weights, used_points).GetValue(1), find_way(links, weights, used_points).GetValue(0))))
                {
                    sum += weights[links.IndexOf(string.Format("{0},{1}", find_way(links, weights, used_points).GetValue(1), find_way(links, weights, used_points).GetValue(0)))];
                    used_ways.Add(string.Format("{0},{1}", find_way(links, weights, used_points).GetValue(1), find_way(links, weights, used_points).GetValue(0)));
                    used_points.Add(find_way(links, weights, used_points).GetValue(1).ToString());
                }
            }
            foreach (string ways in used_ways) 
            {
                Console.WriteLine(ways);
            }
            Console.WriteLine(sum);
            string a = Console.ReadLine();


        }
        static Array find_way(List<string> links, List<int> weights, List<string> used_points)
        {
            int the_smallest = weights.Max()+1;
            string next_point = string.Empty;
            string current_point = string.Empty;
            foreach (string point in used_points) 
            {
                foreach (string link in links)
                {
                    if ((link[0]).ToString() == point)
                    {
                        if (!used_points.Contains((link[2]).ToString()))
                        {
                            if (the_smallest > weights[links.IndexOf(link)])
                            {
                                the_smallest = weights[links.IndexOf(link)];
                                next_point = link[2].ToString();
                                current_point = point;
                            }
                        }
                    }
                    else if ((link[2]).ToString() == point)
                    {
                        if (!used_points.Contains((link[0]).ToString()))
                        {
                            if (the_smallest > weights[links.IndexOf(link)])
                            {
                                the_smallest = weights[links.IndexOf(link)];
                                next_point = link[0].ToString();
                                current_point = point;
                            }
                        }
                    }
                }
            }
            string[] answer = new string[] { current_point, next_point };
            return answer;
        }
    }
}

namespace Finding_in_width
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> points = new List<string>();
            List<string> links = new List<string>();
            Queue<string> stack = new Queue<string>();
            int N = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i < N + 1; i++)
            {
                points.Add(Convert.ToString(i));
            }
            int M = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < M; i++)
            {
                string[] link_str = Console.ReadLine().Split(' ');
                links.Add($"{link_str[0]},{link_str[1]}");
            }
            List<List<string>> connected_components = new List<List<string>>();
            string c = string.Empty;
            int b = 0;
            int a = 0;
            while (b < points.Count) 
            {
                foreach (string point in points)
                {
                    bool cond = false;
                    foreach (List<string> strings in connected_components)
                    {
                        if (strings.Contains(point))
                        {
                            cond = true; break;
                        }
                    }
                    if (!cond)
                    {
                        c = point; break;
                    }
                }
                stack.Enqueue(c);
                connected_components.Add(new List<string> { c });
                while(stack.Count > 0) 
                {
                    string temp = stack.Dequeue();
                    foreach (string link in links) 
                    {
                        if (link.Split(",").Contains(temp))
                        {
                            foreach (string s in link.Split(","))
                            {
                                if (!connected_components[a].Contains(s))
                                {
                                    stack.Enqueue(s);
                                    connected_components[a].Add(s);
                                    break;
                                }
                            }
                        }
                    }
                }
                a++;
                b = 0;
                foreach (List<string> strings in connected_components)
                {
                    b += strings.Count;
                } // проверка;

            }
            foreach (List<string> strings1 in connected_components)
            {
                foreach (string strings2 in strings1)
                {
                    Console.Write(strings2 + "\t");
                }
                Console.WriteLine();
            }


        }
    }
}

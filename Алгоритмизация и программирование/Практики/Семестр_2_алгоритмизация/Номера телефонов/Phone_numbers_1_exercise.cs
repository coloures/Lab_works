using System.Collections;

namespace Dictionary_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();
            int a = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < a; i++) 
            {
                queue.Enqueue(Console.ReadLine());
            }
            Dictionary<string, int> info = new Dictionary<string, int> ();
            Hashtable ht = new Hashtable ();
            while (queue.Count > 0)
            {
                string [] temp = queue.Dequeue().Split(' ');
                if (info.ContainsKey(temp[0]))
                {
                    info[temp[0]] = info[temp[0]] + Convert.ToInt32(temp[3]);
                    
                }
                else 
                {
                    info.Add(temp[0], Convert.ToInt32(temp[3]));
                }
                if (ht.ContainsKey(temp[0]))
                {
                    int prev = Convert.ToInt32(ht[temp[0]]);
                    ht.Remove(temp[0]);
                    ht.Add(temp[0], prev + Convert.ToInt32(temp[3]));
                }
                else 
                {
                    ht.Add(temp[0], Convert.ToInt32(temp[3]));
                }
            }
            foreach(string inf in info.Keys) 
            {
                Console.WriteLine($"{inf} -> {info[inf]}");
            }
            foreach (string inf in ht.Keys)
            {
                Console.WriteLine($"{inf} -> {ht[inf]}");
            }

        }
    }
}
namespace Sets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<HashSet<string>> list = new List<HashSet<string>>();
            int a = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < a; i++)
            {
                list.Add(new HashSet<string>());
            }
            a = 0;
            for (int i = a; i < list.Count; i++)
            {
                Console.WriteLine($"Введите элементы {i + 1}-го множества");
                string answer = Console.ReadLine();
                foreach (string s in answer.Split(' '))
                {
                    list[i].Add(s);
                }
            }
            a = list.Count-1;
            string[] temp = new string[list[0].Count];
            list[0].CopyTo(temp);
            list.Add(new HashSet<string>(temp));
            for (int i = 1; i < a + 1; i++) 
            {
                list[a + 1].UnionWith(list[i]);
            }
            Array.Resize(ref temp, list[a+1].Count);
            list[a + 1].CopyTo(temp);
            for (int i = 1; i < a + 2; i++)
            {
                list.Add(new HashSet<string>(temp));
                list[a + 1 + i].SymmetricExceptWith(list[i-1]);
            }
            foreach (HashSet<string> s in list) 
            {
                foreach(string st in s) 
                {
                    Console.Write(st + "\t");
                }
                Console.WriteLine();
            }

        }
    }
}
namespace Hashsets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<HashSet<string>> list = new List<HashSet<string>>();
            list.Add(new HashSet<string>() {"yellow","blue","red" });
            list.Add(new HashSet<string>() { "green", "purple", "blue", "yellow" });
            list.Add(new HashSet<string>() { "red", "black", "brown", "purple","yellow" });
            // пересечение
            HashSet<string> set = new HashSet<string>();
            foreach (var item in list[0]) { set.Add(item); }
            foreach (var set1 in list) 
            {
                set.IntersectWith(set1);
            }
            Console.WriteLine($"Intersect:");
            foreach(var item in set) { Console.Write($"{item}\t"); }
            // Объединение
            set.Clear();
            foreach (var item in list[0]) { set.Add(item); }
            foreach (var set1 in list)
            {
                set.UnionWith(set1);
            }
            Console.WriteLine();
            Console.WriteLine($"Union:");
            foreach (var item in set) { Console.Write($"{item}\t"); }
            Console.WriteLine();
            // дополнение
            Console.WriteLine("Addings");
            List<HashSet<string>> Addings = new List<HashSet<string>>();
            foreach (var set1 in list) 
            {
                HashSet<string> temp = new HashSet<string>();
                foreach (var item in set) { temp.Add(item); }
                temp.SymmetricExceptWith(set1);
                Addings.Add(temp);
            }
            foreach (var set1 in Addings) { foreach (var item in set1) { Console.Write($"{item}\t"); }Console.WriteLine(); }


        }
    }
}
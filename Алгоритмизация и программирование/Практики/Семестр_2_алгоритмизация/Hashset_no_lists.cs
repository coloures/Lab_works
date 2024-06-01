namespace Hashsets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> first = new HashSet<string>() { "yellow", "blue", "red" };
            HashSet<string> second = new HashSet<string>() { "green", "purple", "blue", "yellow" };
            HashSet<string> third = new HashSet<string>() { "red", "black", "brown", "purple", "yellow" };
            // пересечение
            HashSet<string> set = new HashSet<string>();
            foreach (var item in first) { set.Add(item); }
            set.Intersect(second);
            set.Intersect(third);
            Console.WriteLine($"Intersect:");
            foreach(var item in set) { Console.Write($"{item}\t"); }
            // Объединение
            set.Clear();
            foreach (var item in first) { set.Add(item); }
            set.UnionWith(second);
            set.UnionWith(third);
            Console.WriteLine();
            Console.WriteLine($"Union:");
            foreach (var item in set) { Console.Write($"{item}\t"); }
            Console.WriteLine();
            // дополнение
            Console.WriteLine("Addings");
            HashSet<string> set1 = new HashSet<string>();
            foreach (var item in set) { set1.Add(item); }
            set1.SymmetricExceptWith(first);
            first = set1;
            HashSet<string> set2 = new HashSet<string>();
            foreach (var item in set) { set2.Add(item); }
            set2.SymmetricExceptWith(second);
            HashSet<string> set3 = new HashSet<string>();
            foreach (var item in set) { set3.Add(item); }
            set3.SymmetricExceptWith(third);
            foreach (var item in set1) { Console.Write($"{item}\t"); }
            Console.WriteLine() ;
            foreach (var item in set2) { Console.Write($"{item}\t"); }
            Console.WriteLine();
            foreach (var item in set3) { Console.Write($"{item}\t"); }
            Console.WriteLine();


        }
    }
}

namespace Sets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Сколько множеств вводим? : ");
            int quantity = Convert.ToInt32(Console.ReadLine());
            string[][] sets = new string[quantity][];
            for (int i = 0; i < quantity;i++) 
            {
                Console.Write($"Сколько элементов в множестве {i+1}? :");
                int a = Convert.ToInt32(Console.ReadLine());
                sets[i] = new string[a];
            }
            for (int i = 0;i < quantity;i++) 
            {
                for (int j = 0; j < sets[i].Length; j++) 
                {
                    Console.Write($"Каким будет элемент {j+1} множества {i+1}?: ");
                    string value = Console.ReadLine();
                    sets[i][j] = value;
                }
            }
            // Создание строки-универсума
            string values = "";
            for (int i = 0; i < quantity; i++)
            {
                for (int j = 0; j < sets[i].Length; j++)
                {
                    if (!values.Split(' ').Contains(sets[i][j])) 
                    {
                        values += " " + sets[i][j];
                    }
                }
            }
            int b = 0;
            foreach(string str in values.Split(' ')) 
            {
                if(!(str == "")) 
                {
                b++;
                }   
            }
            string[] universum = new string[b];
            b = 0;
            // массив универсум
            foreach (string str in values.Split(' '))
            {
                if (!(str == ""))
                {
                    universum[b++] = str;
                }
            }
            string peresechenie = "";
            b = 0;
            // строка пересечение
            foreach (string str in universum)
            {
                int _if = 0;
                for(int i = 0; i < quantity; i++) 
                {
                    if (sets[i].Contains(str)) 
                    {
                        _if++;
                    }
                }
                if(_if == quantity) 
                {
                    b++;
                    peresechenie += " " + str;
                }
            }
            // массив пересечение
            string[] peresechenie_ = new string[b];
            b = 0;
            foreach(string str in peresechenie.Split(' '))
            {
                if (!(str == ""))
                {
                    peresechenie_[b++] = str;
                }
            }
            b = 0;
            // вывод универсума
            Console.Write("Объединение: ");
            foreach (string str in universum) 
            {
                Console.Write(str + " ");
            }
            Console.WriteLine();
            // вывод пересечения
            Console.Write("Пересечение: ");
            foreach (string str in peresechenie_)
            {
                Console.Write(str + " ");
            }
            Console.WriteLine();
            // вывод дополнений
            for (int i = 0; i < quantity; i++) 
            {
                Console.Write($"Дополнение {i + 1} множества: ");
                foreach (string str in universum) 
                {
                    if (!sets[i].Contains(str)) 
                    {
                        Console.Write(str + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}

namespace Kruskal_s_alghorithm_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> points = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            List<string> used_points = new List<string>();
            List<string> used_ways = new List<string>();
            int sum = 0;
            List<string> links = new List<string>() { "1,2", "1,5", "1,4", "2,3", "2,4", "2,5", "3,5", "3,6", "4,5", "4,7", "4,8", "5,6", "5,8", "5,9", "7,8", "8,9" };
            List<int> weights = new List<int>() { 15, 14, 23, 19, 16, 15, 14, 26, 25, 23, 20, 24, 27, 18, 14, 18 };
            string[,] ways = new string[2,weights.Count];
            for(int i = 0; i < weights.Count; i++) 
            {
                ways[0,i] = links[i];
                ways[1, i] = weights[i] + "";
            }
            Dictionary<string, List<string>> sets_of_points = new Dictionary<string, List<string>>();
            weights.Sort(); // "Шаблон", по которому будет сортироваться массив ways
            int a = 0;
            foreach (int weight in weights) // Сортировка
            {
                for (int i = a; i < ways.GetUpperBound(1); i++) 
                {
                    if (weight+"" == ways[1, i]) 
                    {
                        string temp_link = ways[0, i]; // заводим в доп. переменные данные нашей "дешевой" дороги
                        string temp_weight = ways[1, i];
                        ways[0, i] = ways[0, a]; // на его место (место самой "дешевой" дороги) ставится первая (которая не самая дешевая)
                        ways[1, i] = ways[1, a];
                        ways[0, a] = temp_link; // на первое место возращаются данные из переменных temp_...
                        ways[1, a] = temp_weight;
                        a++; // первый элемент уже есть, поэтому его повторно не нужно сортировать!!!
                        // Пример: 23, 13, 56, 30, 13, 12
                        // Отсортированный список: 12, 13, 13, 23, 30, 56
                        // теперь первый попадающийся элемент 12 ставится на первое место:
                        // 12, 13, 56, 30, 13, 23
                        // Потом ставятся два элемента 13 (причём во второй итерации идет выборка с элемента под индексом 2)
                        // Чтобы потом не переставлять снова тот же элемент (если элементы могут быть похожи)
                    }
                }
            }
            for (int i = 0; i < ways.GetUpperBound(1); i++) // перебор путей 
            {
                if (!sets_of_points.ContainsKey(ways[0, i][0] + "") && !sets_of_points.ContainsKey(ways[0, i][2] + ""))
                {
                    used_ways.Add(ways[0, i]);
                    sets_of_points[ways[0, i][0] + ""] = new List<string>(); // создается в словаре ссылка с именем первой вершины
                    sets_of_points[ways[0, i][0] + ""].Add(ways[0, i][0] + "");
                    sets_of_points[ways[0, i][0] + ""].Add(ways[0, i][2] + ""); // по ней доступны две вершины (вторая и она сама)
                    sets_of_points[ways[0, i][2] + ""] = new List<string>(); // создается в словаре ссылка с именем второй вершины
                    sets_of_points[ways[0, i][2] + ""].Add(ways[0, i][0] + ""); 
                    sets_of_points[ways[0, i][2] + ""].Add(ways[0, i][2] + ""); // по ней доступны две вершины (первая и она сама)
                    sum += weights[i];
                }
                else if (!sets_of_points.ContainsKey(ways[0, i][0] + "") && sets_of_points.ContainsKey(ways[0, i][2] + ""))
                {
                    used_ways.Add(ways[0, i]);
                    sets_of_points[ways[0, i][0] + ""] = new List<string>(); // создание ссылки с именем вершины, имени которой нет в ссылках (новая вершина)
                    sets_of_points[ways[0, i][0] + ""].Add(ways[0, i][0] + ""); // добавление в ссылку саму себя
                    foreach (string key in sets_of_points[ways[0, i][2] + ""])
                    {
                        sets_of_points[ways[0, i][0] + ""].Add(key); // добавление к новой вершине старых вершин (верших из ссылки, которая уже есть в словаре)
                    }
                    List<string> keys = new List<string>(); 
                    foreach (string key in sets_of_points[ways[0, i][2] + ""]) // Иначе foreach жалуется, что меняю список! (делаю список вершин статичным)
                    {
                        keys.Add(key); 
                    }
                    foreach (string key in keys)
                    {
                        sets_of_points[key].Add(ways[0, i][0] + ""); // добавление новой вершины в старые ссылки
                    }
                    sum += weights[i];

                }
                else if (sets_of_points.ContainsKey(ways[0, i][0] + "") && !sets_of_points.ContainsKey(ways[0, i][2] + ""))
                {
                    used_ways.Add(ways[0, i]); // идентично второму ifу только зеркально (первая вершина в словаре есть, а второй нет)
                    sets_of_points[ways[0, i][2] + ""] = new List<string>();
                    sets_of_points[ways[0, i][2] + ""].Add(ways[0, i][2] + "");
                    foreach (string key in sets_of_points[ways[0, i][0] + ""])
                    {
                        sets_of_points[ways[0, i][2] + ""].Add(key);
                    }
                    List<string> keys = new List<string>();
                    foreach (string key in sets_of_points[ways[0, i][0] + ""]) // Иначе foreach жалуется, что меняю список! (делаю список вершин статичным)
                    {
                        keys.Add(key);
                    }
                    foreach (string key in keys)
                    {
                        sets_of_points[key].Add(ways[0, i][2] + "");
                    }
                    sum += weights[i];
                }
                else if (sets_of_points.ContainsKey(ways[0, i][0] + "") && sets_of_points.ContainsKey(ways[0, i][2] + "") && !sets_of_points[ways[0, i][0] + ""].Contains(ways[0, i][2] + "")) 
                {
                    used_ways.Add(ways[0, i]);
                    List<string> temp_1 = new List<string>();
                    foreach (string temp in sets_of_points[ways[0, i][0] + ""]) // Иначе foreach жалуется, что меняю список! (делаю список вершин статичным)
                    {
                        temp_1.Add(temp); // вершины, которых нет в группе второй вершины
                    }
                    List<string> temp_2 = new List<string>();
                    foreach (string temp in sets_of_points[ways[0, i][2] + ""]) // Иначе foreach жалуется, что меняю список! (делаю список вершин статичным)
                    {
                        temp_2.Add(temp); // вершины, которых нет в группе первой вершины
                    }
                    foreach (string point in temp_1)
                    {
                        foreach (string into in temp_2) 
                        {
                            sets_of_points[point].Add(into); // добавление этих вершин друг в друга
                        }
                    }
                    foreach (string point in temp_2)
                    {
                        foreach (string into in temp_1)
                        {
                            sets_of_points[point].Add(into);
                        }
                    }
                    sum += weights[i];

                }
            }
            foreach(string way in used_ways) 
            {
                Console.WriteLine(way);
            }
            Console.WriteLine(sum);


        }
    }
}

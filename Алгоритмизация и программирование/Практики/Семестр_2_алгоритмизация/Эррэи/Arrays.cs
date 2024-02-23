using System.Collections;
using System.ComponentModel.Design;
using System.Dynamic;

namespace Arrays
{
    internal class Arrays
    {
        static void Main(string[] args)
        {
            Types_of_arrays trying = new Types_of_arrays("3");
        }
    }
    class Types_of_arrays 
    {
        public Array arr;
        public ArrayList arrlist;
        public SortedList sortedlist;
        string type;
        public string type_of_arr;
        public string type_of_sortedlist_key;
        public string Type 
        {
            get { return type; }
            set { type = value; }
        }
        public Types_of_arrays(string String) 
        {
            if (String == "array" || String == "1" || String == "1)")
            {
                Type = "array";
                Console.Write("Какая будет длина у массива: ");
                int quantity = Convert.ToInt32(Console.ReadLine());
                Console.Write("Какой тип объектов будет в массиве (введите пример): ");
                string answer = Console.ReadLine();
                try
                {
                    arr = Array.CreateInstance((Boolean.Parse(answer)).GetType(), quantity);
                    type_of_arr = "bool";
                    Console.Write($"Введите {quantity} элементов {Boolean.Parse(answer).GetType()} типа:");
                    for (int i = 0; i < quantity; i++)
                    {
                        arr.SetValue(Boolean.Parse(Console.ReadLine()), i);
                    }
                    Console.WriteLine("Успешно создан массив");
                    return;
                }
                catch (FormatException)
                { }
                try
                {
                    arr = Array.CreateInstance((int.Parse(answer)).GetType(), quantity);
                    type_of_arr = "int";
                    Console.Write($"Введите {quantity} элементов {int.Parse(answer).GetType()} типа:");
                    for (int i = 0; i < quantity; i++)
                    {
                        arr.SetValue(int.Parse(Console.ReadLine()), i);
                    }
                    Console.WriteLine("Успешно создан массив");
                    return;
                }
                catch (FormatException)
                {
                }
                try
                {
                    arr = Array.CreateInstance((char.Parse(answer)).GetType(), quantity);
                    type_of_arr = "char";
                    Console.Write($"Введите {quantity} элементов {char.Parse(answer).GetType()} типа:");
                    for (int i = 0; i < quantity; i++)
                    {
                        arr.SetValue(char.Parse(Console.ReadLine()), i);
                    }
                    Console.WriteLine("Успешно создан массив");
                    return;
                }
                catch (FormatException)
                {
                }
                try
                {
                    arr = Array.CreateInstance(answer.GetType(), quantity);
                    type_of_arr = "string";
                    Console.Write($"Введите {quantity} элементов {answer.GetType()} типа:");
                    for (int i = 0; i < quantity; i++)
                    {
                        arr.SetValue(Console.ReadLine(), i);
                    }
                    Console.WriteLine("Успешно создан массив");
                    return;
                }
                catch (FormatException)
                {
                }
            }
            else if (String == "arraylist" || String == "2" || String == "2)")
            {
                Type = "arraylist";
                
                arrlist = new ArrayList();
                Console.Write("Какая будет длина у arraylist: ");
                int quantity = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < quantity; i++)
                {
                    Console.Write($"Введите {i}-й элемент arraylist: ");
                    string answer = Console.ReadLine();
                    try
                    {
                        arrlist.Add(Boolean.Parse(answer));
                        continue;
                    }
                    catch (FormatException)
                    {
                    }
                    try
                    {
                        arrlist.Add(int.Parse(answer));
                        continue;
                    }
                    catch (FormatException)
                    {
                    }
                    try
                    {
                        arrlist.Add(char.Parse(answer));
                        continue;
                    }
                    catch (FormatException)
                    {
                    }
                    try
                    {
                        arrlist.Add(answer);
                        continue;
                    }
                    catch (FormatException)
                    {
                    }
                }
                Console.WriteLine("Успешно создан arraylist");
            }
            else if (String == "sortedlist" || String == "3" || String == "3)") 
            {
                Type = "sortedlist";
                sortedlist = new SortedList();
                Console.Write("Какая будет длина у sortedlist: ");
                int quantity = Convert.ToInt32(Console.ReadLine());
                Console.Write("Какой тип объектов будет у ключей в sortedlist (введите пример): ");
                string answer_temp = Console.ReadLine();
                try
                {
                    bool answer = Boolean.Parse(answer_temp);
                    type_of_sortedlist_key = "bool";
                    Console.WriteLine("Так как тип булевый, то размер уменьшен до 2-х элементов!");
                    quantity = 2;
                    for (int i = 0;i < quantity;i++) 
                    {
                        Console.Write($"Введите {i}-й ключ: ");
                        answer = Boolean.Parse(Console.ReadLine());
                        Console.Write($"Введите {i}-е значение: ");
                        string value_temp = Console.ReadLine();
                        try 
                        {
                            sortedlist.Add(answer, Boolean.Parse(value_temp));
                            continue;

                        }
                        catch (FormatException)
                        {
                        }
                        try
                        {
                            sortedlist.Add(answer, int.Parse(value_temp));
                            continue;

                        }
                        catch (FormatException)
                        {
                        }
                        try
                        {
                            sortedlist.Add(answer, char.Parse(value_temp));
                            continue;

                        }
                        catch (FormatException)
                        {
                        }
                        try
                        {
                            sortedlist.Add(answer, value_temp);
                            continue;

                        }
                        catch (FormatException)
                        {
                        }
                    }
                    Console.WriteLine("Успешно создан sortedlist");
                    return;

                }
                catch (FormatException) 
                {
                }
                try 
                {
                    int answer = int.Parse(answer_temp);
                    type_of_sortedlist_key = "int";
                    for (int i = 0; i < quantity; i++)
                    {
                        Console.Write($"Введите {i}-й ключ: ");
                        answer = int.Parse(Console.ReadLine());
                        Console.Write($"Введите {i}-е значение: ");
                        string value_temp = Console.ReadLine();
                        try
                        {
                            sortedlist.Add(answer, Boolean.Parse(value_temp));
                            continue;

                        }
                        catch (FormatException)
                        {
                        }
                        try
                        {
                            sortedlist.Add(answer, int.Parse(value_temp));
                            continue;

                        }
                        catch (FormatException)
                        {
                        }
                        try
                        {
                            sortedlist.Add(answer, char.Parse(value_temp));
                            continue;

                        }
                        catch (FormatException)
                        {
                        }
                        try
                        {
                            sortedlist.Add(answer, value_temp);
                            continue;

                        }
                        catch (FormatException)
                        {
                        }

                    }
                    Console.WriteLine("Успешно создан sortedlist");
                    return;
                }
                catch (FormatException)
                {
                }
                try
                {
                    char answer = char.Parse(answer_temp);
                    type_of_sortedlist_key = "char";
                    for (int i = 0; i < quantity; i++)
                    {
                        Console.Write($"Введите {i}-й ключ: ");
                        answer = char.Parse(Console.ReadLine());
                        Console.Write($"Введите {i}-е значение: ");
                        string value_temp = Console.ReadLine();
                        try
                        {
                            sortedlist.Add(answer, Boolean.Parse(value_temp));
                            continue;

                        }
                        catch (FormatException)
                        {
                        }
                        try
                        {
                            sortedlist.Add(answer, int.Parse(value_temp));
                            continue;

                        }
                        catch (FormatException)
                        {
                        }
                        try
                        {
                            sortedlist.Add(answer, char.Parse(value_temp));
                            continue;

                        }
                        catch (FormatException)
                        {
                        }
                        try
                        {
                            sortedlist.Add(answer, value_temp);
                            continue;

                        }
                        catch (FormatException)
                        {
                        }

                    }
                    Console.WriteLine("Успешно создан sortedlist");
                    return;
                }
                catch (FormatException)
                {
                }
                try
                {
                    string answer = answer_temp;
                    type_of_sortedlist_key = "string";
                    for (int i = 0; i < quantity; i++)
                    {
                        Console.Write($"Введите {i}-й ключ: ");
                        answer = Console.ReadLine();
                        Console.Write($"Введите {i}-е значение: ");
                        string value_temp = Console.ReadLine();
                        try
                        {
                            sortedlist.Add(answer, Boolean.Parse(value_temp));
                            continue;

                        }
                        catch (FormatException)
                        {
                        }
                        try
                        {
                            sortedlist.Add(answer, int.Parse(value_temp));
                            continue;

                        }
                        catch (FormatException)
                        {
                        }
                        try
                        {
                            sortedlist.Add(answer, char.Parse(value_temp));
                            continue;

                        }
                        catch (FormatException)
                        {
                        }
                        try
                        {
                            sortedlist.Add(answer, value_temp);
                            continue;

                        }
                        catch (FormatException)
                        {
                        }

                    }
                    Console.WriteLine("Успешно создан sortedlist");
                    return;
                }
                catch (FormatException)
                {
                }
            }
        }
        public void Menu() 
        {
            if (Type == "array")
            {
                Console.WriteLine("Выберите операцию над массивом: 1)Count;\n2)BinSearch;\n" +
                    "3)Copy;\n4)Find\n5)FindLast\n6)IndexOf;\n7)Reverse;\n8)Resize;\n9)Sort.");
            }
            else if (Type == "arraylist")
            {
                Console.WriteLine("Выберите операцию над arraylist: 1)Count;\n2)BinSearch;\n" +
                    "3)Copy;\n4)IndexOf;\n5)Insert;\n6)Reverse;\n7)Sort;\n8)Add.");
            }
            else if (Type == "sortedlist") 
            {
                Console.WriteLine("Выберите операцию над sortedlist: 1)Add;\n2)IndexOf (by key);\n" +
                    "3)IndexOf (by value);\n4)Writing key by index;\n5)Writing value by index.");
            }
        }
        public void Process(ref Array arr_out, ref ArrayList arrlist_out, ref SortedList sortedList_out, int number) 
        {
            if (Type == "array")
            {
                switch (number) 
                {
                    case 1:
                        Console.WriteLine(arr.Length);
                        break;
                    case 2:
                        if (type_of_arr == "bool")
                        {
                            bool what_to_find = Boolean.Parse(Console.ReadLine());
                            Console.WriteLine($"Индекс элемента {what_to_find} в массиве: {Array.BinarySearch(arr, what_to_find)}");
                        }
                        else if (type_of_arr == "string")
                        {
                            string what_to_find = Console.ReadLine();
                            Console.WriteLine($"Индекс элемента {what_to_find} в массиве: {Array.BinarySearch(arr, what_to_find)}");
                        }
                        else if (type_of_arr == "char")
                        {
                            char what_to_find = char.Parse(Console.ReadLine());
                            Console.WriteLine($"Индекс элемента {what_to_find} в массиве: {Array.BinarySearch(arr, what_to_find)}");
                        }
                        else if (type_of_arr == "int") 
                        {
                            int what_to_find = int.Parse(Console.ReadLine());
                            Console.WriteLine($"Индекс элемента {what_to_find} в массиве: {Array.BinarySearch(arr, what_to_find)}");
                        }
                        break;
                    case 3:
                        Array.Copy(arr, arr_out,arr.Length);
                        break;
                    case 4:


                }
            }
            else if (Type == "arraylist")
            {
                Console.WriteLine("Выберите операцию над arraylist: 1)Count;\n2)BinSearch;\n" +
                    "3)Copy;\n4)IndexOf;\n5)Insert;\n6)Reverse;\n7)Sort;\n8)Add.");
            }
            else if (Type == "sortedlist")
            {
                Console.WriteLine("Выберите операцию над sortedlist: 1)Add;\n2)IndexOf (by key);\n" +
                    "3)IndexOf (by value);\n4)Writing key by index;\n5)Writing value by index.");
            }
        }
    }
}
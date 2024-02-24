using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ConsoleApplication19
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Что вы хотите создать (1 - массив; 2 - arraylist; 3 - sortedlist): ");
            string answer = Console.ReadLine();
            Types_of_arrays trying = new Types_of_arrays(answer);
            Object[] arr = new object[4];
            ArrayList arrList = new ArrayList();
            SortedList sortedlist = new SortedList();
            while (true)
            {
                trying.Menu();
                int number = Convert.ToInt32(Console.ReadLine());
                if (!trying.Process(ref arr, ref arrList, ref sortedlist, number))
                {
                    break;
                }
            }
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
                    Console.Write(string.Format("Введите {0} элементов {1} типа:", quantity, Boolean.Parse(answer).GetType()));
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
                    Console.Write(string.Format("Введите {0} элементов {1} типа:", quantity, int.Parse(answer).GetType()));
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
                    Console.Write(string.Format("Введите {0} элементов {1} типа:", quantity, char.Parse(answer).GetType()));
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
                    Console.Write(string.Format("Введите {0} элементов {1} типа:", quantity, answer.GetType()));
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
                    Console.Write(string.Format("Введите {0}-й элемент arraylist: ", i));
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
                    for (int i = 0; i < quantity; i++)
                    {
                        Console.Write(string.Format("Введите {0}-й ключ: ", i));
                        answer = Boolean.Parse(Console.ReadLine());
                        Console.Write(string.Format("Введите {0}-е значение: ", i));
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
                        Console.Write(string.Format("Введите {0}-й ключ: ", i));
                        answer = int.Parse(Console.ReadLine());
                        Console.Write(string.Format("Введите {0}-е значение: ", i));
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
                        Console.Write(string.Format("Введите {0}-й ключ: ", i));
                        answer = char.Parse(Console.ReadLine());
                        Console.Write(string.Format("Введите {0}-е значение: ", i));
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
                        Console.Write(string.Format("Введите {0}-й ключ: ", i));
                        answer = Console.ReadLine();
                        Console.Write(string.Format("Введите {0}-е значение: ", i));
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
                    "3)Copy;\n4)IndexOf;\n5)Reverse;\n6)Resize;\n7)Sort;\n8)Exit;\n9)Show.");
            }
            else if (Type == "arraylist")
            {
                Console.WriteLine("Выберите операцию над arraylist: 1)Count;\n2)BinSearch;\n" +
                    "3)Copy;\n4)IndexOf;\n5)Insert;\n6)Reverse;\n7)Sort;\n8)Add;\n9)Exit;\n10)Show.");
            }
            else if (Type == "sortedlist")
            {
                Console.WriteLine("Выберите операцию над sortedlist: 1)Add;\n2)IndexOf (by key);\n" +
                    "3)IndexOf (by value);\n4)Writing key by index;\n5)Writing value by index;\n6)Exit;\n7)Show.");
            }
        }
        public bool Process(ref Object[] arr_out, ref ArrayList arrlist_out, ref SortedList sortedList_out, int number)
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
                            Console.Write("Что вы ищете? ");
                            bool what_to_find = Boolean.Parse(Console.ReadLine());
                            Console.WriteLine(string.Format("Индекс элемента {0} в массиве: {1}", what_to_find, arr.Length + Array.BinarySearch(arr, what_to_find)));
                        }
                        else if (type_of_arr == "string")
                        {
                            Console.Write("Что вы ищете? ");
                            string what_to_find = Console.ReadLine();
                            Console.WriteLine(string.Format("Индекс элемента {what_to_find} в массиве: {arr.Length + Array.BinarySearch(arr, what_to_find)}"));
                        }
                        else if (type_of_arr == "char")
                        {
                            Console.Write("Что вы ищете? ");
                            char what_to_find = char.Parse(Console.ReadLine());
                            Console.WriteLine(string.Format("Индекс элемента {what_to_find} в массиве: {arr.Length + Array.BinarySearch(arr, what_to_find)}"));
                        }
                        else if (type_of_arr == "int")
                        {
                            Console.Write("Что вы ищете? ");
                            int what_to_find = int.Parse(Console.ReadLine());
                            Console.WriteLine(string.Format("Индекс элемента {what_to_find} в массиве: {arr.Length + Array.BinarySearch(arr, what_to_find)}"));
                        }
                        break;
                    case 3:
                        Array.Resize(ref arr_out, arr.Length);
                        Array.Copy(arr, arr_out, arr.Length);
                        break;
                    case 4:
                        Console.Write("Введите элемент, индекс которого вы хотите узнать: ");
                        string answ_temp = Console.ReadLine();
                        try
                        {
                            bool answ = Boolean.Parse(answ_temp);
                            Console.WriteLine(Array.IndexOf(arr, answ));
                            break;
                        }
                        catch (FormatException)
                        {
                        }
                        try
                        {
                            int answ = int.Parse(answ_temp);
                            Console.WriteLine(Array.IndexOf(arr, answ));
                            break;
                        }
                        catch (FormatException)
                        {
                        }
                        try
                        {
                            char answ = char.Parse(answ_temp);
                            Console.WriteLine(Array.IndexOf(arr, answ));
                            break;
                        }
                        catch (FormatException)
                        {
                        }
                        try
                        {
                            string answ = answ_temp;
                            Console.WriteLine(Array.IndexOf(arr, answ));
                            break;
                        }
                        catch (FormatException)
                        {
                        }
                        break;
                    case 5:
                        Array.Reverse(arr);
                        Console.WriteLine("Массив был перевернут");
                        break;
                    case 6:
                        Console.Write("Каким должен быть новый размер массива: ");
                        int num = Convert.ToInt32(Console.ReadLine());
                        Object[] arr_temp = new Object[num];
                        Array.Copy(arr, arr_temp, num);
                        Array.Clear(arr,0,arr.Length);
                        arr = arr_temp; // меняется тип!!!!
                        Console.WriteLine(string.Format("Массив уменьшен до {num} элементов"));
                        break;
                    case 7:
                        Array.Sort(arr);
                        Console.WriteLine("Массив был отсортирован");
                        break;
                    case 8:
                        return false;
                    case 9:
                        foreach (var smth in arr)
                        {
                            Console.WriteLine(smth.ToString());
                        }
                        break;
                }
                return true;
            }
            else if (Type == "arraylist")
            {
                switch (number)
                {
                    case 1:
                        Console.WriteLine(arrlist.Count);
                        break;
                    case 2:
                        Console.Write("Что вы ищете? ");
                        string answer = Console.ReadLine();
                        Console.Write("Какого типа элемент? ");
                        string type = Console.ReadLine();
                        if (type == "string")
                        {
                            Console.WriteLine(arrlist.Count - arrlist.BinarySearch(answer));
                        }
                        else if (type == "int")
                        {
                            Console.WriteLine(arrlist.Count - arrlist.BinarySearch(int.Parse(answer)));
                        }
                        else if (type == "bool")
                        {
                            Console.WriteLine(arrlist.Count - arrlist.BinarySearch(Boolean.Parse(answer)));
                        }
                        else if (type == "char")
                        {
                            Console.WriteLine(arrlist.Count - arrlist.BinarySearch(char.Parse(answer)));
                        }
                        break;
                    case 3:
                        arrlist.CopyTo(arr_out);
                        break;
                    case 4:
                        Console.Write("Что вы ищете? ");
                        answer = Console.ReadLine();
                        Console.Write("Какого типа элемент? ");
                        type = Console.ReadLine();
                        if (type == "string")
                        {
                            Console.WriteLine(arrlist.Count - arrlist.IndexOf(Convert.ToString(answer)));
                        }
                        else if (type == "int")
                        {
                            Console.WriteLine(arrlist.Count - arrlist.IndexOf(int.Parse(answer)));
                        }
                        else if (type == "bool")
                        {
                            Console.WriteLine(arrlist.Count - arrlist.IndexOf(Boolean.Parse(answer)));
                        }
                        else if (type == "char")
                        {
                            Console.WriteLine(arrlist.Count - arrlist.IndexOf(char.Parse(answer)));
                        }
                        break;
                    case 5:
                        Console.Write("На какую позицию поставить элемент? ");
                        int index = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Какой элемент вставить? ");
                        string an = Console.ReadLine();
                        Console.Write("Какого типа элемент");
                        type = Console.ReadLine();
                        if (type == "string")
                        {
                            arrlist.Insert(index, Convert.ToString(an));
                        }
                        else if (type == "int")
                        {
                            arrlist.Insert(index, int.Parse(an));
                        }
                        else if (type == "bool")
                        {
                            arrlist.Insert(index, Boolean.Parse(an));
                        }
                        else if (type == "char")
                        {
                            arrlist.Insert(index, char.Parse(an));
                        }
                        Console.WriteLine("Элемент успешно заменён");
                        break;
                    case 6:
                        arrlist.Reverse();
                        Console.WriteLine("Arrlist успешно перевёрнут!");
                        break;
                    case 7:
                        arrlist.Sort();
                        Console.WriteLine("Arrlist успешно отсортирован!");
                        break;
                    case 8:
                        Console.Write("Какой элемент вы хотите добавить? ");
                        answer = Console.ReadLine();
                        Console.Write("Какого типа будет элемент? ");
                        type = Console.ReadLine();
                        if (type == "string")
                        {
                            arrlist.Add(Convert.ToString(answer));
                        }
                        else if (type == "int")
                        {
                            arrlist.Add(int.Parse(answer));
                        }
                        else if (type == "bool")
                        {
                            arrlist.Add(Boolean.Parse(answer));
                        }
                        else if (type == "char")
                        {
                            arrlist.Add(char.Parse(answer));
                        }
                        Console.WriteLine("Элемент успешно добавлен");
                        break;
                    case 9:
                        return false;
                    case 10:
                        foreach (var s in arrlist)
                        {
                            Console.WriteLine(s);
                        }
                        break;
                }
                return true;
            }
            else if (Type == "sortedlist")
            {
                switch (number)
                {
                    case 1:
                        Console.Write("Какой ключ вы хотите добавить? ");
                        string answer_temp = Console.ReadLine();
                        if (type_of_sortedlist_key == "string")
                        {
                            string answer_d = answer_temp;
                            Console.Write("Какое значение вы хотите добавить? ");
                            string key_temp = Console.ReadLine();
                            try
                            {
                                bool key_d = Boolean.Parse(key_temp);
                                sortedlist.Add(answer_d, key_d);
                                Console.WriteLine("Ключ-значение успешно добавлены!");
                                break;
                            }
                            catch (FormatException)
                            {
                            }
                            try
                            {
                                int key_d = int.Parse(key_temp);
                                sortedlist.Add(answer_d, key_d);
                                Console.WriteLine("Ключ-значение успешно добавлены!");
                                break;
                            }
                            catch (FormatException)
                            {
                            }
                            try
                            {
                                char key_d = char.Parse(key_temp);
                                sortedlist.Add(answer_d, key_d);
                                Console.WriteLine("Ключ-значение успешно добавлены!");
                                break;
                            }
                            catch (FormatException)
                            {
                            }
                            try
                            {
                                string key_d = key_temp;
                                sortedlist.Add(answer_d, key_d);
                                Console.WriteLine("Ключ-значение успешно добавлены!");
                                break;
                            }
                            catch (FormatException)
                            {
                            }
                            break;
                        }
                        else if (type_of_sortedlist_key == "int")
                        {
                            int answer_d = int.Parse(answer_temp);
                            Console.Write("Какое значение вы хотите добавить? ");
                            string key_temp = Console.ReadLine();
                            try
                            {
                                bool key_d = Boolean.Parse(key_temp);
                                sortedlist.Add(answer_d, key_d);
                                Console.WriteLine("Ключ-значение успешно добавлены!");
                                break;
                            }
                            catch (FormatException)
                            {
                            }
                            try
                            {
                                int key_d = int.Parse(key_temp);
                                sortedlist.Add(answer_d, key_d);
                                Console.WriteLine("Ключ-значение успешно добавлены!");
                                break;
                            }
                            catch (FormatException)
                            {
                            }
                            try
                            {
                                char key_d = char.Parse(key_temp);
                                sortedlist.Add(answer_d, key_d);
                                Console.WriteLine("Ключ-значение успешно добавлены!");
                                break;
                            }
                            catch (FormatException)
                            {
                            }
                            try
                            {
                                string key_d = key_temp;
                                sortedlist.Add(answer_d, key_d);
                                Console.WriteLine("Ключ-значение успешно добавлены!");
                                break;
                            }
                            catch (FormatException)
                            {
                            }
                            break;
                        }
                        else if (type_of_sortedlist_key == "bool")
                        {
                            bool answer_d = Boolean.Parse(answer_temp);
                            Console.Write("Какое значение вы хотите добавить? ");
                            string key_temp = Console.ReadLine();
                            try
                            {
                                bool key_d = Boolean.Parse(key_temp);
                                sortedlist.Add(answer_d, key_d);
                                Console.WriteLine("Ключ-значение успешно добавлены!");
                                break;
                            }
                            catch (FormatException)
                            {
                            }
                            try
                            {
                                int key_d = int.Parse(key_temp);
                                sortedlist.Add(answer_d, key_d);
                                Console.WriteLine("Ключ-значение успешно добавлены!");
                                break;
                            }
                            catch (FormatException)
                            {
                            }
                            try
                            {
                                char key_d = char.Parse(key_temp);
                                sortedlist.Add(answer_d, key_d);
                                Console.WriteLine("Ключ-значение успешно добавлены!");
                                break;
                            }
                            catch (FormatException)
                            {
                            }
                            try
                            {
                                string key_d = key_temp;
                                sortedlist.Add(answer_d, key_d);
                                Console.WriteLine("Ключ-значение успешно добавлены!");
                                break;
                            }
                            catch (FormatException)
                            {
                            }
                            break;
                        }
                        else if (type_of_sortedlist_key == "char")
                        {
                            char answer_d = char.Parse(answer_temp);
                            Console.Write("Какое значение вы хотите добавить? ");
                            string key_temp = Console.ReadLine();
                            try
                            {
                                bool key_d = Boolean.Parse(key_temp);
                                sortedlist.Add(answer_d, key_d);
                                Console.WriteLine("Ключ-значение успешно добавлены!");
                                break;
                            }
                            catch (FormatException)
                            {
                            }
                            try
                            {
                                int key_d = int.Parse(key_temp);
                                sortedlist.Add(answer_d, key_d);
                                Console.WriteLine("Ключ-значение успешно добавлены!");
                                break;
                            }
                            catch (FormatException)
                            {
                            }
                            try
                            {
                                char key_d = char.Parse(key_temp);
                                sortedlist.Add(answer_d, key_d);
                                Console.WriteLine("Ключ-значение успешно добавлены!");
                                break;
                            }
                            catch (FormatException)
                            {
                            }
                            try
                            {
                                string key_d = key_temp;
                                sortedlist.Add(answer_d, key_d);
                                Console.WriteLine("Ключ-значение успешно добавлены!");
                                break;
                            }
                            catch (FormatException)
                            {
                            }
                            break;
                        }
                        Console.WriteLine("Ключ-значение успешно добавлены!");
                        break;
                    case 2:
                        Console.Write("Введите ключ, индекс которого вы хотите найти: ");
                        string answer = Console.ReadLine();
                        if (type_of_sortedlist_key == "string")
                        {
                            Console.WriteLine(sortedlist.IndexOfKey(answer));
                            break;
                        }
                        else if (type_of_sortedlist_key == "int")
                        {
                            Console.WriteLine(sortedlist.IndexOfKey(int.Parse(answer)));
                            break;
                        }
                        else if (type_of_sortedlist_key == "char")
                        {
                            Console.WriteLine(sortedlist.IndexOfKey(char.Parse(answer)));
                            break;
                        }
                        else if (type_of_sortedlist_key == "bool")
                        {
                            Console.WriteLine(sortedlist.IndexOfKey(bool.Parse(answer)));
                            break;
                        }
                        break;
                    case 3:
                        Console.Write("Введите значение, индекс которого вы хотите найти: ");
                        answer = Console.ReadLine();
                        try
                        {
                            Console.WriteLine(sortedlist.IndexOfValue(bool.Parse(answer)));
                            break;
                        }
                        catch (FormatException)
                        {
                        }
                        try
                        {
                            Console.WriteLine(sortedlist.IndexOfValue(int.Parse(answer)));
                            break;
                        }
                        catch (FormatException)
                        {
                        }
                        try
                        {
                            Console.WriteLine(sortedlist.IndexOfValue(char.Parse(answer)));
                            break;
                        }
                        catch (FormatException)
                        {
                        }
                        try
                        {
                            Console.WriteLine(sortedlist.IndexOfValue(answer));
                            break;
                        }
                        catch (FormatException)
                        {
                        }
                        break;
                    case 4:
                        Console.Write("Введите индекс, ключ которого вы хотите найти: ");
                        int index_ = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(sortedlist.GetKey(index_));
                        break;
                    case 5:
                        Console.Write("Введите индекс, значение которого вы хотите найти: ");
                        int index_1 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(sortedlist[sortedlist.GetKey(index_1)]);
                        break;
                    case 6:
                        return false;
                    case 7:
                        for (int i = 0; i < sortedlist.GetValueList().Count; i++)
                        {
                            Console.WriteLine(string.Format("{0} - {1}", sortedlist.GetKey(i), sortedlist[sortedlist.GetKey(i)]));
                        }
                        break;


                }
                Console.WriteLine("Выберите операцию над sortedlist: 1)Add;\n2)IndexOf (by key);\n" +
                    "3)IndexOf (by value);\n4)Writing key by index;\n5)Writing value by index;\n6)Exit;\n7)Show.");
                return true;
            }
            else
            {
                return true;
            }
        }
    }
}

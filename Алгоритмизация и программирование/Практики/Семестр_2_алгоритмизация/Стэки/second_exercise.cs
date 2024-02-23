namespace Stack_second_exercise
{
    internal class second_exercise
    {
        static void Main(string[] args)
        {
            // берется по итерациям (как в модифицированном алгоритме Краскала)
            Stack<string> symbols = new Stack<string>();
            string str = Console.ReadLine(); // 12 23 + 10 45 * +
            List <string> temp = new List<string>(); // 37 450 
            string current; // текущее число
            int answer = 0; // ответ;
            int check = 0; // проверяет сколько чисел
            bool answ = true;
            foreach (string strin in str.Split(' ').Reverse()) 
            {
                symbols.Push(strin); // 12 23 + 10 45 * + (в стеке) и наоборот по существу
            }
            int first_num = 0;
            int second_num = 0;
            while (true) 
            {
                check++;
                //Console.WriteLine($"{symbols.Count} - число элементов в стеке");
                if (symbols.Count == 0) // новая итерация
                {
                    if (temp.Count == 1) 
                    {
                        answer = Convert.ToInt32(temp[0]);
                        answ = true;
                        break;
                    }
                    if (temp.Count % 2 == 1) // нормальная ситуация
                    {
                        check = 0;
                        temp.Reverse();
                        foreach (string t in temp)
                        {
                            symbols.Push(t);
                        }
                        Console.WriteLine($"{symbols.Count} - размер нового стека");
                        temp.Clear();
                    }
                    else // знаков или чисел больше, чем нужно 
                    {
                        answ = false;
                        break;
                    }
                }
                else if (symbols.TryPop(out current)) // есть ли элементы в стеке? - да, значит, забираем
                {
                    if (check == 1 && current != "+" && current != "-" && current != "*" && current != "/")
                    {
                        first_num = Convert.ToInt32(current);
                    }
                    else if (check == 2 && current != "+" && current != "-" && current != "*" && current != "/")
                    {
                        second_num = Convert.ToInt32(current);
                    }
                    else if (check > 2 && current != "+" && current != "-" && current != "*" && current != "/") // если чисел больше, то либо они нужны и
                                                                                                                // являются необходимыми на следующих итерациях,
                                                                                                                // либо выражение неверно, что и выдастся в следующей
                                                                                                                // итерации
                    {
                        temp.Add(first_num+"");
                        first_num = second_num;
                        second_num = Convert.ToInt32(current);
                        check--;
                    }
                    else if (current == "+" && check == 3) // чек = 3 показывает, что операция относится к данному "уровню" итерации
                    {
                        check = 0;
                        temp.Add((first_num + second_num) + "");
                    }
                    else if (current == "-" && check == 3)
                    {
                        check = 0;
                        temp.Add((first_num - second_num) + "");
                    }
                    else if (current == "*" && check == 3)
                    {
                        check = 0;
                        temp.Add((first_num * second_num) + "");
                    }
                    else if (current == "/" && check == 3)
                    {
                        check = 0;
                        if (second_num == 0) // деление на ноль
                        {
                            answ = false;
                            break;
                        }
                        temp.Add((first_num / second_num) + "");
                    }
                    else if (current == "+" || current == "-" || current == "*" || current == "/" && check != 3) // знак не текущей итерации
                    {
                        check = 0;
                        temp.Add(current);
                    }
                }
            }
            if (answ == true)
            {
                Console.WriteLine(answer);
            }
            else 
            {
                Console.WriteLine("Неверно задано выражение");
            }
        }
    }
}
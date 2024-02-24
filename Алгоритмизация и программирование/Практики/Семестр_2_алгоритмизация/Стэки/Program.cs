namespace Second_exercise_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> symbols = new Stack<int>();
            string str = Console.ReadLine(); // 12 23 + 10 45 * +
            foreach (string strin in str.Split(' '))
            {
                if (strin != "+" && strin != "-" && strin != "*" && strin != "/")
                {
                    symbols.Push(Convert.ToInt32(strin));
                }
                else 
                {
                    int first;
                    int second;
                    if (symbols.TryPop(out second) == true && symbols.TryPop(out first) == true)
                    {
                        if (strin == "+")
                        {
                            symbols.Push(first + second);
                        }
                        else if (strin == "-")
                        {
                            symbols.Push(first - second);
                        }
                        else if (strin == "*")
                        {
                            symbols.Push(first * second);
                        }
                        else if (strin == "/")
                        {
                            try
                            {
                                symbols.Push(first / second);
                            }
                            catch (DivideByZeroException) 
                            {
                                Console.WriteLine("Делить на нуль нельзя!");
                                symbols.Clear();
                                break;
                            }
                        }
                    }
                    else 
                    {
                        Console.WriteLine("Введено неверное выражение!");
                        symbols.Clear();
                        break;
                    }
                }
            }
            if (symbols.Count != 0) 
            {
                Console.WriteLine(symbols.Pop());
            }
        }
    }
}
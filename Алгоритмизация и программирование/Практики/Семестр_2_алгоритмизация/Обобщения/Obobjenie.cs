namespace Obobjenie
{
    delegate T Action<T>();
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] MenuItems = { "Работа с вещественными числами", "Работа с целыми числами"};
            string[] MenuItems1 = { "Сумма", "Вычитание", "Умножение","Деление"};
            int col = Console.CursorLeft;
            int row = Console.CursorTop;
            int index = 0;
            int index1 = 0;
            int col1 = Console.CursorLeft;
            int row1 = Console.CursorTop;
            while (true) 
            {
                DrawMenu(MenuItems, row, col, index);
                switch (Console.ReadKey(true).Key) 
                {
                    case ConsoleKey.Escape: return;
                    case ConsoleKey.DownArrow:
                        if (index < MenuItems.Length - 1) 
                        {
                            index++;
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (index > 0) 
                        {
                            index--;
                        }
                        break;
                    case ConsoleKey.Enter:
                        switch (index) 
                        {
                            case 0:
                                row1 = col1 = index1 = 0;
                                Calc<double> Double = new Calc<double>(0,0);
                                Action<double> Sum = Double.Sum;
                                Action<double> Min = Double.Min;
                                Action<double> Mul = Double.Mul;
                                Action<double> Div = Double.Div;
                                while (true)
                                {
                                    Console.Clear();
                                    DrawMenu(MenuItems1, row1, col1, index1);
                                    bool cond = true;
                                    switch (Console.ReadKey(true).Key)
                                    {
                                        case ConsoleKey.Escape:cond = false; break;
                                        case ConsoleKey.DownArrow:
                                            if (index1 < MenuItems1.Length - 1)
                                            {
                                                index1++;
                                            }
                                            break;
                                        case ConsoleKey.UpArrow:
                                            if (index1 > 0)
                                            {
                                                index1--;
                                            }
                                            break;
                                        case ConsoleKey.Enter:
                                            switch (index1)
                                            {
                                                case 0:
                                                    try
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("Введите первое число:");
                                                        Double.first = Convert.ToDouble(Console.ReadLine());
                                                        Console.WriteLine("Введите второе число:");
                                                        Double.second = Convert.ToDouble(Console.ReadLine());
                                                        Console.WriteLine($"Результат: {Sum()}");
                                                    }
                                                    catch (FormatException)
                                                    {
                                                        Console.WriteLine("Неверно введены числа!!!!");
                                                    }
                                                    Console.ReadKey();
                                                    break;
                                                case 1:
                                                    try
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("Введите первое число:");
                                                        Double.first = Convert.ToDouble(Console.ReadLine());
                                                        Console.WriteLine("Введите второе число:");
                                                        Double.second = Convert.ToDouble(Console.ReadLine());
                                                        Console.WriteLine($"Результат: {Min()}");
                                                    }
                                                    catch (FormatException)
                                                    {
                                                        Console.WriteLine("Неверно введены числа!!!!");
                                                    }
                                                    Console.ReadKey();
                                                    break;
                                                case 2:
                                                    try
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("Введите первое число:");
                                                        Double.first = Convert.ToDouble(Console.ReadLine());
                                                        Console.WriteLine("Введите второе число:");
                                                        Double.second = Convert.ToDouble(Console.ReadLine());
                                                        Console.WriteLine($"Результат: {Mul()}");
                                                    }
                                                    catch (FormatException)
                                                    {
                                                        Console.WriteLine("Неверно введены числа!!!!");
                                                    }
                                                    Console.ReadKey();
                                                    break;
                                                case 3:
                                                    try
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("Введите первое число:");
                                                        Double.first = Convert.ToDouble(Console.ReadLine());
                                                        Console.WriteLine("Введите второе число:");
                                                        Double.second = Convert.ToDouble(Console.ReadLine());
                                                        if (Math.Abs(Double.second) - Math.Pow(10,-8) > 0)
                                                        {
                                                            Console.WriteLine($"Результат: {Div()}");
                                                        }
                                                        else 
                                                        {
                                                            Console.WriteLine("Деление на нуль!!!");
                                                        }
                                                    }
                                                    catch (FormatException)
                                                    {
                                                        Console.WriteLine("Неверно введены числа!!!!");
                                                    }
                                                    Console.ReadKey();
                                                    break;

                                            }
                                            break;
                                    }
                                    if (!cond) { break; }
                                }
                                Console.Clear();
                                break;
                            case 1:
                                row1 = col1 = index1 = 0;
                                Calc<int> Int = new Calc<int>(0, 0);
                                Action<int> Sum1 = Int.Sum;
                                Action<int> Min1 = Int.Min;
                                Action<int> Mul1 = Int.Mul;
                                Action<int> Div1 = Int.Div;
                                while (true)
                                {
                                    Console.Clear();
                                    DrawMenu(MenuItems1, row1, col1, index1);
                                    bool cond = true;
                                    switch (Console.ReadKey(true).Key)
                                    {
                                        case ConsoleKey.Escape: cond = false; break;
                                        case ConsoleKey.DownArrow:
                                            if (index1 < MenuItems1.Length - 1)
                                            {
                                                index1++;
                                            }
                                            break;
                                        case ConsoleKey.UpArrow:
                                            if (index1 > 0)
                                            {
                                                index1--;
                                            }
                                            break;
                                        case ConsoleKey.Enter:
                                            switch (index1)
                                            {
                                                case 0:
                                                    try
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("Введите первое число:");
                                                        Int.first = Convert.ToInt32(Console.ReadLine());
                                                        Console.WriteLine("Введите второе число:");
                                                        Int.second = Convert.ToInt32(Console.ReadLine());
                                                        Console.WriteLine($"Результат: {Sum1()}");
                                                    }
                                                    catch (FormatException)
                                                    {
                                                        Console.WriteLine("Неверно введены числа!!!!");
                                                    }
                                                    Console.ReadKey();
                                                    break;
                                                case 1:
                                                    try
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("Введите первое число:");
                                                        Int.first = Convert.ToInt32(Console.ReadLine());
                                                        Console.WriteLine("Введите второе число:");
                                                        Int.second = Convert.ToInt32(Console.ReadLine());
                                                        Console.WriteLine($"Результат: {Min1()}");
                                                    }
                                                    catch (FormatException)
                                                    {
                                                        Console.WriteLine("Неверно введены числа!!!!");
                                                    }
                                                    Console.ReadKey();
                                                    break;
                                                case 2:
                                                    try
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("Введите первое число:");
                                                        Int.first = Convert.ToInt32(Console.ReadLine());
                                                        Console.WriteLine("Введите второе число:");
                                                        Int.second = Convert.ToInt32(Console.ReadLine());
                                                        Console.WriteLine($"Результат: {Mul1()}");
                                                    }
                                                    catch (FormatException)
                                                    {
                                                        Console.WriteLine("Неверно введены числа!!!!");
                                                    }
                                                    Console.ReadKey();
                                                    break;
                                                case 3:
                                                    try
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("Введите первое число:");
                                                        Int.first = Convert.ToInt32(Console.ReadLine());
                                                        Console.WriteLine("Введите второе число:");
                                                        Int.second = Convert.ToInt32(Console.ReadLine());
                                                        if (Int.second != 0)
                                                        {
                                                            Console.WriteLine($"Результат: {Div1()}");
                                                        }
                                                        else 
                                                        {
                                                            Console.WriteLine("Деление на нуль!!!");
                                                        }
                                                    }
                                                    catch (FormatException)
                                                    {
                                                        Console.WriteLine("Неверно введены числа!!!!");
                                                    }
                                                    Console.ReadKey();
                                                    break;

                                            }
                                            break;
                                    }
                                    if (!cond) 
                                    {
                                        break;
                                    }
                                }
                                Console.Clear();
                                break;

                        }
                        break;
                }
            }
        }
        private static void DrawMenu(string[] items, int row, int col, int index)
        {
            Console.SetCursorPosition(col, row);
            for (int i = 0; i < items.Length; i++)
            {
                if (i == index)
                {
                    Console.BackgroundColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.WriteLine(items[i]);
                Console.ResetColor();
            }
            Console.WriteLine();
        }
    }
    class Calc<T> 
    {
        public T first { get; set; }
        public T second { get; set; }
        public Calc(T first, T second) 
        {
            this.first = first;
            this.second = second;
        }
        public T Sum() 
        {
            dynamic s = first;
            s += second;
            return s;
        }
        public T Min()
        {
            dynamic s = first;
            s -= second;
            return s;
        }
        public T Mul()
        {
            dynamic s = first;
            s *= second;
            return s;
        }
        public T Div() 
        {
            try 
            {
                dynamic s = first;
                s /= second;
                return s;
            }
            catch (DivideByZeroException)
            {
                dynamic res = 0;
                return res;
            }
        }
    }
}
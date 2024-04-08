namespace Delegates_1
{
    delegate double Binnary(double one, double two);
    delegate double Unary(double one);
    interface ICalculator 
    {
        public abstract double Sum(double x, double y);
        public abstract double Minus(double x, double y);
        public abstract double Multi(double x, double y);
        public abstract double Div(double x, double y);
        public abstract double Sqrt(double x);
        public abstract double Sin(double x);
        public abstract double Cos(double x);

    }
    class Calculator : ICalculator
    {
        public double Sum(double one, double two) 
        {
            return one + two;
        }
        public double Minus(double one, double two) 
        {
            return one - two;
        }
        public double Multi(double one, double two) 
        {
            return one * two;
        }
        public double Div(double one, double two) 
        {
            if (Math.Abs(two) < Math.Pow(10, -8))
            {
                throw new Exception("Деление на нуль!!!");
            }
            else 
            {
                return one/two;
            }
        }
        public double Sqrt(double one) 
        {
            if (one > 0)
            {
                return Math.Sqrt(one);
            }
            else 
            {
                throw new Exception("Извлечение корня из отрицательного числа!!!");
            }
        }
        public double Sin(double one) 
        {
            return Math.Sin(one);
        }
        public double Cos(double one) 
        {
            return Math.Cos(one);
        }


    }
    class Program 
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            Binnary bin;
            Unary un;
            Console.WriteLine("Меню");
            Console.WriteLine();
            int row = Console.CursorTop;
            int col = Console.CursorLeft;
            string[] menuItems = new string[] { "Сумма", "Вычитание", "Умножение", "Деление","Извлечение корня", "Синус", "Косинус","Выход" };
            int index = 0;
            while (true)
            {
                DrawMenu(menuItems, 2, 0, index);
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.DownArrow:
                        if (index < menuItems.Length - 1)
                            index++;
                        break;
                    case ConsoleKey.UpArrow:
                        if (index > 0)
                            index--;
                        break;
                    case ConsoleKey.Enter:
                        switch (index)
                        {
                            case 7:
                                Console.Clear();
                                Console.WriteLine("Выбран выход из приложения");
                                return;
                            default:
                                switch (index) 
                                {
                                    case 0:
                                        bin = calc.Sum;
                                        Console.Clear();
                                        Console.WriteLine($"Выбран пункт {menuItems[index]}");
                                        double a, b;
                                        while (true) 
                                        {
                                            try
                                            {
                                                Console.WriteLine("Введите первое число");
                                                a = Convert.ToDouble(Console.ReadLine().Replace(".", ","));
                                                Console.WriteLine("Введите второе число");
                                                b = Convert.ToDouble(Console.ReadLine().Replace(".", ","));
                                                break;
                                            }
                                            catch (FormatException)
                                            {
                                                continue;
                                            }
                                        }
                                        Console.WriteLine($"Результат: {bin(a, b)}");
                                        break;
                                    case 1:
                                        bin = calc.Minus;
                                        Console.Clear();
                                        Console.WriteLine($"Выбран пункт {menuItems[index]}");
                                        while (true)
                                        {
                                            try
                                            {
                                                Console.WriteLine("Введите первое число");
                                                a = Convert.ToDouble(Console.ReadLine().Replace(".", ","));
                                                Console.WriteLine("Введите второе число");
                                                b = Convert.ToDouble(Console.ReadLine().Replace(".", ","));
                                                break;
                                            }
                                            catch (FormatException)
                                            {
                                                continue;
                                            }
                                        }
                                        Console.WriteLine($"Результат: {bin(a, b)}");
                                        break;
                                    case 2:
                                        bin = calc.Multi;
                                        Console.Clear();
                                        Console.WriteLine($"Выбран пункт {menuItems[index]}");
                                        while (true)
                                        {
                                            try
                                            {
                                                Console.WriteLine("Введите первое число");
                                                a = Convert.ToDouble(Console.ReadLine().Replace(".", ","));
                                                Console.WriteLine("Введите второе число");
                                                b = Convert.ToDouble(Console.ReadLine().Replace(".", ","));
                                                break;
                                            }
                                            catch (FormatException)
                                            {
                                                continue;
                                            }
                                        }
                                        Console.WriteLine($"Результат: {bin(a, b)}");
                                        break;
                                    case 3:
                                        bin = calc.Div;
                                        Console.Clear();
                                        Console.WriteLine($"Выбран пункт {menuItems[index]}");
                                        while (true)
                                        {
                                            try
                                            {
                                                Console.WriteLine("Введите первое число");
                                                a = Convert.ToDouble(Console.ReadLine().Replace(".", ","));
                                                Console.WriteLine("Введите второе число");
                                                b = Convert.ToDouble(Console.ReadLine().Replace(".", ","));
                                                break;
                                            }
                                            catch (FormatException)
                                            {
                                                continue;
                                            }
                                        }
                                        Console.WriteLine($"Результат: {bin(a, b)}");
                                        break;
                                    case 4:
                                        un = calc.Sqrt;
                                        Console.Clear();
                                        Console.WriteLine($"Выбран пункт {menuItems[index]}");
                                        while (true)
                                        {
                                            try
                                            {
                                                Console.WriteLine("Введите число");
                                                a = Convert.ToDouble(Console.ReadLine().Replace(".", ","));
                                                break;
                                            }
                                            catch (FormatException)
                                            {
                                                continue;
                                            }
                                        }
                                        Console.WriteLine($"Результат: {un(a)}");
                                        break;
                                    case 5:
                                        un = calc.Sin;
                                        Console.Clear();
                                        Console.WriteLine($"Выбран пункт {menuItems[index]}");
                                        while (true)
                                        {
                                            try
                                            {
                                                Console.WriteLine("Введите число");
                                                a = Convert.ToDouble(Console.ReadLine().Replace(".", ","));
                                                break;
                                            }
                                            catch (FormatException)
                                            {
                                                continue;
                                            }
                                        }
                                        Console.WriteLine($"Результат: {un(a)}");
                                        break;
                                    case 6:
                                        un = calc.Cos;
                                        Console.Clear();
                                        Console.WriteLine($"Выбран пункт {menuItems[index]}");
                                        while (true)
                                        {
                                            try
                                            {
                                                Console.WriteLine("Введите число");
                                                a = Convert.ToDouble(Console.ReadLine().Replace(".", ","));
                                                break;
                                            }
                                            catch (FormatException)
                                            {
                                                continue;
                                            }
                                        }
                                        Console.WriteLine($"Результат: {un(a)}");
                                        break;
                                }
                                Console.ReadKey();
                                Console.Clear();
                                Console.WriteLine("Меню");
                                Console.WriteLine();
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
}
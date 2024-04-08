using System;
using System.ComponentModel.Design;

namespace Garage_2
{
    delegate void Action(Car car);
    delegate void Action1();
    delegate Car Action2(int i);
    delegate List<Car> ActionList();
    internal class Program
    {
        static void Main(string[] args)
        {
            int row = Console.CursorTop;
            int col = Console.CursorLeft;
            string[] menuItems = new string[] { "Создать машину", "Добавить машину в гараж","Удалить машину из гаража", "Помыть машину", "Помыть все машины", "Информация о всех машинах", "Информация о гараже", "Выход" };
            List<Car> list = new List<Car>();
            int index = 0;
            Garage probniy = new Garage();
            Car creating;
            Action adding;
            Action removeing;
            Action cleaning;
            Action2 GetCar;
            ActionList GetList;
            adding = probniy.Add;
            removeing = probniy.Remove;
            GetCar = probniy.GetCar;
            cleaning = Cleaners_service.Cleaning;
            GetList = probniy.GetCars;
            Console.WriteLine("Меню");
            Console.WriteLine();
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
                                        Console.Clear();
                                        Console.WriteLine($"Выбран пункт {menuItems[index]}");
                                        list.Add(new Car());
                                        Console.WriteLine($"Машина под номером {list.Last().ID} была создана!");
                                        break;
                                    case 1:
                                        Console.Clear();
                                        Console.WriteLine($"Выбран пункт {menuItems[index]}");
                                        while (true)
                                        {
                                            try
                                            {
                                                Console.WriteLine("Введите номер машины, которую вы хотите поместить в гараж: ");
                                                int numb = Convert.ToInt32(Console.ReadLine());
                                                if (Car.quantity <= numb && numb >= 0)
                                                {
                                                    Console.WriteLine("Такой машины не существует!!!");
                                                    break;
                                                }
                                                else if (numb < 0)
                                                {
                                                    Console.WriteLine("Такой машины не существует!!!");
                                                    break;
                                                }
                                                else
                                                {
                                                    if (GetCar(numb) == null)
                                                    {
                                                        adding(list[numb]);
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Такая машина уже есть в гараже!!!");
                                                    }
                                                    break;
                                                }
                                            }
                                            catch (FormatException)
                                            {
                                                continue;
                                            }
                                        }
                                        break;
                                    case 2:
                                        Console.Clear();
                                        Console.WriteLine($"Выбран пункт {menuItems[index]}");
                                        while (true)
                                        {
                                            try
                                            {
                                                Console.WriteLine("Введите номер машины, которую вы хотите удалить из гаража: ");
                                                int numb = Convert.ToInt32(Console.ReadLine());
                                                if (GetCar(numb) != null)
                                                {
                                                    removeing(probniy.GetCar(numb));
                                                }
                                                else 
                                                {
                                                    Console.WriteLine("Такой машины нет в гараже!!!");
                                                }
                                                break;
                                            }
                                            catch (FormatException)
                                            {
                                                continue;
                                            }
                                        }
                                        break;

                                    case 3:
                                        Console.Clear();
                                        Console.WriteLine($"Выбран пункт {menuItems[index]}");
                                        while (true)
                                        {
                                            try
                                            {
                                                Console.WriteLine("Введите номер машины, которую вы хотите помыть: ");
                                                int numb = Convert.ToInt32(Console.ReadLine());
                                                if (Car.quantity <= numb && numb >= 0)
                                                {
                                                    Console.WriteLine("Такой машины не существует!!!");
                                                    break;
                                                }
                                                else if (numb < 0)
                                                {
                                                    Console.WriteLine("Такой машины не существует!!!");
                                                    break;
                                                }
                                                else
                                                {
                                                    cleaning(list[numb]);
                                                    Console.WriteLine($"{list[numb].ID} -ая Машина успешно помыта!");
                                                    break;
                                                }
                                            }
                                            catch (FormatException)
                                            {
                                                continue;
                                            }
                                        }
                                        break;
                                    case 4:
                                        Console.Clear();
                                        Console.WriteLine($"Выбран пункт {menuItems[index]}");
                                        int q = Car.quantity;
                                        for (int i = 0; i < q; i++)
                                        {
                                            cleaning(list[i]);
                                        }
                                        break;
                                    case 5:
                                        Console.Clear();
                                        Console.WriteLine($"Выбран пункт {menuItems[index]}");
                                        q = Car.quantity;
                                        Console.WriteLine(Car.quantity);
                                        for (int i = 0; i < q; i++)
                                        {
                                            Console.WriteLine($"Машина {i}-ая; помыта: {list[i].Cleaned}; где находится: {list[i].Place}");
                                        }
                                        break;
                                    case 6:
                                        Console.Clear();
                                        Console.WriteLine($"Выбран пункт {menuItems[index]}");
                                        foreach (Car one_car in GetList())
                                        {
                                            Console.WriteLine($"Машина {one_car.ID}-ая; помыта: {one_car.Cleaned}");
                                        }
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
    class Car
    {
        public static int quantity { get; private set; } = 0;
        public bool Cleaned { get; set; }
        public int ID { get; private set; }
        public string Place { get; set; }
        public Car()
        {
            ID = quantity;
            quantity++;
            Cleaned = false;
            Place = "nowhere";
        }
    }
    class Garage
    {
        List<Car> cars_g = new List<Car>();
        public void Add(Car car) { cars_g.Add(car); car.Place = "garage"; Console.WriteLine($"Машина {car.ID} была поставлена в гараж!"); }
        public void Remove(Car car) { cars_g.Remove(car); car.Place = "nowhere"; Console.WriteLine($"Машина {car.ID} была убрана из гаража!"); }
        public List<Car> GetCars() { return cars_g; }
        public Car GetCar(int id) { foreach (Car car in cars_g) { if (car.ID == id) { return car; } } return null; }
    }
    class Cleaners_service
    {
        public static void Cleaning(Car car)
        {
            car.Cleaned = true;
        }
    }
}
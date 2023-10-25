namespace Lab_4_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = Convert.ToInt32(Console.ReadLine());
            double a = 1;
            double b = 2;
            Console.WriteLine($"{"x",-25}|{"F1",-25}|{"F2",-25}|"); // необязательная строка
            for (double x = a;x<b;x = x+(b-a)/N) 
            {
                double F1 = 1 + Math.Pow(2, x + 5);
                double F2 = Math.Pow(x-1,3);
                Console.Write($"{x,-25}|");
                Console.Write($"{F1,-25}|");
                Console.Write($"{F2,-25}|");
                Console.WriteLine();
            }
        }
    }
}
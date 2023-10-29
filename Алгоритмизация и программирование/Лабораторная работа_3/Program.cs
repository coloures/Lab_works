namespace Lab_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x = Convert.ToDouble(Console.ReadLine());
            double f;
            if (2 < x & x <= 4)
            {
                f = Math.Pow(x + 2.3, 0.2);
            }
            else if (0.3 < x & x <= 2)
            {
                f = x;
            }
            else 
            {
                f = Math.Cos(x - 2.3);
            }
            Console.WriteLine(f);
        }
    }
}
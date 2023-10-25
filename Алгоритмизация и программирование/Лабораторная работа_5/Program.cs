namespace Lab_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float a = 1.9f;
            float x = 2f;
            Console.WriteLine($"|{"x",-20}|{"y",-20}|{"Z",-20}|");
            for (float y = -1 ;x <= 5 ;y = -1, x = x + 0.5f) 
            {
                for (; y <= 1;y = y + 0.5f) 
                {
                    double Z = Math.Pow(a*x*Math.Pow(y, 2), 1/5) 
                        + 1.3*Math.Sin(x-a);
                    Console.WriteLine($"|{x,-20}|{y,-20}|{Z,-20}|");
                }
            }
        }
    }
}
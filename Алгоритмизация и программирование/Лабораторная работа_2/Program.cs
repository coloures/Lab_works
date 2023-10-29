using System;
namespace Lab_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x = Convert.ToInt32(Console.ReadLine());
            double a = 0.7d;
            double c = 2.1d; 
            double y = Math.Sin(x)/Math.Sqrt(1+Math.Pow(a,2)*Math.Pow(Math.Sin(x),2)) - c * Math.Log(a*x);
            Console.WriteLine(y);
        }
    }
}
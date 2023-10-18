using System;
class Program
    {
        static void Main(string[] args)
        {
            int m = Convert.ToInt32(Console.ReadLine());
            int n = Convert.ToInt32(Console.ReadLine());
            int[,] numbers = new int[m, n];
            for (int i = 0; i < numbers.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < numbers.GetUpperBound(1) + 1; j++)
                {
                    numbers[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }            
            for (int i = 0; i < numbers.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < numbers.GetUpperBound(1) + 1; j++)
                {
                    Console.Write(numbers[i, j] + "      ");
                }
                Console.WriteLine();
            }
            int max_quantity = 0;
            for (int i = 0; i < m; i++)
            {
                int max = numbers[i,numbers.GetUpperBound(1)];
                int min = numbers[i, numbers.GetLowerBound(1)];
                if (max == min) 
                {
                    max_quantity++;
                }
            }
            Console.WriteLine(max_quantity);
            Console.ReadKey();
        }
    }
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
            int c = 0;
            for (int i = 0; i < numbers.GetUpperBound(0) + 1; i++) 
            {
                bool condition = true;
                for (int j = 0; j < numbers.GetUpperBound(1) + 1; j++) 
                {
                    if(numbers[i,j] %2 != 0)
                    {
                        condition = false;
                    }
                }
                if(condition)
                {
                    c++;
                }
            }
            Console.WriteLine(c);
        }
    }
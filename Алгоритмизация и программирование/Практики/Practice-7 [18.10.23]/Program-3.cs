using System;
class HelloWorld {
  static void Main() {
    int m = Convert.ToInt32(Console.ReadLine());
    int n = Convert.ToInt32(Console.ReadLine());
    int[,] numbers = new int[m, n];
    //Console.WriteLine(numbers.GetUpperBound(0)); //  строки
    //Console.WriteLine(numbers.GetUpperBound(1)); // столбцы
    for (int i = 0; i < numbers.GetUpperBound(0) + 1; i++) // строки
        {
            for (int j = 0; j < numbers.GetUpperBound(1) + 1; j++) // столбцы
            {
                numbers[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }
    
    for (int i = 0; i < numbers.GetUpperBound(0) + 1; i++) // строки
    {
        for (int j = 0; j < numbers.GetUpperBound(1) + 1; j++) // столбцы
        {
            Console.Write(numbers[i,j] + "     ");
        }
        Console.WriteLine();
    }
    int composition = 1;
    for (int j = 0; j < numbers.GetUpperBound(1) + 1; j++) //  столбцы
    {
        composition = 1;
        bool condition = true;
        for (int i = 0; i < numbers.GetUpperBound(0) + 1; i++) // строки
        {
            if(numbers[i,j] == 0)
            {
                condition = false;
            }
            else
            {
                composition *= numbers[i,j];
            }
        }
        if (condition) 
        {
            Console.WriteLine(composition);
        }

    }
  }
}
using System;
class HelloWorld {
  static void Main() {
    int m = Convert.ToInt32(Console.ReadLine());
    int n = Convert.ToInt32(Console.ReadLine());
    int[,] numbers = new int[m, n];
    Console.WriteLine(numbers.GetUpperBound(0)); //  строки
    Console.WriteLine(numbers.GetUpperBound(1)); // столбцы
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
    int quantity = 0;
    string previous;
    for (int j = 0; j < numbers.GetUpperBound(1) + 1; j++) //  столбцы
    {
        previous = "";
        for (int i = 0; i < numbers.GetUpperBound(0) + 1; i++) // строки
        {
            bool condition = true;
            foreach(string numb in previous.Split(' '))
            {
                if (numb == String.Format("{0}",numbers[i, j]))
                {
                    condition = false;
                }
            }
            if (condition) 
            {
                previous += " " + numbers[i,j];
            }
        }
        Console.WriteLine(previous);
        int c = 0;
        foreach (string numb in previous.Split(' ')) 
        {
            c++;
        }
        if (c-1 == numbers.GetUpperBound(1) + 1) 
        {
            quantity++;
        }
    }
    Console.WriteLine(quantity);
  }
}
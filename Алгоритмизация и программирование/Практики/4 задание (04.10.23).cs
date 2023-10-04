// 4th exercise
using System;
class HelloWorld {
  static void Main() {
    int quantity_of_numbers = Convert.ToInt32(Console.ReadLine());
    int [] numbers = new int [quantity_of_numbers];
    bool condition = true;
    for (int i = 0; i < quantity_of_numbers; i++)
    {
        numbers[i] = Convert.ToInt32(Console.ReadLine());
        double n = numbers[i];
        int length = 0;
        double sum = 0;
        // счетчик кол-ва чисел
        while (n > 0)
        {
            n = Math.Floor(n/10);
            length++;
        }
        Console.WriteLine($"length = {length}");
        n = numbers[i];
        for (int j = 0; j < length; j++)
        {
            sum += n%10;
            n = Math.Floor(n/10);
        }
        Console.WriteLine($"sum = {sum}");
        if (sum%2 != 0)
        {
            condition = false;
        }
    }
    Console.WriteLine(condition);
    
  }
}
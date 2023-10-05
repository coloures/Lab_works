using System;
class HelloWorld {
  static void Main() {
    int quantity = Convert.ToInt32(Console.ReadLine());
    int [] numbers = new int [quantity];
    int n = 0;
    for(int k = 0; k < quantity; k++)
    {
        numbers[k] = Convert.ToInt32(Console.ReadLine());
    }
    for(int i = 0; i < quantity;i++)
    {
        for(int j = i; j < quantity; j++)
        {
            if (j != i)
            {
                n = (numbers[i]*numbers[j])%7==0 ? n+1 : n;
            }
        }
    }
    Console.WriteLine($"{n}");
  }
}
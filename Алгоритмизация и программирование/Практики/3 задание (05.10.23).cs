using System;
class HelloWorld {
  static void Main() {
    int quantity = Convert.ToInt32(Console.ReadLine());
    int [] numbers = new int [quantity];
    int sum = 0;
    for(int i = 0; i < quantity; i++)
    {
        numbers[i] = Convert.ToInt32(Console.ReadLine());
    }
    for(int j = 0; j < quantity-1; j++)
    {

        
        if(numbers[j] < numbers[j+1])
        {
            sum = sum > (numbers[j] + numbers[j+1]) ? sum : (numbers[j] + numbers[j+1]);
        }
        
    }
    Console.WriteLine($"sum = {sum}");
  }
}
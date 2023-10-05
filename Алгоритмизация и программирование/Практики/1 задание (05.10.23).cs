using System;
class HelloWorld {
  static void Main() {
    // Ввод
    int quantity = Convert.ToInt32(Console.ReadLine());
    int [] numbers = new int [quantity];
    double rubbish_number = 0;
    double digit;
    int final = 0;
    for(int i = 0; i < quantity; i++)
    {
        bool condition = true;
        numbers [i] = Convert.ToInt32(Console.ReadLine());
        rubbish_number = Math.Abs(numbers [i]);
        while (rubbish_number > 0)
        {   
            digit = rubbish_number%10;
            rubbish_number = Math.Floor(rubbish_number/10);
            if (digit%2 == 0)
            {
                condition = false;
            }
        }
        if(condition == true)
        {
            final++;
        }
    }
    Console.WriteLine($"quantity of numbers = {final}");
  }
}
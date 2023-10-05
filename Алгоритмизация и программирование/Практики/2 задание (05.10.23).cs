using System;
class HelloWorld {
  static void Main() {
    int quantity = Convert.ToInt32(Console.ReadLine());
    int [] numbers = new int [quantity];
    double rubbish_number = 0;
    int final = 0;
    for(int i = 0; i < quantity; i++)
    {
        numbers [i] = Convert.ToInt32(Console.ReadLine());
        rubbish_number = Math.Abs(numbers [i]);
        if(rubbish_number%5 == 0)
        {
            double sum = 0;
            while(rubbish_number > 0)
            {
                sum += rubbish_number%10;
                rubbish_number = Math.Floor(rubbish_number/10);
                
                
            }
            if(sum%2 == 0)
            {
                final++;
            }
            
            
        }
        
    }
    if(final == quantity){
    Console.WriteLine("True");
    }
    else
    {
        Console.WriteLine("False");
    }
  }
}
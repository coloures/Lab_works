using System;
class HelloWorld {
  static void Main() {
    int number_of_sequence = Convert.ToInt32(Console.ReadLine());
    int quantity = 0;
    double [] sequence = new double [number_of_sequence];
    for(int i = 0; i < number_of_sequence; i++)
    {
        double sum = 0;
        int length = 0;
        sequence[i] = Convert.ToInt32(Console.ReadLine());
        double number = sequence[i];
        // рассчет длины числа
        while (number > 0)
        {
            number = Math.Floor(number/10);
            length++;
        }
        number = sequence[i];
        // разбиение числа на цифры и их проверка на четность и добавление в сумму
        for (int j = 0; j < length; j++)
        {
            if((number%10)%2 == 0)
            {
                sum += number%10;
                Console.WriteLine($"{sum} - сумма цифр для {sequence[i]}");
            }
            number = Math.Floor(number/10);
        }
        // сравнение суммы с 16
        if(sum%16 == 0 & sum != 0)
        {
            quantity++;
        }
        
        
    }
    Console.WriteLine($"{quantity}");
  }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            string convertation = Console.ReadLine();
            foreach (string conv in convertation.Split(' ')) { Console.WriteLine(conv+ "   fefef"); }
            string unlucky_numbers = Console.ReadLine();
            foreach (string unlucky in unlucky_numbers.Split(' ')) { Console.WriteLine(unlucky); }
            //string after_convertation = Console.ReadLine();
            //foreach (string after_conv in after_convertation.Split(' ')) { Console.WriteLine(after_conv); }
            //string after_unlucky_numbers = Console.ReadLine();
            //foreach (string after_unlucky in after_unlucky_numbers.Split(' ')) { Console.WriteLine(after_unlucky); }
            string quantity = Console.ReadLine();
            foreach (string qua in quantity.Split(' ')) { Console.WriteLine(qua); }
            int[,] original = new int[2, Convert.ToInt32(convertation.Split(' ')[0])-1];
            for(int i = 0; i < Convert.ToInt32(convertation.Split(' ')[0])-1; i++)
            {
                original[0,i] = i; // номера разрядов
                original[1,i] = Convert.ToInt32(convertation.Split(' ')[i+1]);  //  конвертация
            }
            //for (int i = 0; i < original.GetUpperBound(0) + 1; i++) 
            //{
            //    for (int j = 0; j < original.GetUpperBound(1) + 1; j++) 
            //    {
            //        Console.Write(original[i, j] + "\t");
            //    }
            //    Console.WriteLine();
            //}
            //for (int i = 1; i < Convert.ToInt32(convertation.Split(' ')[0]); i++)
            //{
            //    Console.WriteLine(convertation.Split(' ')[i]);
            //}
            int num = 0;
            int [] number = new int [Convert.ToInt32(convertation.Split(' ')[0])];
            while(true)
            {
                foreach (int a in number) { Console.Write(a + "\t"); }
                Console.WriteLine();
                bool cond = true;
                int m = 0;
                for (int i = 0; i < Convert.ToInt32(convertation.Split(' ')[0]); i++ )
                {
                    if (number[i] == Convert.ToInt32(quantity.Split(' ')[i])) { m++; }
            
                }
                Console.WriteLine("m = " + m);
                if (m == Convert.ToInt32(convertation.Split(' ')[0])) { break; }
                number[Convert.ToInt32(convertation.Split(' ')[0]) - 1]++;
                foreach (string str in unlucky_numbers.Split(' ')) 
                {
                    if (number[Convert.ToInt32(convertation.Split(' ')[0]) - 1] == Convert.ToInt32(str)) 
                    {
                        number[Convert.ToInt32(convertation.Split(' ')[0]) - 1]++;
                    }
                }
                num++; 
                for (int i = 1; i < Convert.ToInt32(convertation.Split(' ')[0]); i++) 
                {
                    if(number[Convert.ToInt32(convertation.Split(' ')[0]) - i] > Convert.ToInt32(convertation.Split(' ')[convertation.Split(' ').Length-i])-1)
                    {
                        number[Convert.ToInt32(convertation.Split(' ')[0]) - i] = 0;
                        number[Convert.ToInt32(convertation.Split(' ')[0]) - i - 1]++;
                        foreach (string str in unlucky_numbers.Split(' '))
                        {
                            if (number[Convert.ToInt32(convertation.Split(' ')[0]) - i - 1] == Convert.ToInt32(str))
                            {
                                number[Convert.ToInt32(convertation.Split(' ')[0]) - i - 1]++;
                            }
                        }
                    }
            
                }
            }
            Console.WriteLine(num);

                Console.ReadKey();
        }
    }
}

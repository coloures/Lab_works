using System;
namespace For_checking 
{
    class Peasant_and_devil 
    {
        static void Main() 
        {
            long MaxN = Convert.ToInt64(Console.ReadLine());
            if (1 <= MaxN && MaxN <=2000000000) 
            {
                double N = 0;
                int Z = 1;
                double quantity = 0;
                var Max_ = Math.Floor(Math.Log(MaxN+1) / Math.Log(2));
                //Console.WriteLine(Max_);
                for(Z = 1; Z <= Max_; Z++) // рассматривая последовательность чисел мы заметим, что числа с теми же Z имеют схожие качества
                {
                    // N(1) = 2^Z - 1, а K = 2^Z
                    // а другие элементы для того же Z являются просто умноженными на некоторые числа формулами N и K
                    // основная формула такая N(n) = n* (2^Z - 1) ; K(n) = n * 2^Z
                    // для N  у нас ограничение = MaxN
                    N = Math.Pow(2, Z) - 1;
                    quantity += Math.Floor(MaxN / N);  
                }
                Console.WriteLine($"{quantity}");
            }        
        }
    }
}
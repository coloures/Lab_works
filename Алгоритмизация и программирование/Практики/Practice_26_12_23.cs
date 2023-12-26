using System;
class HelloWorld {
  static void Main() {
    for(long i = 106732567; i < 152673836; i++)
    {
        int counting = 0;
        if(Math.Sqrt(i)%1 == 0 && Math.Sqrt(Math.Sqrt(i))%1 == 0)
        {
            //Console.WriteLine("number " + i);
            for(int j = 1; j < Math.Sqrt(Math.Sqrt(i))/2+1; j++)
            {
                if( Math.Sqrt(Math.Sqrt(i))%j == 0){counting++;};
                if(counting > 1){break;}
            }
            if(counting == 1)
            {
                Console.WriteLine(i + " " +  Math.Pow(Math.Sqrt(Math.Sqrt(i)),3));
                continue;
            }
        }
    }
  }
}
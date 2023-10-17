using System;
class HelloWorld {
  static void Main() {
    int quantity = Convert.ToInt32(Console.ReadLine());
    int white_mouse = Convert.ToInt32(Console.ReadLine());
    int k = Convert.ToInt32(Console.ReadLine());
    int []mouses = new int [quantity]; 
    for(int l = 0; l < quantity; l++)
    {
        mouses[l] = l;
    }
    int start = 0;
    while(Array.FindAll(mouses, element => element == -1).Length != mouses.Length-1)
    {
        mouses[Checked(mouses, start, k)] = -1;
        Console.WriteLine(Checked(mouses, start, k) + "frfgr");
        start = Checked(mouses, start, k);
    }
    
    int index = Array.IndexOf(mouses,Array.Find(mouses, element => element != -1));
    int b = 0;
    foreach(int mouse in mouses)
    {
        Console.WriteLine($"{mouse} = {b++}");
    }
    Console.WriteLine(index);
  }
  static int Checked (int[] mouses, int number,int step)
  {
      int m = 0;
      for(int i = 1, j = 0; j < step+1; i++)
      {
        //Console.WriteLine($"{j} - j");
        if(number+i < mouses.Length)
        {
            if(mouses[number+i] != -1)
            {
                ++j;
            }
        }
        else if(number+i > mouses.Length-1)
        {
            int f = number+i;
            while(f > mouses.Length-1)
            {
                f -= mouses.Length;
            }
            if(mouses[f] != -1)
            {
                ++j;
            }
        }
        m = i;
      }
      number+= m;
      while(number > mouses.Length-1)
      {
          number -= mouses.Length;
      }
    //Console.WriteLine(number);
      return number;
  }
}
using System;
class HelloWorld {
  static void Main() {
    int N = Convert.ToInt32(Console.ReadLine());
    int [,] table = new int [2,N-1];
    for(int i = 0; i < N-1; i++)
    {
        table[0,i] = i+2; // номера городов со второго
        int distance = Convert.ToInt32(Console.ReadLine());
        table[1,i] = distance; // расстояния между городами
    }
    for(int i = 0; i < table.GetUpperBound(0)+1; i++)
    {
        for(int j = 0; j < table.GetUpperBound(1)+1; j++)
        {
            Console.Write(table[i,j] + "\t");
        }
        Console.WriteLine();
    }
    int k = Convert.ToInt32(Console.ReadLine());
    int [,] distances = new int [2,N];
    int sum = 10000;
    for(int i = 0; i < N; i++)
    {
        distances[0,i] = i+1; // n города = i+1
    }
    int [,] temp_distances = new int [2,N];
    for(int i = 0; i < N; i++)
    {
        temp_distances[0,i] = i+1; // n города = i+1
    }
    for(int i = 0; i < N-1; i++)
    {
        //Console.WriteLine(i);
        if(table[1,i] / 2 > 2) // n между городами  f+1 и f+2
        {
            int temp_sum =0;
            temp_distances[1,i] = k; // 1
            temp_distances[1,i+1] = table[1,i] - k; // 2
            for(int j = i+1; j < N-1;j++)
            {
                temp_distances[1,j+1] = temp_distances[1,j] + table[1,j];
            }
            for(int j = i; j > 0;j--)
            {
                temp_distances[1,j-1] = temp_distances[1,j] + table[1,j-1];
            }
            for(int j = 0; j < N; j++)
            {
                temp_sum += temp_distances[1,j];
            }
            if (temp_sum < sum)
            {
                distances = temp_distances;
                sum = temp_sum;
            }
        }
    }
    for(int i = 0; i < distances.GetUpperBound(0)+1; i++)
    {
        for(int j = 0; j < distances.GetUpperBound(1)+1; j++)
        {
            Console.Write(distances[i,j] + "\t");
        }
        Console.WriteLine();
    }
    if(sum == 10000)
    {
        Console.WriteLine("Невозможно");
    }
    else
    {Console.WriteLine(sum);}
    
    
    
  }
}
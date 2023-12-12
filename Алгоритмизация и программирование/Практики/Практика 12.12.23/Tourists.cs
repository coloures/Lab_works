using System;
class HelloWorld {
  static void Main() {
    int [] sunrise = new int [2];
    int [] sunset = new int [2];
    for(int i = 0; i < 2; i++)
    {
        Console.WriteLine("введи время восхода ");
        sunrise[i] = Convert.ToInt32(Console.ReadLine());
    }
    for(int i = 0; i < 2; i++)
    {
         Console.WriteLine("введи время захода ");
        sunset[i] = Convert.ToInt32(Console.ReadLine());
    }
    Console.WriteLine("введи скорость ");
    double speed = Convert.ToDouble(Console.ReadLine());
     Console.WriteLine("введи количество пунктов ");
    int quantity = Convert.ToInt32(Console.ReadLine());
    double [,] distances = new double [2,quantity];
    for(int i = 0; i < quantity; i ++)
    {
        distances[0,i] = i+1;
         Console.WriteLine("введи расстояние до пункта "+ (i+1) + " ");
        distances[1,i] = Convert.ToDouble(Console.ReadLine());
    }
    int hours_in_day = sunset[0] - sunrise[0];
    if(sunset[1]-sunrise[1]<0)
    {
        hours_in_day--;
    }
    int time = 0;
    double current_location = 0;
    string points = "";
    while(current_location != distances[1, distances.GetUpperBound(1)])
    {
        Console.WriteLine("current_location  " + current_location);
        Console.WriteLine("time  " + time);
        double possible_distance = hours_in_day*speed;
        for(int i = 0; i < quantity; i++)
        {
            if (current_location + possible_distance >= distances[1, distances.GetUpperBound(1)])
            {
                time++;
                current_location = distances[1, distances.GetUpperBound(1)];
                break;
            }
            else if(current_location+possible_distance > distances[1,i])
            {
                continue;
            }
            else if(current_location + possible_distance < distances[1,i])
            {
                points += distances[0,i-1];
                current_location = distances[1,i-1];
                time++;
                break;
            }
        }
        if(current_location == distances[1, distances.GetUpperBound(1)])
        {
            break;
        }
    }
    Console.WriteLine(time);
    foreach(char a in points.ToCharArray())
    {
        Console.WriteLine("point of a stop " + a);
    }
    
  }
}
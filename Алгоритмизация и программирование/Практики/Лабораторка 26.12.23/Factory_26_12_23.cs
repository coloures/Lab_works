using System;
class Factory
{
    string name;
    int year;
    int capacity;
    public Factory(string name, int year, int capacity)
    {
        this.name = name;
        this.year = year;
        this.capacity = capacity;
        
    }
    public int Print_year_info(int year)
    {
        if(this.year == year)
        {
            return capacity;
        }
        else
        {
            return 0;
        }
    }
    public void Table()
    {
        {
        Console.WriteLine($"||{name, 25}||{year, 25}||{capacity,25}||");
        }
            
    }
}
class HelloWorld {
  static void Main() 
  {
      Factory [] factories = new Factory [6];
      factories[0] = new Factory("Station 1",2001, 40);
      factories[1] = new Factory("Station 1",2002, 60);
      factories[2] = new Factory("Station 3",2001, 50);
      factories[3] = new Factory("Station 3",2004, 60);
      factories[4] = new Factory("Station 5",2006, 79);
      factories[5] = new Factory("Station 6",2001, 10);
      int sum = 0;
      Console.WriteLine($"||{"name",25}||{"year",25}||{"capacity",25}||");
      foreach(Factory fact in factories)
      {
          fact.Table();
          sum += fact.Print_year_info(2001);
      }
      Console.WriteLine(sum);
  }
}
using System;
class Person
{
    string name;
    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
        }
    }
    string date_of_birth;
    public string Date_of_birth
    {
        get
        {
            return date_of_birth;
        }
        set
        {
            date_of_birth = value;
        }
    }
    string education;
    public string Education
    {
        get
        {
            return education;
        }
        set
        {
            education = value;
        }
    }
    string address;
    public string Address
    {
        get
        {
            return address;
        }
        set
        {
            address = value;
        }
    }
    public string Checkbydate (string Date_of_birth)
    {
        if (Date_of_birth == this.Date_of_birth)
        {
            return Name;
        }
        else 
        {
            return "-1";
        }
    }
    public string CheckbyAddress (string Address)
    {
        if (Address == this.Address)
        {
            return Name;
        }
        else
        {
            return "-1";
        }
    }
    public string CheckbyEducation (string Education)
    {
        if (Education == this.Education)
        {
            return Name;
        }
        else
        {
            return "-1";
        }
    }
    public Person () : this("unknown")
    {}
    public Person (string Name) : this(Name, "unknown")
    {}
    public Person (string Name, string Date_of_birth) : this(Name, Date_of_birth, "unknown")
    {}
    public Person (string Name, string Date_of_birth, string Education) : this(Name,Date_of_birth,Education, "unknown")
    {}
    public Person (string Name, string Date_of_birth, string Education, string Address)
    {
        this.Name = Name;
        this.Date_of_birth = Date_of_birth;
        this.Education = Education;
        this.Address = Address;
    }
}
class HelloWorld {
  static void Main() 
  {
      Person [] workers = new Person [5];
      workers[0] = new Person ("Joseph Emerson", "05.04.2000","Kambridge","7/5 Avenue");
      workers[1] = new Person ("Andrew Miers","06.11.1996","Oxford","8/6 Avenue");
      workers[2] = new Person ("Elizabeth Fire","23.01.1987","MSU","9/3 Avenue");
      workers[3] = new Person ("Margo Ammers", "06.11.1996","Oxford","9/3 Avenue");
      workers[4] = new Person ("Petr Maricleff","05.04.2000","OMSTU","10/5 Avenue");
      Console.Write("Sort will be done by (address/education/date):  ");
      string aspect = Console.ReadLine();
      Console.WriteLine();
      Console.Write("What date/education/address you need? Write ");
      string needed = Console.ReadLine();
      Console.WriteLine();
      if(aspect == "date")
      {
          foreach(Person worker in workers)
      {
          if(worker.Checkbydate(needed) != "-1")
          {
            Console.WriteLine(worker.Checkbydate(needed));
          }
      }
      }
      if(aspect == "education")
      {
          foreach(Person worker in workers)
      {
          if(worker.CheckbyEducation(needed) != "-1")
          {
            Console.WriteLine(worker.CheckbyEducation(needed)); 
          }
      }
      }
      if(aspect == "address")
      {
          foreach(Person worker in workers)
      {
          if(worker.CheckbyAddress(needed) != "-1")
          {
            Console.WriteLine(worker.CheckbyAddress(needed));
          }
      }
      }
    
  }
}
/******************************************************************************

Welcome to GDB Online.
GDB online is an online compiler and debugger tool for C, C++, Python, Java, PHP, Ruby, Perl,
C#, OCaml, VB, Swift, Pascal, Fortran, Haskell, Objective-C, Assembly, HTML, CSS, JS, SQLite, Prolog.
Code, Compile, Run and Debug online from anywhere in world.

*******************************************************************************/
using System;
class Books
{
    string author = "";
    public string Author
    {
        get
        {
            return author;
        }
        set
        {
            author = value;
        }
    }
    string title = "";
    public string Title
    {
        get
        {
            return title;
        }
        set
        {
            title = value;
        }
    }
    int year = -1000;
    public int Year
    {
        get
        {
            return year;
        }
        set
        {
            year = value;
        }
    }
    int [] dates_of_issuance = new int [12];
    public int [] Dates_of_issuance
    {
        get
        {
            int [] dates = new int [12];
            int i = 0;
            foreach(int date in dates_of_issuance)
            {
                if(date != 0)
                {
                dates[i++] = date;
                }
            }
            return dates;
        }
        set
        {
            foreach(int a in value)
            {
                for(int i = 0; i < 12; i++)
                {
                    if(dates_of_issuance[i] == 0)
                    {
                        dates_of_issuance[i] = a;
                        break;
                    }
                }
            }
        }
    }
    public void Check_by_year(int year)
    {
        if(Year > year)
        {
            Console.WriteLine(Title);
        }
    }
    public void Check_by_author(string name)
    {
        if(Author == name)
        {
            Console.WriteLine(Title);
        }
    }
    public void Check_by_Title (string title)
    {
        if(Title == title)
        {
            Console.WriteLine("Author: " + Author);
            Console.WriteLine("Year: " + Year);
            foreach(int date in Dates_of_issuance)
            {
                if(date!= 0)
                {
                Console.WriteLine(date);    
                }
            }
        }
    }
    public Books(string author, string title, int year, int[] date_of_issuance)
    {
        Author = author;
        Title = title;
        Year = year;
        Dates_of_issuance = date_of_issuance;
    }
}
class HelloWorld {
  static void Main() {
      int [] dates = new int [2];
      dates[0] = 11;
      dates[1] = 12;
      int [] dates_1 = {8,9};
      Books [] book_shelf = new Books [3];
      book_shelf[0] = new Books ("Arthur Conan Doyle","Sherlock Holmes",1867,dates);
      book_shelf[1] = new Books ("J.K.Rowling","Harry Potter",1998,dates_1);
      book_shelf[2] = new Books ("Arthur Conan Doyle","A study in scarlet",1865, dates_1);
      string title = Console.ReadLine();
      foreach(Books book in book_shelf)
      {
        book.Check_by_Title(title);
      }
      int year = Convert.ToInt32(Console.ReadLine());
      foreach(Books book in book_shelf)
      {
        book.Check_by_year(year);
      }
      string author = Console.ReadLine();
      foreach(Books book in book_shelf)
      {
        book.Check_by_author(author);
      }      
  }
}
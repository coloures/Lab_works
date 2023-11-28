/******************************************************************************

Welcome to GDB Online.
GDB online is an online compiler and debugger tool for C, C++, Python, Java, PHP, Ruby, Perl,
C#, OCaml, VB, Swift, Pascal, Fortran, Haskell, Objective-C, Assembly, HTML, CSS, JS, SQLite, Prolog.
Code, Compile, Run and Debug online from anywhere in world.

*******************************************************************************/
using System;
class HelloWorld {
  static void Main() {
      int n = Convert.ToInt32(Console.ReadLine());
      int t = Convert.ToInt32(Console.ReadLine());
      string pairs; // a b
      int max_1 = 0; // проход по верху
      int max_2 = 0; // проход сверху по диагонали
      int max_3 = 0; // проход снизу
      for(int i = 0; i < n; i++)
      {
          pairs = Console.ReadLine();
          if(i == 0)
          {
              max_1 = Convert.ToInt32(pairs.Split(' ')[0]); // a
              max_2 = max_3 = Convert.ToInt32(pairs.Split(' ')[1]) + t; // b + t
          }
          else if (i != n-1)
          {
              max_3 += Convert.ToInt32(pairs.Split(' ')[1]); // max_3 + b
              max_2 = max_1 + Convert.ToInt32(pairs.Split(' ')[1]) + t; // max_2 + t + b
              if(max_3 > max_2){max_3 = max_2;}
              else {max_2 = max_3;}
              max_1 += Convert.ToInt32(pairs.Split(' ')[0]);
          }
          else 
          {
            max_3 += Convert.ToInt32(pairs.Split(' ')[1]); // max_3 + b
              max_2 = max_1 + Convert.ToInt32(pairs.Split(' ')[1]) + t; // max_2 + t + b
              if(max_3 > max_2){max_3 = max_2;}
              else {max_2 = max_3;}
              max_1 += Convert.ToInt32(pairs.Split(' ')[0]) + t;
              Console.WriteLine(Minimal(max_1, Minimal(max_2,max_3)));
          }
          Console.WriteLine($"{max_1} - max_1; {max_2} - max_2; {max_3} - max_3");
      }
      
  }
  static int Minimal (int n1, int n2)
  {
      if(n1 > n2){return n2;}
      else{return n1;}
  }

}
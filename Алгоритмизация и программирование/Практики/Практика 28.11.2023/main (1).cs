/******************************************************************************

Welcome to GDB Online.
GDB online is an online compiler and debugger tool for C, C++, Python, Java, PHP, Ruby, Perl,
C#, OCaml, VB, Swift, Pascal, Fortran, Haskell, Objective-C, Assembly, HTML, CSS, JS, SQLite, Prolog.
Code, Compile, Run and Debug online from anywhere in world.

*******************************************************************************/
using System;
class HelloWorld {
  static void Main() {
    string str = Console.ReadLine();
    int max_l = 1;
    string pal = str[0]+"";
    for(int i = 0 ; i < str.Length; i++)
    {
        for (int j = 1; j < 1+str.Length-i; j++)
        {
            if(str.Substring(i,j).ToLower() == Reverso(str.Substring(i,j)))
            {
                pal = str.Substring(i,j).ToLower().Length > max_l ? str.Substring(i,j).ToLower() : pal;
                max_l = str.Substring(i,j).ToLower().Length > max_l ? str.Substring(i,j).ToLower().Length : max_l;
            }
        }
    }
    Console.WriteLine($"{pal} - palindrome; {max_l} - max Length");
  }
  static string Reverso (string str)
  {
      string rev;
      string [] str_a = new string [str.Length]; 
      for(int i = 0; i < str.Length; i++)
      {
          str_a [i] = Convert.ToString(str[str.Length-i-1]);
      }
      rev = String.Join("", str_a);
      rev = rev.ToLower();
      return rev;
  }
}
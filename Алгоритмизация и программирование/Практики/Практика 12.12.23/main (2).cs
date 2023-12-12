/******************************************************************************

Welcome to GDB Online.
GDB online is an online compiler and debugger tool for C, C++, Python, Java, PHP, Ruby, Perl,
C#, OCaml, VB, Swift, Pascal, Fortran, Haskell, Objective-C, Assembly, HTML, CSS, JS, SQLite, Prolog.
Code, Compile, Run and Debug online from anywhere in world.

*******************************************************************************/
using System;
class HelloWorld {
  static void Main() {
    int number = Convert.ToInt32(Console.ReadLine());
    string [] strings = new string [number];
    int quantity = 0;
    for(int i = 0 ; i < number; i++)
    {
        strings[i] = Console.ReadLine();
    }
    string sample = Console.ReadLine();
    for(int i = 0; i < number; i++)
    {
        for(int j = 0;j < strings[i].Length-sample.Length;j += sample.Length)
        {
            if(strings[i].Substring(j,sample.Length) == sample)
            {
                quantity++;
            }
        }
    }
    Console.WriteLine(quantity);
  }
}
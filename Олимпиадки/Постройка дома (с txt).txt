using System;
using System.IO;

class HelloWorld
{
    static void Main()
    {
        string number;
        StreamReader f = new StreamReader("input.txt");
        while (!f.EndOfStream)
        {
            number = f.ReadLine();
        }
        int x = Convert.ToInt32(number.Split(' ')[0]);
        int y = Convert.ToInt32(number.Split(' ')[1]);
        int l = Convert.ToInt32(number.Split(' ')[2]);
        int c1 = Convert.ToInt32(number.Split(' ')[3]);
        int c2 = Convert.ToInt32(number.Split(' ')[4]);
        int c3 = Convert.ToInt32(number.Split(' ')[5]);
        int c4 = Convert.ToInt32(number.Split(' ')[6]);
        int c5 = Convert.ToInt32(number.Split(' ')[7]);
        int c6 = Convert.ToInt32(number.Split(' ')[8]);
        f.Close();
        int max = Math.Max(x, y);
        int cond1 = c1;
        int cond2 = c2 + c3;
        int cond3 = c2 + c6 + c5 + c4;
        int s;
        if (l > 2 * (x + y))
        {
            s = (l - 2 * (x + y)) * (c2 + c6);
            l = 2 * (x + y);
        }
        else
        {
            s = (2 * (x + y) - l) * c4 + (2 * (x + y) - l) * c5;
        }
        if (l <= max)
        {
            if (cond1 <= cond2 & cond1 <= cond3)
            {
                s = s + l * cond1;
            }
            if (cond2 < cond1 & cond2 <= cond3)
            {
                s = s + l * cond2;
            }
            if (cond3 < cond1 & cond3 < cond2)
            {
                s = s + l * cond3;
            }
        }
        else
        {
            if (cond1 <= cond2 & cond1 <= cond3)
            {
                s = s + max * cond1;
                if (cond2 <= cond3)
                {
                    s = s + (l - max) * cond2;
                }
                else
                {
                    s = s + (l - max) * cond3;
                }
            }
            if (cond2 < cond1 & cond2 <= cond3)
            {
                s = s + l * cond2;
            }
            if (cond3 < cond1 & cond3 < cond2)
            {
                s = s + l * cond3;
            }
        }
        Console.WriteLine(s);
        StreamWriter t = new StreamWriter("input.txt");
        t.WriteLine(s);
        t.Close();
    }
}
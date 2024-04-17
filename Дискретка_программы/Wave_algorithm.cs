using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication19
{
    class Program
    {
        static void Main(string[] args)
        {
            // Пример ввода данных:
            //5
            //4
            //1111111
            //1000001
            //1111101
            //1000001
            //1200001
            //1111111
            //1
            //1
            int len_x = Convert.ToInt32(Console.ReadLine());
            int len_y = Convert.ToInt32(Console.ReadLine());
            int t = len_x * len_y + 1;
            int[,] table = new int[len_x + 2, len_y + 2];
            int pos_x, pos_y;
            for (int i = 0; i < len_y + 2; i++) 
            {
                string temp = Console.ReadLine();
                for (int j = 0; j < len_x + 2; j++) // по прямой
                {
                    switch (temp[j]) 
                    {
                        case '0':
                            table[j, i] = len_x * len_y + 1;
                            break;
                        case '1':
                            table[j, i] = -1;
                            break;
                        case '2':
                            table[j, i] = 0;
                            break;
                    }
                }
            }
            Console.WriteLine("На какой позиции конец 0x?");
            pos_x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("На какой позиции конец 0y?");
            pos_y = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            int row = Console.CursorTop;
            int col = Console.CursorLeft;
            while (true) 
            {
                int count = 0;
                bool cond = false;
                for (int i = 1; i < table.GetUpperBound(1); i++) 
                {
                    for (int j = 1; j < table.GetUpperBound(0); j++)
                    {
                        for (int k = -1; k < 2; k++) 
                        {
                            for (int l = -1; l < 2; l++) 
                            {
                                if (table[k + j, i + l] + 1 < table[j, i]) 
                                {
                                    if (table[k + j, i + l] == -1) { continue; }
                                    table[j, i] = table[k + j, i + l] + 1;
                                    if (j == pos_x && i == pos_y) 
                                    {
                                        cond = true;
                                    }
                                    count++;
                                }
                            }
                        }
                    }
                }
                for (int i = 0; i <= table.GetUpperBound(1); i++)
                {
                    row = i * 5;
                    for (int j = 0; j <= table.GetUpperBound(0); j++)
                    {
                        col = j * 5;
                        switch (table[j, i])
                        {
                            default:
                                Console.SetCursorPosition(col, row);
                                Console.WriteLine("     ");
                                Console.SetCursorPosition(col, row + 1);
                                Console.WriteLine(String.Format("{0,5}", table[j, i]));
                                Console.SetCursorPosition(col, row + 2);
                                Console.WriteLine("     ");
                                break;
                            case -1:
                                Console.SetCursorPosition(col, row);
                                Console.Write("XXXXX");
                                Console.SetCursorPosition(col, row + 1);
                                Console.Write("XXXXX");
                                Console.SetCursorPosition(col, row + 2);
                                Console.Write("XXXXX");
                                break;
                            case 0:
                                Console.SetCursorPosition(col, row);
                                Console.Write("     ");
                                Console.SetCursorPosition(col, row + 1);
                                Console.Write(" НАЧ ");
                                Console.SetCursorPosition(col, row + 2);
                                Console.Write("     ");
                                break;
                        }
                    }
                }
                Console.ReadKey();
                if (count == 0 || cond) 
                {
                    break;
                }
            
            }
            Console.Clear();
            Console.ReadLine();
        }
    }
}

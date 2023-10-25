namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int[] calendar = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
                int[] extra_calendar = { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
                int[,] info = new int[2, 3];
                int i = 0;
                StreamReader sr = new StreamReader("E:\\Projects_VS\\ConsoleApp25\\ConsoleApp5\\input_s1_08.txt");
                string start_date = sr.ReadLine();
                foreach (string inf in start_date.Split('.'))
                {
                    info[0, i++] = int.Parse(inf);
                }
                string end_date = sr.ReadLine();
                i = 0;
                foreach (string inf in end_date.Split('.'))
                {
                    info[1, i++] = int.Parse(inf);
                }
                int quantity = int.Parse(sr.ReadLine());
                int quantity_of_days = 0;
                if (info[0, 2] == info[1, 2])
                {
                    for (int s = info[0, 1]; s < info[1, 1] + 1; s++)
                    {
                        if (info[0, 1] == info[1, 1]) { quantity_of_days = info[1, 0] - info[0, 0] + 1; break; }
                        if (s == info[0, 1])
                        {
                            quantity_of_days += info[0, 2] % 4 == 0 ? extra_calendar[info[0, 1] - 1] - info[0, 0] + 1
                                : calendar[info[0, 1] - 1] - info[0, 0] + 1;
                        }
                        else if (s == info[1, 1])
                        {
                            quantity_of_days += info[1, 0];

                        }
                        else
                        {
                            quantity_of_days += info[0, 2] % 4 == 0 ? extra_calendar[s - 1]
                                : calendar[s - 1];
                        }

                    }


                }
                else
                {
                    for (int s = info[0, 1]; s < 13; s++)
                    {
                        if (s == info[0, 1])
                        {
                            quantity_of_days += info[0, 2] % 4 == 0 ? extra_calendar[info[0, 1] - 1] - info[0, 0] + 1
                                : calendar[info[0, 1] - 1] - info[0, 0] + 1;
                        }
                        else
                        {
                            quantity_of_days += info[0, 2] % 4 == 0 ? extra_calendar[s - 1]
                                : calendar[s - 1];
                        }
                    }
                    for (int year = info[0, 2] + 1; year < info[1, 2]; year++)
                    {
                        for (int s = 1; s < 13; s++)
                        {
                            quantity_of_days += year % 4 == 0 ? extra_calendar[s - 1]
                                : calendar[s - 1];
                        }
                    }
                    for (int s = 1; s < info[1, 1] + 1; s++)
                    {
                        if (s == info[1, 1])
                        {
                            quantity_of_days += info[1, 0];
                        }
                        else
                        {
                            quantity_of_days += info[1, 2] % 4 == 0 ? extra_calendar[s - 1] : calendar[s - 1];
                        }
                    }

                }
                int sum = (quantity + (quantity + (quantity_of_days - 1) * 1)) * quantity_of_days / 2;
                try
                {
                    StreamWriter sw = new StreamWriter("E:\\Projects_VS\\ConsoleApp25\\ConsoleApp5\\output_s1_08.txt");
                    sw.WriteLine(sum);
                    sw.Close();
                }
                finally
                {
                }
                sr.Close();

            }
            finally 
            {
            }
        }
    }
}
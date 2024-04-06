using System.Linq.Expressions;

namespace Rubics_cube
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int j = 1; j < 21; j++)
            {
                string source = $"E:\\Projects_VS\\Sets\\Rubics_cube\\input_s1_{j.ToString("00")}.txt";
                StreamReader sr = new StreamReader(source);
                string s = sr.ReadLine();
                int size = Convert.ToInt32(s.Split(" ")[0]);
                int steps = Convert.ToInt32(s.Split(" ")[1]);
                string pos = sr.ReadLine();
                int pos_X = Convert.ToInt32(pos.Split(" ")[0]);
                int pos_Y = Convert.ToInt32(pos.Split(" ")[1]);
                int pos_Z = Convert.ToInt32(pos.Split(" ")[2]);
                for (int i = 0; i < steps; i++)
                {
                    string temp = sr.ReadLine();
                    int cond = 0;
                    if (temp.Split(" ")[0] == "X")
                    {
                        cond = 0;
                    }
                    else if (temp.Split(" ")[0] == "Y")
                    {
                        cond = 1;
                    }
                    else { cond = 2; }
                    switch (cond)
                    {
                        case 0:
                            if (pos_X == Convert.ToInt32(temp.Split(" ")[1]))
                            {
                                if (Convert.ToInt32(temp.Split(" ")[2]) == 1)
                                {
                                    Symmetria_by_diag_plus(ref pos_Y, ref pos_Z, size);
                                    Symmetria_by_middle(ref pos_Y, ref pos_Z, size);
                                }
                                else
                                {
                                    Symmetria_by_diag_minus(ref pos_Y, ref pos_Z, size);
                                    Symmetria_by_middle(ref pos_Y, ref pos_Z, size);
                                }
                            }
                            break;
                        case 1:
                            if (pos_Y == Convert.ToInt32(temp.Split(" ")[1]))
                            {
                                if (Convert.ToInt32(temp.Split(" ")[2]) == 1)
                                {
                                    Symmetria_by_diag_plus(ref pos_X, ref pos_Z, size);
                                    Symmetria_by_middle(ref pos_X, ref pos_Z, size);
                                }
                                else
                                {
                                    Symmetria_by_diag_minus(ref pos_X, ref pos_Z, size);
                                    Symmetria_by_middle(ref pos_X, ref pos_Z, size);
                                }
                            }
                            break;
                        case 2:
                            if (pos_Z == Convert.ToInt32(temp.Split(" ")[1]))
                            {
                                if (Convert.ToInt32(temp.Split(" ")[2]) == 1)
                                {
                                    Symmetria_by_diag_plus(ref pos_X, ref pos_Y, size);
                                    Symmetria_by_middle(ref pos_X, ref pos_Y, size);
                                }
                                else
                                {
                                    Symmetria_by_diag_minus(ref pos_X, ref pos_Y, size);
                                    Symmetria_by_middle(ref pos_X, ref pos_Y, size);
                                }
                            }
                            break;
                    }

                }
                sr.Close();
                string way = $"E:\\Projects_VS\\Sets\\Rubics_cube\\output_s1_{j.ToString("00")}.txt";
                StreamWriter sw = new StreamWriter(way);
                sw.WriteLine($"{pos_X} {pos_Y} {pos_Z}");
                sw.Close();
            }
        }
        static void Symmetria_by_diag_plus(ref int Y, ref int Z, int size) // симметрия по диагонали (1, size -> size, 1)
        {
            int Y_main_point = 1;
            int Z_main_point = size;
            int temp_Y = Y + 0;
            int temp_Z = Z - 0;
            Y = Y_main_point - (-Z_main_point + temp_Z);
            Z = Z_main_point - (-Y_main_point + temp_Y);
        }
        static void Symmetria_by_diag_minus(ref int Y, ref int Z, int size) // симметрия по диагонали (size, 1 -> 1, size)
        {
            int Y_main_point = size;
            int Z_main_point = size;
            int temp_Y = Y + 0;
            int temp_Z = Z - 0;
            Y = Y_main_point + (-Z_main_point + temp_Z);
            Z = Z_main_point + (-Y_main_point + temp_Y);
        }
        static void Symmetria_by_middle(ref int Y, ref int Z, int size) // симметрия по середине
        {
            if (Y <= size / 2)
            {
                int Y_main_point = 1;
                Y = size - (Y - Y_main_point);
            }
            else
            {
                int Y_main_point = size;
                Y = 1 + (Y_main_point - Y);
            }
        }
    }
}

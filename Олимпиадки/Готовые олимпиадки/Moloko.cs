
namespace Milk
{
    internal class Program
    {
        static void Main()
        {
            for (int j = 1; j <= 10; ++j) {
                string path = "E:\\Projects_VS\\Exercises\\Milk\\input" + j + ".txt";
                string out_path = "E:\\Projects_VS\\Exercises\\Milk\\output" + j + ".txt";
                try
                {
                    StreamReader sr = new StreamReader(path);
                    int n = Convert.ToInt32(sr.ReadLine());
                    double price = 10000000.0;
                    int number = 1;
                    for (int i = 0; i < n; i++)
                    {
                        string info = sr.ReadLine();
                        string[] info_ = info.Split(' ');
                        double multiplier =
                            (2.0 * Convert.ToInt32(info_[0]) * Convert.ToInt32(info_[2]) +
                             2.0 * Convert.ToInt32(info_[0]) * Convert.ToInt32(info_[1]) +
                             2.0 * Convert.ToInt32(info_[1]) * Convert.ToInt32(info_[2])) /
                            (2.0 * Convert.ToInt32(info_[3]) * Convert.ToInt32(info_[5]) +
                             2.0 * Convert.ToInt32(info_[3]) * Convert.ToInt32(info_[4]) +
                             2.0 * Convert.ToInt32(info_[4]) * Convert.ToInt32(info_[5]));
                        double quantity_of_milk = Convert.ToInt32(info_[0]) * Convert.ToInt32(info_[1]) * Convert.ToInt32(info_[2]) -
                            multiplier * Convert.ToInt32(info_[3]) * Convert.ToInt32(info_[4]) * Convert.ToInt32(info_[5]);
                        if (price > 1000 * (Convert.ToDouble(info_[6].Replace('.', ',')) - multiplier * Convert.ToDouble(info_[7].Replace('.', ','))) / quantity_of_milk)
                        {
                            number = i + 1;
                            price = 1000 * (Convert.ToDouble(info_[6].Replace('.', ',')) - multiplier * Convert.ToDouble(info_[7].Replace('.', ','))) / quantity_of_milk;
                        }
                    }
                    try
                    {
                        StreamWriter sw = new StreamWriter(out_path);
                        if (Math.Round(price, 2) == -0) 
                        {
                            sw.WriteLine(number + " " + 0);
                        }
                        else 
                        {
                            sw.WriteLine(number + " " + Math.Round(price, 2));
                        }
                        sw.Close();
                    }
                    finally { }
                    sr.Close();
                }
                finally { }
            }
        }
    }
}

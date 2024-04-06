namespace Tau_Kita
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            List<string> list = str.Split(" ").ToList();
            string[] done = new string[str.Split(" ").Count()];
            int i = str.Split(" ").Count() - 1;
            for (; i >= 0; i--)
            {
                if (i % 2 == 1)
                {
                    done[i] = list.First();
                    list.Remove(done[i]);
                }
                else
                {
                    done[i] = list.Last();
                    list.Reverse();
                    list.Remove(done[i]);
                    list.Reverse();
                }
            }
            for (int j = 0; j < done.Length; j++) 
            {
                done[j] = Changing_word(done[j]);
            }
            Console.WriteLine(string.Join(" ", done));
        }
        static string Changing_word(string word) 
        {
            char[] chars = word.ToCharArray();
            List<char> chars1 = chars.ToList();
            char[] done = new char[chars.Length];
            int i = chars.Length - 1;
            for (; i >= 0; i--)
            {
                if (i % 2 == 1)
                {
                    done[i] = chars1.First();
                    chars1.Remove(done[i]);
                }
                else
                {
                    done[i] = chars1.Last();
                    chars1.Reverse();
                    chars1.Remove(done[i]);
                    chars1.Reverse();
                }

            }
            return string.Join("", done);
        }
    }
}

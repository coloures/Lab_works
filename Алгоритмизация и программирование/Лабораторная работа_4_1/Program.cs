namespace Lab_4_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = Convert.ToInt32(Console.ReadLine());
            long Z = 1;
            int S = 0;
            for (int i = 1; i < N+1; i++) 
            {
                S = S + 2;
                Z = Z * S;
            }
            Console.WriteLine(Z);
        }
    }
}
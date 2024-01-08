using System;

class Gryadki
{
    static void Main()
    {
        Console.Write("Введите P: ");
        int P = int.Parse(Console.ReadLine());

        Console.Write("Введите k: ");
        int k = int.Parse(Console.ReadLine());

        Console.Write("Введите l: ");
        int l = int.Parse(Console.ReadLine());

        Console.Write("Введите N: ");
        int N = int.Parse(Console.ReadLine());

        // 1-й способ
        int answer1 = 0;
        for (int i = 1; i <= N; i++)
        {
            answer1 += 2 * P + l * (i + 1) + l * (i - 1) + 2 * k;
        }
        Console.WriteLine(answer1);

        // 2-й способ
        int answer2 = l * N * (N - 1) + 2 * N * (l + k + P);
        Console.WriteLine(answer2);
    }
}

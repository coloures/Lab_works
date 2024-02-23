namespace Stack_first_exercise
{
    internal class first_exercise
    {
        static void Main(string[] args) // ( - 40; ) - 41; [ - 91; ] - 93; { - 123; } - 125
        {
            List<char> symbols = new List<char>();
            string str = Console.ReadLine();
            foreach (char symbol in str.ToCharArray()) 
            {
                symbols.Add(symbol);
            }
            Stack<char> stack = new Stack<char>();
            char current_char;
            char current_skobka;
            bool answer = true;
            foreach (char symbol in symbols)
            {
                current_char = symbol;
                if ((int)current_char == 40 || (int)current_char == 91 || (int)current_char == 123) // открывающиеся скобки
                {
                    stack.Push(current_char);
                }
                else if ((int)current_char == 41) // закрывающаяся круглая
                {
                    if (stack.TryPop(out current_skobka) == false || Math.Abs((int)current_skobka- (int)current_char) != 1)
                    {
                        answer = false;
                        break;
                    }
                }
                else if ((int)current_char == 93) // закрывающаяся квадратная
                {
                    if (stack.TryPop(out current_skobka) == false || Math.Abs((int)current_skobka - (int)current_char) != 2)
                    {
                        answer = false;
                        break;
                    }
                }
                else if ((int)current_char == 125) // закрывающаяся фигурная
                {
                    if (stack.TryPop(out current_skobka) == false || Math.Abs((int)current_skobka - (int)current_char) != 2)
                    {
                        answer = false;
                        break;
                    }
                }
                //Console.WriteLine($"{answer} - answer; {current_char} - current char");
                //foreach (char chr in stack) 
                //{
                //    Console.WriteLine(chr);
                //}
            }
            if (stack.Count != 0) 
            {
                answer = false;
            }
            Console.WriteLine(answer);

        }
    }
}
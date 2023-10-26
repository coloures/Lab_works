namespace ConsoleApp3
{
    internal class Final_forms
    {
        static void Main(string[] args)
        {
            try
            {
                StreamReader sr = new StreamReader("E:\\Projects_VS\\Forms\\ConsoleApp3\\input19.txt");
                int number = Convert.ToInt32(sr.ReadLine());
                string[] forms = new string[number];
                for (int i = 0; i < forms.Length; i++)
                {
                    string[] chars = sr.ReadLine().Split(' ');
                    string str = string.Join("", chars);
                    Console.WriteLine(str);
                    forms[i] = str;
                }
                string[] parts = new string[2 * number];
                for (int i = 0; i < parts.Length; i++)
                {
                    string[] chars = sr.ReadLine().Split(' ');
                    string str = string.Join("", chars);
                    parts[i] = str;
                    Console.WriteLine(str);
                }
                string temp_form = "";
                string[] answers = new string[number];
                int[] used_parts = new int[2 * number];
                //Console.WriteLine($"abb{parts[436],-40}|\nabb{parts[478],-40}|\n {forms[215]}");
                for (int t = 0; t < 2 * number; t++)
                {
                    used_parts[t] = t + 1;
                }
                int counterr = 0;
                Boolean Tr = true; // Условие используется для контроля оставшихся деталей
                while (Tr)
                {
                    counterr++;
                    int m = 0;
                    for (int k = 1; m < parts.Length - 1; k++)
                    {
                        //Console.WriteLine($"{m}, {k}");
                        bool cond = true;
                        if (k == parts.Length)
                        {
                            m++;
                            k = m + 1;
                        }
                        if (m == parts.Length - 1)
                        {
                            break;
                        }
                        if (used_parts.Contains(m + 1) && used_parts.Contains(k + 1)) // чтобы не допускать повторений ситуаций и зацикл
                        {
                            string first = parts[m];
                            string second = parts[k];
                            //Console.WriteLine($"{m} {k}");
                            //Console.WriteLine($"{first} - first {m} - m; {second} - second {k} - k");
                            if ((first[0..5] == reversed(second[0..5]) && first[10..15] == reversed(second[10..15]))
                                && (first.Substring(0, 5) == second.Substring(10, 5) && first.Substring(10, 5) == second.Substring(0, 5))) 
                            {
                                temp_form = first[0..5] + reversed(second[5..10]) + first[10..15] + first[5..10];
                                string rev_temp_form = reversed(temp_form[10..15]) + reversed(temp_form[5..10]) +
                                    reversed(temp_form[0..5]) + reversed(temp_form[15..20]);
                                string temp_form_2 = (first.Substring(0, 5) + second.Substring(5, 5) + first.Substring(10, 5) + first.Substring(5, 5));
                                string rev_temp_form_2 = reversed(temp_form[10..15]) + reversed(temp_form[5..10]) +
                                    reversed(temp_form[0..5]) + reversed(temp_form[15..20]);
                                for (int f = 0; f < forms.Length; f++)
                                {
                                    if ((forms[f] + forms[f][0..10]).Contains(temp_form[0..10]) && (forms[f] + forms[f][0..10]).Contains(temp_form[5..15]) &&
                                        (forms[f] + forms[f][0..10]).Contains(temp_form[10..20]) && (forms[f] + forms[f][0..10]).Contains(temp_form[15..20] + temp_form[0..5]))
                                    {
                                        answers[f] = $"{m + 1} {k + 1}";
                                        //Console.WriteLine($"для {f} - ответ: {m} {k}");
                                        //Console.WriteLine("Работает");
                                        cond = false;
                                        break;
                                    }
                                    else if ((forms[f] + forms[f][0..10]).Contains(rev_temp_form[0..10]) && (forms[f] + forms[f][0..10]).Contains(rev_temp_form[5..15]) &&
                                        (forms[f] + forms[f][0..10]).Contains(rev_temp_form[10..20]) && (forms[f] + forms[f][0..10]).Contains(rev_temp_form[15..20] + rev_temp_form[0..5]))
                                    {
                                        answers[f] = $"{m + 1} {k + 1}";
                                        //Console.WriteLine($"для {f} - ответ: {m} {k}");
                                        //Console.WriteLine("Работает");
                                        cond = false;
                                        break;
                                    }
                                    if (m == 436 && k == 478)
                                    {
                                        Console.WriteLine($"{cond} - вот так вот!!!");
                                    }
                            
                                }
                                for (int f = 0; f < forms.Length; f++)
                                {
                                    if ((forms[f] + forms[f][0..5]).Contains(temp_form_2[0..10]) && (forms[f] + forms[f][0..5]).Contains(temp_form_2[5..15]) &&
                                        (forms[f] + forms[f][0..5]).Contains(temp_form_2[10..20]) && (forms[f] + forms[f][0..5]).Contains(temp_form_2[15..20] + temp_form_2[0..5]))
                                    {
                                        answers[f] = $"{m + 1} {k + 1}";
                                        //Console.WriteLine($"для {f} - ответ: {m} {k}");
                                        //Console.WriteLine("Работает");
                                        break;
                                    }
                                    else if ((forms[f] + forms[f][0..5]).Contains(rev_temp_form_2[0..10]) && (forms[f] + forms[f][0..5]).Contains(rev_temp_form_2[5..15]) &&
                                        (forms[f] + forms[f][0..5]).Contains(rev_temp_form_2[10..20]) && (forms[f] + forms[f][0..5]).Contains(rev_temp_form_2[15..20] + rev_temp_form_2[0..5]))
                                    {
                                        answers[f] = $"{m + 1} {k + 1}";
                                        //Console.WriteLine($"для {f} - ответ: {m} {k}");
                                        //Console.WriteLine("Работает");
                                        break;
                                    }
                                }
                                continue;                         
                            }
                            else if (first[0..5] == reversed(second[0..5]) && first[10..15] == reversed(second[10..15]))
                            {
                                Console.WriteLine("1 условие");
                                Console.WriteLine($"{m} {k}");
                                temp_form = first[0..5] + reversed(second[5..10]) + first[10..15] + first[5..10];
                                Console.WriteLine(temp_form + " - не перевернутая");
                                Console.WriteLine($"{temp_form} - temp_form; {m} - m; {k} - k");
                                string rev_temp_form = reversed(temp_form[10..15]) + reversed(temp_form[5..10]) +
                                    reversed(temp_form[0..5]) + reversed(temp_form[15..20]);
                                Console.WriteLine(rev_temp_form + " - перевернутая");




                                for (int f = 0; f < forms.Length; f++)
                                {
                                    if ((forms[f] + forms[f][0..10]).Contains(temp_form[0..10]) && (forms[f] + forms[f][0..10]).Contains(temp_form[5..15]) &&
                                        (forms[f] + forms[f][0..10]).Contains(temp_form[10..20]) && (forms[f] + forms[f][0..10]).Contains(temp_form[15..20] + temp_form[0..5]))
                                    {
                                        answers[f] = $"{m + 1} {k + 1}";
                                        //Console.WriteLine($"для {f} - ответ: {m} {k}");
                                        //Console.WriteLine("Работает");
                                        cond = false;
                                        break;
                                    }
                                    else if ((forms[f] + forms[f][0..10]).Contains(rev_temp_form[0..10]) && (forms[f] + forms[f][0..10]).Contains(rev_temp_form[5..15]) &&
                                        (forms[f] + forms[f][0..10]).Contains(rev_temp_form[10..20]) && (forms[f] + forms[f][0..10]).Contains(rev_temp_form[15..20] + rev_temp_form[0..5]))
                                    {
                                        answers[f] = $"{m + 1} {k + 1}";
                                        //Console.WriteLine($"для {f} - ответ: {m} {k}");
                                        //Console.WriteLine("Работает");
                                        cond = false;
                                        break;
                                    }

                                }
                                    continue;
                            }

                            else if (first.Substring(0, 5) == second.Substring(10, 5) && first.Substring(10, 5) == second.Substring(0, 5))
                            {
                                Console.WriteLine($"{m} {k}");
                                //Console.WriteLine(parts[436][0..5] == parts[478][10..15]);
                                //Console.WriteLine(parts[436][10..15] == parts[478][0..5]);
                                //Console.WriteLine(parts[436][0..5] + parts[478][5..10] + parts[436][10..15] + parts[436][5..10]);
                                ////Console.WriteLine("2 условие");
                                temp_form = (first.Substring(0, 5) + second.Substring(5, 5) + first.Substring(10, 5) + first.Substring(5, 5));
                                //Console.WriteLine(temp_form + " - не перевернутая");
                                // Console.WriteLine($"{temp_form} - temp_form; {m} - m; {k} - k");
                                string rev_temp_form = reversed(temp_form[10..15]) + reversed(temp_form[5..10]) +
                                    reversed(temp_form[0..5]) + reversed(temp_form[15..20]);
                                //Console.WriteLine(rev_temp_form + " - перевернутая");



                                for (int f = 0; f < forms.Length; f++)
                                {
                                    if ((forms[f] + forms[f][0..5]).Contains(temp_form[0..10]) && (forms[f] + forms[f][0..5]).Contains(temp_form[5..15]) &&
                                        (forms[f] + forms[f][0..5]).Contains(temp_form[10..20]) && (forms[f] + forms[f][0..5]).Contains(temp_form[15..20] + temp_form[0..5]))
                                    {
                                        answers[f] = $"{m + 1} {k + 1}";
                                        //Console.WriteLine($"для {f} - ответ: {m} {k}");
                                        //Console.WriteLine("Работает");
                                        break;
                                    }
                                    else if ((forms[f] + forms[f][0..5]).Contains(rev_temp_form[0..10]) && (forms[f] + forms[f][0..5]).Contains(rev_temp_form[5..15]) &&
                                        (forms[f] + forms[f][0..5]).Contains(rev_temp_form[10..20]) && (forms[f] + forms[f][0..5]).Contains(rev_temp_form[15..20] + rev_temp_form[0..5]))
                                    {
                                        answers[f] = $"{m + 1} {k + 1}";
                                        //Console.WriteLine($"для {f} - ответ: {m} {k}");
                                        //Console.WriteLine("Работает");
                                        break;
                                    }
                                }
                                continue;
                            }
                        }


                    }
                    int s = 0;
                    foreach (string j in answers) 
                    {
                        Console.WriteLine($"{j} - ответы к форме номер {s+1} - {forms[s++]}");
                    //    if (j != null)
                    //    {
                            //if (j.Contains("19"))
                            //{
                            //    Console.WriteLine("19!!!!!!");
                            //}
                            //if (j.Contains("375"))
                            //{
                            //    Console.WriteLine("375!!!!!!");
                            //}
                    //    }
                    }
                    foreach (string i in answers)
                    {
                        Console.WriteLine(i);
                        string[] fjk;
                        if (i != null)
                        {
                            fjk = i.Split(' ');
                        }
                        else 
                        {
                            fjk = new string[1];
                            fjk[0] = "-100";
                        }
                        foreach (string fj in fjk)
                        {
                            if (used_parts.Contains(int.Parse(fj)))
                            {
                                used_parts[Array.IndexOf(used_parts, int.Parse(fj))] = -1;
                            }
                        }
                        //int qua = 0;
                        //foreach (int ints in used_parts) 
                        //{
                        //    if (ints != -1) 
                        //    {
                        //        qua++;
                         //   }
                         //   Console.WriteLine($"|{ints, -30}|");
                        //}
                        //Console.WriteLine(qua);

                    }
                    int count = 0;
                    foreach (int d in used_parts)
                    {
                        if (d != -1)
                        {
                            count++;
                            Console.WriteLine($"D = {d}");
                        }
                    }
                    Console.WriteLine($"COUNT - {count}");
                    //foreach (int d in used_parts)
                    //{
                    //    if (d != -1)
                    //    {
                    //        Console.WriteLine($"|{d,-20}|");
                    //    }
                    //}
                    //Console.WriteLine($"{count} - count");
                    if (count == 0)
                    {
                        Tr = false;
                    }
                    if (counterr == 30) 
                    {
                        Tr = false;
                    }
                }
                foreach (var i in answers)
                {
                    Console.WriteLine(i);
                }
                try
                {
                    StreamWriter sw = new StreamWriter("E:\\Projects_VS\\Forms\\ConsoleApp3\\output19.txt");
                    foreach (var i in answers)
                    {
                        sw.WriteLine(i);
                    }
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
        static string reversed(string str)
        {
            char[] chars = str.ToCharArray();
            char[] temporaty_str = new char[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                temporaty_str[i] = chars[str.Length - i - 1];
            }
            string new_str = string.Join("", temporaty_str);
            return new_str; // переворот строки наоборот
        }
    }
}
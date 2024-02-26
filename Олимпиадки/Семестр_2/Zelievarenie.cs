string source = "C:\\Users\\User1\\source\\repos\\ConsoleApp3\\ConsoleApp3\\input10.txt";
string way = "C:\\Users\\User1\\source\\repos\\ConsoleApp3\\ConsoleApp3\\output10.txt";
Dictionary<int, string> strings = new Dictionary<int, string>();
Dictionary<string, string> strings2 = new Dictionary<string, string>() { { "MIX", "MXXM" }, { "WATER", "WTTW" }, { "DUST", "DTTD" }, { "FIRE", "FRRF" } };
StreamWriter sw = new StreamWriter(way);
StreamReader sr = new StreamReader(source);
int i = 0;
while (sr.EndOfStream != true) 
{
    strings.Add(++i, sr.ReadLine());
}
string answer = string.Empty;
foreach (int j in strings.Keys) 
{
    string [] parts = strings[j].Split(' ');
    string answer_temp = string.Empty;
    int pos = 2;
    foreach (string part in parts) 
    {
        int num;
        if (strings2.ContainsKey(part)) 
        {
            answer_temp += strings2[part];
        }
        else if (int.TryParse(part, out num))
        {
            answer_temp = answer_temp.Insert(pos, strings[num]);
            pos = pos + strings[num].Length;
        }
        else 
        {
            answer_temp = answer_temp.Insert(pos, part);
            pos = pos + part.Length;
        }
    }
    strings[j] = answer_temp;
}
sw.WriteLine(strings[strings.Count]);
sw.Close();
sr.Close();

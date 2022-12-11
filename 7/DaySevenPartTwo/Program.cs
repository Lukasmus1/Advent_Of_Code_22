List<string> currentPath = new();
Dictionary<string, int> dirs = new()
{
    { "root", 0 }
};

string[] input = File.ReadAllLines("input.txt");

foreach (string line in input)
{
    if (line[0] == '$')
    {
        string temp = line.Remove(0, 2);
        if (temp.Remove(2) == "cd")
        {
            switch (temp.Remove(0, 3))
            {
                case "..":
                    currentPath.RemoveAt(currentPath.Count - 1);
                    break;

                case "/":
                    currentPath.Clear();
                    currentPath.Add("root");
                    break;

                default:
                    currentPath.Add(line.Remove(0, 5));
                    string s = "";
                    foreach (string str in currentPath)
                    {
                        s += str;
                    }
                    if (!dirs.ContainsKey(s))
                    {
                        dirs.Add(s, 0);
                    }
                    break;
            }
        }
        continue;
    }

    if (line.Remove(3) != "dir")
    {
        string[] file = line.Split(' ');
        string s = "";
        foreach (string str in currentPath)
        {
            s += str;
            dirs[s] += int.Parse(file[0]);
        }
    }
}

int target = 30000000 - (70000000 - dirs["root"]);
var res = dirs["root"];
foreach (var dic in dirs)
{
    if (dic.Value - target >= 0 && dic.Value < res)
    {
        res = dic.Value;
    }
}

Console.WriteLine(res);
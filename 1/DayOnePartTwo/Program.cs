string[] input = File.ReadAllLines("input.txt");

List<int> listOfElves = new();

int i = 0;
foreach (string line in input)
{
    if (line == "")
    {
        listOfElves.Add(i);
        i = 0;
        continue;
    }

    i += int.Parse(line);
}

int res = 0;
for (int index = 0; index < 3; index++)
{
    int temp = listOfElves.Max();
    res += temp;
    listOfElves.Remove(temp);
}

Console.WriteLine(res);
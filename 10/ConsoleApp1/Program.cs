string[] input = File.ReadAllLines("input.txt");

int cycleCount = 0;
int register = 1;
int cycleMult = 0;
List<int> listRes = new();
foreach (string line in input)
{
    if (line.Remove(4) == "addx")
    {
        for (int i = 0; i < 2; i++)
        {
            cycleCount++;
            if (cycleCount == 20 + 40 * cycleMult)
            {
                listRes.Add((40 * cycleMult + 20) * register);
                cycleMult++;
            }
        }
        register += int.Parse(line.Remove(0, 5));
        continue;
    }
    if (cycleCount == 20 + 40 * cycleMult)
    {
        listRes.Add((40 * cycleMult + 20) * register);
        cycleMult++;
    }
    cycleCount++;
}

int res = 0;
foreach (int item in listRes)
{
    res += item;
}

Console.WriteLine(res);
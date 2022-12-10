string[] input = File.ReadAllLines("input.txt");

List<char> duplicates = new();
foreach (string line in input)
{
    string firstPart = "";
    string secondPart = "";

    int i = 0;
    while (i < line.Length / 2)
    {
        firstPart += line[i];
        i++;
    }

    while (i < line.Length)
    {
        secondPart += line[i];
        i++;
    }

    i = 0;
    foreach (char c in firstPart)
    {
        if (secondPart.Contains(c))
        {
            duplicates.Add(c);
            break;
        }
        i++;
    }
}

int res = 0;
foreach (char c in duplicates)
{
    if (char.IsUpper(c))
    {
        res += c - 38;
    }
    else
    {
        res += c - 96;
    }
}

Console.WriteLine(res);
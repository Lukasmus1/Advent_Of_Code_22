string[] input = File.ReadAllLines("input.txt");

List<char> duplicates = new();
for (int i = 0; i < input.Length; i += 3)
{
    foreach (char c in input[i])
    {
        if (input[i + 1].Contains(c) && input[i + 2].Contains(c))
        {
            duplicates.Add(c);
            break;
        }
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
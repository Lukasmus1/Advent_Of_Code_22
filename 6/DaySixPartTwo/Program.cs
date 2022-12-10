string input = File.ReadAllText("input.txt");

char[] arr = new char[14];
for (int i = 0; i < input.Length; i++)
{
    for (int ind = 0; ind < 14; ind++)
    {
        arr[ind] = input[ind + i];
    }

    if (arr.Length == arr.Distinct().Count())
    {
        Console.WriteLine(i + 14);
        break;
    }
}

//Weirdly easy day 
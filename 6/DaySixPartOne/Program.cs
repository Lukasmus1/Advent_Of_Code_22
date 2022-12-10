string input = File.ReadAllText("input.txt");

char[] arr = new char[4];
for (int i = 0; i < input.Length; i++)
{
    for (int ind = 0; ind < 4; ind++)
    {
        arr[ind] = input[ind + i];
    }

    if(arr.Length == arr.Distinct().Count())
    {
        Console.WriteLine(i + 4);
        break;
    }
}
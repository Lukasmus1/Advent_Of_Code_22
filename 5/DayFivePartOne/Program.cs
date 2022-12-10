List<string> input = File.ReadAllLines("input.txt").ToList();

//Getting number of stacks
int count = 0;
int i = 0;
while(i < input.Count)
{
    if (input[i] == "")
    {
        string countLine = input[--i];
        count = int.Parse(countLine[countLine.Length - 2].ToString());
        break;
    }
    i++;
}

//Filling array with stacks
i--;
List<string> arrs = new();
for (int countIndex = 0; countIndex < count; countIndex++)
{
    arrs.Add("");
    for (int arrIndex = i; arrIndex >= 0; arrIndex--)
    {
        if(input[arrIndex][1 + (countIndex * 4)] == ' ')
        {
            break;
        }
        arrs[countIndex] += input[arrIndex][1 + (countIndex * 4)];
    }
}
input.RemoveRange(0, i+3);


foreach (string line in input)
{
    //Getting count
    string help = line.Remove(0, 5);
    string strCount = "";
    foreach (char item in help)
    {
        if(item == ' ') 
        {
            help = help.Remove(0, 1);
            break;
        }
        help = help.Remove(0, 1);
        strCount += item;
    }
    count = int.Parse(strCount);

    //Getting from
    string strFrom = "";
    help = help.Remove(0, 5);
    foreach (char item in help)
    {
        if (item == ' ')
        {
            help = help.Remove(0, 1);
            break;
        }
        help = help.Remove(0, 1);
        strFrom += item;
    }
    int from = int.Parse(strFrom) - 1;

    //Getting to
    string strTo = "";
    help = help.Remove(0, 3);
    foreach (char item in help)
    {
        if (item == ' ')
        {
            help = help.Remove(0, 1);
            break;
        }
        help = help.Remove(0, 1);
        strTo += item;
    }
    int to = int.Parse(strTo) - 1;

    //Doing all the operations
    for (int index = 0; index < count; index++)
    {
        arrs[to] += arrs[from].Last();
        arrs[from] = arrs[from].Remove(arrs[from].Length - 1);
    }
}

foreach (string item in arrs)
{
    Console.WriteLine(item.Last());
}
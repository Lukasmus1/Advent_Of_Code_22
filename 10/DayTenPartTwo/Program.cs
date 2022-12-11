string[] input = File.ReadAllLines("input.txt");

int cycleCount = -1;
int register = 1;
foreach (string line in input)
{
    cycleCount++;

    if (cycleCount == 40)
    {
        cycleCount = 0;
        Console.WriteLine();
    }

    if (cycleCount >= register - 1 && cycleCount <= register + 1)
    {
        Console.Write("#");
    }
    else
    {
        Console.Write(".");
    }

    if(line.Remove(4) == "addx")
    {
        cycleCount++;
        if (cycleCount == 40)
        {
            cycleCount = 0;
            Console.WriteLine();
        }

        if (cycleCount >= register - 1 && cycleCount <= register + 1)
        {
            Console.Write("#");
        }
        else
        {
            Console.Write(".");
        }
        register += int.Parse(line.Remove(0, 5));
    }
}
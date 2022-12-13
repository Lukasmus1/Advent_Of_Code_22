internal class Program
{
    private static void Main(string[] args)
    {
        string[] input = File.ReadAllText("input.txt").Split("\n");

        Dictionary<Monkey, int> monkeys = new();
        List<(int, int)> condMon = new();
        int i = 0;
        List<int> items = new();
        int opInt = 0, m1 = 0, m2 = 0, divisibleBy = 1;
        char op = ' ';
        bool help = false;
        foreach (string line in input)
        {
            switch(i)
            {
                case 1:
                    foreach (string item in line.Remove(0, 18).Split(", "))
                    {
                        items.Add(int.Parse(item));
                    }
                    break;
                
                case 2:
                    op = char.Parse(line.Remove(0, 23).Remove(1));
                    if (line.Remove(0, 25) == "old\r")
                    {
                        help = true;
                        opInt = 0;
                    }
                    else
                    {
                        opInt = int.Parse(line.Remove(0, 25));
                    }
                    break;

                case 3:
                    divisibleBy = int.Parse(line.Remove(0, 21)); 
                    break;

                case 4:
                    m1 = int.Parse(line.Remove(0, 29));
                    break;

                case 5:
                    m2 = int.Parse(line.Remove(0, 30));
                    i = -2;
                    condMon.Add((m1, m2));
                    monkeys.Add(new(items.ToArray(), op, opInt, divisibleBy, help), 0);
                    items.Clear();
                    help = false;
                    break;
            }
            i++;
        }

        i = 0;
        foreach ((int, int) item in condMon)
        {
            monkeys.Keys.ElementAt(i).AssignMonkey(monkeys.Keys.ElementAt(item.Item1), monkeys.Keys.ElementAt(item.Item2));
            i++;
        }

        i = 0;
        while (i < 20)
        {
            for(int index = 0; index < monkeys.Count; index++)
            {
                if(i == 20)
                {
                    break;
                }
                foreach (int item in monkeys.Keys.ElementAt(index).StartItems)
                {
                    int itemLvl = monkeys.Keys.ElementAt(index).Operation(item);
                    itemLvl /= 3;
                    monkeys.Keys.ElementAt(index).Test(itemLvl);
                    monkeys[monkeys.ElementAt(index).Key]++;
                }
                monkeys.Keys.ElementAt(index).StartItems.Clear();
            }
            i++;
        }

        int res = monkeys.Values.Max();
        for(int ind = 0; ind < monkeys.Count; ind++)
        {
            if (monkeys.Values.ElementAt(ind) == res)
            {
                monkeys.Remove(monkeys.Keys.ElementAt(ind));
                res *= monkeys.Values.Max();
            }
        }
        Console.WriteLine(res);
    }
}

class Monkey
{
    List<int> startItems = new();
    public List<int> StartItems
    {
        get { return startItems; }
        set { startItems = value; }
    }
    Monkey mTrue, mFalse;
    private int operationNum, divisibleBy;
    private char operation;
    private bool helper;

    public Monkey(int[] items, char operation, int opNum, int divisibleBy, bool help)
    {
        this.operation = operation;
        operationNum = opNum;
        foreach (int item in items)
        {
            startItems.Add(item);
        }
        this.divisibleBy = divisibleBy;
        this.operation = operation;
        helper = help;
    }

    public int Operation(int old)
    {
        if (helper)
        {
            return old * old;
        }
        if(operation == '+')
        {
            return old + operationNum;
        }
        else
        {
            return old * operationNum;
        }
    }

    public void Test(int num)
    {
        if (num % divisibleBy == 0)
        {
            AddItemToMonkey(num, mTrue);
        }
        else
        {
            AddItemToMonkey(num, mFalse);
        }
    }

    static void AddItemToMonkey(int item, Monkey m)
    {
        m.startItems.Add(item);
    }

    public void AssignMonkey(Monkey mTrue, Monkey mFalse)
    {
        this.mTrue = mTrue;
        this.mFalse = mFalse;
    }
}
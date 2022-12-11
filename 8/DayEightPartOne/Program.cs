string inp = File.ReadAllText("input.txt");

List<List<int>> input = new();
int i = 0;
foreach (string line in inp.Split('\n'))
{
	input.Add(new());
	int ind = 0;
	foreach (char c in line)
	{
		if (c > 47 && c < 58)
		{
			input[i].Add(int.Parse(c.ToString()));
        }
        ind++;
    }
    i++;
}

int res = 0;
i = 0;
foreach (var ind in input)
{
	for(int i2 = 0; i2 < ind.Count; i2++)
	{
		if (i2 == 0 || i2 + 1 == ind.Count || i == 0 || i + 1 == input.Count)
		{
			res++;
            Console.Write(input[i][i2]);
        }
        else
		{
			bool help = true;
            for (int ind1 = i2 - 1; ind1 >= 0 && help; ind1--)
            {
				if (input[i][i2] <= input[i][ind1])
				{
					help = false;
					break;
				}
            }
            if (help)
            {
                res++;
                Console.Write(input[i][i2]);
                continue;
            }

            help = true;
            for (int ind1 = i2 + 1; ind1 < ind.Count && help; ind1++)
            {
                if (input[i][i2] <= input[i][ind1])
                {
					help = false;
                    break;
                }
            }
            if (help)
            {
                res++;
                Console.Write(input[i][i2]);
                continue;
            }

            help = true;
            for (int ind1 = i - 1; ind1 >= 0 && help; ind1--)
            {
                if (input[i][i2] <= input[ind1][i2])
                {
                    help = false;
                    break;
                }
            }
            if (help)
            {
                res++;
                Console.Write(input[i][i2]);
                continue;
            }

            help = true;
            for (int ind1 = i + 1; ind1 < input.Count && help; ind1++)
            {
                if (input[i][i2] <= input[ind1][i2])
                {
                    help = false;
                    break;
                }
            }
            if(help)
            {
                res++;
                Console.Write(input[i][i2]);
                continue;
            }
        }
    }
	Console.WriteLine();
	i++;
}
Console.WriteLine(res);

//Ugly but working 
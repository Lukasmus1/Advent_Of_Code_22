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

i = 0;
int dir1, dir2, dir3, dir4;
List<int> result = new();
foreach (var ind in input)
{
    for (int i2 = 0; i2 < ind.Count; i2++)
    {
        if(i2 != 0 && i2 + 1 != ind.Count && i != 0 && i + 1 != input.Count)
        {
            dir1 = 0;
            dir2 = 0;
            dir3 = 0;
            dir4 = 0;
            for (int ind1 = i2 - 1; ind1 >= 0 ; ind1--)
            {
                if (input[i][i2] > input[i][ind1])
                {
                    dir1++;
                }
                else
                {
                    dir1++;
                    break;
                }
            }


            for (int ind1 = i2 + 1; ind1 < ind.Count; ind1++)
            {
                if (input[i][i2] > input[i][ind1])
                {
                    dir2++;
                }
                else
                {
                    dir2++;
                    break;
                }
            }

            for (int ind1 = i - 1; ind1 >= 0; ind1--)
            {
                if (input[i][i2] > input[ind1][i2])
                {
                    dir3++;
                }
                else
                {
                    dir3++;
                    break;
                }
            }


            for (int ind1 = i + 1; ind1 < input.Count; ind1++)
            {
                if (input[i][i2] > input[ind1][i2])
                {
                    dir4++;
                }
                else
                {
                    dir4++;
                    break;
                }
            }
            result.Add(dir1 * dir2 * dir3 * dir4);
        }
    }
    i++;
}

Console.WriteLine(result.Max());
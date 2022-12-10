string[] input = File.ReadAllLines("input.txt");

int res = 0;
foreach (string line in input)
{
    string[] lineSplit = line.Split(',');
    string[] line1;
    string[] line2;

    line1 = lineSplit[0].Split('-');
    line2 = lineSplit[1].Split('-');


    if (Convert.ToInt32(line1[0]) >= Convert.ToInt32(line2[0]) && Convert.ToInt32(line1[1]) <= Convert.ToInt32(line2[1]))
    {
        res++;
    }
    else if (Convert.ToInt32(line2[0]) >= Convert.ToInt32(line1[0]) && Convert.ToInt32(line2[1]) <= Convert.ToInt32(line1[1]))
    {
        res++;
    }
}
Console.WriteLine(res);
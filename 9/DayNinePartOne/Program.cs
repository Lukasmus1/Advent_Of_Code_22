string[] input = File.ReadAllLines("input.txt");

List<(int, int)> visitedList = new()
{
    (0, 0)
};

(int, int) lastPos, currentPosT = visitedList.First(), currentPosH = visitedList.First();
foreach (string line in input)
{
    switch(line.Remove(1))
    {
        case "L":
            for (int i = 0; i < int.Parse(line.Remove(0, 2)); i++)
            {
                lastPos = currentPosH;
                currentPosH.Item2 --;
                if (!((currentPosH.Item1 >= currentPosT.Item1 - 1 && currentPosH.Item1 <= currentPosT.Item1 + 1) && (currentPosH.Item2 >= currentPosT.Item2 - 1 && currentPosH.Item2 <= currentPosT.Item2 + 1)))
                {
                    currentPosT = lastPos;
                    if (!visitedList.Contains(currentPosT))
                    {
                        visitedList.Add(currentPosT);
                    }
                }
            }
            break;

        case "R":
            for (int i = 0; i < int.Parse(line.Remove(0, 2)); i++)
            {
                lastPos = currentPosH;
                currentPosH.Item2 ++;
                if (!((currentPosH.Item1 >= currentPosT.Item1 - 1 && currentPosH.Item1 <= currentPosT.Item1 + 1) && (currentPosH.Item2 >= currentPosT.Item2 - 1 && currentPosH.Item2 <= currentPosT.Item2 + 1)))
                {
                    currentPosT = lastPos;
                    if (!visitedList.Contains(currentPosT))
                    {
                        visitedList.Add(currentPosT);
                    }
                }
            }
            break;

        case "D":
            for (int i = 0; i < int.Parse(line.Remove(0, 2)); i++)
            {
                lastPos = currentPosH;
                currentPosH.Item1--;
                if (!((currentPosH.Item1 >= currentPosT.Item1 - 1 && currentPosH.Item1 <= currentPosT.Item1 + 1) && (currentPosH.Item2 >= currentPosT.Item2 - 1 && currentPosH.Item2 <= currentPosT.Item2 + 1)))
                {
                    currentPosT = lastPos;
                    if (!visitedList.Contains(currentPosT))
                    {
                        visitedList.Add(currentPosT);
                    }
                }
            }
            break;

        case "U":
            for (int i = 0; i < int.Parse(line.Remove(0, 2)); i++)
            {
                lastPos = currentPosH;
                currentPosH.Item1++;
                if (!((currentPosH.Item1 >= currentPosT.Item1 - 1 && currentPosH.Item1 <= currentPosT.Item1 + 1) && (currentPosH.Item2 >= currentPosT.Item2 - 1 && currentPosH.Item2 <= currentPosT.Item2 + 1)))
                {
                    currentPosT = lastPos;
                    if (!visitedList.Contains(currentPosT))
                    {
                        visitedList.Add(currentPosT);
                    }
                }
            }
            break;
    }
}

Console.WriteLine(visitedList.Count);

//Can be made more readable with functions /shrug
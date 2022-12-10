namespace DayOne
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");

            List<int> listOfElves = new();

            int i = 0;
            foreach (string line in input)
            {
                if(line == "")
                {
                    listOfElves.Add(i);
                    i = 0;
                    continue;
                }

                i += int.Parse(line);
            }

            Console.WriteLine(listOfElves.Max());
        }
    }
}
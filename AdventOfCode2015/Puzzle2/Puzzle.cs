namespace AdventOfCode2015.Puzzle2;

public static class Puzzle
{
    private static string[] GetRows(string inputName)
    {
        return File.ReadAllLines($"inputs/{inputName}")
            .Select(x => x).ToArray();
    }


    public static long PartOne(string inputName)
    {
        var row = GetRows(inputName);

        var total = 0L;
        foreach (var s in row)
        {
            var dimensions = s.Split('x').Select(int.Parse).OrderBy(x=> x).ToList();
            total += 3 * dimensions[0] * dimensions[1]
                     + 2 * dimensions[1] * dimensions[2]
                     + 2 * dimensions[0] * dimensions[2];
        }
        return total;
    }

    public static long PartTwo(string inputName)
    {
        var row = GetRows(inputName);

        var total = 0L;
        foreach (var s in row)
        {
            var dimensions = s.Split('x').Select(int.Parse).OrderBy(x=> x).ToList();
            total += 2 * (dimensions[0] + dimensions[1]) + dimensions[0] * dimensions[1] * dimensions[2];
        }
        return total;
    }
}
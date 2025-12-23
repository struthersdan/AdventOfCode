namespace AdventOfCode2015.Puzzle1;

public static class Puzzle
{
    private static string[] GetRows(string inputName)
    {
        return File.ReadAllLines($"inputs/{inputName}")
            .Select(x => x).ToArray();
    }


    public static long PartOne(string inputName)
    {
        var row = GetRows(inputName)[0].ToCharArray();

        return row.Count(c => c == '(') - row.Count(c => c == ')');
    }

    public static long PartTwo(string inputName)
    {
        var row = GetRows(inputName)[0].ToCharArray();

        var floor = 0;
        for (var i = 0; i < row.Length; i++)
        {
            if (row[i] == '(')
            {
                floor++;
            }
            else
            {
                floor--;
            }
            if (floor == -1)
            {
                return i + 1;
            }
        }

        return -1;
    }
}
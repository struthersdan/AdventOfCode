namespace AdventOfCode2025.Puzzlee12;

public static class Puzzle
{
    private static string[] GetRows(string inputName)
    {
        return File.ReadAllLines($"inputs/{inputName}")
            .Select(x => x).ToArray();
    }


    public static long PartOne(string inputName)
    {
        var rows = GetRows(inputName);

        var index = 0;

        for (var i = 0; i < rows.Length; i++)
        {
            var row = rows[i];
           if (row.StartsWith("47"))
           {
               index = i;
               break;
           }
        }

        var regions = new List<(int,  int)>();
        for (var j = index; j < rows.Length; j++)
        {
            var row = rows[j];
            var x = row[..5].Split("x").Select(int.Parse).ToArray();

            var y = row[7..].Split(" ").Select(int.Parse);

            regions.Add((x[0] * x[1], y.Sum() * 9));
        }

        return regions.Count (r => r.Item1 >= r.Item2);
    }
}
namespace AdventOfCode2015.Puzzle3;

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

        HashSet<(int, int)> visited = new();

       var santaLocation = (x:0, y: 0);

        visited.Add(santaLocation);

        foreach (var c in row)
        {
            santaLocation = GetNextSantaLocation(c, santaLocation);
            visited.Add(santaLocation);
        }

        return visited.Count;
    }

    private static (int x, int y) GetNextSantaLocation(char c, (int x, int y) santaLocation)
    {
        switch (c)
        {
            case '^':
                santaLocation.y++;
                break;
            case 'v':
                santaLocation.y--;
                break;
            case '>':
                santaLocation.x++;
                break;
            case '<':
                santaLocation.x--;
                break;
        }

        return santaLocation;
    }

    public static long PartTwo(string inputName)
    {
        var row = GetRows(inputName)[0].ToCharArray();

        HashSet<(int, int)> visited = new();

        var santaLocation = (x:0, y: 0);
        visited.Add(santaLocation);
        var roboSantaLocation = (x:0, y: 0);
        visited.Add(roboSantaLocation);

        for (var i = 0; i < row.Length - 1; i += 2)
        {
            santaLocation = GetNextSantaLocation(row[i], santaLocation);
            visited.Add(santaLocation);
            roboSantaLocation = GetNextSantaLocation(row[i + 1], roboSantaLocation);
            visited.Add(roboSantaLocation);
        }

        return visited.Count;
    }
}
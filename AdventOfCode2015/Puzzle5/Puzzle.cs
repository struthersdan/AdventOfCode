namespace AdventOfCode2015.Puzzle5;

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

        var niceCount = 0L;
        foreach (var row in rows)
        {
            if(IsNice(row))
            {
                niceCount++;
            }
        }
        return niceCount;
    }

    private static bool IsNice(string row)
    {
        var vowelCount = 0;
        var hasDoubleLetter = false;
        var forbiddenStrings = new[] { "ab", "cd", "pq", "xy" };

        for(int i = 0; i < row.Length; i++)
        {
            var c = row[i];
            if ("aeiou".Contains(c))
            {
                vowelCount++;
            }

            if (i <= 0) continue;

            if (row[i] == row[i - 1])
            {
                hasDoubleLetter = true;
            }
            var pair = $"{row[i - 1]}{row[i]}";
            if (forbiddenStrings.Contains(pair))
            {
                return false;
            }
        }

        return vowelCount >= 3 && hasDoubleLetter;
    }


   

    public static long PartTwo(string inputName)
    {
        var rows = GetRows(inputName);
        var niceCount = 0L;
        foreach (var row in rows)
        {
            if(IsNicePartTwo(row))
            {
                niceCount++;
            }
        }
        return niceCount;
    }

    private static bool IsNicePartTwo(string row)
    {
        var hasPair = false;
        var hasRepeatWithOneBetween = false;
        for(int i = 1; i < row.Length; i++)
        {
            var pair = $"{row[i - 1]}{row[i]}";
            for (int j = i + 1; j < row.Length - 1; j++)
            {
                var nextPair = $"{row[j]}{row[j + 1]}";
                if (pair == nextPair)
                {
                    hasPair = true;
                    break;
                }
            }

            if (hasPair && hasRepeatWithOneBetween) return true;

            if (i <= 1 || hasRepeatWithOneBetween) continue;

            if (row[i] == row[i - 2])
            {
                hasRepeatWithOneBetween = true;
            }
        }
        return hasPair && hasRepeatWithOneBetween;
    }
}
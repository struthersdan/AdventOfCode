using System.Text;

namespace AdventOfCode2025.Puzzle7;

public static class Puzzle
{
    private static string[][] GetRows(string inputName)
    {
        return File.ReadAllLines($"inputs/{inputName}")
            .Select(x => x.Split(" ", StringSplitOptions.RemoveEmptyEntries)).ToArray();
    }

    public static long PartOne(string inputName)
    {
        var rows = File.ReadAllLines($"inputs/{inputName}")
            .Select(row => row.ToCharArray()).ToArray();

        long splitCount = 0;
        var isFirstRun = true;

        var i = 0;
        while (i < rows.Length - 1)
        {
            var row = rows[i];
            for (int j = 0; j < row.Length; j++)
            {
                var curr = row[j];
                switch (curr)
                {
                    case 'S':
                    case '|' when !isFirstRun:
                        if (rows[i + 1][j] != '^')
                            rows[i + 1][j] = '|';
                        break;
                    case '^' when rows[i - 1][j] == '|' && isFirstRun:
                        splitCount++;

                        if (j - 1 >= 0)
                        {
                            rows[i][j - 1] = '|';
                        }

                        if (j + 1 < row.Length)
                        {
                            rows[i][j + 1] = '|';
                        }


                        break;
                }

            }

            if (isFirstRun)
            {
                isFirstRun = false;
            }

            else
            {
                isFirstRun = true;
                i++;
            }
        }


        return splitCount;
    }

    public static long PartTwo(string inputName)
    {
        var rows = File.ReadAllLines($"inputs/{inputName}")
            .Select(row => row.ToCharArray()).ToArray();

        var entries = BuildEntriesArray(rows);
        

        var isFirstRun = true;

        var i = 0;
        while (i < rows.Length-1)
        {
            var row = rows[i];
            for (int j = 0; j < row.Length; j++)
            {
                var curr = row[j];
                switch (curr)
                {
                    case 'S':
                    case '|' when !isFirstRun:
                        if (rows[i + 1][j] != '^')
                        {
                            rows[i + 1][j] = '|';
                            entries[i + 1][j] = entries[i][j] != 0 ? entries[i][j] : 1;
                        }

                        break;
                    case '^' when rows[i - 1][j] == '|' && isFirstRun:
                        var initial = entries[i - 1][j];
                        if (j - 1 >= 0)
                        {
                            rows[i][j - 1] = '|';
                            entries[i][j - 1] += initial;
                        }

                        if (j + 1 < row.Length)
                        {
                            rows[i][j + 1] = '|';
                            entries[i][j + 1]+= initial;
                        }


                        break;
                }

            }

            if (isFirstRun)
            {
                isFirstRun = false;
            }

            else
            {
                isFirstRun = true;
                i++;
            }

            //entries.PrintGrid();
        }

        return entries[^1].Sum(x => x);
    }

    private static long[][] BuildEntriesArray(char[][] rows)
    {
        var entries = new long[rows.Length][];

        for (var i = 0; i < rows.Length; i++)
        {
            entries[i] = new long[rows[i].Length];
        }

        return entries;
    }
}
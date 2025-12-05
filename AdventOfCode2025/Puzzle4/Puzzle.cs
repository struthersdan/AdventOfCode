using System.Runtime.InteropServices;

namespace AdventOfCode2025.Puzzle4;

public static class Puzzle
{
    private static string[][] GetColumns(string inputName) => File.ReadAllLines($"inputs/{inputName}")
        .Select(x => x.Split(" ", StringSplitOptions.RemoveEmptyEntries)).ToArray();

    public static long PartOne(string inputName)
    {
        var warehouseFloor = GetColumns(inputName).Select(x => x[0].ToCharArray()).ToArray();
        return warehouseFloor.Select((t, row) => GetRowTotal(warehouseFloor, row)).Sum();
    }


    private static bool IsCrateAccessible(char[][] warehouseFloor, int row, int column)
    {
        var surroundingCrateLocations = new List<(int currX, int currY)>()
        {
            (column, row - 1), (column, row + 1), (column - 1, row), (column + 1, row), (column - 1, row - 1), (column - 1, row + 1), (column + 1, row - 1),
            (column + 1, row + 1)
        };
        var surroundingCratesCount = 0;
        foreach (var (currX, currY) in surroundingCrateLocations)
        {
            var isCrate = warehouseFloor.SafeAccess(currY, currX, out var c) && c == '@';
            if (isCrate) surroundingCratesCount++;
            if (surroundingCratesCount == 4)
            {
                return false;
            }
        }

        return true;
    }


    public static long PartTwo(string inputName)
    {
        var warehouseFloor = GetColumns(inputName).Select(x => x[0].ToCharArray()).ToArray();
        var total = 0;
        var lastRunFoundAccessibleCrates = true;
        while (lastRunFoundAccessibleCrates)
        {
            var localTotal = warehouseFloor.Select((t, y) => GetRowTotal(warehouseFloor, y, true)).Sum();
            lastRunFoundAccessibleCrates = localTotal > 0;
            total += localTotal;
        }

        return total;
    }

    private static int GetRowTotal(char[][] warehouseFloor, int row, bool remove = false)
    {
        var localTotal = 0;
        for (var column = 0; column < warehouseFloor[row].Length; column++)
        {
            if (warehouseFloor[row][column] != '@' || !IsCrateAccessible(warehouseFloor, row, column)) continue;
            if (remove) warehouseFloor[row][column] = '.';
            localTotal++;
        }

        return localTotal;
    }
}
using System.Text.RegularExpressions;

namespace AdventOfCode2025.Puzzlee10;

public static class Puzzle
{
    private static string[] GetRows(string inputName)
    {
        return File.ReadAllLines($"inputs/{inputName}")
            .Select(x => x).ToArray();
    }

    public static long PartOne(string inputName)
    {
        var machineRows = GetRows(inputName);

        var machines = (from row in machineRows
            let lights = ParseLights(row)
            let buttons = ParseButtons(row)
            let joltages = ParseJoltages(row)
            select new Machine(lights, buttons, joltages)).ToList();

        return machines.Sum(machine => FindMinimumPresses(machine.Lights, machine.Buttons));
    }

    private static int[] ParseJoltages(string row)
    {
        var startIndex = row.IndexOf('{') + 1;
        var joltagesSection = row[startIndex..].Replace("}", "");
        
        return joltagesSection
            .Split(',')
            .Select(int.Parse)
            .ToArray();
    }


    private static int[] ParseButtons(string row)
    {
        var startIndex = row.IndexOf(']') + 1;
        var endIndex = row.IndexOf('{');
        var buttonsSection = row[startIndex..endIndex];
        
        var buttonGroups = buttonsSection
            .Replace("(", "")
            .Replace(")", "")
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        return buttonGroups.Select(ParseButtonGroup).ToArray();
    }

    private static int ParseButtonGroup(string buttonGroup)
    {
        var positions = buttonGroup.Split(',').Select(int.Parse);
        var buttonValue = 0;
        
        foreach (var position in positions)
        {
            buttonValue |= 1 << position; // Bit shift instead of Math.Pow
        }
        
        return buttonValue;
    }

    private static int ParseLights(string row)
    {
        var lightsSection = row[1..row.IndexOf(']')];
        var lightValue = 0;
        
        for (int i = 0; i < lightsSection.Length; i++)
        {
            if (lightsSection[i] == '#')
                lightValue |= 1 << i; // Bit shift instead of Math.Pow
        }

        return lightValue;
    }

    private static int FindMinimumPresses(int expectedLights, int[] machineButtons)
    {
        if (0 == expectedLights) return 0; 

        var visited = new HashSet<int>();
        var queue = new Queue<(int lights, int presses)>();

        queue.Enqueue((0, 0));
        visited.Add(0);

        while (queue.Count > 0)
        {
            var (currentLights, presses) = queue.Dequeue();
    
            foreach (var button in machineButtons)
            {
                var newLights = currentLights ^ button;
        
                if (newLights == expectedLights)
                    return presses + 1;
        
                if (visited.Add(newLights))
                {
                    queue.Enqueue((newLights, presses + 1));
                }
            }
        }

        return -1;
    }

    public static long PartTwo(string inputName)
    {
        var machineRows = GetRows(inputName);
        return -1;
    }
}

public record Machine(int Lights, int[] Buttons, int[] Joltages);
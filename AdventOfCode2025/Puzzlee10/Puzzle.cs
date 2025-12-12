using System.Text.RegularExpressions;
using Microsoft.Z3;



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
        var machines = GetMachines(inputName);

        return machines.Sum(machine => FindMinimumPresses(machine.Lights, machine.Buttons));
    }

    private static List<Machine> GetMachines(string inputName)
    {
        var machineRows = GetRows(inputName);

        var machines = (from row in machineRows
            let lights = ParseLights(row)
            let buttons = ParseButtons(row)
            let joltages = ParseJoltages(row)
            select new Machine(lights, buttons, joltages)).ToList();
        return machines;
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

    private static string[] ParseButtonsPartTwo(string row)
    {
        var startIndex = row.IndexOf(']') + 1;
        var endIndex = row.IndexOf('{');
        var buttonsSection = row[startIndex..endIndex];
        
        var buttonGroups = buttonsSection
            .Replace("(", "")
            .Replace(")", "")
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        return buttonGroups;
    }

    public static long PartTwo(string inputName)
    {
        var machineRows = GetRows(inputName);

        var machines = (from row in machineRows
            let buttons = ParseButtonsPartTwo(row)
            let joltages = ParseJoltages(row)
            select new MachineTwo(buttons, joltages)).ToList();


        var sum = 0L;
        foreach (var (buttons, goalJoltages) in machines)
        {
           sum += CalcutateJoltage(goalJoltages, buttons);
        }


        return sum;
    }

    //https://github.com/mohammedsouleymane/AdventOfCode/blob/main/AdventOfCode/Aoc2025/Day10.cs
    private static int CalcutateJoltage(int[] joltages, string[] buttons) // using Z3
    {
        var btns = buttons.Select(x => x.Split(",").Select(int.Parse)).ToList();
        using var ctx = new Context();
        var variables = btns
            .Select(btn => ctx.MkIntConst(btn.ToStr(",")))
            .ToList(); // creating all variables

        var opt = ctx.MkOptimize(); // creating an optimizer
        for (var i = 0; i < joltages.Length; i++)
        {
            List<IntExpr> vars = []; 
            for (var j = 0; j < btns.Count; j++)
            {
                if(btns[j].Contains(i)) // check if index is in button basically all buttons that have the index
                    vars.Add(variables[j]);// of the current joltage
            }
            var sum = ctx.MkAdd(vars); // sum of all variables
            var constraint = ctx.MkEq(sum, ctx.MkInt(joltages[i])); // check if they equal the goal
            opt.Add(constraint);//add as a constraint
        }
        
        var total = ctx.MkAdd(variables); 
        opt.MkMinimize(total); // what we want to minimize (sum of all variables)
        foreach (var v in variables)
            opt.Add(ctx.MkGe(v, ctx.MkInt(0))); // made sure all are >= 0
        
        var result = opt.Check();

        if (result != Status.SATISFIABLE) return 0;
        
        var model = opt.Model;
        return variables.Sum(v => ((IntNum)model.Evaluate(v)).Int); // we sum up all the numbers
    }

    public static string ToStr<T>(this IEnumerable<T> list, string separator = "")
    {
        return string.Join(separator, list);
    }
}


public record Machine(int Lights, int[] Buttons, int[] Joltages);
public record MachineTwo(string[] Buttons, int[] Joltages);
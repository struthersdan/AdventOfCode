namespace AdventOfCode2025.Puzzle5;

public static class Puzzle
{
    private static string[][] GetColumns(string inputName)
    {
        return File.ReadAllLines($"inputs/{inputName}")
            .Select(x => x.Split(" ", StringSplitOptions.RemoveEmptyEntries)).ToArray();
    }

    public static long PartOne(string inputName)
    {
        var columns = GetColumns(inputName);
        var freshMap = BuildFreshRanges(columns);
        return CheckIngredients(columns.SkipWhile(t => t.Length != 0).Skip(1).Select(x => long.Parse(x[0])), freshMap);
    }

    public static long PartTwo(string inputName)
    {
        var columns = GetColumns(inputName);
        var freshMap = BuildFreshRanges(columns);
        var distinctRanges = MergeRanges(freshMap);


        return distinctRanges.Sum(valueTuple => valueTuple.max - valueTuple.min + 1);
    }

    private static int CheckIngredients(IEnumerable<long> ingredients, List<(long Min, long Max)> freshMap)
    {
        return ingredients.Count(ingredient =>
            freshMap.Any(range => ingredient >= range.Min && ingredient <= range.Max));
    }

    private static List<(long Min, long Max)> BuildFreshRanges(string[][] columns)
    {
        return (from t in columns.TakeWhile(t => t.Length != 0)
            select t[0].Split('-')
            into range
            let min = long.Parse(range[0])
            let max = long.Parse(range[1])
            select (min, max)).ToList();
    }

    private static IEnumerable<(long min, long max)> MergeRanges(List<(long min, long max)> freshMap)
    {
        for (var index = 0; index < freshMap.Count; index++)
        {
            var (min, max) = freshMap[index];

            for (var i = 0; i < freshMap.Count; i++)
            {
                if (index == i) continue;
                var (otherMin, otherMax) = freshMap[i];
                otherMin = SetOtherMin(otherMin, min, max);
                otherMax = SetOtherMax(otherMax, max, min);

                freshMap[i] = (otherMin, otherMax);
            }
        }

        return freshMap.Distinct();
    }

    private static long SetOtherMax(long otherMax, long max, long min)
    {
        return  (otherMax < max && otherMax >= min) ? max : otherMax;       
    }

    private static long SetOtherMin(long otherMin, long min, long max)
    {
        return (otherMin > min && otherMin <= max) ? min : otherMin;
    }
}
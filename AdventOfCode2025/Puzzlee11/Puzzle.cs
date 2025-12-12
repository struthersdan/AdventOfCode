namespace AdventOfCode2025.Puzzlee11;

public static class Puzzle
{
    private static string[] GetRows(string inputName)
    {
        return File.ReadAllLines($"inputs/{inputName}")
            .Select(x => x).ToArray();
    }


    public static long PartOne(string inputName)
    {
        var nodes = GetNodes(inputName);
        var pathCount = CountPaths(nodes, "you", "out", []);

        return pathCount;
    }

    private static Dictionary<string, string[]> GetNodes(string inputName)
    {
        var rows = GetRows(inputName);

        var nodes = rows.Select(row => row.Split(':'))
            .ToDictionary(parts => parts[0], parts => parts[1].Split(" ", StringSplitOptions.RemoveEmptyEntries));
        return nodes;
    }

    private static long CountPaths(Dictionary<string, string[]> nodes, string start, string end, Dictionary<(string start, string end), long> pathCache)
    {
        // Return cached result if available
        if (pathCache.TryGetValue((start, end), out var cachedCount))
            return cachedCount;

        // Base case: no outgoing edges from start
        if (!nodes.TryGetValue(start, out var neighbors))
            return CacheAndReturn(start, end, 0, pathCache);

        // Base case: direct connection to end
        if (neighbors.Contains(end))
            return CacheAndReturn(start, end, 1, pathCache);

        // Recursive case: sum paths through all neighbors
        var pathCount = neighbors.Sum(neighbor => CountPaths(nodes, neighbor, end, pathCache));
        return CacheAndReturn(start, end, pathCount, pathCache);
    }

    private static long CacheAndReturn(string start, string end, long count, Dictionary<(string start, string end), long> pathCache)
    {
        pathCache[(start, end)] = count;
        return count;
    }


    public static long PartTwo(string inputName)
    {
        var nodes = GetNodes(inputName);
        Dictionary<(string start, string end), long> pathCache = [];

        var svrFftPath = CountPaths(nodes, "svr", "fft", pathCache);
        var fftDacPath = CountPaths(nodes, "fft", "dac", pathCache);
        var datOutPath = CountPaths(nodes, "dac", "out", pathCache);

        var svrDacPath = CountPaths(nodes, "svr", "dac", pathCache);
        var dacFftPath = CountPaths(nodes, "dac", "fft", pathCache);
        var fftOutPath = CountPaths(nodes, "fft", "out", pathCache);

        return svrFftPath* fftDacPath * datOutPath + svrDacPath * dacFftPath * fftOutPath;
    }
}
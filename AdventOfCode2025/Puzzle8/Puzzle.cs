namespace AdventOfCode2025.Puzzle8;

public static class Puzzle
{
    private static string[][] GetRows(string inputName)
    {
        return File.ReadAllLines($"inputs/{inputName}")
            .Select(x => x.Split(" ", StringSplitOptions.RemoveEmptyEntries)).ToArray();
    }

    public static long PartOne(string inputName, int loopCount)
    {
        var nodes = GetRows(inputName).Select(row =>
        {
            var points = row[0].Split(",");
            return new Node(int.Parse(points[0]), int.Parse(points[1]), int.Parse(points[2]));
        }).ToArray();


        var orderedDistances = GetOrderedDistances(nodes);

        var circuits = new HashSet<HashSet<int>>();
        for (var index = 0; index < nodes.Length; index++)
        {
            circuits.Add([index]);
        }

        for (int i = 0; i < loopCount; i++)
        {
            var (a, b) = orderedDistances.Dequeue();

            var foundCircuits = circuits.Where(circuit => circuit.Contains(a) || circuit.Contains(b)).ToArray();

            if (foundCircuits.Length < 2) continue;

            for (int j = 1; j < foundCircuits.Length; j++)
            {
                foundCircuits[0].UnionWith(foundCircuits[j]);
                circuits.Remove(foundCircuits[j]);
            }
        }

        var distinct = circuits.Select(x => x.Count).OrderByDescending(x => x).Take(3).Aggregate(1, (a, b) => a * b);
        return distinct;
    }

    public static long PartTwo(string inputName)
    {
        var nodes = GetRows(inputName).Select(row =>
        {
            var points = row[0].Split(",");
            return new Node(int.Parse(points[0]), int.Parse(points[1]), int.Parse(points[2]));
        }).ToArray();

        var orderedDistances = GetOrderedDistances(nodes);
        var circuits = new HashSet<HashSet<int>>();
        for (var index = 0; index < nodes.Length; index++)
        {
            var node = nodes[index];
            circuits.Add([index]);
        }

        while(orderedDistances.TryDequeue(out var current, out _))
        {
            var (a, b) = current;
            var foundCircuits = circuits.Where(circuit => circuit.Contains(a) || circuit.Contains(b)).ToArray();

            if (foundCircuits.Length != 2) continue;
            foundCircuits[0].UnionWith(foundCircuits[1]);
            circuits.Remove(foundCircuits[1]);

            if (foundCircuits[0].Count == nodes.Length)
                return nodes[a].x * (long) nodes[b].x;
        }

        return -1;
    }

    private static PriorityQueue<Circuit, long> GetOrderedDistances(Node[] nodes)
    {
        var distances = new PriorityQueue<Circuit, long>();

        for (var i = 0; i < nodes.Length; i++)
        {
            for (var j = i + 1; j < nodes.Length; j++)
            {
                distances.Enqueue(new Circuit(i, j), CalculateSquaredDistance(nodes[i], nodes[j]));
            }
        }

        return distances;
    }

    private readonly record struct Circuit(int start, int finish);

    private static long CalculateSquaredDistance(Node node1, Node node2)
    {
        long dx = node2.x - node1.x;
        long dy = node2.y - node1.y;
        long dz = node2.z - node1.z;
        return dx * dx + dy * dy + dz * dz;
    }

    private readonly record struct Node(int x, int y, int z);
}
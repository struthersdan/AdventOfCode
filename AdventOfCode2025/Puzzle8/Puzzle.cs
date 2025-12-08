namespace AdventOfCode2025.Puzzle8
{
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
                var node = nodes[index];
                circuits.Add([index]);
            }

            for (int i = 0; i < loopCount; i++)
            {
                var ((a, b), _) = orderedDistances[i];

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

            foreach (var ((a, b), _) in orderedDistances)
            {
               
                var foundCircuits = circuits.Where(circuit => circuit.Contains(a) || circuit.Contains(b)).ToArray();

                if (foundCircuits.Length < 2) continue;
               

                for (int j = 1; j < foundCircuits.Length; j++)
                {
                    foundCircuits[0].UnionWith(foundCircuits[j]);
                    circuits.Remove(foundCircuits[j]);
                }

                if (foundCircuits[0].Count == nodes.Length)
                    return nodes[a].x * (long) nodes[b].x;

            }

            return -1;
        }

        private static List<KeyValuePair<(int, int), double>> GetOrderedDistances(Node[] nodes)
        {
            var distances = new Dictionary<(int, int), double>();

            for (var i = 0; i < nodes.Length; i++)
            {
                for (int j = i + 1; j < nodes.Length; j++)
                {
                    var node = nodes[j];
                    var nodes1 = nodes[i];
                    distances[(i, j)] = CalculateEuclideanDistance(nodes1, node);
                }
            }

            return distances.OrderBy(x => x.Value).ToList();
        }

        private static double CalculateEuclideanDistance(Node node, Node node1)
        {
            return Math.Sqrt(Math.Pow(node1.x - node.x, 2) + Math.Pow(node1.y - node.y, 2) + Math.Pow(node1.z - node.z, 2));
        }

        private readonly record struct Node(int x, int y, int z);
    }
}
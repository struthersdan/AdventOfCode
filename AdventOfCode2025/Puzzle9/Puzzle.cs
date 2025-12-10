namespace AdventOfCode2025.Puzzle9;

public static class Puzzle
{
    private static string[][] GetRows(string inputName)
    {
        return File.ReadAllLines($"inputs/{inputName}")
            .Select(x => x.Split(" ", StringSplitOptions.RemoveEmptyEntries)).ToArray();
    }

    public static long PartOne(string inputName)
    {
        var corners = GetRows(inputName).Select(row =>
        {
            var points = row[0].Split(",");
            return new Corner(int.Parse(points[0]), int.Parse(points[1]));
        }).ToArray();


        return GetLargestArea(corners);
    }

    public static long PartTwo(string inputName)
    {
        var corners = GetRows(inputName).Select(row =>
        {
            var points = row[0].Split(",");
            return new Corner(int.Parse(points[0]), int.Parse(points[1]));
        }).ToArray();

        var edges = GetEdges(corners);
        // Pre-group edges by type for faster filtering
        var verticalEdges = new List<VerticalEdge>();
        var horizontalEdges = new List<HorizontalEdge>();

        foreach (var edgeCorner in edges)
        {
            var (minX, maxX, minY, maxY) = edgeCorner;

            if (minX != maxX)
                horizontalEdges.Add(new HorizontalEdge(minY, minX, maxX));
            else
                verticalEdges.Add(new VerticalEdge(minX, minY, maxY));
        }

        var areas = GetAreas(corners);

        while (areas.TryDequeue(out var area, out _))
        {
            var (rectangle, size) = area;

            if (!HasIntersection(rectangle, verticalEdges, horizontalEdges))
            {
                return size;
            }
        }

        return -1;
    }

    private static bool HasIntersection(
        Rect rect,
        List<VerticalEdge> verticalEdges, 
        List<HorizontalEdge> horizontalEdges)
    {
       var (minX, maxX, minY, maxY) = rect;

        // Check vertical edges - only those that could intersect horizontally
        foreach (VerticalEdge edge in verticalEdges)
        {
            if (edge.x <= minX || edge.x >= maxX) continue;
            if (edge.start < maxY && edge.end > minY)
                return true;
        }

        // Check horizontal edges - only those that could intersect vertically
        foreach (HorizontalEdge edge in horizontalEdges)
        {
            if (edge.y <= minY || edge.y >= maxY) continue;
            if (edge.start < maxX && edge.end > minX)
                return true;
        }

        return false;
    }

    private  interface IEdge
    {
        
    }


    private readonly record struct VerticalEdge(int x, int start, int end) : IEdge;

    private readonly record struct HorizontalEdge(int y, int start, int end) : IEdge;

    private static IEnumerable<Rect> GetEdges(Corner[] corners)
    {
        var edges = new List<(Corner, Corner)>();
        for (var i = 0; i < corners.Length - 1; i++)
        {
            edges.Add((corners[i], corners[i + 1]));
        }

        edges.Add((corners[^1], corners[0]));

        return edges.Select((x) => BuildRectangle(x.Item1, x.Item2));
    }

    private readonly record struct Rect(int minX, int maxX, int minY, int maxY);
    private static PriorityQueue<Area, long> GetAreas(Corner[] corners)
    {
        var areas = new PriorityQueue<Area, long>();
        for (var i = 0; i < corners.Length; i++)
        {
            for (var j = i + 1; j < corners.Length; j++)
            {
                var areaSize = CalculateArea(corners[i], corners[j]);
                areas.Enqueue(new Area(BuildRectangle(corners[i], corners[j]), areaSize), -areaSize);
            }
        }

        return areas;
    }

    private static long GetLargestArea(Corner[] nodes)
    {
        var largestArea = 0L;

        for (var i = 0; i < nodes.Length; i++)
        {
            for (var j = i + 1; j < nodes.Length; j++)
            {
                var area = CalculateArea(nodes[i], nodes[j]);
                if (area > largestArea) largestArea = area;
            }
        }

        return largestArea;
    }


    private static Rect BuildRectangle(Corner node1, Corner node2)
    {
        var minX = Math.Min(node1.x, node2.x);
        var maxX = Math.Max(node1.x, node2.x);
        var minY = Math.Min(node1.y, node2.y);
        var maxY = Math.Max(node1.y, node2.y);
        return new Rect(minX, maxX, minY, maxY);
    }

    private readonly record struct Area(Rect rectangle, long Size);

    private static long CalculateArea(Corner node1, Corner node2)
    {
        return (Math.Abs(node2.x - node1.x) + 1) * (long) (Math.Abs(node2.y - node1.y) + 1);
    }

    private readonly record struct Corner(int x, int y);
}
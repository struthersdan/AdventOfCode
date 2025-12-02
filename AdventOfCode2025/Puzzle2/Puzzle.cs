namespace AdventOfCode2025.Puzzle2
{
    public static class Puzzle
    {
        private static string[][] GetColumns(string inputName) => File.ReadAllLines($"inputs/{inputName}")
            .Select(x => x.Split(" ", StringSplitOptions.RemoveEmptyEntries)).ToArray();

        public static long PartOne(string inputName)
        {
            long total = 0;
            var input = GetRanges(inputName);

            foreach (var range in input)
            {
                for (long i = range.Start; i <= range.End; i++)
                {
                    var numberStr = i.ToString();
                    if(numberStr.Length %2 !=0) continue;
                    var firstHalf= numberStr[..(numberStr.Length / 2)];
                    var secondHalf = numberStr[(numberStr.Length / 2)..];
                    if (firstHalf != secondHalf) continue;
                    total += i;
                }
            }
            return  total;
        }

        private static IEnumerable<(long Start, long End)> GetRanges(string inputName)
        {
            var columns = GetColumns(inputName);

            var ranges = columns.SelectMany(x => x.SelectMany(y => y.Split(",", StringSplitOptions.RemoveEmptyEntries)));
            var input = ranges.Select(x=>
            {
                var items = x.Split("-", StringSplitOptions.RemoveEmptyEntries);

                return  (Start: long.Parse(items[0]), End: long.Parse(items[1]));
            });
            return input;
        }


        public static long PartTwo(string inputName)
        {
            long total = 0;
            var input = GetRanges(inputName);

            foreach (var range in input)
            {
                for (long i = range.Start; i <= range.End; i++)
                {
                    var numberStr = i.ToString();

                    for (var j = 1; j <= numberStr.Length / 2; j++)
                    {
                        if(numberStr.Length % j != 0) continue;
                        if (!IsRepeatingPattern(numberStr.AsSpan(), j)) continue;
                        total += i;
                        break;
                    }

                }
            }
            return  total;
        }

        private static bool IsRepeatingPattern(ReadOnlySpan<char> numberStr, int chunkSize)
        {
            var pattern = numberStr[..chunkSize];
    
            for (var i = chunkSize; i < numberStr.Length; i += chunkSize)
            {
                var chunk = numberStr.Slice(i, chunkSize);
                if (!pattern.SequenceEqual(chunk))
                    return false;
            }
    
            return true;
        }
    }
}
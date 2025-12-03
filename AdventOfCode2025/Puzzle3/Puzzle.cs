namespace AdventOfCode2025.Puzzle3
{
    public static class Puzzle
    {
        private static string[][] GetColumns(string inputName) => File.ReadAllLines($"inputs/{inputName}")
            .Select(x => x.Split(" ", StringSplitOptions.RemoveEmptyEntries)).ToArray();

        public static long PartOne(string inputName)
        {
            return Solve(inputName, 2);
        }

        public static long PartTwo(string inputName)
        {
            return  Solve(inputName, 12);
        }

        private static long Solve(string inputName, int length)
        {
            var columns = GetColumns(inputName);
            long total = 0;
            foreach (var column in columns)
            {
                var numbers = column[0].Select(x => int.Parse(x.ToString())).ToArray();
                total += long.Parse(GetJoltage(numbers, length));
            }

            return total;
        }

        private static string GetJoltage(int[] numbers, int length)
        {
            var joltage = "";
            var start = 0;

            for (var i = 0; i < length; i++)
            {
                var (largest, nextStart) = GetNextLargestNumber(numbers, start, length - 1 - i);
                joltage += largest.ToString();
                start = nextStart;
            }

            return joltage;
        }

        private static (int largest, int nextStart) GetNextLargestNumber(int[] numbers, int start, int endBuffer)
        {
            var largest = 0;
            var nextStart = 0;
            for (var i = start; i < numbers.Length - endBuffer; i++)
            {
                var next = numbers[i];
                if (next > largest)
                {
                    largest = next;
                    nextStart = i + 1;
                }

                if (next == 9)  break;
            }

            return (largest, nextStart);
        }


   
    }
}
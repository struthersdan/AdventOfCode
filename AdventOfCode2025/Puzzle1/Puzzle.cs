using System;
using System.Text.RegularExpressions;

namespace AdventOfCode2025.Puzzle1
{
    public static class Puzzle
    {
        private static string[][] GetColumns(string inputName) => File.ReadAllLines($"inputs/{inputName}")
            .Select(x => x.Split(" ", StringSplitOptions.RemoveEmptyEntries)).ToArray();

        public static long PartOne(string inputName)
        {
            var columns = GetColumns(inputName);

            var current = 50;
            var zeroCount = 0;
            foreach (var instruction in columns.Select(x => x[0]))
            {
                var direction = instruction[0];
                var distance = int.Parse(instruction[1..]) % 100;

                current = UpdatePosition(direction, current, distance);

                if (current == 0)
                    zeroCount++;
            }

            return zeroCount;
        }

        private static int UpdatePosition(char direction, int current, int distance)
        {
            switch (direction)
            {
                case 'L':
                    current -= distance;
                    if (current < 0)
                    {
                        current += 100;
                    }

                    break;
                case 'R':
                    current += distance;
                    if (current >= 100)
                    {
                        current -= 100;
                    }

                    break;
            }

            return current;
        }

        public static long PartTwo(string inputName)
        {
            var columns = GetColumns(inputName);

            var current = 50;
            var zeroCount = 0;
            foreach (var instruction in columns.Select(x => x.First()))
            {
                var currentZeroCount = 0;
                var didNotStartAtZero = current != 0;


                var direction = instruction[0];
                var distance = int.Parse(instruction[1..]);



                var fullRotations = distance / 100;
                var remainingDistance = distance % 100;


                current = UpdateCurrent(direction, current, remainingDistance);


                if (current < 0)
                {
                    if (current != -100 && didNotStartAtZero) currentZeroCount++;

                    current += 100;
                }

                if (current > 99)
                {
                    if (current != 100 && didNotStartAtZero) currentZeroCount++;
                    current -= 100;
                }

                if (current == 0)
                {
                    currentZeroCount++;
                }


                zeroCount += currentZeroCount + fullRotations;
            }

            return zeroCount;
        }

        private static int UpdateCurrent(char direction, int current, int remainingDistance)
        {
            switch (direction)
            {
                case 'L':
                    current -= remainingDistance;

                    break;

                case 'R':
                    current += remainingDistance;


                    break;
            }

            return current;
        }
    }
}
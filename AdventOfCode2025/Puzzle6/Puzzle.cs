namespace AdventOfCode2025.Puzzle6;

public static class Puzzle
{
    private static string[][] GetRows(string inputName)
    {
        return File.ReadAllLines($"inputs/{inputName}")
            .Select(x => x.Split(" ", StringSplitOptions.RemoveEmptyEntries)).ToArray();
    }

    public static long PartOne(string inputName)
    {
        var columns = GetRows(inputName).Transpose();
        var total = 0L;

        foreach (var column in columns)
        {
            var @operator = column.Last();
            var currentTotal = 0L;
            foreach (var variable in column.Take(column.Length - 1))
            {
                if (currentTotal == 0)
                {
                    currentTotal = long.Parse(variable);
                }
                else
                {
                    switch (@operator)
                    {
                        case "+":
                            currentTotal += long.Parse(variable);
                            break;
                        case "*":
                            currentTotal *= long.Parse(variable);
                            break;
                    }
                }
            }

            total += currentTotal;
        }

        return total;
    }

    public static long PartTwo(string inputName)
    {
        var columns = File.ReadAllLines($"inputs/{inputName}")
            .Select(row => row.ToCharArray()).ToArray().Transpose();
        var total = 0L;

        var currentProblem = new List<string>();
        var @operator = ' ';

        for (var index = 0; index < columns.Length; index++)
        {
            var column = columns[index];
            var isNumberColumn = column.Any(x => x != ' ');
            if (isNumberColumn)
            {
                if (column.Last() != ' ') @operator = column.Last();

                var currentNumber = column.Take(column.Length - 1).Where(x => x != ' ')
                    .Aggregate("", (current, c) => current + c);

                currentProblem.Add(currentNumber);
            }

            if (index != columns.Length - 1 && isNumberColumn) continue;

            var currTotal = Calculate(currentProblem, @operator);
            total += currTotal;
            @operator = ' ';
            currentProblem.Clear();
        }

        return total;
    }

    private static long Calculate(List<string> currentProblem, char currentOperator)
    {
        long currentTotal = 0;
        foreach (var variable in currentProblem)
        {
            if (currentTotal == 0)
            {
                currentTotal = long.Parse(variable);
            }
            else
            {
                switch (currentOperator)
                {
                    case '+':
                        currentTotal += long.Parse(variable);
                        break;
                    case '*':
                        currentTotal *= long.Parse(variable);
                        break;
                }
            }
        }

        return currentTotal;
    }
}
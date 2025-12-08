namespace AdventOfCode2025.Puzzle7
{
    [TestFixture]
    internal class Tests
    {
        const string PuzzleName = "Puzzle7";
        [TestCase($"{PuzzleName}/sample.txt", 21)]
        [TestCase($"{PuzzleName}/input.txt", 1560)]
        public void PartA(string inputName, long answer)
        {
            var result = Puzzle.PartOne(inputName);
            Assert.That(result, Is.EqualTo(answer));
            Console.WriteLine(result);
        }

        [TestCase($"{PuzzleName}/sample.txt", 40)]
        [TestCase($"{PuzzleName}/input.txt", 25592971184998)]
        public void PartB(string inputName, long answer)
        {
            var result = Puzzle.PartTwo(inputName);
            Assert.That(result, Is.EqualTo(answer));
            Console.WriteLine(result);
        }
    }
}
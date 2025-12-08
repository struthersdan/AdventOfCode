namespace AdventOfCode2025.Puzzle8
{
    [TestFixture]
    internal class Tests
    {
        const string PuzzleName = "Puzzle8";
        [TestCase($"{PuzzleName}/sample.txt", 40, 10)]
        [TestCase($"{PuzzleName}/input.txt", 122636, 1000)]
        public void PartA(string inputName, long answer, int loopCount)
        {
            var result = Puzzle.PartOne(inputName, loopCount);
            Assert.That(result, Is.EqualTo(answer));
            Console.WriteLine(result);
        }

        [TestCase($"{PuzzleName}/sample.txt", 25272)]
        [TestCase($"{PuzzleName}/input.txt", 9271575747)]
        public void PartB(string inputName, long answer)
        {
            var result = Puzzle.PartTwo(inputName);
            Assert.That(result, Is.EqualTo(answer));
            Console.WriteLine(result);
        }
    }
}
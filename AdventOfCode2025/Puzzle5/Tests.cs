namespace AdventOfCode2025.Puzzle5
{
    [TestFixture]
    internal class Tests
    {
        const string PuzzleName = "Puzzle5";
        [TestCase($"{PuzzleName}/sample.txt", 3)]
        [TestCase($"{PuzzleName}/input.txt", 840)]
        public void PartA(string inputName, long answer)
        {
            var result = Puzzle.PartOne(inputName);
            Assert.That(result, Is.EqualTo(answer));
            Console.WriteLine(result);
        }

        [TestCase($"{PuzzleName}/sample.txt", 14)]
        [TestCase($"{PuzzleName}/input.txt", 359913027576322)]
        public void PartB(string inputName, long answer)
        {
            var result = Puzzle.PartTwo(inputName);
            Assert.That(result, Is.EqualTo(answer));
            Console.WriteLine(result);
        }
    }
}
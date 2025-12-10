namespace AdventOfCode2025.Puzzle9
{
    [TestFixture]
    internal class Tests
    {
        const string PuzzleName = "Puzzle9";
        [TestCase($"{PuzzleName}/sample.txt", 50)]
        [TestCase($"{PuzzleName}/input.txt", 4771532800)]
        public void PartA(string inputName, long answer)
        {
            var result = Puzzle.PartOne(inputName);
            Assert.That(result, Is.EqualTo(answer));
            Console.WriteLine(result);
        }

        [TestCase($"{PuzzleName}/sample.txt", 24)]
        [TestCase($"{PuzzleName}/input.txt", 1544362560)]
        public void PartB(string inputName, long answer)
        {
            var result = Puzzle.PartTwo(inputName);
            Assert.That(result, Is.EqualTo(answer));
            Console.WriteLine(result);
        }
    }
}
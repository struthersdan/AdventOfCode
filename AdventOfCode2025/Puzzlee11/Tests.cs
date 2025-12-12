namespace AdventOfCode2025.Puzzlee11
{
    [TestFixture]
    internal class Tests
    {
        const string PuzzleName = "Puzzlee11";
        [TestCase($"{PuzzleName}/sample.txt", 5)]
        [TestCase($"{PuzzleName}/input.txt", 511)]
        public void PartA(string inputName, long answer)
        {
            var result = Puzzle.PartOne(inputName);
            Assert.That(result, Is.EqualTo(answer));
            Console.WriteLine(result);
        }

        [TestCase($"{PuzzleName}/sample2.txt", 2)]
        [TestCase($"{PuzzleName}/input.txt", 458618114529380)]
        public void PartB(string inputName, long answer)
        {
            var result = Puzzle.PartTwo(inputName);
            Assert.That(result, Is.EqualTo(answer));
            Console.WriteLine(result);
        }
    }
}
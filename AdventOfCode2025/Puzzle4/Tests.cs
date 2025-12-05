namespace AdventOfCode2025.Puzzle4
{
    [TestFixture]
    internal class Tests
    {
        const string PuzzleName = "Puzzle4";
        [TestCase($"{PuzzleName}/sample.txt", 13)]
        [TestCase($"{PuzzleName}/input.txt", 1527)]
        public void PartA(string inputName, long answer)
        {
            var result = Puzzle.PartOne(inputName);
            Assert.That(result, Is.EqualTo(answer));
            Console.WriteLine(result);
        }

        [TestCase($"{PuzzleName}/sample.txt", 43)]
        [TestCase($"{PuzzleName}/input.txt", 8690)]
        public void PartB(string inputName, long answer)
        {
            var result = Puzzle.PartTwo(inputName);
            Assert.That(result, Is.EqualTo(answer));
            Console.WriteLine(result);
        }
    }
}
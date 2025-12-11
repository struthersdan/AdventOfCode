namespace AdventOfCode2025.Puzzlee10
{
    [TestFixture]
    internal class Tests
    {
        const string PuzzleName = "Puzzlee10";
        [TestCase($"{PuzzleName}/sample.txt", 7)]
        [TestCase($"{PuzzleName}/input.txt", 428)]
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
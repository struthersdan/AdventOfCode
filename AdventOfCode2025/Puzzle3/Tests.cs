namespace AdventOfCode2025.Puzzle3
{
    [TestFixture]
    internal class Tests
    {
        const string PuzzleName = "Puzzle3";
        [TestCase($"{PuzzleName}/sample.txt", 357)]
        [TestCase($"{PuzzleName}/input.txt", 17376)]
        public void PartA(string inputName, long answer)
        {
            var result = Puzzle.PartOne(inputName);
            Assert.That(result, Is.EqualTo(answer));
            Console.WriteLine(result);
        }

        [TestCase($"{PuzzleName}/sample.txt", 3121910778619)]
        [TestCase($"{PuzzleName}/input.txt", 172119830406258)]
        public void PartB(string inputName, long answer)
        {
            var result = Puzzle.PartTwo(inputName);
            Assert.That(result, Is.EqualTo(answer));
            Console.WriteLine(result);
        }
    }
}
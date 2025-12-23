namespace AdventOfCode2015.Puzzle1
{
    [TestFixture]
    internal class Tests
    {
        const string PuzzleName = "Puzzle1";
        [TestCase($"{PuzzleName}/sample.txt", 3)]
        [TestCase($"{PuzzleName}/input.txt", 74)]
        public void PartA(string inputName, long answer)
        {
            var result = Puzzle.PartOne(inputName);
            Assert.That(result, Is.EqualTo(answer));
            Console.WriteLine(result);
        }

        [TestCase($"{PuzzleName}/sample.txt", -1)]
        [TestCase($"{PuzzleName}/input.txt", 1795)]
        public void PartB(string inputName, long answer)
        {
            var result = Puzzle.PartTwo(inputName);
            Assert.That(result, Is.EqualTo(answer));
            Console.WriteLine(result);
        }
    }

}
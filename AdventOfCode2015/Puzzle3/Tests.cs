namespace AdventOfCode2015.Puzzle3
{
    [TestFixture]
    internal class Tests
    {
        const string PuzzleName = "Puzzle3";
        [TestCase($"{PuzzleName}/sample.txt", 2)]
        [TestCase($"{PuzzleName}/input.txt", 2565)]
        public void PartA(string inputName, long answer)
        {
            var result = Puzzle.PartOne(inputName);
            Assert.That(result, Is.EqualTo(answer));
            Console.WriteLine(result);
        }

        [TestCase($"{PuzzleName}/sample.txt", 11)]
        [TestCase($"{PuzzleName}/input.txt", 2639)]
        public void PartB(string inputName, long answer)
        {
            var result = Puzzle.PartTwo(inputName);
            Assert.That(result, Is.EqualTo(answer));
            Console.WriteLine(result);
        }
    }

}
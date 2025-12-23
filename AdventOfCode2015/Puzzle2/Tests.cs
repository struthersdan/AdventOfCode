namespace AdventOfCode2015.Puzzle2
{
    [TestFixture]
    internal class Tests
    {
        const string PuzzleName = "Puzzle2";
        [TestCase($"{PuzzleName}/sample.txt", 101)]
        [TestCase($"{PuzzleName}/input.txt", 1588178)]
        public void PartA(string inputName, long answer)
        {
            var result = Puzzle.PartOne(inputName);
            Assert.That(result, Is.EqualTo(answer));
            Console.WriteLine(result);
        }

        [TestCase($"{PuzzleName}/sample.txt", 48)]
        [TestCase($"{PuzzleName}/input.txt", 3783758)]
        public void PartB(string inputName, long answer)
        {
            var result = Puzzle.PartTwo(inputName);
            Assert.That(result, Is.EqualTo(answer));
            Console.WriteLine(result);
        }
    }

}
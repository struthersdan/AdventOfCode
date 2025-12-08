namespace AdventOfCode2025.Puzzle6
{
    [TestFixture]
    internal class Tests
    {
        const string PuzzleName = "Puzzle6";
        [TestCase($"{PuzzleName}/sample.txt", 4277556)]
        [TestCase($"{PuzzleName}/input.txt", 6172481852142)]
        public void PartA(string inputName, long answer)
        {
            var result = Puzzle.PartOne(inputName);
            Assert.That(result, Is.EqualTo(answer));
            Console.WriteLine(result);
        }

        [TestCase($"{PuzzleName}/sample.txt", 3263827)]
        [TestCase($"{PuzzleName}/input.txt", 10188206723429)]
        public void PartB(string inputName, long answer)
        {
            var result = Puzzle.PartTwo(inputName);
            Assert.That(result, Is.EqualTo(answer));
            Console.WriteLine(result);
        }
    }
}
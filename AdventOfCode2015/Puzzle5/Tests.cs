namespace AdventOfCode2015.Puzzle5
{
    [TestFixture]
    internal class Tests
    {
        const string PuzzleName = "Puzzle5";
        [TestCase($"{PuzzleName}/sample.txt", 2)]
        [TestCase($"{PuzzleName}/input.txt", 236)]
        public void PartA(string inputName, long answer)
        {
            var result = Puzzle.PartOne(inputName);
            Assert.That(result, Is.EqualTo(answer));
            Console.WriteLine(result);
        }

        //[TestCase($"{PuzzleName}/sample.txt", 11)]
        [TestCase($"{PuzzleName}/input.txt", 51)]
        public void PartB(string inputName, long answer)
        {
            var result = Puzzle.PartTwo(inputName);
            Assert.That(result, Is.EqualTo(answer));
            Console.WriteLine(result);
        }
    }

}
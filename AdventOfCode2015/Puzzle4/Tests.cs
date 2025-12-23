namespace AdventOfCode2015.Puzzle4
{
    [TestFixture]
    internal class Tests
    {
        const string PuzzleName = "Puzzle4";
        //[TestCase($"{PuzzleName}/sample.txt", 2)]
        [TestCase($"{PuzzleName}/input.txt", 254575)]
        public void PartA(string inputName, long answer)
        {
            var result = Puzzle.PartOne(inputName);
            Assert.That(result, Is.EqualTo(answer));
            Console.WriteLine(result);
        }

        //[TestCase($"{PuzzleName}/sample.txt", 11)]
        [TestCase($"{PuzzleName}/input.txt", 1038736)]
        public void PartB(string inputName, long answer)
        {
            var result = Puzzle.PartTwo(inputName);
            Assert.That(result, Is.EqualTo(answer));
            Console.WriteLine(result);
        }
    }

}
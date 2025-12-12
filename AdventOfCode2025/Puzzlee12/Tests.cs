namespace AdventOfCode2025.Puzzlee12
{
    [TestFixture]
    internal class Tests
    {
        const string PuzzleName = "Puzzlee12";
        //[TestCase($"{PuzzleName}/sample.txt", 5)]
        [TestCase($"{PuzzleName}/input.txt", 511)]
        public void PartA(string inputName, long answer)
        {
            var result = Puzzle.PartOne(inputName);
            Assert.That(result, Is.EqualTo(answer));
            Console.WriteLine(result);
        }
    }
}
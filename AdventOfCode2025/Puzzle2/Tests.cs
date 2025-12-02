namespace AdventOfCode2025.Puzzle2
{
    [TestFixture]
    internal class Tests
    {
        [TestCase("Puzzle2/sample.txt", 1227775554)]

        [TestCase("Puzzle2/input.txt", 21898734247)]
        public void PartA(string inputName, long answer)
        {
            var result = Puzzle.PartOne(inputName);
            Assert.That(result, Is.EqualTo(answer));
            Console.WriteLine(result);
        }

        [TestCase("Puzzle2/sample.txt",  4174379265)]

        [TestCase("Puzzle2/input.txt", 28915664389)]
        public void PartB(string inputName, long answer)
        {
            var result = Puzzle.PartTwo(inputName);
            Assert.That(result, Is.EqualTo(answer));
            Console.WriteLine(result);
        }
    }
}
using AdventOfCode2025.Puzzle1;

namespace AdventOfCode2024.Puzzle1
{
    [TestFixture]
    internal class Tests
    {
        [TestCase("Puzzle1/sample.txt", 3)]

        [TestCase("Puzzle1/input.txt", 1023)]
        public void PartA(string inputName, int answer)
        {
            var result = Puzzle.PartOne(inputName);
            Assert.That(result, Is.EqualTo(answer));
            Console.WriteLine(result);
        }

        [TestCase("Puzzle1/sample.txt", 6)]

        [TestCase("Puzzle1/input.txt", 5899)]
        public void PartB(string inputName, int answer)
        {
            var result = Puzzle.PartTwo(inputName);
            Assert.That(result, Is.EqualTo(answer));
            Console.WriteLine(result);
        }
    }
}
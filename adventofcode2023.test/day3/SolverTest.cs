using adventofcode2023.test.utility;

namespace adventofcode2023.day3
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            Assert.That(new Solver().Part1(FileUtils.ReadAllLines("day3/sample.txt")), Is.EqualTo(4361));
            Assert.That(new Solver().Part1(FileUtils.ReadAllLines("day3/input.txt")), Is.EqualTo(539433));
        }

        [Test]
        public void Test2()
        {
            Assert.That(new Solver().Part2(FileUtils.ReadAllLines("day3/sample.txt")), Is.EqualTo(467835));
            Assert.That(new Solver().Part2(FileUtils.ReadAllLines("day3/input.txt")), Is.EqualTo(75847567));
        }
    }
}

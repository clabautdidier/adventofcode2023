using adventofcode2023.test.utility;

namespace adventofcode2023.day6
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            Assert.That(new Solver().Part1(FileUtils.ReadAllLines("day6/sample.txt")), Is.EqualTo(288));
            Assert.That(new Solver().Part1(FileUtils.ReadAllLines("day6/input.txt")), Is.EqualTo(2344708));
        }

        [Test]
        public void Test2()
        {
            Assert.That(new Solver().Part2(FileUtils.ReadAllLines("day6/sample.txt")), Is.EqualTo(71503));
            Assert.That(new Solver().Part2(FileUtils.ReadAllLines("day6/input.txt")), Is.EqualTo(30125202));
        }
    }
}

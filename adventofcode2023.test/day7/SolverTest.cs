using adventofcode2023.test.utility;

namespace adventofcode2023.day7
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            Assert.That(new Solver().Part1(FileUtils.ReadAllLines("day7/sample.txt")), Is.EqualTo(6440));
            Assert.That(new Solver().Part1(FileUtils.ReadAllLines("day7/input.txt")), Is.EqualTo(250946742));
        }

        [Test]
        public void Test2()
        {
            Assert.That(new Solver().Part2(FileUtils.ReadAllLines("day7/sample.txt")), Is.EqualTo(5905));
            Assert.That(new Solver().Part2(FileUtils.ReadAllLines("day7/input.txt")), Is.EqualTo(251824095));
        }
    }
}

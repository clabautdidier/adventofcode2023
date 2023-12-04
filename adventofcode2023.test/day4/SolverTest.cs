using adventofcode2023.test.utility;

namespace adventofcode2023.day4
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            Assert.That(new Solver().Part1(FileUtils.ReadAllLines("day4/sample.txt")), Is.EqualTo(13));
            Assert.That(new Solver().Part1(FileUtils.ReadAllLines("day4/input.txt")), Is.EqualTo(15205));
        }

        [Test]
        public void Test2()
        {
            Assert.That(new Solver().Part2(FileUtils.ReadAllLines("day4/sample.txt")), Is.EqualTo(30));
            Assert.That(new Solver().Part2(FileUtils.ReadAllLines("day4/input.txt")), Is.EqualTo(6189740));
        }
    }
}

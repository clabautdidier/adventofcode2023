using adventofcode2023.test.utility;

namespace adventofcode2023.day2
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.That(new Solver().Part1(FileUtils.ReadAllLines("day2/sample.txt")), Is.EqualTo(8));
            Assert.That(new Solver().Part1(FileUtils.ReadAllLines("day2/input.txt")), Is.EqualTo(2076));
        }

        [Test]
        public void Test2()
        {
            Assert.That(new Solver().Part2(FileUtils.ReadAllLines("day2/sample.txt")), Is.EqualTo(2286));
            Assert.That(new Solver().Part2(FileUtils.ReadAllLines("day2/input.txt")), Is.EqualTo(70950));
        }
    }
}
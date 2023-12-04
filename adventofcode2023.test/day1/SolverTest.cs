using adventofcode2023.test.utility;

namespace adventofcode2023.day1
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
            Assert.That(new Solver().Part1(FileUtils.ReadAllLines("day1/sample.txt")), Is.EqualTo(142));
            Assert.That(new Solver().Part1(FileUtils.ReadAllLines("day1/input.txt")), Is.EqualTo(54634));
        }

        [Test]
        public void Test2()
        {
            Assert.That(new Solver().Part2(FileUtils.ReadAllLines("day1/sample2.txt")), Is.EqualTo(281));
            Assert.That(new Solver().Part2(FileUtils.ReadAllLines("day1/input.txt")), Is.EqualTo(53855));
        }
    }
}
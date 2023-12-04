using adventofcode2023.test.utility;

namespace adventofcode2023.day0
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            Assert.That(new Solver().Part1(FileUtils.ReadAllLines("day0/sample.txt")), Is.EqualTo(0));
            //Assert.That(new Solver().Part1(FileUtils.ReadAllLines("day0/input.txt")), Is.EqualTo(0));
        }

        [Test]
        public void Test2()
        {
            Assert.That(new Solver().Part2(FileUtils.ReadAllLines("day0/sample.txt")), Is.EqualTo(0));
            //Assert.That(new Solver().Part2(FileUtils.ReadAllLines("day0/input.txt")), Is.EqualTo(0));
        }
    }
}
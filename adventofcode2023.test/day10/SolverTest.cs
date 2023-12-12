using adventofcode2023.test.utility;

namespace adventofcode2023.day10
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            Assert.That(new Solver().Part1(FileUtils.ReadAllLines("day10/sample.txt")), Is.EqualTo(8));
            Assert.That(new Solver().Part1(FileUtils.ReadAllLines("day10/input.txt")), Is.EqualTo(6806));
        }

        [Test]
        public void Test2()
        {
            Assert.That(new Solver().Part2(FileUtils.ReadAllLines("day10/sample2.txt")), Is.EqualTo(10));
            Assert.That(new Solver().Part2(FileUtils.ReadAllLines("day10/sample3.txt")), Is.EqualTo(8));
            Assert.That(new Solver().Part2(FileUtils.ReadAllLines("day10/sample4.txt")), Is.EqualTo(4));
            Assert.That(new Solver().Part2(FileUtils.ReadAllLines("day10/input.txt")), Is.EqualTo(449));
        }
    }
}

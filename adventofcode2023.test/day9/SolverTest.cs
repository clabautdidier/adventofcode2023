using adventofcode2023.test.utility;

namespace adventofcode2023.day9
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            Assert.That(new Solver().Part1(FileUtils.ReadAllLines("day9/sample.txt")), Is.EqualTo(114));
            Assert.That(new Solver().Part1(FileUtils.ReadAllLines("day9/input.txt")), Is.EqualTo(1939607039));
        }

        [Test]
        public void Test2()
        {
            Assert.That(new Solver().Part2(FileUtils.ReadAllLines("day9/sample.txt")), Is.EqualTo(2));
            Assert.That(new Solver().Part2(FileUtils.ReadAllLines("day9/input.txt")), Is.EqualTo(1041));
        }
    }
}

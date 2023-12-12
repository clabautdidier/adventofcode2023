using adventofcode2023.test.utility;

namespace adventofcode2023.day8
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            Assert.That(new Solver().Part1(FileUtils.ReadAllLines("day8/sample.txt")), Is.EqualTo(6));
            Assert.That(new Solver().Part1(FileUtils.ReadAllLines("day8/input.txt")), Is.EqualTo(18157));
        }

        [Test]
        public void Test2()
        {
            Assert.That(new Solver().Part2(FileUtils.ReadAllLines("day8/sample2.txt")), Is.EqualTo(6));
            Assert.That(new Solver().Part2(FileUtils.ReadAllLines("day8/input.txt")), Is.EqualTo(14299763833181));
        }
    }
}

using adventofcode2023.test.utility;

namespace adventofcode2023.day5
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            Assert.That(new Solver().Part1(FileUtils.ReadAllLines("day5/sample.txt")), Is.EqualTo(35));
            Assert.That(new Solver().Part1(FileUtils.ReadAllLines("day5/input.txt")), Is.EqualTo(175622908));
        }

        [Test]
        public void testMapping()
        {
            Assert.That(new MapCollection().applyMappingRangeToSeedLocation(
                new List<long[]> { new long[] { 79, 93, 0 } }, 50, 97, 2),
                Is.EqualTo(new List<long[]> { new long[] { 81, 95, 1 } }));

            Assert.That(new MapCollection().applyMappingRangeToSeedLocation(
                new List<long[]> { new long[] { 74, 87, 0 }, new long[] { 95, 95, 0 } }, 77, 99, -32),
                Is.EqualTo(new List<long[]> { new long[] { 74, 76, 1 }, new long[] { 45, 55, 1 }, new long[] { 63, 63, 1 } }));
        }

        [Test]
        public void Test2()
        {
            Assert.That(new Solver().Part2(FileUtils.ReadAllLines("day5/sample.txt")), Is.EqualTo(46));
            Assert.That(new Solver().Part2(FileUtils.ReadAllLines("day5/input.txt")), Is.EqualTo(5200543));
        }
    }
}

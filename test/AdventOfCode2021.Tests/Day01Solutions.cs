using AdventOfCode2021.Day01;

namespace AdventOfCode2021.Tests;

public class Day01Solutions
{
    [Fact]
    public void Puzzle1And2_CountIncreases()
    {
        var depths = new Depths(Input.Day01);

        depths.SingleWindowIncreases.Should().Be(1676);
        depths.SlidingWindowIncreases.Should().Be(1706);
    }

    public const string Puzzle1Example =
@"199
200
208
210
200
207
240
269
260
263";

    [Fact]
    public void Puzzle1And2_ExampleCountsIncreases()
    {
        var depths = new Depths(Puzzle1Example);

        depths.SingleWindowIncreases.Should().Be(7);
        depths.SlidingWindowIncreases.Should().Be(5);
    }
}
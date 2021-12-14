using AdventOfCode2021.Day01;
using AdventOfCode2021.Inputs;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2021.Tests;

public class Day01Solutions
{
    [Fact]
    public void Puzzle1_CountIncreases()
    {
        var depths = new Depths(Input.Day01);

        depths.Increases.Should().Be(1676);
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
    public void Puzzle1_ExampleCountsIncreases()
    {
        var depths = new Depths(Puzzle1Example);

        depths.Increases.Should().Be(7);
    }
}
using AdventOfCode2021.Day09;

namespace AdventOfCode2021.Tests;

public class Day09Solutions
{
    [Fact]
    public void Puzzle1And2_CalculateRisk_AndBasinSizes()
    {
        var caves = new LavaCave(Input.Day09);

        caves.Risk.Should().Be(512);
        caves.BasinSizes.OrderByDescending(x => x).Take(3).Aggregate(1, (accum, item) => accum * item).Should().Be(1600104);
    }

    public const string PuzzleExample =
@"2199943210
3987894921
9856789892
8767896789
9899965678";

    [Fact]
    public void PuzzleExample_ImportsCorrectly()
    {
        var caves = new LavaCave(PuzzleExample);

        caves.HeightMap.Length.Should().Be(50);
        caves.Risk.Should().Be(15);
        caves.BasinSizes.OrderByDescending(x => x).Take(3).Aggregate(1, (accum, item) => accum * item).Should().Be(1134);
    }
}
using AdventOfCode2021.Day07;

namespace AdventOfCode2021.Tests;

public class Day07Solutions
{
    [Fact]
    public void Puzzle1_FindCheapestCost()
    {
        var crabs = new Crabs(Input.Day07);
        var min = crabs.Positions.Min();
        var max = crabs.Positions.Max();

        for (var k = min; k <= max; ++k)
        {
            crabs.GetCostToMoveTo(k);
        }

        crabs.FuelToMoveTos.MinBy(x => x.Value).Value.Should().Be(355989);
    }

    [Fact]
    public void Puzzle1_FindRealCheapestCost()
    {
        var crabs = new Crabs(Input.Day07);
        var min = crabs.Positions.Min();
        var max = crabs.Positions.Max();

        for (var k = min; k <= max; ++k)
        {
            crabs.GetRealCostToMoveTo(k);
        }

        crabs.FuelToMoveTos.MinBy(x => x.Value).Value.Should().Be(102245489L);
    }

    public const string PuzzleExample = @"16,1,2,0,4,2,7,1,2,14";

    [Theory]
    [InlineData(2, 37)]
    [InlineData(1, 41)]
    [InlineData(3, 39)]
    [InlineData(10, 71)]
    public void Puzzle1Example_CalculateFuelCost(int moveToPosition, long expectedCost)
    {
        var crabs = new Crabs(PuzzleExample);

        crabs.GetCostToMoveTo(moveToPosition).Should().Be(expectedCost);
    }

    [Fact]
    public void Puzzle1Example_FindCheapestCost()
    {
        var crabs = new Crabs(PuzzleExample);
        var min = crabs.Positions.Min();
        var max = crabs.Positions.Max();

        for (var k = min; k <= max; ++k)
        {
            crabs.GetCostToMoveTo(k);
        }

        crabs.FuelToMoveTos.MinBy(x => x.Value).Value.Should().Be(37);
    }

    [Theory]
    [InlineData(5, 168)]
    [InlineData(2, 206)]
    public void Puzzle2Example_CalculateCheapestCost(int moveToPosition, long expectedCost)
    {
        var crabs = new Crabs(PuzzleExample);

        crabs.GetRealCostToMoveTo(moveToPosition).Should().Be(expectedCost);
    }
}
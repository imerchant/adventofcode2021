using System.Collections;
using AdventOfCode2021.Day11;
using Xunit.Abstractions;

namespace AdventOfCode2021.Tests;

public class Day11Solutions
{
    private readonly ITestOutputHelper _output;

    public Day11Solutions(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void Puzzle1_CountFlashesAfter100Steps()
    {
        var cavern = new Cavern(Input.Day11);

        var flashes = 0;
        for (var k = 0; k < 100; ++k)
        {
            flashes += cavern.Step();
        }

        _output.WriteLine("After step 100:");
        _output.WriteLine(cavern.ToString());

        flashes.Should().Be(1546);
    }

    [Fact]
    public void Puzzle2_FindStepWhereAllFlash()
    {
        var cavern = new Cavern(Input.Day11);

        int step;
        for (step = 1; step <= 500; step++)
        {
            var flashes = cavern.Step();

            if (flashes == cavern.Octopuses.Count)
                break;
        }

        _output.WriteLine($"After step {step}:");
        _output.WriteLine(cavern.ToString());

        step.Should().Be(471);
    }

    public const string PuzzleExample =
@"5483143223
2745854711
5264556173
6141336146
6357385478
4167524645
2176841721
6882881134
4846848554
5283751526";

    public const string SmallExample =
@"11111
19991
19191
19991
11111";

    [Fact]
    public void PuzzleExample_AllFlashAtStep195()
    {
        var cavern = new Cavern(PuzzleExample);

        int step;
        for (step = 1; step <= 500; step++)
        {
            var flashes = cavern.Step();

            if (flashes == cavern.Octopuses.Count)
                break;
        }

        _output.WriteLine($"After step {step}:");
        _output.WriteLine(cavern.ToString());

        step.Should().Be(195);
    }

    [Theory]
    [MemberData(nameof(PrintCavernCases))]
    public void PrintExampleCavern(string example)
    {
        var cavern = new Cavern(example);

        _output.WriteLine(cavern.ToString());

        cavern.ToString().Should().Be(example);
    }

    public static IEnumerable<object[]> PrintCavernCases()
    {
        yield return new object[] { SmallExample };
        yield return new object[] { PuzzleExample };
    }

    [Fact]
    public void SmallExample_FlashesAsExpected()
    {
        var cavern = new Cavern(SmallExample);

        _output.WriteLine("Before any steps:");
        _output.WriteLine(cavern.ToString());
        _output.WriteLine(string.Empty);

        cavern.Step();

        _output.WriteLine("After step 1:");
        _output.WriteLine(cavern.ToString());
        _output.WriteLine(string.Empty);

        cavern.Step();

        _output.WriteLine("After step 2:");
        _output.WriteLine(cavern.ToString());
    }

    [Fact]
    public void PuzzleExample_FlashesAsExpected()
    {
        var cavern = new Cavern(PuzzleExample);

        _output.WriteLine("Before any steps:");
        _output.WriteLine(cavern.ToString());
        _output.WriteLine(string.Empty);

        cavern.Step();

        _output.WriteLine("After step 1:");
        _output.WriteLine(cavern.ToString());
        _output.WriteLine(string.Empty);

        cavern.Step();

        _output.WriteLine("After step 2:");
        _output.WriteLine(cavern.ToString());
    }

    [Theory]
    [InlineData(10, 204)]
    [InlineData(100, 1656)]
    public void PuzzleExample_CountFlashesForXSteps(int steps, int expectedFlashes)
    {
        var cavern = new Cavern(PuzzleExample);

        var flashes = 0;
        for (var k = 0; k < steps; ++k)
        {
            flashes += cavern.Step();
        }

        _output.WriteLine($"After step {steps}:");
        _output.WriteLine(cavern.ToString());

        flashes.Should().Be(expectedFlashes);
    }
}
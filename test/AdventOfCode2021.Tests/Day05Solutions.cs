using System.Text;
using AdventOfCode2021.Day05;
using Xunit.Abstractions;

namespace AdventOfCode2021.Tests;

public class Day05Solutions
{
    private readonly ITestOutputHelper _output;

    public Day05Solutions(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void Puzzle1And2_FindOverlaps()
    {
        var vents = new Vents(Input.Day05);

        vents.StraightOverlaps.Should().Be(5147);
        vents.AllOverlaps.Should().Be(16925);
    }

    public const string PuzzleExample =
@"0,9 -> 5,9
8,0 -> 0,8
9,4 -> 3,4
2,2 -> 2,1
7,0 -> 7,4
6,4 -> 2,0
0,9 -> 2,9
3,4 -> 1,4
0,0 -> 8,8
5,5 -> 8,2";

    [Fact]
    public void Puzzle1Example_FindOverlaps()
    {
        var vents = new Vents(PuzzleExample);

        var builder = new StringBuilder(Environment.NewLine);
        for (var k = 0; k <= 9; ++k)
        {
            for (var j = 0; j <= 9; ++j)
            {
                var val = vents.StraightLineVents[(k, j)];
                builder.Append(val == 0 ? "." : $"{val}");
            }
            builder.AppendLine();
        }

        _output.WriteLine(builder.ToString());

        vents.StraightOverlaps.Should().Be(5);
    }

    [Fact]
    public void PuzzleExample_FindAllOverlaps()
    {
        var vents = new Vents(PuzzleExample);

        var builder = new StringBuilder(Environment.NewLine);
        for (var k = 0; k <= 9; ++k)
        {
            for (var j = 0; j <= 9; ++j)
            {
                var val = vents.AllVents[(k, j)];
                builder.Append(val == 0 ? "." : $"{val}");
            }
            builder.AppendLine();
        }

        _output.WriteLine(builder.ToString());

        vents.AllOverlaps.Should().Be(12);
    }
}
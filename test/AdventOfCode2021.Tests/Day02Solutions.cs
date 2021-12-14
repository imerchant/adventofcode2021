using AdventOfCode2021.Day02;

namespace AdventOfCode2021.Tests;

public class Day02Solutions
{
    [Fact]
    public void Puzzle1_FindsResult()
    {
        var submarine = new Submarine(Input.Day02);

        submarine.Result.Should().Be(1989265);
    }

    public const string Puzzle1Example =
@"forward 5
down 5
forward 8
up 3
down 8
forward 2";

    [Fact]
    public void Puzzle1Example_FindsResult()
    {
        var submarine = new Submarine(Puzzle1Example);

        submarine.Result.Should().Be(150);
    }
}
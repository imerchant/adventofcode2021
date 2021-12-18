using AdventOfCode2021.Day06;

namespace AdventOfCode2021.Tests;

public class Day06Solutions
{
    [Theory]
    [InlineData(80, 386_536)]
    [InlineData(256, 1_732_821_262_171L)]
    public void Puzzle1And2_FishCountAfterDays(int days, long expectedCount)
    {
        var school = new SchoolOfFish(Input.Day06);

        for (var k = 0; k < days; k++)
        {
            school.Advance();
        }

        school.Fish.Values.Sum().Should().Be(expectedCount);
    }

    public const string PuzzleExample = @"3,4,3,1,2";

    [Fact]
    public void PuzzleExample_CreatesFish()
    {
        var school = new SchoolOfFish(PuzzleExample);

        school.Fish.Values.Sum().Should().Be(5);

        school.Advance();
        school.Fish.Values.Sum().Should().Be(5);

        school.Advance();
        school.Fish.Values.Sum().Should().Be(6);

        school.Advance();
        school.Fish.Values.Sum().Should().Be(7);
    }

    [Theory]
    [InlineData(18, 26)]
    [InlineData(80, 5934)]
    [InlineData(256, 26_984_457_539L)]
    public void PuzzleExample_GeneratesFish(int days, long expectedFishCount)
    {
        var school = new SchoolOfFish(PuzzleExample);

        for (var k = 0; k < days; ++k)
        {
            school.Advance();
        }

        school.Fish.Values.Sum().Should().Be(expectedFishCount);
    }
}
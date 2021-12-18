using AdventOfCode2021.Day06;

namespace AdventOfCode2021.Tests;

public class Day06Solutions
{
    [Fact]
    public void Puzzle1_FishCountAfter80Days()
    {
        var school = new SchoolOfFish(Input.Day06);

        for (var k = 0; k < 80; k++)
        {
            school.Advance();
        }

        school.Should().HaveCount(386536);
    }

    public const string Puzzle1Example = @"3,4,3,1,2";

    [Fact]
    public void Puzzle1Example_CreatesFish()
    {
        var school = new SchoolOfFish(Puzzle1Example);

        school.Should().SatisfyRespectively(
            item => item.Age.Should().Be(3),
            item => item.Age.Should().Be(4),
            item => item.Age.Should().Be(3),
            item => item.Age.Should().Be(1),
            item => item.Age.Should().Be(2)
        );

        school.Advance();

        school.Should().SatisfyRespectively(
            item => item.Age.Should().Be(2),
            item => item.Age.Should().Be(3),
            item => item.Age.Should().Be(2),
            item => item.Age.Should().Be(0),
            item => item.Age.Should().Be(1)
        );

        school.Advance();

        school.Should().SatisfyRespectively(
            item => item.Age.Should().Be(1),
            item => item.Age.Should().Be(2),
            item => item.Age.Should().Be(1),
            item => item.Age.Should().Be(6),
            item => item.Age.Should().Be(0),
            item => item.Age.Should().Be(8)
        );
    }

    [Theory]
    [InlineData(18, 26)]
    [InlineData(80, 5934)]
    public void Puzzle1Example_GeneratesFish(int days, int expectedFishCount)
    {
        var school = new SchoolOfFish(Puzzle1Example);

        for (var k = 0; k < days; ++k)
        {
            school.Advance();
        }

        school.Should().HaveCount(expectedFishCount);
    }
}
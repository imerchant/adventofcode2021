using AdventOfCode2021.Day03;

namespace AdventOfCode2021.Tests;

public class Day03Solutions
{
    [Fact]
    public void Puzzle1_FindPowerConsumption()
    {
        var report = new DiagnosticReport(Input.Day03);

        report.PowerConsumption.Should().Be(1458194);
    }

    public const string Puzzle1Example =
@"00100
11110
10110
10111
10101
01111
00111
11100
10000
11001
00010
01010";

    [Fact]
    public void Puzzle1Example_FindPowerConsumption()
    {
        var report = new DiagnosticReport(Puzzle1Example);

        report.GammaRate.Should().Be(22);
        report.EpsilonRate.Should().Be(9);
        report.PowerConsumption.Should().Be(198);
    }
}
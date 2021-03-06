using AdventOfCode2021.Day03;

namespace AdventOfCode2021.Tests;

public class Day03Solutions
{
    [Fact]
    public void Puzzle1And2_FindPowerConsumption_AndLifeSupportRating()
    {
        var report = new DiagnosticReport(Input.Day03);

        report.PowerConsumption.Should().Be(1458194);
        report.LifeSupportRating.Should().Be(2829354);
    }

    public const string PuzzleExample =
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
    public void PuzzleExample_FindPowerConsumption_AndLifeSupportRating()
    {
        var report = new DiagnosticReport(PuzzleExample);

        report.GammaRate.Should().Be(22);
        report.EpsilonRate.Should().Be(9);
        report.PowerConsumption.Should().Be(198);

        report.OxygenGeneratorRating.Should().Be(23);
        report.CO2ScrubberRating.Should().Be(10);
        report.LifeSupportRating.Should().Be(230);
    }
}
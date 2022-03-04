using AdventOfCode2021.Day08;

namespace AdventOfCode2021.Tests;

public class Day08Solutions
{
    [Fact]
    public void Puzzle1And2_Count1478Instances_AndFindSumOfOutput()
    {
        var display = new Display(Input.Day08);
        
        display.Sum(x => x.InstancesOf1478).Should().Be(397);
        display.Sum(x => x.Value).Should().Be(1027422);
    }
    
    public const string PuzzleExample = @"be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe
edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc
fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg
fbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega | efabcd cedba gadfec cb
aecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga | gecf egdcabf bgf bfgea
fgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf | gebdcfa ecba ca fadegcb
dbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf | cefg dcbef fcge gbcadfe
bdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd | ed bcgafe cdgba cbgef
egadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg | gbdfcae bgc cg cgb
gcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc | fgae cfgab fg bagce";

    [Fact]
    public void Puzzle1_ExampleCounts1478Instances()
    {
        var display = new Display(PuzzleExample);

        display.Sum(x => x.InstancesOf1478).Should().Be(26);
    }

    [Fact]
    public void Puzzle2Example_EntryAssignsCorrectValues()
    {
        const string input = "acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab";
        const string output = "cdfeb fcadb cdfeb cdbaf";
        const string threeSegment = "fbcad";
        const string zeroSegment = "cagedb";
        const string nineSegment = "cefabd";
        const string sixSegment = "cdfgeb";
        const string fiveSegment = "cdfbe";
        const string twoSegment = "gcdfa";

        var entry = new Entry(input, output);

        entry.Input.First(x => x.Content == threeSegment).Value.Should().Be(3);
        entry.Input.First(x => x.Content == zeroSegment).Value.Should().Be(0);
        entry.Input.First(x => x.Content == nineSegment).Value.Should().Be(9);
        entry.Input.First(x => x.Content == sixSegment).Value.Should().Be(6);
        entry.Input.First(x => x.Content == fiveSegment).Value.Should().Be(5);
        entry.Input.First(x => x.Content == twoSegment).Value.Should().Be(2);

        entry.Output.Should().SatisfyRespectively(
            x => x.Value.Should().Be(5),
            x => x.Value.Should().Be(3),
            x => x.Value.Should().Be(5),
            x => x.Value.Should().Be(3));

        entry.Value.Should().Be(5353);
    }

    [Fact]
    public void Puzzle2_ExampleGathersOutputValues()
    {
        var display = new Display(PuzzleExample);

        display.Should().SatisfyRespectively(
            x => x.Value.Should().Be(8394),
            x => x.Value.Should().Be(9781),
            x => x.Value.Should().Be(1197),
            x => x.Value.Should().Be(9361),
            x => x.Value.Should().Be(4873),
            x => x.Value.Should().Be(8418),
            x => x.Value.Should().Be(4548),
            x => x.Value.Should().Be(1625),
            x => x.Value.Should().Be(8717),
            x => x.Value.Should().Be(4315)
        );

        display.Sum(x => x.Value).Should().Be(61229);
    }
}

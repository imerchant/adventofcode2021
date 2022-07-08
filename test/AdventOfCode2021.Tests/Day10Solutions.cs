using AdventOfCode2021.Day10;

namespace AdventOfCode2021.Tests;

public class Day10Solutions
{
    [Fact]
    public void Puzzle1And2_FindTotalSyntaxErrorScore_AndMedianCompletionScore()
    {
        var navigation = new Navigation(Input.Day10);

        navigation.SyntaxErrorScore.Should().Be(367227);
        navigation.MedianCompletionScore.Should().Be(3583341858);
    }

    [Theory]
    [InlineData("{([(<{}[<>[]}>{[]{[(<()>", 1197)]
    [InlineData("[[<[([]))<([[{}[[()]]]", 3)]
    [InlineData("[{[{({}]{}}([{[{{{}}([]", 57)]
    [InlineData("[<(<(<(<{}))><([]([]()", 3)]
    [InlineData("<{([([[(<>()){}]>(<<{{", 25137)]
    public void Puzzle1Examples_FindCorrectScore(string instruction, int expectedScore)
    {
        Navigation.CalculateSyntaxErrorScore(instruction).Should().Be(expectedScore);
    }

    public const string PuzzleExample =
@"[({(<(())[]>[[{[]{<()<>>
[(()[<>])]({[<{<<[]>>(
{([(<{}[<>[]}>{[]{[(<()>
(((({<>}<{<{<>}{[]{[]{}
[[<[([]))<([[{}[[()]]]
[{[{({}]{}}([{[{{{}}([]
{<[[]]>}<{[{[{[]{()[[[]
[<(<(<(<{}))><([]([]()
<{([([[(<>()){}]>(<<{{
<{([{{}}[<[[[<>{}]]]>[]]";

    [Fact]
    public void PuzzleExample_SumSyntaxErrorScores()
    {
        var navigation = new Navigation(PuzzleExample);

        navigation.SyntaxErrorScore.Should().Be(26397);
    }

    [Theory]
    [InlineData("[({(<(())[]>[[{[]{<()<>>", 288957)]
    [InlineData("[(()[<>])]({[<{<<[]>>(", 5566)]
    [InlineData("(((({<>}<{<{<>}{[]{[]{}", 1480781)]
    [InlineData("{<[[]]>}<{[{[{[]{()[[[]", 995444)]
    [InlineData("<{([{{}}[<[[[<>{}]]]>[]]", 294)]
    public void Puzzle2Examples_FindCompletionScore(string instruction, int expectedScore)
    {
        IncompleteInstruction.CalculateCompletionScore(instruction).Should().Be(expectedScore);
    }

    [Fact]
    public void PuzzleExample_FindMedianCompletionScore()
    {
        var navigation = new Navigation(PuzzleExample);

        navigation.MedianCompletionScore.Should().Be(288957);
    }
}
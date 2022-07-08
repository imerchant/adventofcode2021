using AdventOfCode2021.Day10;

namespace AdventOfCode2021.Tests;

public class Day10Solutions
{
    [Fact]
    public void Puzzle1_FindTotalSyntaxErrorScore()
    {
        var navigation = new Navigation(Input.Day10);

        navigation.SyntaxErrorScore.Should().Be(367227);
    }

    [Theory]
    [InlineData("{([(<{}[<>[]}>{[]{[(<()>", 1197)]
    [InlineData("[[<[([]))<([[{}[[()]]]", 3)]
    [InlineData("[{[{({}]{}}([{[{{{}}([]", 57)]
    [InlineData("[<(<(<(<{}))><([]([]()", 3)]
    [InlineData("<{([([[(<>()){}]>(<<{{", 25137)]
    public void Puzzle1Example_FindCorrectScore(string instruction, int expectedScore)
    {
        Navigation.CalculateSyntaxErrorScore(instruction).Should().Be(expectedScore);
    }

    public const string Puzzle1Example =
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
    public void Puzzle1Example_SumCorrectScores()
    {
        var navigation = new Navigation(Puzzle1Example);

        navigation.SyntaxErrorScore.Should().Be(26397);
    }
}
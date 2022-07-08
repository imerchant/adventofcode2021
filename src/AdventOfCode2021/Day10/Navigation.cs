namespace AdventOfCode2021.Day10;

public class Navigation
{
    public const string Starts = "([{<";
    public const string Ends = ")]}>";

    public static readonly IDictionary<char, int> EndPoints = new Dictionary<char, int>
    {
        { ')', 3 },
        { ']', 57 },
        { '}', 1197 },
        { '>', 25137 },
    };

    public List<string> Instructions { get; }

    public int SyntaxErrorScore { get; private set; }

    public Navigation(string input)
    {
        Instructions = input.SplitLines().ToList();

        foreach (var instruction in Instructions)
        {
            SyntaxErrorScore += CalculateSyntaxErrorScore(instruction);
        }
    }

    internal static int CalculateSyntaxErrorScore(string instruction)
    {
        var starts = new Stack<char>();
        starts.Push(instruction[0]);

        for (var k = 1; k < instruction.Length; ++k)
        {
            var c = instruction[k];
            if (Starts.Contains(c))
            {
                starts.Push(c);
                continue; // new group start
            }

            var challenge = starts.Pop();
            if (Starts.IndexOf(challenge) == Ends.IndexOf(c))
            {
                continue; // end matches the most recent start
            }

            return EndPoints[c]; // end doesn't match, return its point value
        }

        return 0;
    }
}